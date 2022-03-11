using Hotel.Data;
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
using System.Net.Mail;
using System.Net;
using System.Globalization;

namespace Hotel.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly AppDbContext _context;

        
        public ApartmentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(VmSearch search)
        {
            VmApartment model = new VmApartment
            {
                Socials = _context.Socials.ToList(),
                Setting = _context.Settings.FirstOrDefault(),
                Amenities = _context.Amenities.ToList(),
                Apartments = _context.Apartments.Include(ap => ap.ApartmentImages).Include(a => a.ApartmentToAmenities)
                .ThenInclude(b => b.Amenity).ToList(),
                //Apartments = _context.Reservations.Where(r => r.StartDate < search.startDate).Select(a=>a.Apartment).ToList()
            };
            return View(model);
        }
        public IActionResult Details(int id)
        {
            VmApartmentDetails model = new VmApartmentDetails
            {
                Socials = _context.Socials.ToList(),
                Setting = _context.Settings.FirstOrDefault(),
                Apartment = _context.Apartments.Include(i => i.ApartmentImages).Include(m => m.ApartmentToAmenities).
                ThenInclude(p => p.Amenity).Include(i => i.Reservations).FirstOrDefault(a => a.Id == id)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateHelper(VmApartmentDetails model)
        {
            bool check = true;
            if (model.Reservation.StartDate != null && model.Reservation.EndDate != null /*&& (model.Reservation.KidsCount + model.Reservation.AdultsCount) > 0 && (model.Reservation.KidsCount + model.Reservation.AdultsCount < model.Apartment.Limit)*/)
            {
                foreach (var b in _context.Reservations.Where(r=>r.Id == model.Reservation.ApartmentId))
                {
                    if ((b.StartDate < model.Reservation.StartDate && model.Reservation.StartDate < b.EndDate) || (b.StartDate > model.Reservation.StartDate && b.StartDate < model.Reservation.EndDate) || (b.EndDate > model.Reservation.StartDate && model.Reservation.EndDate > b.EndDate) || (b.StartDate < model.Reservation.EndDate && model.Reservation.EndDate < b.EndDate) || (b.StartDate < model.Reservation.StartDate && model.Reservation.EndDate < b.EndDate))
                    {
                        check = false;
                    }
                }
                if (check)
                {
                    TempData["AdultCount"] = model.Reservation.AdultsCount;
                    TempData["KidsCount"] = model.Reservation.KidsCount;
                    TempData["StartDate"] = model.Reservation.StartDate;
                    TempData["EndDate"] = model.Reservation.EndDate;
                    TempData["Title"] = model.Apartment.Title;
                    TempData["Apartment"] = model.Reservation.ApartmentId;
                    model.DifferDate = (int)((model.Reservation.EndDate - model.Reservation.StartDate).TotalDays);
                    TempData["DateDiffer"] = model.DifferDate;
                    TempData["Amount"] = (int)model.DifferDate * (int)model.Apartment.Price;
                    return RedirectToAction("Checkout");
                }
                else
                {
                    TempData["Error"] = "Some day(s) reserved please choose again";
                    return RedirectToAction("Details", "Apartment", new { id = model.Reservation.ApartmentId });
                }
            }
            else
            {
                TempData["Error"] = "Don't hack the system :)";
                return RedirectToAction("Details", "Apartment", new { id = model.Reservation.ApartmentId });
            }

        }


        [HttpPost]
        public IActionResult Create(VmBooking model)
        {
            if (model.Reservation.Email !=null && model.Reservation.Phone != null) 
            {
                if (ModelState.IsValid)
                {

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("apartmentsbookingrio@gmail.com", "Rio Apartments");
                    mail.To.Add(model.Reservation.Email);
                    mail.Body = "<p> Congratulations </p>";
                    mail.IsBodyHtml = true;
                    mail.Subject = "Successfull Reservation";

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("apartmentsbookingrio@gmail.com", "adidas123456adidas");

                    smtpClient.Send(mail);

                    CultureInfo provider = CultureInfo.InvariantCulture;

                    
                    model.Reservation.CreatedDate = DateTime.Now;
                    model.Reservation.Tax = 0.21 * model.Reservation.Amount;
                    model.Reservation.TotalAmount = model.Reservation.Amount + model.Reservation.Tax;
                    _context.Reservations.Add(model.Reservation);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Checkout", "Apartment");
                }

            }
            else
            {
                TempData["AdultCount"] = model.Reservation.AdultsCount;
                TempData["KidsCount"] = model.Reservation.KidsCount;
                TempData["StartDate"] = model.Reservation.StartDate;
                TempData["EndDate"] = model.Reservation.EndDate;
                TempData["Apartment"] = model.Reservation.ApartmentId;
                TempData["DateDiffer"] = (int)((model.Reservation.EndDate - model.Reservation.StartDate).TotalDays);
                TempData["Amount"] = model.Reservation.Amount;
                TempData["Error"] = "All Section is required";
                return RedirectToAction("Checkout", "Apartment");
            }


        }

        public IActionResult Checkout()
        {
            if (TempData["AdultCount"] != null && TempData["EndDate"] != null && TempData["Apartment"] != null && ((int)TempData["KidsCount"] +  (int)TempData["AdultCount"]) > 1)
            {
                VmBooking model = new VmBooking
                {
                    Socials = _context.Socials.ToList(),
                    Setting = _context.Settings.FirstOrDefault()
                };
                return View(model);
            }
            else
            {
                return RedirectToAction("Error404","Account", new { Area = "Admin" });
            }



        }

        public ActionResult GetReserves(int id)
        {
            return Ok(Json(_context.Reservations.Where(a => a.ApartmentId == id)));
        }


    }
}



