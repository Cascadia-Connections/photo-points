using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public interface IAdminReviewServices
{
        bool ApproveCapture(Capture capture, long CaptureId);
        IQueryable<Capture> GetAllCaptures();
        
        // IQueryable<Data> Datas { get; }
        // IQueryable<PhotoPoint> PhotoPoints { get; }
}
}
