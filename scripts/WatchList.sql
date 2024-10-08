USE [master]
GO
/****** Object:  Database [WatchList]    Script Date: 16-09-2024 19:01:27 ******/
CREATE DATABASE [WatchList]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WatchList', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\WatchList.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WatchList_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\WatchList_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [WatchList] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WatchList].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WatchList] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WatchList] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WatchList] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WatchList] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WatchList] SET ARITHABORT OFF 
GO
ALTER DATABASE [WatchList] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WatchList] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WatchList] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WatchList] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WatchList] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WatchList] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WatchList] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WatchList] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WatchList] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WatchList] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WatchList] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WatchList] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WatchList] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WatchList] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WatchList] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WatchList] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WatchList] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WatchList] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WatchList] SET  MULTI_USER 
GO
ALTER DATABASE [WatchList] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WatchList] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WatchList] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WatchList] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WatchList] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WatchList] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [WatchList] SET QUERY_STORE = ON
GO
ALTER DATABASE [WatchList] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [WatchList]
GO
/****** Object:  Table [dbo].[tblAnimeList]    Script Date: 16-09-2024 19:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAnimeList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](250) NULL,
	[RATING] [float] NULL,
	[GENRE] [nvarchar](50) NULL,
	[DESCRIPTION] [nvarchar](500) NULL,
	[ISFAVOURITE] [bit] NULL,
	[SATAUS] [int] NOT NULL,
 CONSTRAINT [PK_tblAnimeList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStatus]    Script Date: 16-09-2024 19:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStatus](
	[Sid] [int] NOT NULL,
	[STATUS] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblStatus] PRIMARY KEY CLUSTERED 
(
	[Sid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 16-09-2024 19:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[gender] [nvarchar](10) NULL,
	[contact] [nchar](10) NULL,
	[address] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblAnimeList] ON 

INSERT [dbo].[tblAnimeList] ([ID], [NAME], [RATING], [GENRE], [DESCRIPTION], [ISFAVOURITE], [SATAUS]) VALUES (1, N'Solo Leveling', 9, N'Action', N'Korean Anime', 0, 2)
SET IDENTITY_INSERT [dbo].[tblAnimeList] OFF
GO
INSERT [dbo].[tblStatus] ([Sid], [STATUS]) VALUES (1, N'Watching')
INSERT [dbo].[tblStatus] ([Sid], [STATUS]) VALUES (2, N'Pending')
GO
SET IDENTITY_INSERT [dbo].[tblUser] ON 

INSERT [dbo].[tblUser] ([id], [name], [email], [gender], [contact], [address]) VALUES (8, N'Vishal ', N'vishalpardeshi@gmail.com', N'0', N'2934723986', N'pune')
INSERT [dbo].[tblUser] ([id], [name], [email], [gender], [contact], [address]) VALUES (10, N'Natasha', N'natasha@gmail.com', N'1', N'654645465 ', N'pnsdkv')
INSERT [dbo].[tblUser] ([id], [name], [email], [gender], [contact], [address]) VALUES (11, N'Siddhi', N'djsdjh@hafk.com', N'1', N'309852    ', N'pedo')
INSERT [dbo].[tblUser] ([id], [name], [email], [gender], [contact], [address]) VALUES (12, N'Ranjit', N'ranjit@gmail.vom', N'0', N'93457429  ', N'0234')
SET IDENTITY_INSERT [dbo].[tblUser] OFF
GO
ALTER TABLE [dbo].[tblAnimeList]  WITH CHECK ADD  CONSTRAINT [FK_tblAnimeList_tblStatus] FOREIGN KEY([SATAUS])
REFERENCES [dbo].[tblStatus] ([Sid])
GO
ALTER TABLE [dbo].[tblAnimeList] CHECK CONSTRAINT [FK_tblAnimeList_tblStatus]
GO
/****** Object:  StoredProcedure [dbo].[dbUser]    Script Date: 16-09-2024 19:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[dbUser]
	(
	@id int = null,
	@name nvarchar(50) =null,
	@email nvarchar(50) =null,
	@gender nvarchar(10) =null,
	@contact nvarchar(10) =null,
	@address nvarchar(50)= null,
	@Flag nvarchar(50)=null
	)
	AS
BEGIN
	if(@Flag='GetAllUser')
	begin
		select * from tblUser;
	end
	---------------------------------------------------------------
	if(@Flag='GetUserbyId')
	begin
		select * from tblUser where id=@id;
	end
	------------------------------------------------------------------------------
	if(@Flag='SaveUser')
	begin
		insert into tblUser values (@name,@email,@gender,@contact,@address);
	end
	-------------------------------------------------------------------------
	if(@Flag='UpdateUser')
	begin
		update  tblUser set name= @name, email=@email,gender= @gender,contact= @contact,address= @address
		where id=@id;
	end
	-------------------------------------------------------------------------
	if(@Flag='DeleteUser')
	begin
		delete tblUser where id=@id;
	end
END

GO
/****** Object:  StoredProcedure [dbo].[WatchListSP]    Script Date: 16-09-2024 19:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[WatchListSP]
	(
	@Id int = null,
	@Name nvarchar(250) =null,
	@Rating float = null,
	@Genre nvarchar(50) = null,
	@Description nvarchar(500) =null,
	@isFav bit= null,
	@Status int =null,
	@Flag nvarchar(50)=null
	)
AS
BEGIN

	if(@Flag='ListAnime')
	begin
		select * from tblAnimeList;
	end
	-------------------------------
	if(@Flag='SaveAnime')
	begin
		insert into tblAnimeList values(@Name,@Rating,@Genre,@Description,@isFav,@Status);
	end
	----------------------------------
	if(@Flag='UpdateAnime')
	begin
		update tblAnimeList set NAME=@Name,RATING=@Rating,GENRE=@Genre,DESCRIPTION=@Description,ISFAVOURITE=@isFav,SATAUS=@Status 
		where ID=@Id;
	end
	---------------------------
	if(@Flag='GetAnime')
	begin
	select* from tblAnimeList where ID=@Id;
	end
	-------------------------------
	if(@Flag='DeleteAnime')
	begin
		delete tblAnimeList where ID=@Id;
	end
	--------------------------
	If(@Flag='GetStatus')
	begin
		select*from tblStatus;
	end
END

GO
USE [master]
GO
ALTER DATABASE [WatchList] SET  READ_WRITE 
GO
