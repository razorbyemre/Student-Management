using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories.Abstracts;

namespace DAL.Repositories.Concretes
{
    public class UnitofWork : IUnitofWork
    {
        private SMdbContext db;
        private UserRepository userRepository;
        private StudentRepository studentRepository;
        private TeacherRepository teacherRepository;
        private MarkRepository markRepository;
        private TypeMarkRepository typeMarkRepository;
        private DisciplineRepository disciplineRepository;
        private FacultyRepository facultyRepository;
        private MessageRepository messageRepository;
        private MessageJoinRepository messageJoinRepository;
        private GroupRepository groupRepository;

        public UnitofWork()
        {
            db = new SMdbContext();
        }

        public IRepository<User> User
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Teacher> Teacher
        {
            get
            {
                if (teacherRepository == null)
                    teacherRepository = new TeacherRepository(db);
                return teacherRepository;
            }
        }

        public IRepository<Student> Student
        {
            get
            {
                if (studentRepository == null)
                    studentRepository = new StudentRepository(db);
                return studentRepository;
            }

        }
        public IRepository<Mark> Mark
        {
            get
            {
                if (markRepository == null)
                    markRepository = new MarkRepository(db);
                return markRepository;
            }
        }

        public IRepository<TypeMark> TypeMark
        {
            get
            {
                if (typeMarkRepository == null)
                    typeMarkRepository = new TypeMarkRepository(db);
                return typeMarkRepository;
            }
        }

        public IRepository<Discipline> Discipline
        {
            get
            {
                if (disciplineRepository == null)
                    disciplineRepository = new DisciplineRepository(db);
                return disciplineRepository;
            }
        }

        public IRepository<Message> Message
        {
            get
            {
                if (messageRepository == null)
                    messageRepository = new MessageRepository(db);
                return messageRepository;
            }
        }
        public IRepository<MessageJoin> MessageJoin
        {
            get
            {
                if (messageJoinRepository == null)
                    messageJoinRepository = new MessageJoinRepository(db);
                return messageJoinRepository;
            }
        }

        public IRepository<Group> Group
        {
            get
            {
                if (groupRepository == null)
                    groupRepository = new GroupRepository(db);
                return groupRepository;
            }
        }

        public IRepository<Faculty> Faculty
        {
            get
            {
                if (facultyRepository == null)
                    facultyRepository = new FacultyRepository(db);
                return facultyRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
