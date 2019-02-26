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

        [HttpGet]
        public IActionResult Index()
        {
            return View(new { City = db.Room.Select(o => o.City).Distinct().ToList() } );
        }

        [HttpGet]
        public IActionResult Search(string city, string checkin, string checkout, int? persons = 0, int? minprice = 0, int? maxprice = 0)
        {

            IEnumerable<RoomExtended> rooms = null;

            //rooms = (from c in db.Room
            //         join u in db.RoomType on c.RoomType equals u.Id
            //         select new RoomExtended {
            //             Room = c,
            //             Type = u
            //         }
            //    );

            rooms = db.Room
                .Join( db.RoomType,
                    room => room.RoomType,
                    type => type.Id,
                    (room, type) =>
                         new RoomExtended {
                             Room = room,
                             Type = type
                         }
                )
                .Where( 
                    room =>
                        persons <= room.Room.CountOfGuests
                        && (string.IsNullOrEmpty(city) || room.Room.City == city)
                );

            //rooms = rooms
            //    .Join( 
            //        db.Reviews.GroupBy(review => review.RoomId).Select(review => new { ReviewRoomId = review.Key, AverageRate = review.Min(r => r.Rate)}),
            //        room => room.Room.RoomId,
            //        review => review?.ReviewRoomId,
            //        (room, review) =>
            //             new RoomExtended {
            //                 Room = room.Room,
            //                 Type = room.Type,
            //                 Rate = review?.AverageRate
            //             }
            //    );

            return View(rooms);
        }

        [HttpGet]
        public IActionResult Room(int? id)
        {
            RoomExtended room = null;

            room = db.Room
                .Join(db.RoomType,
                    roomobj => roomobj.RoomType,
                    type => type.Id,
                    (roomobj, type) =>
                         new RoomExtended {
                             Room = roomobj,
                             Type = type
                         }
                )
                .Where(
                    roomobj => roomobj.Room.RoomId == id
                ).SingleOrDefault();

            var rate = db.Reviews
                .Where(
                    review => review.RoomId == id
                ).GroupBy(review => review.RoomId)
                .Select(review => new
                {
                    AverageRate = review.Min( r => r.Rate)
                }).SingleOrDefault();

            Console.WriteLine("--- rate", rate);
            return View(room);
        }
    }
}