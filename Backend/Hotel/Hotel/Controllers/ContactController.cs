using Hotel.Data;
using Hotel.Models;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VmContact model = new VmContact
            {
                Socials = _context.Socials.ToList(),
                Setting = _context.Settings.FirstOrDefault(),
            };

            return View(model);
        }


        //[HttpPost]
        //public IActionResult CreateMessage(Message message)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Messages.Add(message);
        //        _context.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}

        public IActionResult CreateMessage(string email, string content, string name)
        {
            VmContactResponse response = new VmContactResponse();


            if (email != null && content != null && name != null)
            {
                Message message = new Message();
                message.Content = content;
                message.Email = email;
                message.Name = name;
                _context.Messages.Add(message);
                _context.SaveChanges();
                response.Status = true;
                response.Message = "Your message send successfully!";
            }
            else
            {
                response.Status = false;
                response.Message = "Your email have already subscribed!";
            }
            return Json(response);

        }

    }
}
