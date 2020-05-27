﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using photo_points.Models;
using photo_points.Services;
using photo_points.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
                if (_dbc.Users.Any(u => u.Email == lvm.UserName && u.Password == lvm.Password))
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
                .OrderBy(p => p.PhotoPointID)
                .Take(10);
            return View("PhotoStream", photos);
        }

        [HttpGet]
        public IActionResult DeleteFromPhotoStream(long id)
        {
            var photoPoint = _dbc.PhotoPoints.FirstOrDefault(u => u.PhotoPointID == id);

            if (photoPoint != null)
                _dbc.PhotoPoints.Remove(photoPoint);

            _dbc.SaveChanges();
            return RedirectToAction("PhotoStream");
        }

        [HttpGet]
        public IActionResult Pending()
        {
            // get list of pending models
            var pendingModels = _adminReviewService
                .GetCapturesWithPhotoPointByApprovalStatus(ApprovalStatus.Pending);

            var pendingViewModel = new PendingViewModel
            {
                PendingCaptures = pendingModels.ToList()
            };

            return View("Pending", pendingViewModel);
        }

        [HttpGet]
        public IActionResult SearchCaptures()
        {
            return View("SearchPhotoPoints");
        }

        [HttpPost]
        public IActionResult SearchCaptures(SearchViewModel search)
        {
            var capturesPending = _adminReviewService.GetUnapprovedCaptures().ToList();
            var capturesApproved = _adminReviewService.GetApprovedCaptures().ToList();
            var results = _adminReviewService.GetCaptures().ToList();

            if (search.PhotoPointId > 0 && search.PhotoPointId <= results.Count())//if searched by photo point id
            {
                results = results.Where(r => r.PhotoPoint.PhotoPointID == search.PhotoPointId).ToList();
                return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = results });
            }
            if (search.PhotoPointId < 0 || search.PhotoPointId > results.Count())  //if searched by invalid photo point id
            {
                return View("SearchCapturesResultsNotFound");
            }

            if (search.FromDate != new DateTime())     //if searched by fromDate
            {
                results = results.Where(r => r.CaptureDate >= search.FromDate).ToList();
                return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = results });
            }
            if (search.ToDate != new DateTime())      //if searched by toDate
            {
                results = results.Where(r => r.CaptureDate <= search.ToDate).ToList();
                return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = results });
            }

            if (search.TagName != null)    //search by tag
            {
                results = results.Where(r => r.Tags.Select(t => t.TagName)
                .Contains(search.TagName)).ToList();
                return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = results });
            }

            //Search for pending captures
            if (search.Approval == SearchViewModel.ApprovalType.Pending)
            {
                if (capturesPending.Count() == 0)
                {
                    return View("SearchCapturesResultsNotFound");
                }
                else
                {
                    return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = capturesPending });
                }
            }
            //search for approved captures. Return results not found if there are no approved captures
            if (search.Approval == SearchViewModel.ApprovalType.Approved)
            {
                if (capturesApproved.Count() == 0)
                {
                    return View("SearchCapturesResultsNotFound");
                }
                else
                {
                    return View("SearchCapturesResults", new SearchViewModel { SearchCaptures = capturesApproved });
                }
            }

            //if (search.approval != SearchViewModel.ApprovalType.Pending || search.approval != SearchViewModel.ApprovalType.Approved)
            //{
            //    return View("SearchCapturesResultsNotFound");
            //}
            else
            {
                return View("SearchCapturesResultsNotFound");
            }
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
            Capture pendingCapture = pendingCaptures.First(p => p.CaptureId == id);
            return View(pendingCapture);
        }

        [HttpPost]
        public JsonResult EditCapture(Capture capture)
        {
            return new JsonResult("{\"id\" : " + capture.CaptureId + "}");
        }

        // testing capture when saving
        //[HttpPost]
        //public IActionResult SubmitCapture(Capture capture)
        //{
        //    _adminReviewService.ad
        //}
    }
}