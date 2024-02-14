using Mawgood.Core.DTO.Request;
using Mawgood.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.Core.AutoMapper
{
    public interface IMapping
    {
        public Job FromJobInfoToJob(JobInfo jobInfo);
        public List<Job> FromtJobInfoLisToJobList(List<JobInfo> jobInfo);
    }
}
