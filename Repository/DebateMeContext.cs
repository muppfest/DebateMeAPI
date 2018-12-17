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
        public DebateMeContext(DbContextOptions options) : base (options)
        {
        }

        DbSet<User> Users { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Topic> Topics { get; set; }
        DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "IT/Data"
                }
            );

            modelBuilder.Entity<Topic>().HasData(
                new Topic
                {
                    TopicId = 1,
                    Name = "GDPR"
                }
            );

            modelBuilder.Entity<Message>().HasData(
                new Message
                {
                    MessageId = 1,
                    RoomId = 1,
                    Text = "Testar hej hej",
                    UserId = 1
                },
                new Message
                {
                    MessageId = 2,
                    RoomId = 1,
                    Text = "Testar2 hej2 hej2",
                    UserId = 2
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    FirstName = "Anton",
                    LastName = "Nummer Ett",
                    Email = "Test@test.com",
                    PasswordHash = "12345",
                    PhoneNumber = "07012312345",
                    VerficationCode = "12345",
                    IsVerified = true,
                    ForgotPasswordCode = "12345"
                }, 
                new User
                {
                    UserId = 2,
                    FirstName = "Anton",
                    LastName = "Nummer Två",
                    Email = "Test2@test2.com",
                    PasswordHash = "12345",
                    PhoneNumber = "07012312343",
                    VerficationCode = "12345",
                    IsVerified = true,
                    ForgotPasswordCode = "12345"
                }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    RoomId = 1,
                    FirstUserId = 1,
                    SecondUserId = 2,
                    FirstUserTurn = true,
                    PostCount = 2,
                    ViewerCount = 0,
                    CategoryId = 1,
                    TopicId = 1
                }
            );
        }
    }
}
