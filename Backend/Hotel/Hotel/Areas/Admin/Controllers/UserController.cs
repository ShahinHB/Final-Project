using Hotel.Data;
using Hotel.Models;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public UserController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            VmAdminUserList model = new VmAdminUserList();
            model.Users = _context.AdminPanelUsers.ToList();
            model.Roles = _context.Roles.ToList();
            model.UserRoles = _context.UserRoles.ToList();
            return View(model);
        }

        public IActionResult CreateUser()
        {
            VmAccount model = new VmAccount();
            ViewBag.Roles = _context.Roles.ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(VmAccount model)
        {
            if (ModelState.IsValid)
            {
                AdminPanelUser newUser = new AdminPanelUser()
                {
                    UserName = model.UserName,
                };
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                    return View(model);
                }
            }
            return View(model);
        }

        public IActionResult UpdateUser(string id)
        {
            VmAccount model = new VmAccount();
            model.User = _context.AdminPanelUsers.Find(id);
            ViewBag.Roles = _context.Roles.ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(VmAccount model)
        {
            if (ModelState.IsValid)
            {
                AdminPanelUser user = _context.AdminPanelUsers.Find(model.User.Id);
                user.UserName = model.User.UserName;

                IdentityUserRole<string> userRole = _context.UserRoles.FirstOrDefault(u => u.UserId == model.User.Id);
                if (userRole != null)
                {
                    string oldRole = _context.Roles.Find(userRole.RoleId).Name;
                    await _userManager.RemoveFromRoleAsync(user, oldRole);
                }

                IdentityRole selectedRole = _context.Roles.Find(model.User.RoleId);

                await _userManager.AddToRoleAsync(user, selectedRole.Name);
                _context.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            return View(model);
        }

    }
}
