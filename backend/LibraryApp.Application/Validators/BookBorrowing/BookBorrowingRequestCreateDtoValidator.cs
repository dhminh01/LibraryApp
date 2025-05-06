using FluentValidation;
using LibraryApp.Application.DTOs.BookBorrowing;
namespace LibraryApp.Application.Validators.BookBorrowing
{
    public class BookBorrowingRequestCreateDtoValidator : AbstractValidator<BookBorrowingRequestCreateDto>
    {
        public BookBorrowingRequestCreateDtoValidator()
        {
            RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.");

            RuleFor(x => x.BookIds)
                .NotEmpty().WithMessage("You must select at least one book.")
                .Must(bookIds => bookIds.Count <= 5)
                .WithMessage("You cannot borrow more than 5 books in a single request.");

            RuleFor(x => x.Note)
                .MaximumLength(500).WithMessage("Note cannot exceed 500 characters.");
        }
    }
}

