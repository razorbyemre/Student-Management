﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories.Abstracts
{
    public interface IUnitofWork
    {
        IRepository<User> User { get; }
        IRepository<Teacher> Teacher { get; }
        IRepository<Student> Student { get; }
        IRepository<Mark> Mark { get; }
        IRepository<TypeMark> TypeMark { get; }
        IRepository<Discipline> Discipline { get; }
        IRepository<Message> Message { get;}
        IRepository<MessageJoin> MessageJoin { get; }
        IRepository<Group> Group { get; }
        IRepository<Faculty> Faculty { get; }

        int Save();

    }
}
