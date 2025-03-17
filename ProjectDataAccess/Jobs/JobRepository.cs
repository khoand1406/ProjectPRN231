using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDataAccess.Jobs
{
    public class JobRepository : IJobRepository
    {
        public void DeleteJob(int jobid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> getAllJobs(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> getJobByAllFilters(int skillid, string location, string companyName, string employmentType, string job_type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> getJobByCompanyId(int companyId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> getJobByCompanyName(string companyName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> getJobByEmploymentType(string employmentType)
        {
            throw new NotImplementedException();
        }

        public Job getJobById(int jobid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> getJobByJobType(string jobtype)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> getJobByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public Job getJobByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> getJobBySkill(int skillid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> getJobBySkillandCompanyName(int skillid, string companyName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> getJobBySkillandLocation(int skillid, string location)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> getJobBySkills(IEnumerable<Skill> skills)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> getTop5Job()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> getTopLatestJob()
        {
            throw new NotImplementedException();
        }

        public void UpdateJob(Job job)
        {
            throw new NotImplementedException();
        }
    }
}
