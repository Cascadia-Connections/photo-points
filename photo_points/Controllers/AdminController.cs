﻿using System;
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
            return View("PhotoStream", new PhotoStreamViewModel { ApprovedCaptures = _adminReviewServices.GetApprovedCaptures().ToList() });
        }

        [HttpGet]
        public IActionResult DeleteFromPhotoStream(long id)
        {
            //Remove the Photo associated with the given id number; Save Changes
            Capture capture = new Capture { captureID = id };
            _dbc.Captures.Remove(capture);
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
