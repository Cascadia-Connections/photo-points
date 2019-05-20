using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD

namespace photo_points.Models
{
    public class AdminReviewServices
    {
        private IAdminReviewRepository _capturerepo;

        public AdminReviewServices(IAdminReviewRepository capturerepo)
        {
            _capturerepo = capturerepo;
        }

        public IQueryable<Capture> GetAllCaptures()
        {
            return _capturerepo.GetCaptures();
        }
    }
=======
using photo_points.Models;

namespace photo_points.Services
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AdminReviewServices : IAdminReviewServices
    {

        public bool approve(long captureID)
        {
        // this will be uncomment after Eric pull my branch
            //  new Capture capt =_fakeAdminRepo.GetCapture(captureID);
          
            return true;
        }

        // private readonly IAdminReviewServiceRepository _adminRepo;
        private IAdminReviewServiceRepository _fakeAdminRepo;

        public AdminReviewServices(IAdminReviewServiceRepository fakeAdminRepo)
        {
            _fakeAdminRepo = fakeAdminRepo;
        }



        //public object approve()
        //{
        //    throw new NotImplementedException();
        //}
    }

   
>>>>>>> issue-22-sara
}
