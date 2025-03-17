using FluentValidation;
using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.CustomValidation
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator() {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(5, 20).WithMessage("Username must be between 5 and 20 characters.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(user => user.Role)
                .NotEmpty().WithMessage("Role is required.")
                .Must(role => role == "Employer" || role == "Employee").WithMessage("Role must be either 'Employer' or 'Employee'.");

            RuleFor(user => user.CreateAt)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Creation date cannot be in the future.");
        }
    }
}
