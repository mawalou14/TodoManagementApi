
using FluentValidation;
using TodoManagementAPI.Domain.DTOs.Todo;

namespace TodoManagementAPI.Application.Validators
{
    public class CreateTodoValidator : AbstractValidator<CreateTodo>
    {
        public CreateTodoValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(255).WithMessage("Description must not exceed 255 characters.");

            RuleFor(x => x.TargetedTime)
                .NotEmpty().WithMessage("Targeted time is required.")
                .Must(BeAValidDate).WithMessage("Targeted time must be a valid date.");

            RuleFor(x => x.Priority)
                .IsInEnum().WithMessage("Invalid priority value.");

            RuleFor(x => x.Status)
           .InclusiveBetween(1, 2).WithMessage("Status must be either 1 or 2.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return date > DateTime.UtcNow;
        }
    }
}
