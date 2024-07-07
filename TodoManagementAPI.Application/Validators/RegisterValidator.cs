using FluentValidation;
using TodoManagementAPI.Domain.DTOs.User;

namespace TodoManagementAPI.Application.Validators
{
    public class RegisterValidator : AbstractValidator<Register>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Passwords do not match.");
            RuleFor(x => x.FullName).NotEmpty();
        }
    }
}
