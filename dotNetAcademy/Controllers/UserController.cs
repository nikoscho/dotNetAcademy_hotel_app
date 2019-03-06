using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using dotNetAcademy.Models;
using dotNetAcademy.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


namespace dotNetAcademy.Controllers
{
    public class UserController : Controller
    {
        private readonly WdaContext _db;
        private readonly SignInManager<User> _signInManager;

        public UserController(WdaContext db, SignInManager<User> signInManager) {
            this._db = db;
            this._signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid) {

                var result = _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false).Result;

                if (result.Succeeded) {
                    return RedirectToAction("Profile", "User");
                } else {
                    return RedirectToAction("Index", "Home");
                }

            }

            ModelState.AddModelError("", "Invalid login attempt");

            return View(model);
        }

        [HttpGet]
        public IActionResult Logout() { 

            if (ModelState.IsValid) {
                var result = _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Profile() {

            string username = User.Identity.Name;

            var useid = this.User.Identity.IsAuthenticated ? int.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier).Value) : -1;

            var user = _db.User
                .Include(r => r.Reviews)
                    .ThenInclude(r => r.Room)
                .Include(r => r.Favorites)
                    .ThenInclude(r => r.Room)
                .Include(b => b.Bookings)
                    .ThenInclude(r => r.Room)
                        .ThenInclude(t => t.RoomType)
                .Where(o => o.UserId == useid).SingleOrDefault();

            return View(user);
        }
    }

}