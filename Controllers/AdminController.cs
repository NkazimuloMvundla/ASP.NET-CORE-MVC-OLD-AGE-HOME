using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Orphanage.Models;

namespace Orphanage.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private NGODbContext repository;
        public AdminController(NGODbContext repoService, ILogger<AdminController> logger)
        {
            _logger = logger;
            repository = repoService;
        }
        [Route("/ManageDonations")]
        public IActionResult ManageDonations()
        {

            return View(repository.Donations);
        }
        [Route("/ManageVolunteers")]
        public IActionResult ManageVolunteers()
        {
            return View(repository.Users);
        }
        [Route("/Volunteer")]
        public IActionResult Volunteer()
        {
            return View(repository.HomeEvents);
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Volunteer")]
        public ActionResult Volunteer(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {

                repository.Volunteers.Add(volunteer);
                repository.SaveChanges();
                return View();


            }
            return View();


        }

        [HttpGet]
        [Route("/AddEvent")]
        public IActionResult AddEvent()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/AddEvent")]
        public ActionResult AddEvent(HomeEvent events)
        {
            if (ModelState.IsValid)
            {

                repository.HomeEvents.Add(events);
                repository.SaveChanges();
                return Redirect("/Home/Activities");


            }
            return View();


        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
