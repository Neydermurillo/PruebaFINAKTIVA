USE [master]
GO
/****** Object:  Database [TestFinaktivaBD]    Script Date: 17/07/2020 13:17:02 ******/
CREATE DATABASE [TestFinaktivaBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestFinaktivaBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TestFinaktivaBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TestFinaktivaBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TestFinaktivaBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TestFinaktivaBD] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestFinaktivaBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestFinaktivaBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TestFinaktivaBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestFinaktivaBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestFinaktivaBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TestFinaktivaBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestFinaktivaBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TestFinaktivaBD] SET  MULTI_USER 
GO
ALTER DATABASE [TestFinaktivaBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestFinaktivaBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestFinaktivaBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestFinaktivaBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TestFinaktivaBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TestFinaktivaBD] SET QUERY_STORE = OFF
GO
USE [TestFinaktivaBD]
GO
/****** Object:  Table [dbo].[MunicipalityRegion]    Script Date: 17/07/2020 13:17:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MunicipalityRegion](
	[MunicipalyRegionId] [int] IDENTITY(1,1) NOT NULL,
	[MunicipalityId] [int] NOT NULL,
	[RegionId] [int] NOT NULL,
 CONSTRAINT [PK_MunicipalityRegion] PRIMARY KEY CLUSTERED 
(
	[MunicipalyRegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Municipalitys]    Script Date: 17/07/2020 13:17:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Municipalitys](
	[MunicipalityId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[State] [bit] NOT NULL,
 CONSTRAINT [PK_Municipalitys] PRIMARY KEY CLUSTERED 
(
	[MunicipalityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 17/07/2020 13:17:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[RegionId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[RegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MunicipalityRegion] ON 
GO
INSERT [dbo].[MunicipalityRegion] ([MunicipalyRegionId], [MunicipalityId], [RegionId]) VALUES (1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[MunicipalityRegion] OFF
GO
SET IDENTITY_INSERT [dbo].[Municipalitys] ON 
GO
INSERT [dbo].[Municipalitys] ([MunicipalityId], [Name], [State]) VALUES (1, N'tado', 1)
GO
INSERT [dbo].[Municipalitys] ([MunicipalityId], [Name], [State]) VALUES (2, N'medellin', 0)
GO
SET IDENTITY_INSERT [dbo].[Municipalitys] OFF
GO
SET IDENTITY_INSERT [dbo].[Region] ON 
GO
INSERT [dbo].[Region] ([RegionId], [Name]) VALUES (1, N'Choco')
GO
SET IDENTITY_INSERT [dbo].[Region] OFF
GO
ALTER TABLE [dbo].[MunicipalityRegion]  WITH CHECK ADD  CONSTRAINT [FK_MunicipalityRegion_Municipalitys] FOREIGN KEY([MunicipalityId])
REFERENCES [dbo].[Municipalitys] ([MunicipalityId])
GO
ALTER TABLE [dbo].[MunicipalityRegion] CHECK CONSTRAINT [FK_MunicipalityRegion_Municipalitys]
GO
ALTER TABLE [dbo].[MunicipalityRegion]  WITH CHECK ADD  CONSTRAINT [FK_MunicipalityRegion_Region] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Region] ([RegionId])
GO
ALTER TABLE [dbo].[MunicipalityRegion] CHECK CONSTRAINT [FK_MunicipalityRegion_Region]
GO
USE [master]
GO
ALTER DATABASE [TestFinaktivaBD] SET  READ_WRITE 
GO