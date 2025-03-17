using FluentValidation;
using ProjectBusinessModel.Models;
using ProjectDataAccess.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions.ValidationException;

namespace Services.Jobs
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private IValidator<Job> _validator;

        public JobService(IJobRepository jobRepository, IValidator<Job> validator)
        {
            _jobRepository = jobRepository;
            _validator = validator;
        }

        public void createJob(Job job)
        {
            var validationResult= _validator.Validate(job);
            if(!validationResult.IsValid) {
                throw new JobValidationException();
            }
            else
            {
                _jobRepository.CreateJob(job);
            }
        }

        public void DeleteJob(int jobId)
        {
            var job = _jobRepository.getJobById(jobId);
            if (job == null)
            {
                throw new ArgumentException("Job not found.");
            }
            _jobRepository.DeleteJob(jobId);
        }

        public IEnumerable<Job> getAllJobs(int page, int pageSize)
        {
            return _jobRepository.GetJobs()
               .Skip((page - 1) * pageSize)
               .Take(pageSize);
        }

       public IEnumerable<Job> getJobByAllFilters(List<int> skillid, string location, string companyName, string employmentType, string job_type)
        {
            return _jobRepository.GetJobs()
                .Where(j => (skillid == null || j.Skills.Any(s => skillid.Contains(s.Id))) &&
                            (string.IsNullOrEmpty(location) || j.Location == location) &&
                            (string.IsNullOrEmpty(companyName) || j.Company.CompanyName == companyName) &&
                            (string.IsNullOrEmpty(employmentType) || j.EmploymentType == employmentType) &&
                            (string.IsNullOrEmpty(job_type) || j.JobType == job_type));
        }

       

        public IEnumerable<Job> getJobByCompanyId(int companyId)
        {
            return _jobRepository.getJobByCompanyId(companyId);
        }

       
        public IEnumerable<Job> getJobByCompanyName(string companyName)
        {
            return _jobRepository.getJobByCompanyName(companyName);
        }


        public IEnumerable<Job> getJobByEmploymentType(string employmentType)
        {
            return _jobRepository.getJobByEmploymentType(employmentType);
        }

       

        public Job getJobById(int jobid)
        {
            var job = _jobRepository.getJobById(jobid);
            if (job == null)
            {
                throw new ArgumentException("Job not found.");
            }
            return job;
        }

        

        public IEnumerable<Job> getJobByJobType(string jobtype)
        {
            return _jobRepository.getJobByJobType(jobtype);
        }


        public IEnumerable<Job> getJobByLocation(string location)
        {
            return _jobRepository.getJobByLocation(location);
        }

        public IEnumerable<Job> getJobByName(string name)
        {
            return _jobRepository.getJobByName(name);
        }

        
        public IEnumerable<Job> getJobBySkill(int skillid)
        {
            return _jobRepository.getJobBySkill(skillid);
        }


        public IEnumerable<Job> getJobBySkillandCompanyName(int skillid, string companyName)
        {
            return _jobRepository.getJobBySkillandCompanyName(skillid, companyName);
        }


        public IEnumerable<Job> getJobBySkillandLocation(int skillid, string location)
        {
            return _jobRepository.getJobBySkillandLocation(skillid, location);
        }

        
        public IEnumerable<Job> getJobBySkills(IEnumerable<Skill> skills)
        {
            var skillIds = skills.Select(s => s.Id).ToList();
            return _jobRepository.GetJobs()
                .Where(j => j.Skills.Any(s => skillIds.Contains(s.Id)));
        }

        public IEnumerable<Job> GetJobs()
        {
            return _jobRepository.GetJobs();
        }

        public IEnumerable<Job> getTop5Job()
        {
            return _jobRepository.GetJobs()
                .OrderByDescending(j => j.JobVieweds) 
                .Take(5);
        }


        public IEnumerable<Job> getTopLatestJob()
        {
            return _jobRepository.GetJobs()
                .OrderByDescending(j => j.ExpiredAt) 
                .Take(5);
        }

        public void UpdateJob(int id, Job job)
        {
            var existingJob = _jobRepository.getJobById(id);
            if (existingJob == null)
            {
                throw new ArgumentException("Job not found.");
            }
            else
            {
                var validationResult = _validator.Validate(job);
                if (validationResult.IsValid) {
                    _jobRepository.UpdateJob(id, job);
                }
            }
        }

        public void UpdateStatusJob(int jobid, bool status)
        {
            var existingJob= _jobRepository.getJobById(jobid);
            if (existingJob == null)
            {
                throw new ArgumentException("Job not found");
            }
            else
            {
                _jobRepository.UpdateStatusJob(jobid, status);
            }
        }
    }
}

