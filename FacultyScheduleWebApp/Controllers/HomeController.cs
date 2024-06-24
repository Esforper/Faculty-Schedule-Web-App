using FacultyScheduleWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FacultyScheduleWebApp.Controllers
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
            if (User.Identity.IsAuthenticated)
            {
                // Kullanıcı giriş yapmışsa DashboardController'a yönlendir
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                // Kullanıcı giriş yapmamışsa normal şekilde Index view'sını göster
                return View();
            }
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