﻿using System;
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
        public IActionResult Search(RoomFiltersModel filters)
        {
            ViewData["Cities"] = db.Room.Select(r => r.City).Distinct();
            ViewData["RoomTypes"] = db.RoomType;

            if (!ModelState.IsValid)
                return Redirect(Request.Headers["Referer"].ToString());
                //throw new ApplicationException("Invalid Filters");

            var rooms = db.Room
                .Include( t => t.RoomType)
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

            SearchViewModel model = new SearchViewModel {
                Rooms = rooms.AsEnumerable(),
                FilterModel = new RoomFiltersModel {
                        CheckIn = filters.CheckIn,
                        CheckOut = filters.CheckOut
                },
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Room(int id, BookingFormModel booking)
        {
            ViewData["RoomId"] = id;

            Room room = db.Room
                .Include( r => r.RoomType )
                .Include( r => r.Reviews )
                .Include( b => b.Bookings )
                .Where(
                    r => r.RoomId == id
                ).SingleOrDefault();

            var bookings = db.Bookings.Where(b =>
                b.CheckInDate.CompareTo(booking.CheckOut) <= 0 &&
                booking.CheckIn.CompareTo(b.CheckOutDate) <= 0 &&
                b.RoomId == id);

            RoomViewModel model = new RoomViewModel {
                Room = room,
                ReviewForm = new ReviewFormModel(),
                BookingForm = booking,
                ShowBookingButton = !string.IsNullOrEmpty(booking.CheckIn) && !string.IsNullOrEmpty(booking.CheckOut),
                IsAvailable = !bookings.Any()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult SubmitReview(int id, ReviewFormModel review) {

            Reviews review_obj = new Reviews {
                RoomId = id,
                Rate = review.Rate,
                Text = review.Text,
                UserId = 1
            };

            db.Reviews.Add(review_obj);
            db.SaveChanges();

            return RedirectToAction("Room", "Hotels", new { id });
        }

        [HttpPost]
        public IActionResult ToggleFavorite(int id, ToggleFavoriteForm favoriteform) {

            try {
                var favorite = db.Favorites.FirstOrDefault(fav => fav.RoomId == id && fav.UserId == favoriteform.UserId);

                if (favorite == null) {
                    db.Favorites.Add(new Favorites {
                        RoomId = id,
                        UserId = favoriteform.UserId,
                        Status = 1,
                        DateCreated = DateTime.Now,
                    });
                    db.SaveChanges();
                } else {
                    db.Favorites.Remove(favorite);
                    db.SaveChanges();
                    return Json(false);
                }

                return Json(true);
            }
            catch {
                return Json(false);
            }
        }

        [HttpPost]
        public IActionResult Book(int id, BookingFormModel BookingForm) {

            db.Bookings.Add(new Bookings {
                CheckInDate = BookingForm.CheckIn,
                CheckOutDate = BookingForm.CheckOut,
                DateCreated = DateTime.Now,
                RoomId = id,
                UserId = 1,
            });
            db.SaveChanges();

            //return RedirectToAction("Room", "Hotels", new { id });
            return RedirectToAction("Room", "Hotels", new { id, BookingForm.CheckIn, BookingForm.CheckOut });
        }

        //[HttpDelete, ActionName("Book")]
        //public IActionResult DeleteBooking(int id, BookingFormModel BookingForm) {
        [HttpPost]
        public IActionResult DeleteBooking(int id, BookingFormModel BookingForm) {

            try {
                var booking = db.Bookings.FirstOrDefault( b =>
                       b.RoomId == id
                       && b.CheckInDate == BookingForm.CheckIn
                       && b.CheckOutDate == BookingForm.CheckOut
                       && b.UserId == 1
                    );

                if (booking != null) {
                    db.Bookings.Remove(booking);
                    db.SaveChanges();
                }
            }
            catch {
                return RedirectToAction("Room", "Hotels", new { id, BookingForm.CheckIn, BookingForm.CheckOut });
                //return RedirectToAction("Room", "Hotels", new { id });
            }

            return RedirectToAction("Room", "Hotels", new { id, BookingForm.CheckIn, BookingForm.CheckOut });
        }
    }
}