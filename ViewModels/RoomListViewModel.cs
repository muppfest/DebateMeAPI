using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.ViewModels
{
    public class RoomListViewModel
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int ViewerCount { get; set; }
        public int PostCount { get; set; }
    }
}
