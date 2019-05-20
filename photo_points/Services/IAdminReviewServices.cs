using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using photo_points.Models;

namespace photo_points.Services
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public interface IAdminReviewServices
    {
        ///// /// 
        bool approve(long captureID);

    }


}
