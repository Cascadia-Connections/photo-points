using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using photo_points.Models;
using photo_points.ViewModels;
using photo_points.Controllers;
using System.IO;
using photo_points.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace photo_points.Controllers
{
    public class AdminController : Controller
    {

        private readonly IAdminReviewRepository _adminReviewRepo;
        private readonly PhotoDataContext _dbc;
        public AdminController(IAdminReviewRepository adminReviewRepo)
        {
            _adminReviewRepo = adminReviewRepo;
        }
        
        // GET: test for capture
        [HttpPost]
        public IActionResult TestCapture()
        {
            var captures = _adminReviewRepo.GetCaptures();
            return Ok(captures);
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }
        /*
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
        */

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
        public IActionResult SearchPhotoPoints()
        {
            return View("SearchPhotoPoints");
        }

        [HttpGet]
        public IActionResult Collaborators()
        {
            return View("Collaborators");
        }

        [HttpPost]
        public JsonResult EditCapture(Capture capture)
        {
            return new JsonResult("{\"id\" : " + capture.captureID + "}");
        }
    }
}
