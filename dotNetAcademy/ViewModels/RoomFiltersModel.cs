using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetAcademy.ViewModels {
    public class RoomFiltersModel {

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Guests")]
        public int? NumberOfGuests { get; set; }

        [Display(Name = "Room Type")]
        public int? RoomTypeId { get; set; }

        [Display(Name = "Check In")]
        //[Required(ErrorMessage = "Please provide check in date")]
        public string CheckIn { get; set; }

        [Display(Name = "Check Out")]
        //[Required(ErrorMessage = "Please provide check out date")]
        public string CheckOut { get; set; }

        [Display(Name = "Minimun Amount")]
        public int? AmountMin { get; set; }

        [Display(Name = "Maximum Amount")]
        public int? AmountMax { get; set; }
    }
}
