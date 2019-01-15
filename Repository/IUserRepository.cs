using DebateMeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        bool Login(string email, string password);
        void Register(User user);
        int GetIdByEmail(string email);
        bool EmailExist(string email);
        bool PhoneNumberExist(string phoneNumber);
        string GetEmailById(int id);
    }
}
