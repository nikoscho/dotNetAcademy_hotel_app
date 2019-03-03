using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotNetAcademy.ViewModels {
    public class ReviewFormModel {

        [Display(Name = "Rate")]
        public int Rate { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }

    }
}
