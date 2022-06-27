using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories.Abstracts;

namespace DAL.Repositories.Concretes
{
   public class DisciplineRepository: IRepository<Discipline>
    {
        private SMdbContext db;

        public DisciplineRepository(SMdbContext context)
        {
            db = context;
        }

        public void Add(Discipline entity)
        {
            db.Disciplines.Add(entity);
        }

        public List<Discipline> GetAll()
        {
            return db.Disciplines.ToList();
        }

        public Discipline GetByID(int id)
        {
            return db.Disciplines.Find(id);
        }

        public void Remove(int id)
        {
            db.Disciplines.Remove(GetByID(id));
        }

        public void Update(Discipline entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
