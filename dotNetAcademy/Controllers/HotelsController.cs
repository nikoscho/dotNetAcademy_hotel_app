using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using dotNetAcademy.Models;


namespace dotNetAcademy.Controllers
{
    public class HotelsController : Controller
    {
        private readonly WdaContext db;

        public HotelsController(WdaContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string city, string checkin, string checkout, int? persons = 0)
        {

            //var person = db.Room
            //    .Join(db.RoomType,
            //          p => p.RoomType,
            //          e => e.Id,
            //          (p, e) => new {
            //              RoomType = e.Id
            //          }
            //          ).Take(5);

            //return View(person);


            return View(
                db.Room
                    .Where(room =>
                        persons <= room.CountOfGuests
                        && ( string.IsNullOrEmpty(city) || room.City == city )
                    )
            );




        }

        public IActionResult Room(int? id)
        {
            //return View(db.Room.Where(room => room.City == "Athens"));

            //ViewBag.somevariable = "eeee";
            //ViewBag.someid = id;
            //return View();

            //if (id == null)
            //{
                //return new System.Web.HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //}

            Room room = db.Room.SingleOrDefault(Room => Room.RoomId == id);

            //if (room == null)
            //{
                //return HttpNotFound();
            //}

            return View(room);

        }

    }
}