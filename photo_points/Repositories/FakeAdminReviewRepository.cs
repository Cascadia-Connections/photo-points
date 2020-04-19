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



    public class FakeAdminReviewRepository : IAdminReviewRepository
    {


        private DateTime dateTime(int v)
        {
            throw new NotImplementedException();
        }

        byte[] imgdata = System.IO.File.ReadAllBytes("wwwroot/images/maple-leaf-888807_640.jpg");

        byte[] imgdata1 = System.IO.File.ReadAllBytes("wwwroot/images/blackberry-flower-4070045_640.jpg");

        byte[] imgdata2 = System.IO.File.ReadAllBytes("wwwroot/images/fern-1105988_640.jpg");

        // Need to pull Willie's updated entity model with "Approved" property
        public List<Capture> repo = new List<Capture> {
                new Capture {
                    captureID= 1,
                    photo = System.IO.File.ReadAllBytes("wwwroot/images/maple-leaf-888807_640.jpg"),
                    captureDate = DateTime.Now,
                    approval=Capture.ApprovalType.Pending,
                    PhotoPoint=new PhotoPoint(){photoPointID=1, feature=PhotoPoint.FeatureType.Leaves, locationName="Oak Trees #1"},
                    user=new User(){firstName="Tom", lastName="Jones"},
                    tags=new List<Tag>(){{new Tag() {tagID=0, tagName="Leaves Falling"} }, new Tag() {tagID=1,tagName = "On Track" } },
                    data=new List<Data>(){{new Data() {dataID=0,type="Color", value="Green"} } }
                    },
                new Capture {
                captureID=2,
                photo =System.IO.File.ReadAllBytes("wwwroot/images/blackberry-flower-4070045_640.jpg"),
                 captureDate = DateTime.Now ,
                 approval=Capture.ApprovalType.Pending
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
            return captures.Where(a => a.approval == Capture.ApprovalType.Pending); // Approve//Pening//or Reject to test 

        }

        public void SaveChanges(Capture capt)
        {
            foreach (photo_points.Models.Capture c in repo)
            {
                //it will compare properties in fake repository with service changes
                //it will save and replace new info to repo
                if (c.captureID == capt.captureID)

                {
                    c.approval = capt.approval;
                    c.captureDate = capt.captureDate;
                    c.data = capt.data;
                    c.photo = capt.photo;
                    c.PhotoPoint = capt.PhotoPoint;
                    c.tags = capt.tags;
                    c.user = capt.user;
                }

            }




        }
    }
}