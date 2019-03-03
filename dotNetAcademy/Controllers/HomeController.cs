using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotNetAcademy.Models;
using dotNetAcademy.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace dotNetAcademy.Controllers
{
    public class HomeController : Controller
    {
        private readonly WdaContext db;

        public HomeController(WdaContext db) {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index() {
            ViewData["Cities"] = db.Room.Select(r => r.City).Distinct();
            ViewData["RoomTypes"] = db.RoomType;

            return View();
        }

        public IActionResult Login() {
            return View();
        }

        public IActionResult Profile() {

            var rooms = db.Room
                .Include(t => t.RoomType)
                .Include(r => r.Reviews)
                .Include(b => b.Bookings)
                .AsQueryable();

            var user_bookings = db.Bookings
                .Where(booking => booking.UserId == 1).AsQueryable();

            rooms = rooms.Where(i => user_bookings.Any(b => b.RoomId == i.RoomId));

            var favorites = db.Favorites
                .Include(t => t.Room)
                .Where( o => o.UserId == 1);

            var reviews = db.Reviews
                .Include(t => t.Room)
                .Where(o => o.UserId == 1);

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
