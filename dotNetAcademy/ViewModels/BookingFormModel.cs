using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotNetAcademy.ViewModels {
    public class BookingFormModel {

        [Display(Name = "Check in")]
        public string CheckIn { get; set; }

        [Display(Name = "Check out")]
        public string CheckOut { get; set; }
    }
}
