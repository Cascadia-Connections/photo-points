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
            var capturesPending = _adminReviewServices.GetUnapprovedCaptures().ToList();
            var capturesApproved = _adminReviewServices.GetApprovedCaptures().ToList();
            var results = _adminReviewServices.GetCaptures().ToList();
            if (search.photoPointId > 0 && search.photoPointId <= results.Count())//if searched by photo point id
            {
                results = results.Where(r => r.PhotoPoint.photoPointID == search.photoPointId).ToList();
                return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = results });
            }
            if (search.fromDate != new DateTime())     //if searched by fromDate
            {
                results = results.Where(r => r.captureDate >= search.fromDate).ToList();
                return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = results });
            }
            if (search.toDate != new DateTime())      //if searched by toDate
            {
                results = results.Where(r => r.captureDate <= search.toDate).ToList();
                return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = results });
            }

            if (search.tagName != null)    //search by tag
            {
                results = results.Where(r => r.tags.Select(t => t.tagName)
                .Contains(search.tagName)).ToList();
                return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = results });
            }

            //Search for pending captures
            if(search.approval == SearchViewModel.ApprovalType.Pending)
            {
                if (capturesPending.Count() == 0)
                {
                    return View("SearchCapturesResultsNotFound");
                }
                else
                {
                    return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = capturesPending });
                }
            }
            //search for approved captures. Return results not found if there are no approved captures
            if (search.approval == SearchViewModel.ApprovalType.Approved)
            {
                if (capturesApproved.Count() == 0)
                {
                    return View("SearchCapturesResultsNotFound");
                }
                else
                {
                    return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = capturesApproved });
                }
            }

            //if (search.approval != SearchViewModel.ApprovalType.Pending || search.approval != SearchViewModel.ApprovalType.Approved)
            //{
            //    return View("SearchCapturesResultsNotFound");
            //}

            else
            {
                return View("SearchCapturesResultsNotFound");
            }

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
