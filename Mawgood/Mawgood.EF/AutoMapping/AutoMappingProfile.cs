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
            CreateMap<JobInfo, Job>()
                        .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore mapping for Id since it's typically auto-generated
                        .ForMember(dest => dest.Employer, opt => opt.Ignore()) // Ignore mapping for Id since it's typically auto-generated
                        .ForMember(dest => dest.EmployerId, opt => opt.MapFrom(src => src.EmployerId)) // Map EmployerId directly
                        .ForMember(dest => dest.Applications, opt => opt.Ignore()); // Ignore mapping for Applications since it's null initially
            CreateMap<ApplicationInfo, Application>();
        }

    }
}
