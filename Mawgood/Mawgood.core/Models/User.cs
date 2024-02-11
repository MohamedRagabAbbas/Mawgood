using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.core.Models
{
    internal class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public Employer? Employer { get; set; }
        public JobSeeker? JobSeeker { get; set; }
    }
}
