using LibraryApp.Domain.Enums;

namespace LibraryApp.Application.DTOs.BookBorrowing
{
    public class BookBorrowingRequestUpdateStatusDto
    {
        public Guid RequestId { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime ApprovedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}