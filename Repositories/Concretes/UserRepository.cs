using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Abstracts;
using DAL.Entities;
namespace DAL.Repositories.Concretes
{
    public class UserRepository :IRepository <User>
    {
        private SMdbContext db;
        public UserRepository(SMdbContext context)
        {
            db = context;
        }

        public void Add(User entity)
        {
            db.Users.Add(entity);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User GetByID(int id)
        {
            return db.Users.Find(id); 
        }

        public void Remove(int id)
        {
            db.Users.Remove(GetByID(id));
        }

        public void Update(User entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
