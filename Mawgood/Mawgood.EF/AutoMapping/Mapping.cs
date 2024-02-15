using Mawgood.Core.AutoMapper;
using Mawgood.Core.DTO.Request;
using Mawgood.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.EF.AutoMapping
{
    public class Mapping : IMapping
    {
        public Job JobInfoToJob(JobInfo jobInfo)
        {
            return new Job()
            {
                Title = jobInfo.Title,
                Description = jobInfo.Description,
                ImageUrl = jobInfo.ImageUrl,
                Location = jobInfo.Location,
                Type = jobInfo.Type,
                Category = jobInfo.Category,
                Salary = jobInfo.Salary,
                Currency = jobInfo.Currency,
                SalaryPeriod = jobInfo.SalaryPeriod,
                Experience = jobInfo.Experience,
                Classification = jobInfo.Classification,
                Education = jobInfo.Education,
                Skills = jobInfo.Skills,
                Languages = jobInfo.Languages,
                Benefits = jobInfo.Benefits,
                Responsibilities = jobInfo.Responsibilities,
                Requirements = jobInfo.Requirements,
                Deadline = jobInfo.Deadline,
                Status = jobInfo.Status,
                CreatedAt = jobInfo.CreatedAt,
                UpdatedAt = jobInfo.UpdatedAt,
                IsRemote = jobInfo.IsRemote,
                EmployerId = jobInfo.EmployerId
            };
        }

        public List<Job> JobInfoLisToJobList(List<JobInfo> jobInfo)
        {
            List<Job> jobs = new List<Job>();
            foreach (var item in jobInfo)
            {
                jobs.Add(JobInfoToJob(item));
            }
            return jobs;
        }
        
        public Application ApplicationInfoToApplication(ApplicationInfo applicationInfo)
        {
            return new Application()
            {
                AppliedAt = DateTime.Now,
                Status = applicationInfo.Status,
                Message = applicationInfo.Message,
                CvUrl = applicationInfo.CvUrl,
                JobId = applicationInfo.JobId,
                JobSeekerId = applicationInfo.JobSeekerId
            };
        }

        public List<Application> ApplicationInfoListToApplicationList(List<ApplicationInfo> applicationInfo)
        {
            List<Application> applications = new List<Application>();
            foreach (var item in applicationInfo)
            {
                applications.Add(ApplicationInfoToApplication(item));
            }
            return applications;
        }


        public Job JobInfoToJob(JobInfo jobInfo, int jobId)
        {
            return new Job()
            {
                Id = jobId,
                Title = jobInfo.Title,
                Description = jobInfo.Description,
                ImageUrl = jobInfo.ImageUrl,
                Location = jobInfo.Location,
                Type = jobInfo.Type,
                Category = jobInfo.Category,
                Salary = jobInfo.Salary,
                Currency = jobInfo.Currency,
                SalaryPeriod = jobInfo.SalaryPeriod,
                Experience = jobInfo.Experience,
                Classification = jobInfo.Classification,
                Education = jobInfo.Education,
                Skills = jobInfo.Skills,
                Languages = jobInfo.Languages,
                Benefits = jobInfo.Benefits,
                Responsibilities = jobInfo.Responsibilities,
                Requirements = jobInfo.Requirements,
                Deadline = jobInfo.Deadline,
                Status = jobInfo.Status,
                CreatedAt = jobInfo.CreatedAt,
                UpdatedAt = jobInfo.UpdatedAt,
                IsRemote = jobInfo.IsRemote,
                EmployerId = jobInfo.EmployerId
            };
        }

        public List<Job> JobInfoLisToJobList(List<JobInfo> jobInfo, int jobId)
        {
            List<Job> jobs = new List<Job>();
            foreach (var item in jobInfo)
            {
                jobs.Add(JobInfoToJob(item, jobId));
            }
            return jobs;
        }

        public Application ApplicationInfoToApplication(ApplicationInfo applicationInfo, int applicationId)
        {
            return new Application()
            {
                Id = applicationId,
                AppliedAt = DateTime.Now,
                Status = applicationInfo.Status,
                Message = applicationInfo.Message,
                CvUrl = applicationInfo.CvUrl,
                JobId = applicationInfo.JobId,
                JobSeekerId = applicationInfo.JobSeekerId
            };
        }

        public List<Application> ApplicationInfoListToApplicationList(List<ApplicationInfo> applicationInfo, int applicationId)
        {
            List<Application> applications = new List<Application>();
            foreach (var item in applicationInfo)
            {
                applications.Add(ApplicationInfoToApplication(item, applicationId));
            }
            return applications;
        }
    }
}
