using FluentValidation;
using TodoManagementAPI.Domain.DTOs.User;

namespace TodoManagementAPI.Application.Validators
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        }
    }
}
