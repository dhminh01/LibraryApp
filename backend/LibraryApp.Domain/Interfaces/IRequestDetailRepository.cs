using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Interfaces
{
    public interface IBookBorrowingRequestDetailRepository
    {
        Task<List<BookBorrowingRequestDetail>> GetByRequestIdAsync(Guid requestId);
    }

}

