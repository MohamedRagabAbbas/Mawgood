using AutoMapper;
using Mawgood.Core.DTO.Request;
using Mawgood.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.EF.AutoMapping
{
    public class AutoMappingProfile: Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<JobInfo,Job>();
            CreateMap<ApplicationInfo, Application>();
        }

    }
}
