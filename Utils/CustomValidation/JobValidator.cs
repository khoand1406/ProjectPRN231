using FluentValidation;
using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.CustomValidation
{
    public class JobValidator: AbstractValidator<Job>
    {
        public JobValidator() {
            RuleFor(job => job.Title)
                    .NotEmpty().WithMessage("Job title is required.")
                    .Length(5, 100).WithMessage("Job title must be between 5 and 100 characters.");

            RuleFor(job => job.Description)
                .NotEmpty().WithMessage("Job description is required.")
                .Length(20, 1000).WithMessage("Job description must be between 20 and 1000 characters.");

            RuleFor(job => job.Location)
                .NotEmpty().WithMessage("Location is required.");

            RuleFor(job => job.Salary)
                .Matches(@"^\d+(\.\d{1,2})?$").WithMessage("Salary must be a valid number.");

            RuleFor(job => job.JobType)
                .NotEmpty().WithMessage("Job type is required.");

            RuleFor(job => job.Requirements)
                .NotEmpty().WithMessage("Requirements are required.");

            RuleFor(job => job.PostedAt)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Posted date cannot be in the future.");

            RuleFor(job => job.ExpiredAt)
                .GreaterThan(job => job.PostedAt).WithMessage("Expiration date must be after the posted date.");

            RuleFor(job => job.EmploymentType)
                .NotEmpty().WithMessage("Employment type is required.");

            RuleFor(job => job.Benefits)
                .NotEmpty().WithMessage("Benefits are required.");
        }
    }
}
    

