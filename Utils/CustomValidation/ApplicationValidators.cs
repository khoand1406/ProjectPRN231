using FluentValidation;
using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.CustomValidation
{
    public class ApplicationValidators: AbstractValidator<Application>{
        
        public ApplicationValidators() {
            RuleFor(x => x.ApplicantId)
           .NotNull()
           .WithMessage("Applicant ID is required.");

            // JobId is required
            RuleFor(x => x.JobId)
                .NotNull()
                .WithMessage("Job ID is required.");

          
            RuleFor(x => x.CvId)
                .NotNull()
                .When(x => x.ApplicantId.HasValue)
                .WithMessage("A valid CV is required for the applicant.");

          
            RuleFor(x => x.CoverLetter)
                .NotEmpty()
                .WithMessage("Cover letter is required.")
                .MinimumLength(50)
                .WithMessage("Cover letter must be at least 50 characters.");

            // Status is required and must be either "Pending", "Approved", or "Rejected"
            RuleFor(x => x.Status)
                .NotEmpty()
                .WithMessage("Status is required.")
                .Must(status => new[] { "Pending", "Approved", "Rejected" }.Contains(status))
                .WithMessage("Status must be either 'Pending', 'Approved', or 'Rejected'.");

        
            RuleFor(x => x.AppliedAt)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Applied date cannot be in the future.");
        }
    }

    }

