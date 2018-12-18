using DebateMeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.ViewModels
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int PostCount { get; set; }
        public int ViewerCount { get; set; }
        public bool FirstUserTurn { get; set; }

        public UserViewModel FirstUser { get; set; }
        public UserViewModel SecondUser { get; set; }
        public TopicViewModel Topic { get; set; }
        public CategoryViewModel Category { get; set; }
        public List<MessageViewModel> Messages { get; set; }
    }
}
