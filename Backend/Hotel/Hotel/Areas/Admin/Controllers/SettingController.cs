using Hotel.Data;
using Hotel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        public SettingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Settings.ToList());
        }
        public IActionResult Update(int id)
        {
            return View(_context.Settings.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Setting model)
        {
            if (ModelState.IsValid)
            {
                _context.Settings.Update(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Null Error");
            return View(model);
        }
    }
}
