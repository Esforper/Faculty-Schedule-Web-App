using Microsoft.AspNetCore.Mvc;

namespace FacultyScheduleWebApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Database()
        {
            return View();
        }

        public IActionResult CreateSchedule()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
}
