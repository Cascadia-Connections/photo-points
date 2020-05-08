
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


        byte[] imgdata = System.IO.File.ReadAllBytes("wwwroot/images/maple-leaf-888807_640.jpg");

        byte[] imgdata1 = System.IO.File.ReadAllBytes("wwwroot/images/blackberry-flower-4070045_640.jpg");

        byte[] imgdata2 = System.IO.File.ReadAllBytes("wwwroot/images/fern-1105988_640.jpg");

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
            var capture = _dbcontext.Captures.FirstOrDefault(c => c.captureID == capt.captureID);

            if(capture != null)
            {
                capture.approval = capt.approval;
                capture.captureDate = capt.captureDate;
                capture.data = capt.data;
                capture.photo = capt.photo;
                capture.PhotoPoint = capt.PhotoPoint;
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
