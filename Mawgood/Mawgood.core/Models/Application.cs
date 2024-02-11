using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.Core.Models
{
    public class Application
    {
        public int Id { get; set; }
        public DateTime AppliedAt { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string CvUrl { get; set; } = string.Empty;

        //Relationships
        public int JobId { get; set; }
        public Job? Job { get; set; }
        public int JobSeekerId { get; set; }
        public JobSeeker? JobSeeker { get; set; }




    }
}
