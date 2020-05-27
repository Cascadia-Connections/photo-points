using Microsoft.EntityFrameworkCore;
using photo_points.Models;
using System.Collections.Generic;
using System.Linq;

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
            var captureToDelete = _dbcontext.Captures.FirstOrDefault(p => p.CaptureId == captureId);

            if (captureToDelete != null)
            {
                _dbcontext.Captures.Remove(captureToDelete);
            }
            return captureToDelete;
        }

        public IEnumerable<Capture> GetAllUnapproved()
        {
            return _dbcontext.Captures
                .Where(a => a.Approval == ApprovalStatus.Pending);
        }

        public Capture GetCapture(long captureId)
        {
            var capture = _dbcontext.Captures.FirstOrDefault(p => p.CaptureId == captureId);
            return capture;
        }

        public IEnumerable<Capture> GetCaptures()
        {
            var captures = _dbcontext.Captures;
            return captures;
        }

        public IEnumerable<Capture> GetCapturesWithPhotoPoints()
        {
            return _dbcontext
                .Captures
                .Include(c => c.PhotoPoint)
                .ToList();
        }

        public void SaveChanges(Capture capt)
        {
            var capture = _dbcontext.Captures.FirstOrDefault(c => c.CaptureId == capt.CaptureId);

            if (capture != null)
            {
                capture.Approval = capt.Approval;
                capture.CaptureDate = capt.CaptureDate;
                capture.Data = capt.Data;
                capture.Photo = capt.Photo;
                capture.PhotoPoint = capt.PhotoPoint;
                capture.Tags = capt.Tags;
                capture.User = capt.User;

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