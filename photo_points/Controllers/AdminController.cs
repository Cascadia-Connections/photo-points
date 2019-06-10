﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using photo_points.Models;
using photo_points.ViewModels;
using photo_points.Controllers;
using photo_points.Services; // added from issue #47
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace photo_points.Controllers
{
    public class AdminController : Controller
    {
   
        private IAdminReviewServices _adminReviewServices;

        public AdminController(IAdminReviewServices adminServiceReview)

        {
            _adminReviewServices = adminServiceReview;
        }

        ///UNComment above block of code before commit
        ///
        // private Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}


        // GET: /<controller>/
        [HttpGet]
        public IActionResult WelcomeAdmin()
        {
            if (ModelState.IsValid)
            {
                return View("WelcomeAdmin");
            }
            return View();
        }


        [HttpGet]
        public IActionResult PhotoStream()
        {

            return View("PhotoStream");
        }


        [HttpGet]
        public IActionResult Pending()
        {
            //build a view model //
             PendingViewModel pvm = new PendingViewModel();
            
            //start with entire collection
            IEnumerable<Capture> pendingCaptures = _adminReviewServices.GetUnapprovedCaptures();

            //create a foreach loop that goes thru the list and converts bytes to string. 
            foreach (Capture capture in pendingCaptures) // looking at comments on line 18 and 23 in Capture.cs // should we display all images since they are the default?
            {
                string mimeType = "images/jpeg";
                string base64 = Convert.ToBase64String(capture.photo); ////
                string.Format("fate:{0}; base64,{1}", mimeType, base64);
                pvm.ImageSource.Add(string.Format("fate:{0}; base64,{1}", mimeType, base64));
            }
            return View("Pending", pvm);
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


    }
}