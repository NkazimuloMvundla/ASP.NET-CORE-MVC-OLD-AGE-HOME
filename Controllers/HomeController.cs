using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Orphanage.Models;
using Orphanage.Infrastructure;
//using Microsoft.AspNetCore.Http.HttpContextAccessor;
using Microsoft.AspNetCore.Http;
namespace Orphanage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private INGORepository repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public HomeController(IHttpContextAccessor context, INGORepository repoService,ILogger<HomeController> logger)
        {
            repository = repoService;
            _logger = logger;
            _httpContextAccessor = context;
        }
     
        public IActionResult Index()
        {
          
                return View();
        
        
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Ageing()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Donation()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Activities()
        {

            return View(repository.HomeEvents);
        }

        [HttpPost]
        public IActionResult Donation(Donation donate)
        {
            if (ModelState.IsValid)
            {
                repository.SaveDonation(donate);
                return View("Thanks", donate);
            }
            else
            {
                return View();
            }
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
