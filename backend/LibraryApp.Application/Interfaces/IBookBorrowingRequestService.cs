using LibraryApp.Application.DTOs.BookBorrowing;

namespace LibraryApp.Application.Interfaces
{
    public interface IBookBorrowingRequestService
    {
        Task<BookBorrowingRequestResponseDto> BorrowBooksAsync(BookBorrowingRequestCreateDto dto);
        Task<List<BookBorrowingRequestResponseDto>> GetAllRequestsForUserAsync(Guid userId);
        Task<List<BookBorrowingRequestResponseDto>> GetAllRequestsAsync();
        Task<BookBorrowingRequestResponseDto> UpdateRequestStatusAsync(Guid requestId, BookBorrowingRequestUpdateStatusDto dto);
    }
}