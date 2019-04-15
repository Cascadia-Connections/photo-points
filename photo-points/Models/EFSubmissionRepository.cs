using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public class EFSubmissionRepository : ISubmissionRepository
{
        private ApplicationDbContext context;

        public EFSubmissionRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Submission> Submissions => context.Submissions;
}
}
