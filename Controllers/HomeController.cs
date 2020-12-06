using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using power_classroom.Models;
using System.Globalization;
namespace power_classroom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        public IActionResult AboutUs()
        {
            return View();
        }


        public IActionResult Subscribe()
        {
            return View();
        }

        public IActionResult CaseUpdate()
        {
            var caseViewModel = new CaseViewModel()
            {
                Confirmed = 378343,
                Deceased = 300478,
                Recovered = 12130,
                Date = DateTime.Now.ToString()
            };

            return View(caseViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
