using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Abstracts;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _contex;
        private DbSet<T> _dbset;
        protected SMdbContext db;

        public Repository(DbContext context)
        {
            _contex = context;
            _dbset = _contex.Set<T>();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }
       

        List<T> IRepository<T>.GetAll()
        {
            return _dbset.ToList();
        }

        public T GetByID(int id)
        {
            return _dbset.Find(id);
        }

        public void Remove(int id)
        {
            _dbset.Remove(GetByID(id));
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
