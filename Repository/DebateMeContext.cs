using DebateMeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.Repository
{
    public class DebateMeContext : DbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Topic> Topics { get; set; }
        DbSet<Question> Questions { get; set; }
    }
}
