
using photo_points.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Repositories
{
    public class AdminReviewRepository : IAdminReviewRepository
    {
        private readonly PhotoDataContext _dbcontext;

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
                 approval=Capture.ApprovalType.Pending,
                 PhotoPoint=new PhotoPoint(){photoPointID=2, feature=PhotoPoint.FeatureType.Bush, locationName="Branches"},
                    user=new User(){firstName="Tom", lastName="Jones"},
                    tags=new List<Tag>(){{new Tag() {tagID=0, tagName="Leaves Falling"} }, new Tag() {tagID=1,tagName = "On Track" } },
                    data=new List<Data>(){{new Data() {dataID=0,type="Color", value="Green"} } }
                 },
                new Capture {
                captureID=3, photo =  System.IO.File.ReadAllBytes("wwwroot/images/fern-1105988_640.jpg") ,
                captureDate = DateTime.Now ,
                approval=Capture.ApprovalType.Pending,
                PhotoPoint=new PhotoPoint(){photoPointID=3, feature=PhotoPoint.FeatureType.Fern, locationName="Something else"},
                    user=new User(){firstName="Tom", lastName="Jones"},
                    tags=new List<Tag>(){{new Tag() {tagID=0, tagName="Leaves Falling"} }, new Tag() {tagID=1,tagName = "On Track" } },
                    data=new List<Data>(){{new Data() {dataID=0,type="Color", value="Green"} }} }
        };

        public AdminReviewRepository(PhotoDataContext Dbcontext)
        {
            _dbcontext = Dbcontext;
        }
        public Capture DeleteCapture(long captureId)
        {
            var captureToDelete = _dbcontext.Captures.FirstOrDefault(p => p.captureID == captureId);

            if(captureToDelete != null)
            {
                _dbcontext.Captures.Remove(captureToDelete);
            }
            return captureToDelete;
        }

        public IEnumerable<Capture> GetAllUnapproved()
        {
            return _dbcontext.Captures
                .Where(a => a.approval == Capture.ApprovalType.Pending); 
        }

        public Capture GetCapture(long captureId)
        {
            var capture = _dbcontext.Captures.FirstOrDefault(p => p.captureID == captureId);
            return capture;
        }

        public IEnumerable<Capture> GetCaptures()
        {
            var captures = _dbcontext.Captures;
            return captures;
        }

        public void SaveChanges(Capture capt)
        {
            var capture = _dbcontext.Captures.FirstOrDefault(c => c.captureID == capt.captureID);

            if(capture != null)
            {
                capture.approval = capt.approval;
                capture.captureDate = capt.captureDate;
                capture.data = capt.data;
                capture.photo = capt.photo;
                capture.PhotoPoint = capt.PhotoPoint;
                capture.tags = capt.tags;
                capture.user = capt.user;

                _dbcontext.Captures.Update(capture);
            }
            else
            {
                _dbcontext.Captures.Add(capt);
            }
            _dbcontext.SaveChanges();
        }
    }
}
