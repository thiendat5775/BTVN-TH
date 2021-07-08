using BTVN_TH.Models;
using BTVN_TH.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTVN_TH.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext(); 
        }
        [Authorize]
       public ActionResult Create()
        {
           var viewModel = new CourseViewModel
           {
               Categories = _dbContext.Categories.ToList()

            };
           return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        // GET: Courses
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
               LectureId = User.Identity.GetUserId(),
               DateTime = viewModel.GetDateTime(),
               CatelogyId=viewModel.Category,
               Place = viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}