using Hotel.Data;
using Hotel.Models;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PageController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            VmAdminPageList model = new VmAdminPageList();
            model.Pages = _context.Pages.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VmAdminPage model)
        {
            if (ModelState.IsValid)
            {
                if (model.Page.ImageFile != null )
                {
                    if (model.Page.ImageFile.ContentType == "image/jpeg" || model.Page.ImageFile.ContentType == "image/png")
                    {
                        string fileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fffffff") + model.Page.ImageFile.FileName;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            model.Page.ImageFile.CopyTo(stream);
                        }

                        model.Page.ImageName = fileName;
                        _context.Pages.Add(model.Page);
                        _context.SaveChanges();


                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can upload only .jpeg, .jpg and .png");
                        return View(model);
                    }
                }
                else
                {
                    _context.Pages.Add(model.Page);
                    _context.SaveChanges();
                }
                
                
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }

        public IActionResult Update(int id)
        {
            return View(_context.Pages.Find(id));
        }
        
        [HttpPost]
        public IActionResult Update(Page model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    string fileName = model.Title + DateTime.Now;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }

                    model.ImageName = fileName;
                    _context.Pages.Update(model);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Pages.Update(model);
                    _context.SaveChanges();
                }
                    


                    return RedirectToAction("Index");
                
            }
            ModelState.AddModelError("", "All section is required");
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Page page = _context.Pages.Find(id);
            _context.Pages.Remove(page);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
