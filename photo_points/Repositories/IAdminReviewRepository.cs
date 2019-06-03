using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using photo_points.Models;

namespace photo_points.Repositories
{
    public interface IAdminReviewRepository
    {
        IQueryable<Capture> GetCaptures();
        Capture GetCapture(long captureId);
        IEnumerable<Capture> GetAllUnapproved();

        IQueryable<Capture> SavedCaptures();


    }
}
