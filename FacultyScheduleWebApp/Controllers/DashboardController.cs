using Microsoft.AspNetCore.Mvc;
using FacultyScheduleWebApp.Data;
using FacultyScheduleWebApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyScheduleWebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Database()
        {
            var spaces = _context.Spaces.ToList();
            return View(spaces);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpace(Workspace space)
        {
            if (ModelState.IsValid)
            {
                space.Id = Guid.NewGuid(); // Rastgele GUID oluştur
                _context.Spaces.Add(space);
                await _context.SaveChangesAsync();
                return RedirectToAction("Database");
            }
            return View("CreateSchedule", space);
        }

        public IActionResult Settings()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSpace(Guid id, string confirmName)
        {
            var space = await _context.Spaces.FindAsync(id);
            if (space == null)
            {
                return NotFound();
            }

            if (space.Name == confirmName)
            {
                _context.Spaces.Remove(space);
                await _context.SaveChangesAsync();
                return RedirectToAction("Database");
            }

            ModelState.AddModelError("", "Space name does not match.");
            return View("SpaceDetails", space);
        }

        public IActionResult SpaceDetails(Guid id)
        {
            var space = _context.Spaces.FirstOrDefault(s => s.Id == id);
            if (space == null)
            {
                return NotFound();
            }
            return View(space);
        }
    }
}
