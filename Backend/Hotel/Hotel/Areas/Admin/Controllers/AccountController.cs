using Hotel.Data;
using Hotel.Models;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        public AccountController(AppDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult AccessDenied()
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
                _context.AdminPanelUsers.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Profile", new { id = model.Id });
            }

            return View(model);
        }
    }
}
