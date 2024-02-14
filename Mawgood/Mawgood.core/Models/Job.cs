using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.Core.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Salary { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string SalaryPeriod { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public string Classification { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;
        public string Skills { get; set; } = string.Empty;
        public string Languages { get; set; } = string.Empty;
        public string Benefits { get; set; } = string.Empty;
        public string Responsibilities { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;
        public string Deadline { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string UpdatedAt { get; set; } = string.Empty;
        public bool IsRemote { get; set; } = false;

        //Relationships
        public int EmployerId { get; set; }
        public Employer? Employer { get; set; } = null;
        public List<Application>? Applications { get; set; } = null;

    }
}
