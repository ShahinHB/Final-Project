using Hotel.Data;
using Hotel.Models;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
            VmAdminApartmentList model = new VmAdminApartmentList
            {
                Apartments = _context.Apartments.ToList()
            };

            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Amenity = _context.Amenities.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(VmAdminApartment model)
        {
            if (ModelState.IsValid)
            {

                _context.Apartments.Add(model.Apartment);
                _context.SaveChanges();



                foreach (var item in model.Apartment.ApartmentToAmenityId)
                {
                    ApartmentToAmenity apartmentToAmenity = new ApartmentToAmenity();
                    apartmentToAmenity.AmenityId = item;
                    apartmentToAmenity.ApartmentId = model.Apartment.Id;
                    _context.ApartmentToAmenities.Add(apartmentToAmenity);
                    _context.SaveChanges();
                }


                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }

        public IActionResult Update(int id)
        {
            Apartment apartment = _context.Apartments.FirstOrDefault(i => i.Id == id);
            apartment.ApartmentToAmenityId = _context.ApartmentToAmenities.Where(fr => fr.ApartmentId == id).Select(r => r.AmenityId).ToList();


            ViewBag.Amenity = _context.Amenities.ToList();
            return View(_context.Apartments.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Apartment model)
        {
            if (ModelState.IsValid)
            {

                _context.Apartments.Update(model);
                _context.SaveChanges();

                List<ApartmentToAmenity> restaurantToFeatures = _context.ApartmentToAmenities.Where(fr => fr.ApartmentId == model.Id).ToList();

                foreach (var item in restaurantToFeatures)
                {
                    _context.ApartmentToAmenities.Remove(item);
                }
                _context.SaveChanges();

                foreach (var item in model.ApartmentToAmenityId)
                {
                    ApartmentToAmenity restaurantToFeature = new ApartmentToAmenity();
                    restaurantToFeature.AmenityId = item;
                    restaurantToFeature.ApartmentId = model.Id;
                    _context.ApartmentToAmenities.Add(restaurantToFeature);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);
        }
        public IActionResult CreateImage(int id)
        {
            VmAdminApartmentImage model = new VmAdminApartmentImage
            {
                Apartment = _context.Apartments.FirstOrDefault(a => a.Id == id),
                ApartmentImages = _context.ApartmentImages.Where(i => i.ApartmentId == id).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateImage(VmAdminApartmentImage model)
        {
            if (ModelState.IsValid)
            {
                string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.ApartmentImage.ImageFile.FileName;
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.ApartmentImage.ImageFile.CopyTo(stream);
                }
                model.ApartmentImage.Name = fileName;
                _context.ApartmentImages.Add(model.ApartmentImage);
                _context.SaveChanges();
                return RedirectToAction("Index", "Apartment");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Apartment model = _context.Apartments.Find(id);
            _context.Apartments.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult DeleteImage(int id)
        {
            ApartmentImage model = _context.ApartmentImages.Find(id);
            _context.ApartmentImages.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

