using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.Models
{
    [Table("Topics")]
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }
        public string Name { get; set; }

        public Category Category { get; set; }
        public List<Question> Questions { get; set; }
    }
}
