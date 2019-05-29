using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using photo_points.Models;


namespace photo_points.Services
{
    public interface IAdminReviewServices
    {
        void ApproveOrReject(long CaptureId, bool choice);
        IEnumerable<Capture> GetUnapprovedCaptures();
        IEnumerable<Capture> GetApprovedCaptures();

        // IQueryable<Data> Datas { get; }
        // IQueryable<PhotoPoint> PhotoPoints { get; }
    }
}