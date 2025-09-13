
/****** Object:  Database [TaskManagement]    Script Date: 13-Sep-2025 10:49:44 PM ******/
CREATE DATABASE [TaskManagement]

USE [TaskManagement]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 13-Sep-2025 10:49:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](250) NULL,
	[CreatedID] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedID] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedID] [bigint] NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskAttachments]    Script Date: 13-Sep-2025 10:49:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskAttachments](
	[TaskAttachmentID] [bigint] IDENTITY(1,1) NOT NULL,
	[TaskID] [bigint] NULL,
	[FileName] [varchar](250) NULL,
	[FilePath] [varchar](500) NULL,
	[CreatedID] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedID] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedID] [bigint] NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_TaskAttachments] PRIMARY KEY CLUSTERED 
(
	[TaskAttachmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskComments]    Script Date: 13-Sep-2025 10:49:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskComments](
	[TaskCommentID] [bigint] IDENTITY(1,1) NOT NULL,
	[TaskID] [bigint] NULL,
	[Comment] [nvarchar](max) NULL,
	[CreatedID] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedID] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedID] [bigint] NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_TaskComments] PRIMARY KEY CLUSTERED 
(
	[TaskCommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskMembers]    Script Date: 13-Sep-2025 10:49:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskMembers](
	[TaskMemberID] [bigint] IDENTITY(1,1) NOT NULL,
	[TaskID] [bigint] NULL,
	[UserID] [bigint] NULL,
	[CreatedID] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedID] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedID] [bigint] NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_TaskMembers] PRIMARY KEY CLUSTERED 
(
	[TaskMemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 13-Sep-2025 10:49:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskID] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentTaskID] [bigint] NULL,
	[TaskNo] [int] NULL,
	[Title] [varchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[Progress] [int] NULL,
	[TaskTypeID] [int] NULL,
	[TeamID] [int] NULL,
	[ProjectID] [int] NULL,
	[Complexity] [int] NULL,
	[PriorityID] [int] NULL,
	[TaskStatusID] [int] NULL,
	[Duration_Hours] [int] NULL,
	[Duration_Minutes] [int] NULL,
	[AssignedToID] [bigint] NULL,
	[RequestedByID] [bigint] NULL,
	[StartDate] [datetime] NULL,
	[DueDate] [datetime] NULL,
	[CreatedID] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedID] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedID] [bigint] NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskStatus]    Script Date: 13-Sep-2025 10:49:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskStatus](
	[TaskStatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](250) NULL,
	[OrderBy] [int] NULL,
	[CreatedID] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedID] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedID] [bigint] NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_TaskStatus] PRIMARY KEY CLUSTERED 
(
	[TaskStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskTypes]    Script Date: 13-Sep-2025 10:49:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskTypes](
	[TaskTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TaskTypeName] [varchar](250) NULL,
	[OrderBy] [int] NULL,
	[CreatedID] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedID] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedID] [bigint] NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_TaskTypes] PRIMARY KEY CLUSTERED 
(
	[TaskTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 13-Sep-2025 10:49:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamID] [int] IDENTITY(1,1) NOT NULL,
	[TeamName] [varchar](50) NULL,
	[CreatedID] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedID] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedID] [bigint] NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[TeamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 13-Sep-2025 10:49:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[UserName] [varchar](50) NULL,
	[EmailID] [varchar](150) NULL,
	[Password] [varchar](50) NULL,
	[RoleName] [varchar](100) NULL,
	[IsActice] [bit] NULL,
	[CreatedID] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedID] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedID] [bigint] NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
