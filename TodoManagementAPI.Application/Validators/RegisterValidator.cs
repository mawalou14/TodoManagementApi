﻿using FluentValidation;
using TodoManagementAPI.Domain.DTOs.User;

namespace TodoManagementAPI.Application.Validators
{
    public class RegisterValidator : AbstractValidator<Register>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty()
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
                .MaximumLength(20).WithMessage("Password must not exceed 20 characters.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,20}$")
                    .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, and one digit."); ;
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Passwords do not match.");
            RuleFor(x => x.FullName).NotEmpty();
        }
    }
}
