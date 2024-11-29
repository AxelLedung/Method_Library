using Method_Library.Data;
using Method_Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Method_Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;

        }

        public IActionResult Index()
        {
            var languages = _context.Languages
            .ToList();

            return View(languages);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
