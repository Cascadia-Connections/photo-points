using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using photo_points.Models;
using photo_points.ViewModels;
using photo_points.Services;
using Microsoft.EntityFrameworkCore.Internal;

namespace photo_points.Controllers
{
    public class AdminController : Controller
    {

        private IAdminReviewServices _adminReviewService;
        private PhotoDataContext _dbc;

        public AdminController(IAdminReviewServices adminReviewService, PhotoDataContext dbc)

        {
            _adminReviewService = adminReviewService;
            _dbc = dbc;
        }

        [HttpPost]
        public IActionResult AdminLogout()
        {
            return RedirectToAction("AdminLogin");
        }

        // testing for captures data
        [HttpGet]
        public JsonResult GetCaptures()
        {
            IEnumerable<Capture> captures = _adminReviewService.GetCaptures().ToList();
            return new JsonResult(captures);
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
            var photoPoint = _dbc.PhotoPoints.FirstOrDefault(u => u.photoPointID == id);

            if(photoPoint != null)
                _dbc.PhotoPoints.Remove(photoPoint);
            
            _dbc.SaveChanges();
            return RedirectToAction("PhotoStream");
        }


        [HttpGet]
        public IActionResult Pending()
        {
            return View("Pending", new PendingViewModel
            {
                PendingCaptures = _adminReviewService.GetUnapprovedCaptures().ToList()
            });
        }


        [HttpGet]
        public IActionResult SearchPhotoPoints()
        {
            return View("SearchPhotoPoints");
        }

        [HttpGet]
        public IActionResult Collaborators()
        {
            return View("Collaborators");
        }

        [HttpGet]
        public IActionResult Details(long id)
        {
            IEnumerable<Capture> pendingCaptures = _adminReviewService.GetCaptures();
            Capture pendingCapture = pendingCaptures.First(p => p.captureID == id);
            return View(pendingCapture);
        }

        [HttpPost]
        public JsonResult EditCapture(Capture capture)
        {
            return new JsonResult("{\"id\" : " + capture.captureID + "}");
        }

        // testing capture when saving
        //[HttpPost]
        //public IActionResult SubmitCapture(Capture capture)
        //{
        //    _adminReviewService.ad
        //}

    }
}
