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
    public class AmenityController : Controller
    {
        private readonly AppDbContext _context;

        public AmenityController(AppDbContext context)
        {
            _context = context;            
        }
        public IActionResult Index()
        {
            return View(_context.Amenities.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Amenity model)
        {
            if (ModelState.IsValid)
            {
                _context.Amenities.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }
        public IActionResult Update(int id)
        {
            return View(_context.Amenities.Find(id));
        } 
        [HttpPost]
        public IActionResult Update(Amenity model)
        {
            if (ModelState.IsValid)
            {
                _context.Amenities.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }

        public IActionResult Delete( int id)
        {
            Amenity amenity = _context.Amenities.Find(id);
            _context.Amenities.Remove(amenity);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
