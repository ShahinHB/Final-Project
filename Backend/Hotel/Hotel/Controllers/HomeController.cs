using Hotel.Data;
using Hotel.Models;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            VmHome model = new VmHome
            {
                Sub = _context.Subs.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Setting = _context.Settings.FirstOrDefault(),
                AboutApartment = _context.Aboutapartments.FirstOrDefault(),
                Location = _context.Locations.FirstOrDefault(),
                Feedback = _context.Feedbacks.FirstOrDefault()
            };
                     
            return View(model);
        }


       
    }
}
