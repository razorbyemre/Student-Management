﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories.Abstracts;

namespace DAL.Repositories.Concretes
{
     public class TypeMarkRepository : IRepository<TypeMark>
    {
        private SMdbContext db;

        public TypeMarkRepository (SMdbContext context)
        {
            db = context; 
        }

        public void Add(TypeMark entity)
        {
            db.TypeMarks.Add(entity);
        }

        public List<TypeMark> GetAll()
        {
            return db.TypeMarks.ToList();
        }

        public TypeMark GetByID(int id)
        {
            return db.TypeMarks.Find(id);
        }

        public void Remove(int id)
        {
            db.TypeMarks.Remove(GetByID(id));
        }

        public void Update(TypeMark entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
