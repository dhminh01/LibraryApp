namespace LibraryApp.Application.DTOs.Book
{
    public class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public int TotalCopies { get; set; }
        public Guid CategoryId { get; set; }
    }
}