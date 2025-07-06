using FluentValidation;
using MarketplaceB2B.Application.Dtos;
using MarketplaceB2B.Domain.Enums;

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

            RuleFor(u => u.TypeUser)
                .NotEmpty().WithMessage("TypeUser is required")
                .Must(type => type.ToUpper().Equals(TypeUser.PROVIDER.ToString()) 
                        || type.ToUpper().Equals(TypeUser.COMPANY.ToString()))
                            .WithMessage("TypeUser must be either PROVIDER or COMPANY");
        }

    }
}
