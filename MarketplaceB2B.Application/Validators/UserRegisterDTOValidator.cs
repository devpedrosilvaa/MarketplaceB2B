using FluentValidation;
using MarketplaceB2B.Application.Dtos;

namespace MarketplaceB2B.Application.Validators {
    public sealed class UserRegisterDTOValidator : AbstractValidator<UserRegisterDTO> {
    
        public UserRegisterDTOValidator() {

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("Username is required");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long");

        }

    }
}
