using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Applications
{
    public interface IApplication
    {
        IEnumerable<Application> GetApplicationsByuserId(int userId);

        Applicant GetApplicantById(int Id);

        //user
        void CreateApplication(Application application);

        //Employers view this
        IEnumerable<Application> GetAllApplicationsByJobId(int jobid);

        ProjectBusinessModel.Models.User getUserByApplicantId(int applicantId);

        void UpdateApplicationStatus(Application application);
    }
}
