using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetAcademy.Models;

namespace dotNetAcademy.ViewModels {
    public class ProfileViewModel {
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Favorites> Favorites { get; set; }
        public IEnumerable<Reviews> Reviews { get; set; }
    }
}
