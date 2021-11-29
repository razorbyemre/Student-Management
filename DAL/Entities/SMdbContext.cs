using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entities
{
    public partial class SMdbContext : DbContext
    {
        public SMdbContext()
            : base("name=SMdbContext")
        {
        }

        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MessageJoin> MessageJoins { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TypeMark> TypeMarks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discipline>()
                .Property(e => e.DisciplineTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Discipline>()
                .HasMany(e => e.Marks)
                .WithRequired(e => e.Discipline)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Faculty>()
                .Property(e => e.FacultyName)
                .IsUnicode(false);

            modelBuilder.Entity<Faculty>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.Faculty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .Property(e => e.Group1)
                .IsFixedLength();

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Message1)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .HasMany(e => e.MessageJoins)
                .WithRequired(e => e.Message)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Marks)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.MessageJoins)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.MessageJoins)
                .WithRequired(e => e.Teacher)
                .HasForeignKey(e => e.StudentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeMark>()
                .Property(e => e.TypeMark1)
                .IsFixedLength();

            modelBuilder.Entity<TypeMark>()
                .HasMany(e => e.Marks)
                .WithRequired(e => e.TypeMark)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.TypeUser)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Teachers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
