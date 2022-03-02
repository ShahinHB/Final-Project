using Hotel.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.ViewModels;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Reservations.Include(a=>a.Apartment).ToList());
        }

        public IActionResult Detail(int id)
        {
            return View(_context.Reservations.Include(a => a.Apartment).FirstOrDefault(r=>r.Id == id));
        }

        public IActionResult Delete(int id)
        {
            Reservation model = _context.Reservations.Find(id);
            _context.Reservations.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Confirm(int id)
        {
            Reservation res = _context.Reservations.Find(id);
            res.IsActive = true;
            _context.Reservations.Update(res);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
