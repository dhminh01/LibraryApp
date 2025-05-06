using LibraryApp.Application.DTOs.Book;

namespace LibraryApp.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto?> GetByIdAsync(Guid id);
        Task<BookDto> CreateAsync(CreateBookDto dto);
        Task<BookDto?> UpdateAsync(Guid id, UpdateBookDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}