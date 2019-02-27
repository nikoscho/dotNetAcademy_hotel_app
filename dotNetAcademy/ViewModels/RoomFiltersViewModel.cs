using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetAcademy.ViewModels {
    public class RoomFiltersViewModel {

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Room Type")]
        public int? RoomTypeId { get; set; }

        [Display(Name = "Check In")]
        public string CheckIn { get; set; }

        [Display(Name = "Check Out")]
        public string CheckOut { get; set; }

    }
}
