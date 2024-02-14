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
        public Job FromJobInfoToJob(JobInfo jobInfo)
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

        public List<Job> FromtJobInfoLisToJobList(List<JobInfo> jobInfo)
        {
            List<Job> jobs = new List<Job>();
            foreach (var item in jobInfo)
            {
                jobs.Add(FromJobInfoToJob(item));
            }
            return jobs;
        }
    }
}
