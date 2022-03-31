USE [master]
GO
/****** Object:  Database [Account]    Script Date: 16-Nov-20 11:09:20 AM ******/
CREATE DATABASE [Account]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Account', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Account.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Account_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Account_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Account] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Account].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Account] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Account] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Account] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Account] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Account] SET ARITHABORT OFF 
GO
ALTER DATABASE [Account] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Account] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Account] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Account] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Account] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Account] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Account] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Account] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Account] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Account] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Account] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Account] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Account] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Account] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Account] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Account] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Account] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Account] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Account] SET  MULTI_USER 
GO
ALTER DATABASE [Account] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Account] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Account] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Account] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Account] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Account]
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDOwner]    Script Date: 16-Nov-20 11:09:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDOwner]()
RETURNS NCHAR(10)
AS
BEGIN
	DECLARE @ID NCHAR(10)
	IF (SELECT COUNT(OwnerID) FROM Owner) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(OwnerID, 3)) FROM Owner
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN '003' + CONVERT(nchar, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN '003' + CONVERT(nchar, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

GO
/****** Object:  Table [dbo].[Account]    Script Date: 16-Nov-20 11:09:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Pass] [nvarchar](20) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[PhoneNumber] [char](12) NOT NULL,
	[Birthday] [date] NOT NULL,
	[acctype] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Owner]    Script Date: 16-Nov-20 11:09:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owner](
	[OwnerID] [nchar](10) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[IdentityCard] [nvarchar](20) NOT NULL,
	[Phone] [nvarchar](10) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Birthday] [date] NOT NULL,
	[RoomID] [nchar](10) NOT NULL,
	[Face] [image] NULL,
 CONSTRAINT [PK_Owner_1] PRIMARY KEY CLUSTERED 
(
	[IdentityCard] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 16-Nov-20 11:09:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomID] [nchar](10) NOT NULL,
	[Floor] [int] NOT NULL,
	[Accommodated] [int] NOT NULL,
	[RoomNumber] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Room_1] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TinhTrang]    Script Date: 16-Nov-20 11:09:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinhTrang](
	[RoomID] [nchar](10) NOT NULL,
	[TinhTrang] [int] NOT NULL,
 CONSTRAINT [PK_TinhTrang] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Room]    Script Date: 16-Nov-20 11:09:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_Room] ON [dbo].[Room]
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Owner]  WITH CHECK ADD  CONSTRAINT [FK_Owner_Owner] FOREIGN KEY([IdentityCard])
REFERENCES [dbo].[Owner] ([IdentityCard])
GO
ALTER TABLE [dbo].[Owner] CHECK CONSTRAINT [FK_Owner_Owner]
GO
ALTER TABLE [dbo].[Owner]  WITH CHECK ADD  CONSTRAINT [FK_Owner_Room] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[Owner] CHECK CONSTRAINT [FK_Owner_Room]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_TinhTrang] FOREIGN KEY([RoomID])
REFERENCES [dbo].[TinhTrang] ([RoomID])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_TinhTrang]
GO
/****** Object:  StoredProcedure [dbo].[FindOwner]    Script Date: 16-Nov-20 11:09:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FindOwner]
@id NChar(10)
as
begin
	Select * From Owner where OwnerID like @id + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[FindRoom]    Script Date: 16-Nov-20 11:09:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: MyProject.sql|0|0|C:\Users\Admin\OneDrive\Documents\SQL Server Management Studio\MyProject.sql


CREATE PROC [dbo].[FindRoom]
@id NChar(10)
as
begin
	Select * From Room where RoomNumber like @id + '%'
end

Select * From Room where RoomNumber like '101'
exec FindRoom 101
GO
USE [master]
GO
ALTER DATABASE [Account] SET  READ_WRITE 
GO
