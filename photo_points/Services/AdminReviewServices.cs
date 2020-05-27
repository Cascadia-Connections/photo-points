using photo_points.Models;
using photo_points.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace photo_points.Services
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AdminReviewServices : IAdminReviewServices
    {
        private IAdminReviewRepository _AdminRepo;

        public AdminReviewServices(IAdminReviewRepository AdminRepo)
        {
            _AdminRepo = AdminRepo;
        }

        public void ApproveOrReject(long captureID, ApprovalStatus choice)
        {
            Capture capt = _AdminRepo.GetCapture(captureID);
            capt.Approval = choice;
            _AdminRepo.SaveChanges(capt);
        }

        public IEnumerable<Capture> GetCaptures()
        {
            return _AdminRepo.GetCaptures();
        }

        public IEnumerable<Capture> GetUnapprovedCaptures()
        {
            return GetCaptures().Where(a => a.Approval == ApprovalStatus.Pending);
        }

        public IEnumerable<Capture> GetApprovedCaptures()
        {
            return GetCaptures().Where(a => a.Approval == ApprovalStatus.Approve);
        }

        public IEnumerable<Capture> GetCapturesWithPhotoPointByApprovalStatus(ApprovalStatus approvalStatus)
        {
            return
                _AdminRepo
                .GetCapturesWithPhotoPoints()
                .Where(c => c.Approval == approvalStatus)
                .ToList();
        }
    }
}