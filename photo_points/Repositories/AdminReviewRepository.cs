using photo_points.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Repositories
{
    public class AdminReviewRepository : IAdminReviewRepository
    {
        private readonly PhotoDataContext _dbcontext;
        public AdminReviewRepository(PhotoDataContext Dbcontext)
        {
            _dbcontext = Dbcontext;
        }
        public Capture DeleteCapture(long captureId)
        {
            // find capture to delete
            var captureToDelete = _dbcontext.Captures.FirstOrDefault(p => p.captureID == captureId);

            if(captureToDelete != null)
            {
                _dbcontext.Captures.Remove(captureToDelete);
            }
            return captureToDelete;
        }

        // getting all rejected
        public IEnumerable<Capture> GetAllUnapproved()
        {
            // get all captures that are unapproved 

            var captures = _dbcontext.Captures.Where(p => p.approval.ToString() == "reject");
            return captures;
        }

        public Capture GetCapture(long captureId)
        {
            var capture = _dbcontext.Captures.FirstOrDefault(p => p.captureID == captureId);
            return capture;
        }

        public IEnumerable<Capture> GetCaptures()
        {
            var captures = _dbcontext.Captures;
            return captures;
        }

        public void SaveChanges(Capture capt)
        {
            throw new NotImplementedException();
        }

        // unfinished
        public Capture UpdateCapture(Capture capture)
        {
            var captureToUpdate = _dbcontext.Captures.FirstOrDefault(p => p.captureID == capture.captureID);
            // get proper props to update
            return captureToUpdate;
        }
    }
}
