using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotNetAcademy.Models;
using dotNetAcademy.ViewModels;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
