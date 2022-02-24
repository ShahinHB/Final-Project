using Hotel.Data;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly AppDbContext _context;

        public ApartmentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VmApartment model = new VmApartment
            {
                Sub = _context.Subs.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Setting = _context.Settings.FirstOrDefault(),
                Amenities = _context.Amenities.ToList(),
                Apartments = _context.Apartments.ToList(),
                ApartmentImages = _context.ApartmentImages.ToList()
            };
            return View(model);
        }
    }
}
