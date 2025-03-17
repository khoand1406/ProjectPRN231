using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Jobs
{
    public interface IJobService
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

        IEnumerable<Job> getJobByName(string name);

        IEnumerable<Job> getJobBySkillandLocation(int skillid, string location);

        IEnumerable<Job> getJobBySkillandCompanyName(int skillid, string companyName);

        IEnumerable<Job> GetJobs();

        IEnumerable<Job> getJobByAllFilters(List<int> skillid, string location, string companyName, string employmentType, string job_type);

        IEnumerable<Job> getJobByJobType(string jobtype);

        //

        
        void createJob(Job job);
        void UpdateJob(int id, Job job);

        void DeleteJob(int jobid);

        void UpdateStatusJob(int jobid, bool status );
    }
}
