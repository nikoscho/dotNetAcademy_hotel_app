using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotNetAcademy.ViewModels {
    public class LoginViewModel {
        internal bool RememberMe;

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

    }
}
