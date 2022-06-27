namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discipline",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DisciplineTitle = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Result = c.Int(),
                        TypeMarkID = c.Int(nullable: false),
                        DisciplineID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Student", t => t.StudentID)
                .ForeignKey("dbo.TypeMark", t => t.TypeMarkID)
                .ForeignKey("dbo.Discipline", t => t.DisciplineID)
                .Index(t => t.TypeMarkID)
                .Index(t => t.DisciplineID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, unicode: false),
                        UserID = c.Int(nullable: false),
                        GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Group", t => t.GroupID)
                .ForeignKey("dbo.UserStudent", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Group = c.String(maxLength: 20, fixedLength: true),
                        FacultyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Faculty", t => t.FacultyID)
                .Index(t => t.FacultyID);
            
            CreateTable(
                "dbo.Faculty",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MessageJoin",
                c => new
                    {
                        MessageID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MessageID, t.StudentID, t.TeacherID })
                .ForeignKey("dbo.Message", t => t.MessageID)
                .ForeignKey("dbo.Teacher", t => t.StudentID)
                .ForeignKey("dbo.Student", t => t.StudentID)
                .Index(t => t.MessageID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(maxLength: 2000, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Name = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserTeacher", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.UserTeacher",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeacherLogin = c.String(maxLength: 50, unicode: false),
                        TeacherPass = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserStudent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentLogin = c.String(maxLength: 50, unicode: false),
                        StudentPass = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TypeMark",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TypeMark = c.String(maxLength: 30, fixedLength: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Marks", "DisciplineID", "dbo.Discipline");
            DropForeignKey("dbo.Marks", "TypeMarkID", "dbo.TypeMark");
            DropForeignKey("dbo.Student", "UserID", "dbo.UserStudent");
            DropForeignKey("dbo.MessageJoin", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Teacher", "UserID", "dbo.UserTeacher");
            DropForeignKey("dbo.MessageJoin", "StudentID", "dbo.Teacher");
            DropForeignKey("dbo.MessageJoin", "MessageID", "dbo.Message");
            DropForeignKey("dbo.Marks", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Student", "GroupID", "dbo.Group");
            DropForeignKey("dbo.Group", "FacultyID", "dbo.Faculty");
            DropIndex("dbo.Teacher", new[] { "UserID" });
            DropIndex("dbo.MessageJoin", new[] { "StudentID" });
            DropIndex("dbo.MessageJoin", new[] { "MessageID" });
            DropIndex("dbo.Group", new[] { "FacultyID" });
            DropIndex("dbo.Student", new[] { "GroupID" });
            DropIndex("dbo.Student", new[] { "UserID" });
            DropIndex("dbo.Marks", new[] { "StudentID" });
            DropIndex("dbo.Marks", new[] { "DisciplineID" });
            DropIndex("dbo.Marks", new[] { "TypeMarkID" });
            DropTable("dbo.TypeMark");
            DropTable("dbo.UserStudent");
            DropTable("dbo.UserTeacher");
            DropTable("dbo.Teacher");
            DropTable("dbo.Message");
            DropTable("dbo.MessageJoin");
            DropTable("dbo.Faculty");
            DropTable("dbo.Group");
            DropTable("dbo.Student");
            DropTable("dbo.Marks");
            DropTable("dbo.Discipline");
        }
    }
}
