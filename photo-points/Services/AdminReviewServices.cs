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

      // private readonly IAdminReviewServiceRepository _adminRepo;
      private IAdminReviewServiceRepository _adminRipo;

        public AdminReviewServices(IAdminReviewServiceRepository adminRepo)
        {
            _adminRipo = adminRepo;
        }

    }

   
}
