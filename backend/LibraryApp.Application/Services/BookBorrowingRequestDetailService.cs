using AutoMapper;
using LibraryApp.Application.DTOs.BookBorrowing;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Application.Services
{
    public class BookBorrowingRequestDetailService : IBookBorrowingRequestDetailService
    {
        private readonly IBookBorrowingRequestDetailRepository _repository;
        private readonly IMapper _mapper;

        public BookBorrowingRequestDetailService(
            IBookBorrowingRequestDetailRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BookBorrowingRequestDetailDto>> GetDetailsByRequestIdAsync(Guid requestId)
        {
            var details = await _repository.GetByRequestIdAsync(requestId);

            return _mapper.Map<List<BookBorrowingRequestDetailDto>>(details);
        }
    }
}