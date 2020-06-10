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


        [HttpPost]
        public IActionResult AdminLogout()
        {
            return RedirectToAction("AdminLogin");
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
                if (_dbc.Users.Any(u => u.Email == lvm.UserName && u.Password == lvm.Password))
                    return RedirectToAction("SearchPhotoPoints");
                else
                {
                    return View();
                }
            else
            {
                ViewBag.LoginIssue = "There is something wrong with you password or email";
                return View();
            }
        }

        //[HttpGet]
        //public IActionResult PhotoStream()
        //{
        //    IQueryable<PhotoPoint> photos = _dbc.PhotoPoints
        //        .OrderBy(p => p.photoPointID)
        //        .Take(10);
        //    return View("PhotoStream", photos);
        //}

        //[HttpGet]
        //public IActionResult DeleteFromPhotoStream(long id)
        //{
        //    //Remove the Photo associated with the given id number; Save Changes
        //    PhotoPoint photo = new PhotoPoint { photoPointID = id };
        //    _dbc.PhotoPoints.Remove(photo);
        //    _dbc.SaveChanges();

        //    return RedirectToAction("PhotoStream");
        //}


        //[HttpGet]
        //public IActionResult Pending()
        //{
        //    return View("Pending", new PendingViewModel { PendingCaptures = _adminReviewServices.GetUnapprovedCaptures().ToList() });
        //}

        [HttpGet]
        public IActionResult SearchPhotoPoints()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchPhotoPoints(SearchViewModel search)
        {
            var capturesPending = _adminReviewServices.GetUnapprovedCaptures().ToList();
            var capturesApproved = _adminReviewServices.GetApprovedCaptures().ToList();
            var results = _adminReviewServices.GetCaptures().ToList();

            if (search.PhotoPointId > 0 && search.PhotoPointId <= results.Count())//if searched by photo point id
            {
                results = results.Where(r => r.PhotoPoint.PhotoPointID == search.PhotoPointId).ToList();
                return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = results });
            }
            if (search.PhotoPointId < 0 || search.PhotoPointId > results.Count())  //if searched by invalid photo point id
            {
                ViewBag.SearchError = "Results not found.";
                return View();
            }

            if (search.FromDate != new DateTime())     //if searched by fromDate
            {
                results = results.Where(r => r.CaptureDate >= search.FromDate).ToList();
                return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = results });
            }
            if (search.ToDate != new DateTime())      //if searched by toDate
            {
                results = results.Where(r => r.CaptureDate <= search.ToDate).ToList();
                return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = results });
            }

            if (search.TagName != null)    //search by tag
            {
                results = results.Where(r => r.Tags.Select(t => t.TagName)
                .Contains(search.TagName)).ToList();
                return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = results });
            }

            //Search for pending captures
            if (search.Approval == SearchViewModel.ApprovalType.Pending)
            {
                if (capturesPending.Count() == 0)
                {
                    ViewBag.SearchError = "Results not found.";
                    return View();
                }
                else
                {
                    return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = capturesPending });
                }
            }
            //search for approved captures. Return results not found if there are no approved captures
            if (search.Approval == SearchViewModel.ApprovalType.Approved)
            {
                if (capturesApproved.Count() == 0)
                {
                    ViewBag.SearchError = "Results not found.";
                    return View();
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
                ViewBag.SearchError = "Results not found.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Collaborators()
        {           
            var users = _dbc.Users;
            return View(users);            
        }

        [HttpGet]
        public IActionResult UserTags(long id)
        {
            _dbc.Tags.Add(new Tag
            {
                TagName = "First flower",
            });
            _dbc.SaveChanges();
            var tag = _dbc.Tags.First();
            var user = _dbc.Users.First(u => u.UserID == id);
            _dbc.UserTags.Update(new UserTag
            {
                UserID = id,
                TagID = tag.TagID
            });

            _dbc.SaveChanges();
            IEnumerable<UserTag> userTags = _dbc.UserTags;
            IEnumerable<UserTag> thisUsersTags = userTags.Where(ut => ut.UserID == id);
            return View("UserTags", userTags);
        }

        [HttpGet]
        public IActionResult Details(long id)
        {
            IEnumerable<Capture> pendingCaptures = _adminReviewServices.GetCaptures();
            Capture pendingCapture = pendingCaptures.First(p => p.CaptureId == id);
            return View(pendingCapture);
        }

        [HttpPost]
        public JsonResult EditCapture(Capture capture)
        {
            return new JsonResult("{\"id\" : " + capture.CaptureId + "}");
        }
    }
}