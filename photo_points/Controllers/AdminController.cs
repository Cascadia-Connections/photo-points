using System;
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
            //build a view model 

            PendingViewModel pvm = new PendingViewModel();

            _adminReviewServices.GetUnapprovedCaptures(); 

            //create a foreach loop that goes thru the list and pulls out images that have NOT been approved. 
           

            //if()
            //{
                return View("Pending");

            //}


            //return View("Pending");
            //all the new submissions can be displayed
            // //  if Capture approval is false. 
            // // display the Capture image and Data. 



            //foreach(photo_points.Models.Capture approve in @Models)
            //    {
            //    if (approve == false)
            //    {
            //        //Card list html will go here

            // // Below 3 lines of code are from Brian 

                    //string mimeType = /* Get mime type somehow (e.g. "image/png") */;
                    //string base64 = Convert.ToBase64String(yourImageBytes);
                    //return string.Format("data:{0};base64,{1}", mimeType, base64); 

            //    }

            //}
            //foreach (approved in IEnumerable) 

        }

        [HttpGet]
        public IActionResult newView()
        {
            return View("newView");

        }


        // // // below can be deleted?
        //[HttpGet]
        //public IActionResult Update(long id)
        //{
        //    User user = _pdc.Users.Single(u => u.UserId == id);
        //    return View("WelcomeAdmin", user);
        //}


        //to add the picture//from Sara
        //public Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}
    }
}
