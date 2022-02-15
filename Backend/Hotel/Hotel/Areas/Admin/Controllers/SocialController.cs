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
    public class SocialController : Controller
    {
        private readonly AppDbContext _context;

        public SocialController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Socials.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Social model)
        {
            if (ModelState.IsValid)
            {
                _context.Socials.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }
        public IActionResult Update(int id)
        {
            return View(_context.Socials.Find(id));
        }
        [HttpPost]
        public IActionResult Update(Social model)
        {
            if (ModelState.IsValid)
            {
                _context.Socials.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Social social = _context.Socials.Find(id);
            _context.Socials.Remove(social);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
