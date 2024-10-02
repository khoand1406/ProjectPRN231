using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDataAccess.CVs
{
   

    internal class CVrepository : ICVRepository
    {
        private readonly FinalProjectPrn231Context _context;
        public CVrepository(FinalProjectPrn231Context context) {
            this._context = context;
        }
        public List<Cv> getListCvsByApplicantId(int applicantId)
        {
            try
            {
                var listCv = _context.Cvs.Where(cv => cv.ApplicantId == applicantId).ToList();
                return listCv;
            }
            catch (Exception ex)
            {
                // Log the exception message or handle it as per your application's requirements
                Console.WriteLine($"Error retrieving CVs for applicant ID {applicantId}: {ex.Message}");
                throw;  // Consider re-throwing the exception to notify the calling code
            }
        }

        public Cv getCVbyApplicantId(int id, int applicantId)
        {
            try
            {
                var cv = _context.Cvs.FirstOrDefault(cv => cv.Id == id && cv.ApplicantId == applicantId);
                return cv;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void createNewCV(int applicantId, Cv cv)
        {
            try
            {
                cv.ApplicantId = applicantId;

                cv.CreateAt = DateTime.UtcNow;
                _context.Cvs.Add(cv);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void deleteCV(int id, int applicantId)
        {
            try
            {
                var cv = _context.Cvs.FirstOrDefault(cv => cv.Id == id && cv.ApplicantId == applicantId);
                _context.Cvs.Remove(cv);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void updateCV(int id, Cv cv, int applicantId)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
    }
}
