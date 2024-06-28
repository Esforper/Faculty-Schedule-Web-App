﻿using Microsoft.AspNetCore.Mvc;
using FacultyScheduleWebApp.Data;
using FacultyScheduleWebApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public IActionResult Academicians(Guid id)
        {
            var academians = _context.Academians.Where(a => a.WorkspaceID == id).ToList();
            ViewBag.WorkspaceId = id;
            return View(academians);
        }

        public IActionResult AddAcademian(Guid workspaceId)
        {
            ViewBag.WorkspaceId = workspaceId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAcademian(AcademianClass academian, string lessonCodesJson, string availableDatesJson)
        {
            if (!ModelState.IsValid)
            {
                // ModelState'teki hataları kontrol et
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                ViewBag.WorkspaceId = academian.WorkspaceID;
                return View(academian);
            }

            academian.Id = Guid.NewGuid();

            if (!string.IsNullOrEmpty(lessonCodesJson))
            {
                academian.LessonCodes = JsonConvert.DeserializeObject<List<string>>(lessonCodesJson);
            }

            if (!string.IsNullOrEmpty(availableDatesJson))
            {
                academian.AvaibleDates = JsonConvert.DeserializeObject<int[]>(availableDatesJson);
            }

            _context.Academians.Add(academian);
            await _context.SaveChangesAsync();
            return RedirectToAction("Academicians", new { id = academian.WorkspaceID });
        }


    }
}
