using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using dotNetAcademy.Models;
using dotNetAcademy.ViewModels;


namespace dotNetAcademy.Controllers
{
    public class HotelsController : Controller
    {
        private readonly WdaContext db;

        public HotelsController(WdaContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Cities"] = db.Room.Select(r => r.City).Distinct();
            ViewData["RoomTypes"] = db.RoomType;

            return View();
        }

        [HttpGet]
        public IActionResult Search(RoomFiltersViewModel filters)
        {
            ViewData["Cities"] = db.Room.Select(r => r.City).Distinct();
            ViewData["RoomTypes"] = db.RoomType;

            if (!ModelState.IsValid)
                return Redirect(Request.Headers["Referer"].ToString());
                //throw new ApplicationException("Invalid Filters");

            var rooms = db.Room
                .Include(room => room.RoomType)
                .Include(r => r.Reviews)
                .Where( room =>
                       ( filters.RoomTypeId == null           || room.RoomTypeId == filters.RoomTypeId    )
                    && ( string.IsNullOrEmpty(filters.City)   || room.City == filters.City                )
                );



            //var rooms = db.Room.Include(room => room.RoomType).AsQueryable();

            //if (!string.IsNullOrEmpty(filters.City))
            //    rooms = rooms.Where(room => room.City == filters.City);

            //if ( filters.RoomTypeId != null )
            //    rooms = rooms.Where(room => room.RoomTypeId == filters.RoomTypeId);

            if (!string.IsNullOrEmpty(filters.CheckIn) && !string.IsNullOrEmpty(filters.CheckOut) && filters.CheckIn.CompareTo(filters.CheckOut) <= 0) {

                var bookings = db.Bookings
                    .Where(booking =>
                       booking.CheckInDate.CompareTo(filters.CheckOut) <= 0 &&
                       filters.CheckIn.CompareTo(booking.CheckOutDate) <= 0);

                rooms = rooms.Where(i => !bookings.Any(b => b.RoomId == i.RoomId));

            }

            SearchViewModel model = new SearchViewModel();
            model.Rooms = rooms.AsEnumerable();

            return View(model);
        }

        [HttpGet]
        public IActionResult Room(int? id)
        {
            Room room = db.Room
                .Include( r => r.RoomType)
                .Include( r => r.Reviews)
                .Where(
                    r => r.RoomId == id
                ).SingleOrDefault();

            //room.Rate = (int) db.Room
            //    .Include(r => r.Reviews).Average(r => r.Rate);

            return View(room);
        }
    }
}