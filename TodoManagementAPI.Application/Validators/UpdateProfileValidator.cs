using FluentValidation;
using TodoManagementAPI.Domain.DTOs.User;

namespace TodoManagementAPI.Application.Validators
{
    public class UpdateProfileValidator : AbstractValidator<UpdateProfile>
    {
        public UpdateProfileValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required.")
                .MaximumLength(100).WithMessage("Full name must not exceed 100 characters.");
        }
    }
}
