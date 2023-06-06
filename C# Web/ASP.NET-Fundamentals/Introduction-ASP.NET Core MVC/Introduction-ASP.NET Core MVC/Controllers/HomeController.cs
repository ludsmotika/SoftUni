using Introduction_ASP.NET_Core_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Introduction_ASP.NET_Core_MVC.Controllers
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
            ViewBag.Message = "This message is coming from the ViewBag";
            return View();
        }


        [Route("/Home/Numbers")]
        public IActionResult Numbers1To50()
        {
            return View();
        }


        [HttpGet]
        public IActionResult NumbersToN()
        {
            return View(3);
        }


        [HttpPost]
        public IActionResult NumbersToN(int number)
        {

            if (number <= 0)
            {
                return RedirectToAction("Error");
            }

            return View(number);
        }

        public IActionResult About()
        {
            ViewBag.Message = "This is an ASP.NET Core MVC web application.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}