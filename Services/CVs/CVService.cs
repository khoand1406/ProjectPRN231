using FluentValidation;
using ProjectBusinessModel.Models;
using ProjectDataAccess.CVs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.CustomValidation;

namespace Services.CVs
{
    public class CVService : ICVServices
    {
        private readonly ICVRepository _cvRepository;
        private readonly CvValidators _cvValidators;

        public CVService(ICVRepository cvRepository, CvValidators cvValidators)
        {
            _cvRepository = cvRepository;
            _cvValidators = cvValidators;
        }


        public async Task createNewCV(int applicantId, Cv cv)
        {
            if (cv == null)
                throw new ArgumentNullException(nameof(cv));

            var validationResult = await _cvValidators.ValidateAsync(cv);
            if (!validationResult.IsValid)
                throw new ValidationException("CV validation failed", validationResult.Errors);

            cv.ApplicantId = applicantId;
            _cvRepository.createNewCV(applicantId, cv);
        }

        

        public void deleteCV(int id, int applicantId)
        {
            var cv = _cvRepository.getCVbyApplicantId(id, applicantId);
            if (cv == null)
                throw new ArgumentException("CV not found.");

            _cvRepository.deleteCV(id, applicantId);
        }


        public Cv getCVbyApplicantId(int id, int applicantId)
        {
            var cv = _cvRepository.getCVbyApplicantId(id, applicantId);
            if (cv == null)
                throw new ArgumentException("CV not found.");

            return cv;
        }

       

        public List<Cv> getListCvsByApplicantId(int id)
        {
            return _cvRepository.getListCvsByApplicantId(id);
        }


        public void updateCV(int id, Cv cv, int applicantId)
        {
            var existingCv = _cvRepository.getCVbyApplicantId(id, applicantId);
            if (existingCv == null)
                throw new ArgumentException("CV not found.");

            var validationResult = _cvValidators.Validate(cv);
            if (!validationResult.IsValid)
                throw new ValidationException("CV validation failed", validationResult.Errors);

            existingCv.CvName = cv.CvName;
            existingCv.CvUrl = cv.CvUrl;
            existingCv.UpdateAt = DateTime.UtcNow;

            _cvRepository.updateCV(id,existingCv, applicantId);
        }
    }
}
