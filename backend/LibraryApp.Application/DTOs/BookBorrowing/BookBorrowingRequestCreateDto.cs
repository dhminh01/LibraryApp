namespace LibraryApp.Application.DTOs.BookBorrowing
{
    public class BookBorrowingRequestCreateDto
    {
        public Guid UserId { get; set; }
        public List<Guid> BookIds { get; set; } = [];
        public string Note { get; set; } = string.Empty;
    }
}