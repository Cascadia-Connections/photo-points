using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public interface ISubmissionRepository
{
        IQueryable<Submission> Submissions { get; }
}
}
