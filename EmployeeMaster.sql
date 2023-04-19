USE [master]
GO
/****** Object:  Database [EmployeeMaster]    Script Date: 4/19/2023 1:01:51 PM ******/
CREATE DATABASE [EmployeeMaster]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeMaster', FILENAME = N'C:\Users\GRUBBRR\EmployeeMaster.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeeMaster_log', FILENAME = N'C:\Users\GRUBBRR\EmployeeMaster_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EmployeeMaster] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeMaster].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeMaster] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeMaster] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeMaster] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeMaster] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeMaster] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeMaster] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeMaster] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeMaster] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeMaster] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeMaster] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeMaster] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeMaster] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeMaster] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeMaster] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeMaster] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeMaster] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeMaster] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeMaster] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeMaster] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeMaster] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeMaster] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeMaster] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeMaster] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmployeeMaster] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeMaster] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeMaster] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeMaster] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeMaster] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmployeeMaster] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeeMaster] SET QUERY_STORE = OFF
GO
USE [EmployeeMaster]
GO
/****** Object:  Table [dbo].[DepartmentMaster]    Script Date: 4/19/2023 1:01:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentMaster](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_DepartmentMaster] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeMaster]    Script Date: 4/19/2023 1:01:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeMaster](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [varchar](50) NOT NULL,
	[EmailID] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_EmployeeMaster] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DepartmentMaster] ON 
GO
INSERT [dbo].[DepartmentMaster] ([DepartmentID], [DepartmentName], [IsActive], [IsDeleted], [CreatedDate]) VALUES (1, N'Sales', 1, 0, CAST(N'2023-04-18T15:41:54.780' AS DateTime))
GO
INSERT [dbo].[DepartmentMaster] ([DepartmentID], [DepartmentName], [IsActive], [IsDeleted], [CreatedDate]) VALUES (2, N'Marketing', 1, 0, CAST(N'2023-04-18T15:42:03.460' AS DateTime))
GO
INSERT [dbo].[DepartmentMaster] ([DepartmentID], [DepartmentName], [IsActive], [IsDeleted], [CreatedDate]) VALUES (3, N'Finance', 1, 0, CAST(N'2023-04-18T15:42:11.237' AS DateTime))
GO
INSERT [dbo].[DepartmentMaster] ([DepartmentID], [DepartmentName], [IsActive], [IsDeleted], [CreatedDate]) VALUES (4, N'HR', 1, 0, CAST(N'2023-04-18T15:42:15.200' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[DepartmentMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeMaster] ON 
GO
INSERT [dbo].[EmployeeMaster] ([EmployeeID], [EmployeeName], [EmailID], [DateOfBirth], [DepartmentID], [IsActive], [IsDeleted], [CreatedDate], [UpdatedDate]) VALUES (1, N'Bhavya Bhayani', N'bhavya@gmail.com', CAST(N'1992-10-04T00:00:00.000' AS DateTime), 3, 1, 0, CAST(N'2023-04-18T18:04:27.783' AS DateTime), CAST(N'2023-04-19T11:08:28.133' AS DateTime))
GO
INSERT [dbo].[EmployeeMaster] ([EmployeeID], [EmployeeName], [EmailID], [DateOfBirth], [DepartmentID], [IsActive], [IsDeleted], [CreatedDate], [UpdatedDate]) VALUES (2, N'Jay S Chikani', N'jay@gmail.com', CAST(N'1992-02-23T00:00:00.000' AS DateTime), 2, 1, 0, CAST(N'2023-04-19T10:12:17.897' AS DateTime), CAST(N'2023-04-19T11:12:29.880' AS DateTime))
GO
INSERT [dbo].[EmployeeMaster] ([EmployeeID], [EmployeeName], [EmailID], [DateOfBirth], [DepartmentID], [IsActive], [IsDeleted], [CreatedDate], [UpdatedDate]) VALUES (3, N'Jainy Shah', N'jainy@gmail.com', CAST(N'1995-12-02T00:00:00.000' AS DateTime), 2, 1, 0, CAST(N'2023-04-19T10:17:01.430' AS DateTime), NULL)
GO
INSERT [dbo].[EmployeeMaster] ([EmployeeID], [EmployeeName], [EmailID], [DateOfBirth], [DepartmentID], [IsActive], [IsDeleted], [CreatedDate], [UpdatedDate]) VALUES (4, N'Dharmik dd Patel', N'dharmik@gmail.com', CAST(N'2000-02-02T00:00:00.000' AS DateTime), 4, 0, 1, CAST(N'2023-04-19T12:22:21.767' AS DateTime), CAST(N'2023-04-19T12:40:07.383' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[EmployeeMaster] OFF
GO
ALTER TABLE [dbo].[DepartmentMaster] ADD  CONSTRAINT [DF_DepartmentMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[DepartmentMaster] ADD  CONSTRAINT [DF_DepartmentMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[DepartmentMaster] ADD  CONSTRAINT [DF_DepartmentMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[EmployeeMaster] ADD  CONSTRAINT [DF_EmployeeMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[EmployeeMaster] ADD  CONSTRAINT [DF_EmployeeMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[EmployeeMaster] ADD  CONSTRAINT [DF_EmployeeMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
USE [master]
GO
ALTER DATABASE [EmployeeMaster] SET  READ_WRITE 
GO
