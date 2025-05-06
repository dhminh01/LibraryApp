// File: Infrastructure/Persistence/Repositories/BookBorrowingRequestDetailRepository.cs
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class BookBorrowingRequestDetailRepository : IBookBorrowingRequestDetailRepository
{
    private readonly ApplicationDbContext _context;

    public BookBorrowingRequestDetailRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<BookBorrowingRequestDetail>> GetByRequestIdAsync(Guid requestId)
    {
        return await _context.BookBorrowingRequestDetails
            .Include(d => d.Book)
            .Where(d => d.BookBorrowingRequestId == requestId)
            .ToListAsync();
    }
}
