using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public class FakeSubmissionRepository : SubmissionRepository
{
        public IQueryable<Submission> Submissions => new List<Submission>
        {
            new Submission{ User = "Eric", ApprovalStatus = false },
            new Submission{ User = "Ro", ApprovalStatus = true },
            new Submission{ User = "BIT286", ApprovalStatus = false },
            new Submission{ User = "PhotoPoints", ApprovalStatus = true }
        }.AsQueryable<Submission>();
}
}
