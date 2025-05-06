using AutoMapper;
using LibraryApp.Application.DTOs.Book;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto?> GetByIdAsync(Guid id)
        {
            var book = await _repository.GetByIdAsync(id);

            return book == null ? null : _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> CreateAsync(CreateBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            book.AvailableCopies = book.TotalCopies;
            await _repository.AddAsync(book);

            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto?> UpdateAsync(Guid id, UpdateBookDto dto)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null) return null;

            _mapper.Map(dto, book);
            book.UpdatedAt = DateTime.UtcNow;
            await _repository.UpdateAsync(book);

            return _mapper.Map<BookDto>(book);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null) return false;

            await _repository.DeleteAsync(book);

            return true;
        }
    }
}