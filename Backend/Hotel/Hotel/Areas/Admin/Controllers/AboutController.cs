using Hotel.Data;
using Hotel.Models;
using Hotel.ViewModels;
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
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            VmAdminAbout model = new VmAdminAbout()
            {
                AboutCities = _context.AboutCities.ToList(),
                AboutGames = _context.AboutGames.ToList(),
                AboutApartment = _context.Aboutapartments.ToList(),
                Locations = _context.Locations.ToList(),
                Feedbacks = _context.Feedbacks.ToList(),
            };
            return View(model);

        }
        //Apartment

        public IActionResult CreateApartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateApartment(AboutApartment model)
        {
            if (ModelState.IsValid)
            {
                _context.Aboutapartments.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Apartment");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }
        public IActionResult UpdateApartment(int id)
        {
            return View(_context.Aboutapartments.Find(id));
        }
        [HttpPost]
        public IActionResult UpdateApartment(AboutApartment model)
        {
            if (ModelState.IsValid)
            {
                _context.Aboutapartments.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index","About");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }

        public IActionResult DeleteApartment(int id)
        {
            AboutApartment model = _context.Aboutapartments.Find(id);
            _context.Aboutapartments.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Apartment");
        }


        //City
       
        public IActionResult CreateCity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCity(AboutCity model)
        {
            if (ModelState.IsValid)
            {
                _context.AboutCities.Add(model);
                _context.SaveChanges();
                return RedirectToAction("City");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }
        public IActionResult UpdateCity(int id)
        {
            return View(_context.AboutCities.Find(id));
        }
        [HttpPost]
        public IActionResult UpdateCity(AboutCity model)
        {
            if (ModelState.IsValid)
            {
                _context.AboutCities.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index","About");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }

        public IActionResult DeleteCity(int id)
        {
            AboutCity model = _context.AboutCities.Find(id);
            _context.AboutCities.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("City");
        }

        //Games
       
        public IActionResult CreateGames()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateGames(AboutGames model)
        {
            if (ModelState.IsValid)
            {
                _context.AboutGames.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "About");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }
        public IActionResult UpdateGames(int id)
        {
            return View(_context.AboutGames.Find(id));
        }
        [HttpPost]
        public IActionResult UpdateGames(AboutGames model)
        {
            if (ModelState.IsValid)
            {
                _context.AboutGames.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "About");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }

        public IActionResult DeleteGames(int id)
        {
            AboutGames model = _context.AboutGames.Find(id);
            _context.AboutGames.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Games");
        }

        //Location
      
        public IActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateLocation(Location model)
        {
            if (ModelState.IsValid)
            {
                _context.Locations.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Location");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }
        public IActionResult UpdateLocation(int id)
        {
            return View(_context.Locations.Find(id));
        }
        [HttpPost]
        public IActionResult UpdateLocation(Location model)
        {
            if (ModelState.IsValid)
            {
                _context.Locations.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "About");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }

        public IActionResult DeleteLocation(int id)
        {
            Location model = _context.Locations.Find(id);
            _context.Locations.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index", "About");
        }


        //Feedback

        public IActionResult CreateFeedback()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFeedback(Feedback model)
        {
            if (ModelState.IsValid)
            {
                _context.Feedbacks.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "About");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }
        public IActionResult UpdateFeedback(int id)
        {
            return View(_context.Feedbacks.Find(id));
        }
        [HttpPost]
        public IActionResult UpdateFeedback(Feedback model)
        {
            if (ModelState.IsValid)
            {
                _context.Feedbacks.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "About");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }

        public IActionResult DeleteFeedback(int id)
        {
            Feedback model = _context.Feedbacks.Find(id);
            _context.Feedbacks.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index", "About");
        }

    }
}
