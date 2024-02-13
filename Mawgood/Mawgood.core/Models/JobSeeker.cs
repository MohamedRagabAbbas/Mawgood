using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.Core.Models
{
    public class JobSeeker
    {
        public int Id { get; set; }
        public string Feild { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string CvUrl { get; set; } = string.Empty;

        //Relationships
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }
        public List<Application>? Applications { get; set; }
    }
}
