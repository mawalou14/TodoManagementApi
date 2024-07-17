using FluentValidation;
using TodoManagementAPI.Domain.DTOs.Todo;

namespace TodoManagementAPI.Application.Validators
{
    public class UpdateTodoStatusValidator : AbstractValidator<UpdateTodoStatusDto>
    {
        public UpdateTodoStatusValidator()
        {
            RuleFor(x => x.TodoId).NotEmpty();
            RuleFor(x => x.Status).InclusiveBetween(1, 3).WithMessage("Status must be either 1, 2 or 3.");
        }
    }
}
