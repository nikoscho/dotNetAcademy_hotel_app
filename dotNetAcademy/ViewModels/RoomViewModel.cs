using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetAcademy.Models;

namespace dotNetAcademy.ViewModels {
    public class RoomViewModel {
        public Room Room;
        public ReviewFormViewModel ReviewForm;
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
    }
}
