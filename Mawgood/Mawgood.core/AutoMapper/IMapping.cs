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
        public Job JobInfoToJob(JobInfo jobInfo);
        public List<Job> JobInfoLisToJobList(List<JobInfo> jobInfo);

        public Application ApplicationInfoToApplication(ApplicationInfo applicationInfo);
        public List<Application> ApplicationInfoListToApplicationList(List<ApplicationInfo> applicationInfo);



        // for update medthos 
        public Job JobInfoToJob(JobInfo jobInfo, int jobId);
        public List<Job> JobInfoLisToJobList(List<JobInfo> jobInfo,int jobId);

        public Application ApplicationInfoToApplication(ApplicationInfo applicationInfo, int applicationID);
        public List<Application> ApplicationInfoListToApplicationList(List<ApplicationInfo> applicationInfo, int applicationID);
    }
}
