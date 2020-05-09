using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using photo_points.Models;
using photo_points.ViewModels;
using photo_points.Controllers;
using photo_points.Services;
using System.IO;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace photo_points.Controllers
{
    public class AdminController : Controller
    {

        private IAdminReviewServices _adminReviewServices;
        private PhotoDataContext _dbc;

        public AdminController(IAdminReviewServices adminServiceReview, PhotoDataContext dbc)

        {
            _adminReviewServices = adminServiceReview;
            _dbc = dbc;
        }

        ///
        // private Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}


        // GET: /<controller>/

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
                if (_dbc.Users.Any(u => u.email == lvm.UserName && u.password == lvm.Password))
                    return RedirectToAction("WelcomeAdmin");
                else
                    return View();
            else
            {
                ViewBag.LoginIssue = "There is something wrong with you password or email";
                return View();
            }
        }

        [HttpGet]
        public IActionResult WelcomeAdmin()
        {

            return View();

        }


        [HttpGet]
        public IActionResult PhotoStream()
        {
            IQueryable<PhotoPoint> photos = _dbc.PhotoPoints
                .OrderBy(p => p.photoPointID)
                .Take(10);
            return View("PhotoStream", photos);
        }

        [HttpGet]
        public IActionResult DeleteFromPhotoStream(long id)
        {
            //Remove the Photo associated with the given id number; Save Changes
            PhotoPoint photo = new PhotoPoint { photoPointID = id };
            _dbc.PhotoPoints.Remove(photo);
            _dbc.SaveChanges();

            return RedirectToAction("PhotoStream");
        }


        [HttpGet]
        public IActionResult Pending()
        {
            return View("Pending", new PendingViewModel { PendingCaptures = _adminReviewServices.GetUnapprovedCaptures().ToList() });
        }


        [HttpGet]
        public IActionResult SearchPhotoPoints()
        {
            return View("SearchPhotoPoints");
        }

        [HttpGet]
        public IActionResult SearchCaptures()
        {
            return View("SearchPhotoPoints");
        }

        [HttpPost]
        public IActionResult SearchCaptures(SearchViewModel search)
        {
            var ret = _adminReviewServices.GetCaptures().ToList();
            //if (search.photoPointId > 0)   //if searched by photo point id
            //{
            //    //captures = captures.Where(c => c.PhotoPoint.photoPointID == search.photoPointId);
            //    ret = ret.Where(r => r.PhotoPoint.photoPointID == search.photoPointId).ToList();
            //    return View("SearchCapturesResults", ret);
            //}

            //if (search.fromDate != new DateTime())     //if searched by fromDate
            //{
            //    ret = ret.Where(r => r.captureDate >= search.fromDate).ToList();
            //    return View("SearchCapturesResults");
            //}
            //if (search.toDate != new DateTime())      //if searched by toDate
            //{
            //    ret = ret.Where(r => r.captureDate <= search.toDate).ToList();
            //    return View("SearchCapturesResults");
            //}

            //if (search.tagName != null)    //search by tag
            //{
            //    ret = ret.Where(r => r.tags.Select(t => t.tagName)      
            //    .Contains(search.tagName)).ToList();
            //    return View("SearchCapturesResults");
            //}
            //else
            //{
            //    return View("SearchCapturesResults");
            //}

            //return View("SearchCaptures", ret);
            return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = ret });

        }

        //[HttpPost]
        //public IActionResult SearchPhotoPoints(SearchViewModel search)
        //{
        //    //Full Collection Search
        //    IQueryable<Capture> captures = _dbc.Captures;
        //    IQueryable<PhotoPoint> photoPoints = _dbc.PhotoPoints;
        //    IQueryable<Tag> tags = _dbc.Tags;

        //    //photoPointId searched
        //    if (search.photoPointId > 0)
        //    {
        //        //captures = captures.Where(c => c.PhotoPoint.photoPointID == search.photoPointId);
        //        photoPoints = photoPoints.Where(p => p.photoPointID == search.photoPointId);
        //        return View("PhotoStream", photoPoints);
        //    }

        //    // search by tag
        //    if (search.tagName != null)
        //    {
        //        tags = tags.Include(t => t.capture)
        //            .Where(t => t.tagName.Contains(search.tagName));
        //        return View("PhotoStream", tags);
        //    }

        //    //return all photos/captures if no filter was selected
        //    else
        //    {
        //        return View("PhotoStream", photoPoints);
        //    }
        //}

        [HttpGet]
        public IActionResult Collaborators()
        {
            return View("Collaborators");
        }

        [HttpGet]
        public IActionResult Details(long id)
        {
            IEnumerable<Capture> pendingCaptures = _adminReviewServices.GetCaptures();
            Capture pendingCapture = pendingCaptures.First(p => p.captureID == id);
            return View(pendingCapture);
        }

        [HttpPost]
        public JsonResult EditCapture(Capture capture)
        {
            return new JsonResult("{\"id\" : " + capture.captureID + "}");
        }
    }
}
