﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public class Submission
{
        public long Id { get; set; }
        public string User { get; set; }
        public bool ApprovalStatus { get; set; }
}
}
