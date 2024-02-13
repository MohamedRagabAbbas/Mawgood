using Mawgood.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.Core.DTO.Request
{
    public class ApplicationInfo
    {
        public DateTime AppliedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string CvUrl { get; set; } = string.Empty;

        //Relationships
        public int JobId { get; set; }
        public int JobSeekerId { get; set; }
    }
}
