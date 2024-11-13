using Method_Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Method_Library.Controllers
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

        public IActionResult CSharp()
        {
            return View();
        }
        public IActionResult CPlusPlus()
        {
            return View();
        }
        public IActionResult C()
        {
            return View();
        }
        public IActionResult Python()
        {
            return View();
        }
        public IActionResult Java()
        {
            return View();
        }
        public IActionResult Javascript()
        {
            return View();
        }
        public IActionResult HTML()
        {
            return View();
        }
        public IActionResult CSS()
        {
            return View();
        }
        public IActionResult SQL()
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
