using Hotel.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.ViewModels;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VmBookingList model = new VmBookingList();
            model.Reservations = _context.Reservations.ToList();
            return View(model);
        }     
    }
}
