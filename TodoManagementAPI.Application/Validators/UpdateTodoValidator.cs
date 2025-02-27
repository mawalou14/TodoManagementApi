﻿using FluentValidation;
using TodoManagementAPI.Domain.DTOs.Todo;

namespace TodoManagementAPI.Application.Validators
{
    public class UpdateTodoValidator : AbstractValidator<UpdateTodoDto>
    {
        public UpdateTodoValidator()
        {
            RuleFor(x => x.TodoId)
                .NotEmpty().WithMessage("TodoId is required.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(255).WithMessage("Description must not exceed 255 characters.");

            RuleFor(x => x.TargetedTime)
                .NotEmpty().WithMessage("Targeted time is required.")
                .Must(BeAValidDate).WithMessage("Targeted time must be a valid date.");

            RuleFor(todo => todo.Priority)
            .InclusiveBetween(1, 3).WithMessage("Priority must be either 1 (Low), 2 (Medium), or 3 (High).");

            RuleFor(x => x.Status)
           .InclusiveBetween(1, 3).WithMessage("Status must be either 1, 2 or 3.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return date > DateTime.UtcNow;
        }
    }
}
