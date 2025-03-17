using FluentValidation;
using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.CustomValidation
{
    public class CvValidators:AbstractValidator<Cv>
    {
        public CvValidators()
        {
            // Validation for CvName
            RuleFor(cv => cv.CvName)
                .NotEmpty().WithMessage("CV Name is required.")
                .Length(5, 100).WithMessage("CV Name must be between 5 and 100 characters.");

            // Validation for CvUrl
            RuleFor(cv => cv.CvUrl)
                .NotEmpty().WithMessage("CV URL is required.")
                .Must(IsValidUrl).WithMessage("Invalid URL format.");

            // Validation for CreateAt
            RuleFor(cv => cv.CreateAt)
                .NotEmpty().WithMessage("Create date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Create date cannot be in the future.");

            // Validation for UpdateAt
            RuleFor(cv => cv.UpdateAt)
                .NotEmpty().WithMessage("Update date is required.")
                .GreaterThan(cv => cv.CreateAt).WithMessage("Update date must be greater than Create date.");

            // Validation for IsActive
            RuleFor(cv => cv.IsActive)
                .NotNull().WithMessage("IsActive must be provided.");
        }

        private bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }

    }
}
