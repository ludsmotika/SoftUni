using Introduction_ASP.NETCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Introduction_ASP.NETCore.Controllers
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

            ViewBag.Title = "Home";
            ViewBag.Message = "Hello World!";
            return View();
        }

        public IActionResult About() 
        {
            ViewBag.Message = "This is an ASP.NET core MVC web project!";
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