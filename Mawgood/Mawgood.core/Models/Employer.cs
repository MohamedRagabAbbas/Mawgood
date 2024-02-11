using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.Core.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyLogoUrl { get; set; } = string.Empty;
        public string CompanyDescription { get; set; } = string.Empty;
        public string CompanyLocation { get; set; } = string.Empty;
        public string CompanyWebsite { get; set; } = string.Empty;
        public string CompanyEmail { get; set; } = string.Empty;
        public string CompanyPhone { get; set; } = string.Empty;
        public string CompanyFax { get; set; } = string.Empty;
        public string CompanyMobile { get; set; } = string.Empty;
        public string CompanySocialMedia { get; set; } = string.Empty;
        public string CompanyIndustry { get; set; } = string.Empty;
        public string CompanySize { get; set; } = string.Empty;
        public string CompanyType { get; set; } = string.Empty;
        public string CompanyFounded { get; set; } = string.Empty;
        public string CompanySpecialties { get; set; } = string.Empty;
        public string CompanyMission { get; set; } = string.Empty;
        public string CompanyVision { get; set; } = string.Empty;
        public string CompanyValues { get; set; } = string.Empty;
        public string CompanyServices { get; set; } = string.Empty;
        public string CompanyProducts { get; set; } = string.Empty;
        public string CompanyAwards { get; set; } = string.Empty;
        public string CompanyCertifications { get; set; } = string.Empty;
        public string CompanyMemberships { get; set; } = string.Empty;
        public string CompanyAffiliations { get; set; } = string.Empty;
        public string CompanyPartnerships { get; set; } = string.Empty;
        public string CompanyClients { get; set; } = string.Empty;
        public string CompanyProjects { get; set; } = string.Empty;
        public string CompanyCareers { get; set; } = string.Empty;
        public string CompanyNews { get; set; } = string.Empty;
        public string CompanyEvents { get; set; } = string.Empty;

        //Relationships
        public string UserId { get; set; } = string.Empty;  
        public User? User { get; set; }
        public int? JobId { get; set; }
        public List<Job>? Jobs { get; set; }




    }
}
