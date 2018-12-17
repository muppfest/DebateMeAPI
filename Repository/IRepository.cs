using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.Repository
{
    interface IRepository<T>
    {
        T GetById(int id);
        List<T> GetAll();
        void Insert(T t);
        void Delete(int id);
        void Update(T t);
        void Save();
    }
}
