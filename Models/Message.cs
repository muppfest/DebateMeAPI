using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.Models
{
    [Table("Messages")]
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
