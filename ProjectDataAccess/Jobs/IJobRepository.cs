using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDataAccess.Jobs
{
    internal interface IJobRepository
    {
        IEnumerable<Job> getTop5Job();

       IEnumerable<Job> getTopLatestJob();

        IEnumerable<Job> getJobByCompanyId(int companyId);

        IEnumerable<Job> getJobByCompanyName(string companyName);

        IEnumerable<Job> getJobByLocation(string location);    

        IEnumerable<Job> getJobByEmploymentType(string employmentType);    

        IEnumerable<Job> getAllJobs(int page, int pageSize);

        IEnumerable<Job> getJobBySkill(int skillid);

        IEnumerable<Job> getJobBySkills(IEnumerable<Skill> skills);

        Job getJobById(int jobid);

        Job getJobByName(string name);

        IEnumerable<Job> getJobBySkillandLocation(int skillid, string location);

        IEnumerable<Job> getJobBySkillandCompanyName(int  skillid, string companyName);

       

        IEnumerable<Job> getJobByAllFilters(int skillid, string location, string companyName, string employmentType, string job_type);

        IEnumerable<Job> getJobByJobType(string jobtype);

        //
        void UpdateJob(Job job);

        void DeleteJob(int jobid);

    }
}
