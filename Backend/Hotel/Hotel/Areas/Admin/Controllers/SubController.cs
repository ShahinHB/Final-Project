using Hotel.Data;
using Hotel.Models;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class SubController : Controller
    {
        private readonly AppDbContext _context;

        public SubController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Subs.ToList());
        }

        //[HttpPost]
        //public IActionResult CreateSub(VmLayout model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Subs.Add(model.Sub);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index", "Home", new { area = "" });

        //    }
        //    return View(model);
        //}

        public IActionResult Subscribe(string email)
        {
            VmSubscribeResponse response = new VmSubscribeResponse();

            if (string.IsNullOrEmpty(email))
            {
                response.Status = false;
                response.Message = "Subscribtion failed! You must enter your email";
                return Json(response);
            }

            bool isExist = _context.Subs.Any(s => s.MailAddress == email);

            if (isExist)
            {
                response.Status = false;
                response.Message = "Your email have already subscribed!";
                return Json(response);
            }

            Sub subscribe = new Sub();
            subscribe.MailAddress = email;
            subscribe.CreatedDate = DateTime.Now;
            _context.Subs.Add(subscribe);
            _context.SaveChanges();

            response.Status = true;
            response.Message = "Your subscribe successfully!";
            return Json(response);
        }

        public IActionResult DeleteSub(int id)
        {
            Sub sub = _context.Subs.Find(id);
            _context.Subs.Remove(sub);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult SendMailAll()
        {
            return View(_context.Subs.ToList());
        }

        [HttpPost]
        public IActionResult SendMailAll(string MailText)
        {
            List<Sub> subscribes = _context.Subs.ToList();

            foreach (var item in subscribes)
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("apartmentsbookingrio@gmail.com", "Rio Apartments");
                mail.To.Add(item.MailAddress);
                mail.Body = MailText;
                mail.IsBodyHtml = true;
                mail.Subject = "Reklam";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("apartmentsbookingrio@gmail.com", "adidas123456adidas");

                smtpClient.Send(mail);
            }

            return RedirectToAction("Index");
        }
    }
}
