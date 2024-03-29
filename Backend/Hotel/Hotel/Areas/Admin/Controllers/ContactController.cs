﻿using Hotel.Data;
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
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {
            VmAdminMessageList model = new VmAdminMessageList();
            model.Messages = _context.Messages.Where(a=>a.IsReplied == false).ToList();
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Message message = _context.Messages.Find(id);
            _context.Messages.Remove(message);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Confirm(int id)
        {
            Message mes = _context.Messages.Find(id);
            mes.IsReplied = true;


            _context.Messages.Update(mes);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult ViewMessage(int id)
        {
            return View(_context.Messages.Find(id));
        }
        public IActionResult OldMessages()
        {
            return View(_context.Messages.Where(a => a.IsReplied == true).ToList());
        }
    }
}
