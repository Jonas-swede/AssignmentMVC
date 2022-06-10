using Assignment_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_MVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment_MVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager, ApplicationDbContext context,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            UserViewModel model = new UserViewModel();
            var allUsers = _userManager.Users.Select(u => new { u.Id, u.UserName,u.FirstName,u.LastName}).ToList();
            model.Roles = _context.Set<IdentityRole>().ToList();
            foreach(var item in allUsers)
            {
                UserSelected user = new UserSelected();
                user.Id = item.Id;
                user.UserName = item.UserName;
                user.Roles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(item.Id));
                user.FirstName = item.FirstName;
                user.LastName = item.LastName;
                model.Users.Add(user);
            }
            ViewData["Roles"] = new SelectList(model.Roles,"Name","Name");
            return View(model);
        }

        public async Task<IActionResult> AddRole(UserViewModel input)
        {
            var user = await _userManager.FindByIdAsync(input.UserId);
            await _userManager.AddToRoleAsync(user, input.NewRole);
            return RedirectToAction("Index");
        }
    }
}
