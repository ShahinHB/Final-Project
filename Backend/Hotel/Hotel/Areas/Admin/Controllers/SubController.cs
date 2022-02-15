using Hotel.Data;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubController : Controller
    {
        private readonly AppDbContext _context;

        public SubController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Subs.ToList());
        }

        [HttpPost]
        public IActionResult Create(Sub model)
        {
            if (ModelState.IsValid)
            {
                _context.Subs.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Apartment");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Sub sub = _context.Subs.Find(id);
            _context.Subs.Remove(sub);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
