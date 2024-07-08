using FluentValidation;
using TodoManagementAPI.Domain.DTOs.Todo;

namespace TodoManagementAPI.Application.Validators
{
    public class UpdateTodoPriorityValidator : AbstractValidator<UpdateTodoPriorityDto>
    {
        public UpdateTodoPriorityValidator()
        {
            RuleFor(x => x.TodoId).NotEmpty();
            RuleFor(x => x.Priority).InclusiveBetween(1, 3).WithMessage("Priority must be either 1, 2, or 3.");
        }
    }
}
