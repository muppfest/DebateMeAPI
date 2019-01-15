using DebateMeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DebateMeContext _db;

        public UserRepository(DebateMeContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public bool Login(string email, string passwordHash)
        {
            if (_db.Set<User>().Where(w => w.Email == email && w.PasswordHash == passwordHash).Count() > 0) return true;

            return false;
        }

        public void Register(User user)
        {
            _db.Set<User>().Add(user);

        }

        public int GetIdByEmail(string email)
        {
            return _db.Set<User>().ToList().Where(w => w.Email == email).Select(s => s.UserId).FirstOrDefault();
        }

        public bool EmailExist(string email)
        {
            if (_db.Set<User>().ToList().Where(w => w.Email == email).Count() > 0) return true;
            return false;
        }

        public bool PhoneNumberExist(string phoneNumber)
        {
            if (_db.Set<User>().Where(w => w.PhoneNumber == phoneNumber).Count() > 0) return true;
            return false;
        }

        public string GetEmailById(int id)
        {
            return _db.Set<User>().ToList().Where(w => w.UserId == id).Select(s => s.Email).FirstOrDefault();
        }
    }
}
