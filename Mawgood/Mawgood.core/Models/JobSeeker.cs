﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.core.Models
{
    internal class JobSeeker
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string CvUrl { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }
    }
}
