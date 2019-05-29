using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using photo_points.Models;

namespace photo_points.Services
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AdminReviewServices //: IAdminReviewServices
    {
        
        public bool approve(long captureID)
        {
        // this will be uncomment after Eric pull my branch
            //  new Capture capt =_fakeAdminRepo.GetCapture(captureID);
          
            return true;
        }

        // private readonly IAdminReviewServiceRepository _adminRepo;
        private IAdminReviewRepository _fakeAdminRepo;

        public AdminReviewServices(IAdminReviewRepository fakeAdminRepo)
        {
            _fakeAdminRepo = fakeAdminRepo;
        }

        public IQueryable<Capture> GetAllCaptures()
        {
            return _fakeAdminRepo.GetCaptures();
        }

        public IEnumerable<Capture> GetUnnapprovedCaptures()
        {
            return _fakeAdminRepo.GetCaptures();
            ////Eric: is the line above correct? everything after the dot . was missing and I filled it in
        }

        public IEnumerable<Capture> GetUnapprovedCaptures()
        {
            throw new NotImplementedException();
        }

        //public object approve()
        //{
        //    throw new NotImplementedException();
        //}
    }

   
}
