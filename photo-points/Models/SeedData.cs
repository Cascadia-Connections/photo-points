using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace photo_points.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            if (!context.Submissions.Any())
            {
                context.Submissions.AddRange(
                    new Submission { User = "Eric", ApprovalStatus = false },
			        new Submission { User = "Ro", ApprovalStatus = true },
			        new Submission { User = "BIT286", ApprovalStatus = false },
			        new Submission { User = "PhotoPoints", ApprovalStatus = true }
                    );
                context.SaveChanges();
            }
        }
    }
}