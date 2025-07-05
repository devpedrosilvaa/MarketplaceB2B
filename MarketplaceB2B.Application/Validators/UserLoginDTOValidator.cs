using FluentValidation;
using MarketplaceB2B.Application.Dtos;

namespace MarketplaceB2B.Application.Validators {
    public sealed class UserLoginDTOValidator : AbstractValidator<UserLoginDTO>{
        public UserLoginDTOValidator() {

            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("Username is required");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long");
        }
    }
}
