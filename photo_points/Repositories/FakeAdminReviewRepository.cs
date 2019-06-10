using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using photo_points.Models;
using photo_points.Services;


namespace photo_points.Repositories
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project



    // FakePhotoRepository And IPhotoRepository changed by Eric's Codes//
    public class FakeAdminReviewRepository : IAdminReviewRepository
    { 


        private DateTime DateTime(int v)
        {
            throw new NotImplementedException();
        }

        byte[] imgdata = System.IO.File.ReadAllBytes("/wwwroot/images/maple-leaf-888807_640.jpg");

        byte[] imgdata1 = System.IO.File.ReadAllBytes("/wwwroot/images/blackberry-flower-4070045_640.jpg");

        byte[] imgdata2 = System.IO.File.ReadAllBytes ("/wwwroot/images/fern-1105988_640.jpg");

        // Need to pull Willie's updated entity model with "Approved" property
        public IQueryable<Capture> captures => new List<Capture> {
            new Capture { captureID= 1, photo = imgdata, captureDate = DateTime (4/25/2019) ,approval=Capture.ApprovalType.Approve },
            new Capture { captureID=2, photo =imgdata1, captureDate = DateTime (3/13/2019) ,approval=Capture.ApprovalType.Reject},
            new Capture { captureID=3, photo = imgdata2 , captureDate = DateTime(2/3/2019) ,approval=Capture.ApprovalType.Pending}

        List<Capture> repo = new List<Capture> {
            new Capture {
                captureID= 1,
                photo = System.IO.File.ReadAllBytes("wwwroot/images/maple-leaf-888807_640.jpg"),
                captureDate = DateTime.Now,
                approval=Capture.ApprovalType.Approve
                },
            new Capture {
            captureID=2,
            photo =System.IO.File.ReadAllBytes("wwwroot/images/blackberry-flower-4070045_640.jpg"),
             captureDate = DateTime.Now ,
             approval=Capture.ApprovalType.Reject
             },

            new Capture {
            captureID=3, photo =  System.IO.File.ReadAllBytes("wwwroot/images/fern-1105988_640.jpg") ,
            captureDate = DateTime.Now ,
            approval=Capture.ApprovalType.Pending}
        };



       

        // Need to pull Willie's updated entity model with "Approved" property
        public IQueryable<Capture> captures => repo.AsQueryable<Capture>();


        public IQueryable<Capture> GetCaptures()
        {
            return captures;
        }

        public Capture GetCapture(long id)
        {
            return captures.SingleOrDefault(r => r.captureID == id);
        }


        public IEnumerable<Capture> GetAllUnapproved()
        {
           // return captures.Where(a => a.approve == true);
         return captures.Where(a => a.approval == Capture.ApprovalType.Approve);

        }






    }
}