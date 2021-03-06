USE [StudentManagement]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 3/15/2022 12:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discipline]    Script Date: 3/15/2022 12:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discipline](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DisciplineTitle] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.Discipline] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 3/15/2022 12:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FacultyName] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.Faculty] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 3/15/2022 12:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Group] [nchar](20) NULL,
	[FacultyID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Group] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marks]    Script Date: 3/15/2022 12:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Result] [int] NULL,
	[TypeMarkID] [int] NOT NULL,
	[DisciplineID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Marks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 3/15/2022 12:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [varchar](2000) NULL,
 CONSTRAINT [PK_dbo.Message] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MessageJoin]    Script Date: 3/15/2022 12:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageJoin](
	[MessageID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[TeacherID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.MessageJoin] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC,
	[StudentID] ASC,
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 3/15/2022 12:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[UserID] [int] NOT NULL,
	[GroupID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 3/15/2022 12:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.Teacher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeMark]    Script Date: 3/15/2022 12:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeMark](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeMark] [nchar](30) NULL,
 CONSTRAINT [PK_dbo.TypeMark] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserStudent]    Script Date: 3/15/2022 12:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserStudent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentLogin] [varchar](50) NULL,
	[StudentPass] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.UserStudent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTeacher]    Script Date: 3/15/2022 12:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTeacher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherLogin] [varchar](50) NULL,
	[TeacherPass] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.UserTeacher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Group_dbo.Faculty_FacultyID] FOREIGN KEY([FacultyID])
REFERENCES [dbo].[Faculty] ([ID])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_dbo.Group_dbo.Faculty_FacultyID]
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Marks_dbo.Discipline_DisciplineID] FOREIGN KEY([DisciplineID])
REFERENCES [dbo].[Discipline] ([ID])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_dbo.Marks_dbo.Discipline_DisciplineID]
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Marks_dbo.Student_StudentID] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_dbo.Marks_dbo.Student_StudentID]
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Marks_dbo.TypeMark_TypeMarkID] FOREIGN KEY([TypeMarkID])
REFERENCES [dbo].[TypeMark] ([ID])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_dbo.Marks_dbo.TypeMark_TypeMarkID]
GO
ALTER TABLE [dbo].[MessageJoin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MessageJoin_dbo.Message_MessageID] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Message] ([ID])
GO
ALTER TABLE [dbo].[MessageJoin] CHECK CONSTRAINT [FK_dbo.MessageJoin_dbo.Message_MessageID]
GO
ALTER TABLE [dbo].[MessageJoin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MessageJoin_dbo.Student_StudentID] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[MessageJoin] CHECK CONSTRAINT [FK_dbo.MessageJoin_dbo.Student_StudentID]
GO
ALTER TABLE [dbo].[MessageJoin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MessageJoin_dbo.Teacher_StudentID] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Teacher] ([ID])
GO
ALTER TABLE [dbo].[MessageJoin] CHECK CONSTRAINT [FK_dbo.MessageJoin_dbo.Teacher_StudentID]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Student_dbo.Group_GroupID] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([ID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_dbo.Student_dbo.Group_GroupID]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Student_dbo.UserStudent_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserStudent] ([ID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_dbo.Student_dbo.UserStudent_UserID]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Teacher_dbo.UserTeacher_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTeacher] ([ID])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_dbo.Teacher_dbo.UserTeacher_UserID]
GO
