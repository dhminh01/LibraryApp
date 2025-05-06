using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(Guid id);
        Task<List<Book>> GetAllAsync();
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
        Task<List<Book>> GetBooksByIdsAsync(List<Guid> bookIds);
        Task UpdateBooksAsync(List<Book> books);
    }
}