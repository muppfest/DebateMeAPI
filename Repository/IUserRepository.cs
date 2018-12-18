using DebateMeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.Repository
{
    public interface IUserRepository<T> : IRepository<T>
    {
        void Login(User user);
        void Register(User user);
    }
}
