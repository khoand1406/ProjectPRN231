using FluentValidation;
using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.CustomValidation
{
    public class ApplicantsValidatior: AbstractValidator<Applicant>
    {
        public ApplicantsValidatior() {
            // FullName is required
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Full Name is required.");

            // Phone is required and must match phone number format
            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .WithMessage("Invalid phone number format.");

            // Education is required
            RuleFor(x => x.Education)
                .NotEmpty()
                .WithMessage("Education is required.");

            // Cross-property validation: If Education is "Bachelor's degree" or higher, Experience is required
            RuleFor(x => x.Experience)
                .NotEmpty()
                .When(x => !string.IsNullOrEmpty(x.Education) && x.Education.ToLower().Contains("bachelor"))
                .WithMessage("Experience is required if the education level is Bachelor's degree or higher.");

            // Validate Address
            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address is required.")
                .MaximumLength(250)
                .WithMessage("Address cannot exceed 250 characters.");
        }

    }

    }

