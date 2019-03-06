using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotNetAcademy.Models;
using dotNetAcademy.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace dotNetAcademy.Controllers
{
    public class HomeController : Controller
    {
        private readonly WdaContext _db;
        private readonly SignInManager<User> _signInManager;

        public HomeController(WdaContext db, SignInManager<User> signInManager) {
            this._db = db;
            this._signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index() {
            ViewData["Cities"] = _db.Room.Select(r => r.City).Distinct();
            ViewData["RoomTypes"] = _db.RoomType;

            return View();
        }

        public IActionResult Login() {
            return View();
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
                .Where( o => o.UserId == useid);

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
