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
                return RedirectToAction("WelcomeAdmin");
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

            return View("PhotoStream");
        }


        [HttpGet]
        public IActionResult Pending()
        {
            //build a view model //
             PendingViewModel pvm = new PendingViewModel();
             pvm.ImageSource = new List<string>();
            
            //start with entire collection
            IEnumerable<Capture> pendingCaptures = _adminReviewServices.GetUnapprovedCaptures();

            //create a foreach loop that goes thru the list and converts bytes to string. 
            foreach (Capture capture in pendingCaptures) 
            {
                string mimeType = "image/jpeg";
                string base64 = Convert.ToBase64String(capture.photo); ////
               // string.Format("fate:{0}; base64,{1}", mimeType, base64);
                pvm.ImageSource.Add(string.Format("data:{0}; base64,{1}", mimeType, base64));
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
