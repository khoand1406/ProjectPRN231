using FluentValidation;
using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.CustomValidation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.CompanyName)
            .NotEmpty().WithMessage("CompanyName must not be empty.")
            .WithErrorCode("COMANY_NAME_REQUIRED")
            .MinimumLength(10)
            .WithMessage("Company name must be longer than 10 characters")
            .WithErrorCode("COMPANY_NAME_TOO_SHORT");
            

            RuleFor(x=> x.CompanyLogo)
                .NotEmpty().WithMessage("Logo image directory must not be empty.")
                .WithErrorCode("LOGO_DIRECTORY_REQUIRED")
                .MinimumLength(10).WithMessage("Logo must be at least 10 characters")
                .WithErrorCode("COMPANY_LOGO_TOO_SHORT");

            RuleFor(x => x.CompanyEmail)
            .NotEmpty().WithMessage("Company email is required").WithErrorCode("COMPANY_EMAIL_REQUIRED")
            .EmailAddress().WithMessage("Invalid email format").WithErrorCode("INVALID_EMAIL_FORMAT");

            RuleFor(x => x.Website)
                .NotEmpty().WithMessage("Website is required").WithErrorCode("WEBSITE_REQUIRED")
                .MinimumLength(10).WithMessage("Website must be at least 10 characters").WithErrorCode("WEBSITE_TOO_SHORT");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required").WithErrorCode("PHONE_REQUIRED")
                .Matches(@"^\d{10,15}$").WithMessage("Phone number must be 10-15 digits").WithErrorCode("INVALID_PHONE_FORMAT");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required").WithErrorCode("ADDRESS_REQUIRED")
                .MinimumLength(10).WithMessage("Address must be at least 10 characters").WithErrorCode("ADDRESS_TOO_SHORT");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required").WithErrorCode("DESCRIPTION_REQUIRED")
                .MinimumLength(10).WithMessage("Description must be at least 10 characters").WithErrorCode("DESCRIPTION_TOO_SHORT");

            RuleFor(x => x.EmployeeSize)
                .InclusiveBetween(1, 9999).WithMessage("Employee size must be between 1 and 9999").WithErrorCode("INVALID_EMPLOYEE_SIZE");

            RuleFor(x => x.TechStack)
                .NotEmpty().WithMessage("Tech stack information must not be empty").WithErrorCode("TECH_STACK_REQUIRED");

            RuleFor(x => x.FollowCount)
                .NotNull().WithMessage("Follow count is required").WithErrorCode("FOLLOW_COUNT_REQUIRED");

        }

    }
}
