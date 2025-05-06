using System;
using FluentValidation;
using LibraryApp.Application.DTOs.User;

namespace LibraryApp.Application.Validators.User
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("User ID is required.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First Name cannot exceed 50 characters")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("First Name can only contain letters and spaces");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last Name cannot exceed 50 characters")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Last Name can only contain letters and spaces");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters")
                .MaximumLength(30).WithMessage("Username cannot exceed 30 characters")
                .Matches(@"^[a-zA-Z0-9_]+$").WithMessage("Username can only contain letters, numbers, and underscores");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required")
                .Matches(@"^\+?[0-9\s\-()]+$").WithMessage("Phone Number can only contain numbers, spaces, and special characters (+, -, (, ))")
                .MaximumLength(20).WithMessage("Phone Number cannot exceed 20 characters");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required")
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters")
                .Matches(@"^[a-zA-Z0-9\s,.-]+$").WithMessage("Address can only contain letters, numbers, spaces, and special characters (, . -)");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of Birth is required")
                .LessThan(DateTime.UtcNow).WithMessage("Date of Birth must be in the past");

            RuleFor(x => x.Role)
                .IsInEnum().WithMessage("Invalid role.");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("IsActive must be specified.");
        }
    }
}