using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetAcademy.Models;

namespace dotNetAcademy.ViewModels {
    public class RoomViewModel {
        public Room Room;
        public ReviewFormModel ReviewForm;
        public BookingFormModel BookingForm;

        public bool ShowBookingButton { get; set; }
        public bool IsAvailable { get; set; }
    }
}
