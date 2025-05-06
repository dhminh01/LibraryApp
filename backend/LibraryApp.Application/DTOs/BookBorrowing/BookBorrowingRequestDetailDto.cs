namespace LibraryApp.Application.DTOs.BookBorrowing
{
    public class BookBorrowingRequestDetailDto
    {
        public Guid Id { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime DueDate { get; set; }
        public Guid BookId { get; set; }
        public string BookTitle { get; set; } = string.Empty;
    }
}
