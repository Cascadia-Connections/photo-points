using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using photo_points.Models;


namespace photo_points.Services
{
    public interface IAdminReviewServices
    {
        void ApproveOrReject(long CaptureId, Capture.ApprovalType choice);
        IEnumerable<Capture> GetCaptures();
        IEnumerable<Capture> GetUnapprovedCaptures();
        IEnumerable<Capture> GetApprovedCaptures();
        IEnumerable<Capture> GetCapturesWithPhotoPointByApprovalStatus(Capture.ApprovalType approvalStatus);
    }
}