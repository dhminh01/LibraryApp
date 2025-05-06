using FluentValidation;
using LibraryApp.Application.DTOs.Book;

namespace LibraryApp.Application.Validators.Book
{
    public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(50).WithMessage("Title must not exceed 50 characters.");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author is required.")
                .MaximumLength(50).WithMessage("Author name must not exceed 50 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).When(x => !string.IsNullOrWhiteSpace(x.Description))
                .WithMessage("Description must not exceed 1000 characters.");

            RuleFor(x => x.PublicationYear)
                .InclusiveBetween(1000, DateTime.UtcNow.Year)
                .WithMessage("Publication year must be valid.");

            RuleFor(x => x.TotalCopies)
                .GreaterThan(0).WithMessage("Total copies must be greater than 0.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category is required.");
        }
    }

    public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Book ID is required.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(50).WithMessage("Title must not exceed 50 characters.");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author is required.")
                .MaximumLength(50).WithMessage("Author name must not exceed 50 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).When(x => !string.IsNullOrWhiteSpace(x.Description))
                .WithMessage("Description must not exceed 1000 characters.");

            RuleFor(x => x.PublicationYear)
                .InclusiveBetween(1000, DateTime.UtcNow.Year)
                .WithMessage("Publication year must be valid.");

            RuleFor(x => x.TotalCopies)
                .GreaterThan(0).WithMessage("Total copies must be greater than 0.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category is required.");
        }
    }
}
