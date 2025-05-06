using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Interfaces
{
    public interface IBookBorrowingRequestRepository
    {
        Task<List<BookBorrowingRequest>> GetAllRequestsAsync();
        Task<BookBorrowingRequest?> GetRequestByIdAsync(Guid requestId);
        Task<List<BookBorrowingRequest>> GetAllRequestsForUserAsync(Guid userId);
        Task<int> GetMonthlyRequestCountAsync(Guid userId, DateTime monthStart, DateTime monthEnd);
        Task<BookBorrowingRequest> CreateAsync(BookBorrowingRequest request);
        Task<List<Book>> GetBooksByIdsAsync(List<Guid> bookIds);
        Task SaveChangesAsync();
    }
}