using LibraryApp.Domain.Common;

namespace LibraryApp.Domain.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public ICollection<BookBorrowingRequestDetail> BookBorrowingRequestDetails { get; set; } = [];
}
