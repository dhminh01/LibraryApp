using LibraryApp.Domain.Enums;

namespace LibraryApp.Application.DTOs.BookBorrowing
{
    public class BookBorrowingRequestResponseDto
    {
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Waiting;
        public string Note { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<string> BookTitles { get; set; } = [];
    }
}