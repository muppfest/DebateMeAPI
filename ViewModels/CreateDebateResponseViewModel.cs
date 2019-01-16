using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.ViewModels
{
    public class CreateDebateResponseViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int RoomId { get; set; }
        public int TopicId { get; set; }
        public int CategoryId { get; set; }
    }
}
