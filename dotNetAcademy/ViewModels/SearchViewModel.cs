using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetAcademy.ViewModels;
using dotNetAcademy.Models;

namespace dotNetAcademy.ViewModels {
    public class SearchViewModel {
        public RoomFiltersModel FilterModel;
        public IEnumerable<Room> Rooms;
    }
}
