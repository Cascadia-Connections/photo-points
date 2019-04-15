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


        private PhotoDataContext _pdc;

        public AdminController(PhotoDataContext pdContext)

        {
            _pdc = pdContext;
        }



        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }





        [HttpGet]
        public IActionResult Update(long id)
        {
            User user = _pdc.Users.Single(u => u.UserId == id);
            return View("", user);
        }
    }
}
