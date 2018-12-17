using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ForgotPasswordCode { get; set; }
        public string VerficationCode { get; set; }
        public bool IsVerified { get; set; }
        public string PhoneNumber { get; set; }
        public string AndroidDeviceId { get; set; }
        public string IosDeviceId { get; set; }
        public string WebDeviceId { get; set; }

        public List<Room> Room { get; set; }
        public List<Message> Messages { get; set; }
    }
}
