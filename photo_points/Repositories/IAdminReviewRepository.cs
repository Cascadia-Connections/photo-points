using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using photo_points.Models;

namespace photo_points.Repositories
{
    // knows about the dbcontext issue 88
    public interface IAdminReviewRepository 
    {
        IEnumerable<Capture> GetCaptures();
        Capture GetCapture(long captureId);
        IEnumerable<Capture> GetAllUnapproved();
        Capture UpdateCapture(Capture capture);
        Capture DeleteCapture(long captureId);
    }
}
