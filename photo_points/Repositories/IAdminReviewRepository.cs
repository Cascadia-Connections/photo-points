using photo_points.Models;
using System.Collections.Generic;

namespace photo_points.Repositories
{
    public interface IAdminReviewRepository
    {
        IEnumerable<Capture> GetCaptures();

        Capture GetCapture(long captureId);

        IEnumerable<Capture> GetAllUnapproved();

        Capture DeleteCapture(long captureId);

        void SaveChanges(Capture capt);

        IEnumerable<Capture> GetCapturesWithPhotoPoints();
    }
}