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

        // private readonly IAdminReviewServiceRepository _adminRepo;
        private IAdminReviewRepository _fakeAdminRepo;

        public AdminReviewServices(IAdminReviewRepository fakeAdminRepo)
        {
            _fakeAdminRepo = fakeAdminRepo;
        }

        public void ApproveOrReject(long captureID, bool choice)
        {
            // this will be uncomment after Eric pull my branch
            Capture capt = _fakeAdminRepo.GetCapture(captureID);
            capt.approved = choice;

        }

        public IEnumerable<Capture> GetUnapprovedCaptures()
        {
            return _fakeAdminRepo.GetCaptures().Where(a => a.approved == false);
            ////Eric: is the line above correct? everything after the dot . was missing and I filled it in
        }

        public IEnumerable<Capture> GetApprovedCaptures()
        {
            return _fakeAdminRepo.GetCaptures().Where(a => a.approved == true);
        }

        //public IEnumerable<Capture> GetUnapprovedCaptures()
        //{
        //    throw new NotImplementedException();
        //}

        //public object approve()
        //{
        //    throw new NotImplementedException();
        //}
    }

   
}
