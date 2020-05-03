using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using photo_points.Models;
using photo_points.Repositories;

namespace photo_points.Services
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AdminReviewServices  : IAdminReviewServices
    {
        private IAdminReviewRepository _AdminRepo;

        public AdminReviewServices(IAdminReviewRepository AdminRepo)
        {
            _AdminRepo = AdminRepo;
        }

        public void ApproveOrReject(long captureID, Capture.ApprovalType choice)
        {
            Capture capt = _AdminRepo.GetCapture(captureID);
            capt.approval = choice;
            _AdminRepo.SaveChanges(capt);
        }

        public IEnumerable<Capture> GetCaptures()
        {
            return _AdminRepo.GetCaptures();
        }
        public IEnumerable<Capture> GetUnapprovedCaptures()
        {
            return GetCaptures().Where(a => a.approval == Capture.ApprovalType.Pending);
        }

        public IEnumerable<Capture> GetApprovedCaptures()
        {
            return GetCaptures().Where(a => a.approval == Capture.ApprovalType.Approve);
        }
    }
}
