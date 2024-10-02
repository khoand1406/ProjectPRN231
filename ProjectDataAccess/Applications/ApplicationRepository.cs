using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDataAccess.Applications
{
    public class ApplicationRepository : IApplicantRepository
    {
        public void CreateApplication(Application application)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Application> GetAllApplicationsByJobId(int jobid)
        {
            throw new NotImplementedException();
        }

        public Applicant GetApplicantById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Application> GetApplicationsByuserId(int userId)
        {
            throw new NotImplementedException();
        }

        public User getUserByApplicantId(int applicantId)
        {
            throw new NotImplementedException();
        }

        public void UpdateApplicationStatus(Application application)
        {
            throw new NotImplementedException();
        }
    }
}
