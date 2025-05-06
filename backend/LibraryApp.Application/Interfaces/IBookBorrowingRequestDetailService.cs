using LibraryApp.Application.DTOs.BookBorrowing;

namespace LibraryApp.Application.Interfaces
{
    public interface IBookBorrowingRequestDetailService
    {
        Task<List<BookBorrowingRequestDetailDto>> GetDetailsByRequestIdAsync(Guid requestId);
    }
}

