using Hotel.Data;
using Hotel.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApartmentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ApartmentController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_context.Apartments.Include(a=>a.ApartmentImages)
                .Include(a=>a.ApartmentToAmenities).ThenInclude(a=>a.Amenity));
        }
        public IActionResult Create()
        {
            ViewBag.Amenity = _context.Amenities.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(ApartmentImage model)
        {
            return View();
        }
    }
}
