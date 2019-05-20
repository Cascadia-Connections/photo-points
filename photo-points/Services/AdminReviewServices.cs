using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using photo_points.Models;

namespace photo_points.Services
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AdminReviewServices : IAdminReviewServices
    {

        public bool approve(long captureID, byte photo, DateTime captureDate, bool Approved)
        {
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

   
}
