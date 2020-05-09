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
        public IActionResult SearchCaptures()
        {
            return View("SearchPhotoPoints");
        }

        [HttpPost]
        public IActionResult SearchCaptures(SearchViewModel search)
        {
            var results = _adminReviewServices.GetCaptures().ToList();
            if (search.photoPointId > 0)   //if searched by photo point id
            {
                results = results.Where(r => r.PhotoPoint.photoPointID == search.photoPointId).ToList();
            }

            if (search.fromDate != new DateTime())     //if searched by fromDate
            {
                results = results.Where(r => r.captureDate >= search.fromDate).ToList();
            }
            if (search.toDate != new DateTime())      //if searched by toDate
            {
                results = results.Where(r => r.captureDate <= search.toDate).ToList();
            }

            if (search.tagName != null)    //search by tag
            {
                results = results.Where(r => r.tags.Select(t => t.tagName)
                .Contains(search.tagName)).ToList();
            }
            
            //return results based on the search filters.
            return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = results });

        }

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
