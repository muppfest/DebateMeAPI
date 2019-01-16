using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.Repository
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly DebateMeContext _db;

        public Repository(DebateMeContext dbContext)
        {
            _db = dbContext;
        }

        public void Delete(int id)
        {
            T t = GetById(id);
            _db.Set<T>().Remove(t);
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public void Insert(T t)
        {
            _db.Set<T>().Add(t);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(T t)
        {
            _db.Entry(t).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
