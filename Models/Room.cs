using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.Models
{
    [Table("Rooms")]
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public int CategoryId { get; set; }
        public int TopicId { get; set; }
        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }
        public int PostCount { get; set; }
        public int ViewerCount { get; set; }
        public bool FirstUserTurn { get; set; }

        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [ForeignKey("FirstUserId")]
        public User FirstUser { get; set; }
        [ForeignKey("SecondUserId")]
        public User SecondUser { get; set; }
    }
}
