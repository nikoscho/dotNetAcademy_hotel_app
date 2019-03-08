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
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using dotNetAcademy.Extensions;

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


            //ViewData["ModelState"] = TempData.Get<ModelStateDictionary>("ModelState");
            if ( TempData["ViewData"] != null )
                ViewData = TempData.Get<ViewDataDictionary>("ViewData");

            //RoomFiltersModel model = TempData["RoomFilters"] as RoomFiltersModel;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
