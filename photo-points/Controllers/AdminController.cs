using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using photo_points.Models;
using photo_points.Controllers;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace photo_points.Controllers
{
    public class AdminController : Controller
    {


        private PhotoDataContext _pdc;

        public AdminController(PhotoDataContext pdContext)

        {
            _pdc = pdContext;
        }
        // // uncomment above before submission


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



    }
}
