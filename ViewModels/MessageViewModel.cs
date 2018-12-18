using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.ViewModels
{
    public class MessageViewModel
    {
        public int MessageId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public bool IsFirstPlayer { get; set; }
    }
}
