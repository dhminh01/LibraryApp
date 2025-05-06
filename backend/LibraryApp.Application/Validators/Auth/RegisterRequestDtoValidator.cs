using FluentValidation;
using LibraryApp.Application.DTOs.Auth;

namespace LibraryApp.Application.Validators.Auth
{
    public class RegisterRequestDtoValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required")
                .MaximumLength(50).WithMessage("First Name cannot exceed 50 characters")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("First Name can only contain letters and spaces");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required")
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

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters")
                .MaximumLength(100).WithMessage("Password cannot exceed 100 characters")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one number")
                .Matches(@"[!@#$%^&*(),.?""':{}|<>]").WithMessage("Password must contain at least one special character");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm Password is required")
                .Equal(x => x.Password).WithMessage("The password and confirmation password do not match");

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
        }
    }
}

