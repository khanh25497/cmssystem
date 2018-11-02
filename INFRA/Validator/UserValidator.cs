using CORE.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace INFRA.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Username)
                .NotEmpty().WithMessage("Username must not be empty")
                .Length(0, 50).WithMessage("Length must be between 0 and 50");
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password must not be empty")
                .Length(8, 100).WithMessage("Length must be between 8 and 100");
        }
    }
}
