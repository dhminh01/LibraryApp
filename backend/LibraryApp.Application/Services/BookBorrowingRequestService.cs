using AutoMapper;
using LibraryApp.Application.DTOs.BookBorrowing;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Enums;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Application.Services
{
    public class BookBorrowingRequestService : IBookBorrowingRequestService
    {
        private readonly IBookBorrowingRequestRepository _requestRepo;
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;

        public BookBorrowingRequestService(
            IBookBorrowingRequestRepository requestRepo,
            IBookRepository bookRepo,
            IMapper mapper)
        {
            _requestRepo = requestRepo;
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        public async Task<BookBorrowingRequestResponseDto> BorrowBooksAsync(BookBorrowingRequestCreateDto dto)
        {
            var now = DateTime.UtcNow;
            var monthStart = new DateTime(now.Year, now.Month, 1);
            var monthEnd = monthStart.AddMonths(1).AddSeconds(-1);

            var monthlyRequestCount = await _requestRepo.GetMonthlyRequestCountAsync(dto.UserId, monthStart, monthEnd);

            if (monthlyRequestCount >= 3)
                throw new Exception("You have reached the monthly request limit (3 requests).");

            var books = await _bookRepo.GetBooksByIdsAsync(dto.BookIds);

            if (books.Count != dto.BookIds.Count)
                throw new Exception("One or more selected books do not exist.");

            if (books.Any(b => b.AvailableCopies <= 0))
                throw new Exception("One or more books are not available.");

            var request = _mapper.Map<BookBorrowingRequest>(dto);

            request.Id = Guid.NewGuid();
            request.RequestDate = now;
            request.CreatedAt = now;

            request.BookBorrowingRequestDetails = books.Select(book => new BookBorrowingRequestDetail
            {
                Id = Guid.NewGuid(),
                BookId = book.Id,
                BorrowedDate = now,
                DueDate = now.AddDays(14),
                CreatedAt = now
            }).ToList();

            foreach (var book in books)
            {
                book.AvailableCopies--;
            }

            await _requestRepo.CreateAsync(request);
            await _bookRepo.UpdateBooksAsync(books);
            await _requestRepo.SaveChangesAsync();

            return _mapper.Map<BookBorrowingRequestResponseDto>(request);
        }

        public async Task<List<BookBorrowingRequestResponseDto>> GetAllRequestsForUserAsync(Guid userId)
        {
            var requests = await _requestRepo.GetAllRequestsForUserAsync(userId);

            return requests.Select(r => _mapper.Map<BookBorrowingRequestResponseDto>(r)).ToList();
        }

        public async Task<List<BookBorrowingRequestResponseDto>> GetAllRequestsAsync()
        {
            var requests = await _requestRepo.GetAllRequestsAsync();

            return requests.Select(r => _mapper.Map<BookBorrowingRequestResponseDto>(r)).ToList();
        }

        public async Task<BookBorrowingRequestResponseDto> UpdateRequestStatusAsync(Guid requestId, BookBorrowingRequestUpdateStatusDto dto)
        {
            var request = await _requestRepo.GetRequestByIdAsync(requestId) ?? throw new Exception("Request not found.");

            _mapper.Map(dto, request);

            if (dto.Status == RequestStatus.Approved)
            {
                request.Note = "Approved by Admin";
                request.ApprovedDate = DateTime.UtcNow;
            }
            else if (dto.Status == RequestStatus.Rejected)
            {
                request.Note = "Rejected by Admin";
                request.ReturnedDate = DateTime.UtcNow;

                foreach (var detail in request.BookBorrowingRequestDetails)
                {
                    var book = await _bookRepo.GetByIdAsync(detail.BookId);
                    if (book != null)
                    {
                        book.AvailableCopies += 1;
                    }
                }
            }

            await _requestRepo.SaveChangesAsync();

            return _mapper.Map<BookBorrowingRequestResponseDto>(request);
        }
    }
}
