using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using photo_points.Models;
using photo_points.Controllers;
using photo_points.Services; // added from issue #47
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace photo_points.Controllers
{
    public class AdminController : Controller
    {
   
        private IAdminReviewServices _pdc;

        public AdminController(IAdminReviewServices pdContext)

        {
            _pdc = pdContext;
        }

        ///UNComment above block of code before commit


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
            return View("Pending");
            //all the new submissions can be displayed
            // //  if Capture approval is false. 
            // // display the Capture image and Data. 

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
