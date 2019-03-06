using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetAcademy.ViewModels {
    public class LoginViewModel {
        internal bool RememberMe;

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
