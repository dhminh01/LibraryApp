using LibraryApp.Domain.Common;
using LibraryApp.Domain.Enums;

namespace LibraryApp.Domain.Entities
{
    public class BookBorrowingRequest : BaseEntity
    {
        public DateTime RequestDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Waiting;
        public string Note { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<BookBorrowingRequestDetail> BookBorrowingRequestDetails { get; set; } = [];
    }
}

