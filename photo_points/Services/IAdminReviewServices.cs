using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD

namespace photo_points.Models
{
    public interface IAdminReviewServices
{
        bool ApproveCapture(Capture capture, long CaptureId);
        IQueryable<Capture> GetAllCaptures();
        
        // IQueryable<Data> Datas { get; }
        // IQueryable<PhotoPoint> PhotoPoints { get; }
}
=======
using photo_points.Models;

namespace photo_points.Services
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public interface IAdminReviewServices
    {
        ///// /// 
        bool approve(long captureID);

    }


>>>>>>> issue-22-sara
}
