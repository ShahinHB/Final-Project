using Hotel.Data;
using Hotel.Models;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {

        private readonly AppDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;



        public AccountController(AppDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
               
        [HttpPost]
        public async Task<IActionResult> Login(VmAccount model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is not correct");
                    return View(model);
                }
            }

            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [Authorize(Roles = "SUPERADMIN")]
        public IActionResult Roles()
        {
            VmAdminRolesList model = new VmAdminRolesList();
            model.Roles = _context.Roles.ToList();
            return View(model);
        }

        [Authorize(Roles = "SUPERADMIN")]
        public IActionResult RoleCreate()
        {
            VmAdminRole model = new VmAdminRole();
            return View(model);
        }

        [Authorize(Roles = "SUPERADMIN")]
        [HttpPost]
        public async Task<IActionResult> RoleCreate(VmAdminRole model)
        {
            await _roleManager.CreateAsync(model.Role);
            return RedirectToAction("Roles");
        }

        [Authorize]
        public IActionResult Profile(string id)
        {
            return View(_context.AdminPanelUsers.Find(id));
        }

        [Authorize]
        public IActionResult Edit(string id)
        {
            return View(_context.AdminPanelUsers.Find(id));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(AdminPanelUser model)
        {
            if (ModelState.IsValid)
            {
                AdminPanelUser user = _context.AdminPanelUsers.Find(model.Id);
                user.Name = model.Name;
                user.Address = model.Address;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                _context.SaveChanges();
                return RedirectToAction("Profile", new { id = model.Id });
            }

            return View(model);
        }


        //public IActionResult ProfilePhoto(string id)
        //{
        //    return (_context.AdminPanelUser.Find(id));
        //}

        [HttpPost]
        public IActionResult ProfilePhoto(AdminPanelUser model)
        {
            if (model.ImageFile != null)
            {
                if (ModelState.IsValid)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                    {
                        AdminPanelUser user = _context.AdminPanelUsers.Find(model.Id);
                        string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.ImageFile.FileName;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            model.ImageFile.CopyTo(stream);
                        }
                        model.Image = fileName;
                        user.Image = model.Image;
                        _context.SaveChanges();
                        return RedirectToAction("Profile", new { id = model.Id });
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can only choose .png .jpg and .jpeg format file");
                        return View(model);
                    }
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Profile", new { id = model.Id });
            }

        }

        public async Task<IActionResult> Lock(string id) 
        {
            await _signInManager.SignOutAsync();

            VmAccount user = new VmAccount();
            user.User = _context.AdminPanelUsers.Find(id);
            
            return View(user);
        }
        public IActionResult ChangePassword(string id)
        {
            ChangePasswordViewModel model = new ChangePasswordViewModel();
            model.User = _context.AdminPanelUsers.Find(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                // ChangePasswordAsync changes the user password
                var result = await _userManager.ChangePasswordAsync(user,
                    model.CurrentPassword, model.NewPassword);

                // The new password did not meet the complexity rules or
                // the current password is incorrect. Add these errors to
                // the ModelState and rerender ChangePassword view
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                // Upon successfully changing the password refresh sign-in cookie
                await _signInManager.RefreshSignInAsync(user);
                return View("ChangePasswordConfirmation");
            }

            return View(model);
        }

    }
}
