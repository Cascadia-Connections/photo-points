using photo_points.Models;
using System.Collections.Generic;

namespace photo_points.Services
{
    public interface IAdminReviewServices
    {
        void ApproveOrReject(long CaptureId, ApprovalStatus choice);

        IEnumerable<Capture> GetCaptures();

        IEnumerable<Capture> GetUnapprovedCaptures();

        IEnumerable<Capture> GetApprovedCaptures();

        IEnumerable<Capture> GetCapturesWithPhotoPointByApprovalStatus(ApprovalStatus approvalStatus);
    }
}