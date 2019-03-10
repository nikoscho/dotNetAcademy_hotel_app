using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotNetAcademy.ViewModels {
    public class BookingFormModel {

        [Display(Name = "Check in")]
        [Required]
        public string CheckIn { get; set; }

        [Display(Name = "Check out")]
        [Required]
        public string CheckOut { get; set; }
    }
}
