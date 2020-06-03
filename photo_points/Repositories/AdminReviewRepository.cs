
using Microsoft.EntityFrameworkCore;
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
            var captureToDelete = _dbcontext.Captures.FirstOrDefault(p => p.captureID == captureId);

            if(captureToDelete != null)
            {
                _dbcontext.Captures.Remove(captureToDelete);
            }
            return captureToDelete;
        }

        public IEnumerable<Capture> GetAllUnapproved()
        {
            return _dbcontext.Captures
                .Where(a => a.approval == Capture.ApprovalType.Pending); 
        }

        public Capture GetCapture(long captureId)
        {
            var capture = _dbcontext.Captures.Include(c => c.user).Include(c => c.data).Include(c => c.photoPoint).Include(c => c.tags).FirstOrDefault(p => p.captureID == captureId);
            return capture;
        }

        public IEnumerable<Capture> GetCaptures()
        {
            var captures = _dbcontext.Captures.Include(c => c.user).Include(c => c.data).Include(c => c.tags).Include(c => c.photoPoint);
            return captures;
        }

        public IEnumerable<Capture> GetCapturesWithPhotoPoints()
        {
            return _dbcontext
                .Captures
                .Include(c => c.photoPoint)
                .ToList();
                
        }

        public void SaveChanges(Capture capt)
        {
            var capture = _dbcontext.Captures.FirstOrDefault(c => c.captureID == capt.captureID);

            if(capture != null)
            {
                capture.approval = capt.approval;
                capture.captureDate = capt.captureDate;
                capture.data = capt.data;
                capture.photo = capt.photo;
                capture.photoPoint = capt.photoPoint;
                capture.tags = capt.tags;
                capture.user = capt.user;

                _dbcontext.Captures.Update(capture);
            }
            else
            {
                _dbcontext.Captures.Add(capt);
            }
            _dbcontext.SaveChanges();
        }
    }
}
