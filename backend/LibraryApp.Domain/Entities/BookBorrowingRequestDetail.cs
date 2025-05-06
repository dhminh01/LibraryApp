using LibraryApp.Domain.Common;

namespace LibraryApp.Domain.Entities
{
    public class BookBorrowingRequestDetail : BaseEntity
    {
        public DateTime BorrowedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid BookBorrowingRequestId { get; set; }
        public Guid BookId { get; set; }
        public BookBorrowingRequest BookBorrowingRequest { get; set; } = null!;
        public Book Book { get; set; } = null!;
    }
}
