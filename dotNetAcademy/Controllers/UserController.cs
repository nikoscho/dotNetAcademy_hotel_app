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
using System.Linq;
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

        [HttpPost, ActionName("Login")]
        public IActionResult SignIn(LoginViewModel model)
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

        [Authorize]
        public IActionResult Profile() {

            string username = User.Identity.Name;

            var useid = this.User.Identity.IsAuthenticated ? int.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier).Value) : -1;

            var rooms = _db.Room
            .Include(t => t.RoomType)
            .Include(r => r.Reviews)
            .Include(b => b.Bookings)
            .AsQueryable();

            var user_bookings = _db.Bookings
                .Where(booking => booking.UserId == useid).AsQueryable();

            rooms = rooms.Where(i => user_bookings.Any(b => b.RoomId == i.RoomId));

            var favorites = _db.Favorites
                .Include(t => t.Room)
                .Where(o => o.UserId == useid);

            var reviews = _db.Reviews
                .Include(t => t.Room)
                .Where(o => o.UserId == useid);

            ProfileViewModel model = new ProfileViewModel {
                Rooms = rooms.AsEnumerable(),
                Reviews = reviews,
                Favorites = favorites,
            };

            return View(model);
        }
    }

}