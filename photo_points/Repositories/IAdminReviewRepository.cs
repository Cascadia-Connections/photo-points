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


       //to connect to future method to save changes, as there is nothing to save currently
       // IQueryable<Capture> SavedCaptures();


        void SaveChanges(Capture capt);
    }
}
