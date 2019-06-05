using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using photo_points.Models;
using photo_points.Controllers;
//using photo_points.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace photopoints.Controllers
{
    public class AdminController : Controller
    {



        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PhotoCard()
        {
            return View();
        }

        public IActionResult PhotoStream()
        {
            return View();
        }

    }
}
