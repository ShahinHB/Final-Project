using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data;
using Hotel.Models;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            VmAdminHome model = new VmAdminHome
            {
                Reservations = _context.Reservations.ToList()
            };
            return View(model);
        }

        //public IActionResult Chart()
        //{
        //    return Json(Reserves, JsonRequestBehavior.AllowGet);
        //}

        
    }
}
