﻿using Hotel.Data;
using Hotel.ViewModels;
using Hotel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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
                Socials = _context.Socials.ToList(),
                Setting = _context.Settings.FirstOrDefault(),
                Amenities = _context.Amenities.ToList(),
                Apartments = _context.Apartments.ToList(),
                ApartmentImages = _context.ApartmentImages.ToList()
            };
            return View(model);
        }
        public IActionResult Details(int id)
        {
            VmApartmentDetails model = new VmApartmentDetails
            {
                Socials = _context.Socials.ToList(),
                Setting = _context.Settings.FirstOrDefault(),
                Apartment = _context.Apartments.Include(i => i.ApartmentImages).Include(m=>m.ApartmentToAmenities).
                ThenInclude(p=>p.Amenity).Include(i=>i.Reservations).FirstOrDefault(a => a.Id == id)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateHelper(VmApartmentDetails model)
        {
            
            TempData["AdultCount"] = model.Reservation.AdultsCount;
            TempData["KidsCount"] = model.Reservation.KidsCount;
            TempData["StartDate"] = model.Reservation.StartDate;
            TempData["EndDate"] = model.Reservation.EndDate;
            TempData["Title"] = model.Apartment.Title;
            TempData["Apartment"] = model.Reservation.ApartmentId;
            model.DifferDate = (int)((model.Reservation.EndDate - model.Reservation.StartDate).TotalDays);
            TempData["DateDiffer"] = model.DifferDate;
            return RedirectToAction("Checkout");
        }


        [HttpPost]
        public IActionResult Create(VmBooking model)
        {
            if (ModelState.IsValid)
            {
                _context.Reservations.Add(model.Reservation);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }

        public IActionResult Checkout()
        {
            VmBooking model = new VmBooking
            {
                Socials = _context.Socials.ToList(),
                Setting = _context.Settings.FirstOrDefault()                
            };

            return View(model);
        }

        public ActionResult GetReserves(int id)
        {
            return Ok(Json(_context.Reservations.Where(a => a.ApartmentId == id)));
        }

      
    }
}