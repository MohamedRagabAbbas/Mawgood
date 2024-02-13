using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.Core.DTO.Request
{
    public class EmployerRegistrationRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyLogoUrl { get; set; } = string.Empty;
        public string CompanyDescription { get; set; } = string.Empty;
        public string CompanyLocation { get; set; } = string.Empty;
        public string CompanyWebsite { get; set; } = string.Empty;
        public string CompanyEmail { get; set; } = string.Empty;
        public string CompanyPhone { get; set; } = string.Empty;
        public string CompanyMobile { get; set; } = string.Empty;
        public string CompanySocialMedia { get; set; } = string.Empty;
        public string CompanyIndustry { get; set; } = string.Empty;
        public string CompanySize { get; set; } = string.Empty;
        public string CompanyType { get; set; } = string.Empty;
        public string CompanyFounded { get; set; } = string.Empty;
        public string CompanySpecialties { get; set; } = string.Empty;
        public string CompanyMission { get; set; } = string.Empty;
        public string CompanyVision { get; set; } = string.Empty;
        public string CompanyServices { get; set; } = string.Empty;
    }
}
