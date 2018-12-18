using DebateMeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.Repository
{
    public class UserRepository<T> : Repository<User>, IUserRepository<User>
    {
        private readonly DebateMeContext _db;

        public UserRepository(DebateMeContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public void Login(User user)
        {
            throw new NotImplementedException();
        }

        public void Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
