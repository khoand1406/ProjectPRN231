using FluentValidation;
using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.CustomValidation
{
    public class EmployerValidation: AbstractValidator<Employer>
    {
        public EmployerValidation()
        {
            // Id and UserId should be required and greater than zero
            RuleFor(employer => employer.Id)
                .GreaterThan(0)
                .WithMessage("Employer ID must be greater than zero.");

            RuleFor(employer => employer.UserId)
                .GreaterThan(0)
                .WithMessage("User ID must be greater than zero.");

            // CompanyId is optional but if provided, it should be positive
            RuleFor(employer => employer.CompanyId)
                .GreaterThan(0)
                .When(employer => employer.CompanyId.HasValue)
                .WithMessage("Company ID, if provided, must be greater than zero.");

            // Position is optional but should have a reasonable maximum length
            RuleFor(employer => employer.Position)
                .MaximumLength(100)
                .WithMessage("Position can be at most 100 characters long.");

            // Phone is required and should have a length check
            RuleFor(employer => employer.Phone)
                .NotEmpty()
                .WithMessage("Phone number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .WithMessage("Phone number must be in valid international format.");

            // Email is required and must be a valid email address
            RuleFor(employer => employer.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Email must be a valid email address.");
        }
    }
}
