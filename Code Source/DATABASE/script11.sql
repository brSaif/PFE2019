USE [master]
GO
/****** Object:  Database [VegaPlatform]    Script Date: 20/09/2019 20:13:48 ******/
CREATE DATABASE [VegaPlatform]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VegaPlatform', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.CSHARP\MSSQL\DATA\VegaPlatform.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'VegaPlatform_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.CSHARP\MSSQL\DATA\VegaPlatform_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [VegaPlatform] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VegaPlatform].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VegaPlatform] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VegaPlatform] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VegaPlatform] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VegaPlatform] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VegaPlatform] SET ARITHABORT OFF 
GO
ALTER DATABASE [VegaPlatform] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [VegaPlatform] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VegaPlatform] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VegaPlatform] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VegaPlatform] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VegaPlatform] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VegaPlatform] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VegaPlatform] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VegaPlatform] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VegaPlatform] SET  ENABLE_BROKER 
GO
ALTER DATABASE [VegaPlatform] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VegaPlatform] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VegaPlatform] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VegaPlatform] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VegaPlatform] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VegaPlatform] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [VegaPlatform] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VegaPlatform] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VegaPlatform] SET  MULTI_USER 
GO
ALTER DATABASE [VegaPlatform] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VegaPlatform] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VegaPlatform] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VegaPlatform] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [VegaPlatform] SET DELAYED_DURABILITY = DISABLED 
GO
USE [VegaPlatform]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Company] [varchar](50) NOT NULL,
	[FirstName] [varchar](25) NOT NULL,
	[LastName] [varchar](25) NOT NULL,
	[Email] [varchar](80) NOT NULL,
	[Phone] [int] NOT NULL,
	[Adress] [varchar](150) NOT NULL,
 CONSTRAINT [PK_dbo.Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Components]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Components](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Components] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExpenceCats]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenceCats](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ExpenceCats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Expences]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expences](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Payment] [real] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
	[ExpenceCatId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Expences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FabricationOrders]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FabricationOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomenclatureId] [int] NOT NULL,
	[Length] [real] NOT NULL,
	[Status] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[StartingDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.FabricationOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupPermissions]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupPermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.GroupPermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Groups]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](15) NOT NULL,
 CONSTRAINT [PK_dbo.Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ImportingInvoices]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportingInvoices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SuplierId] [int] NOT NULL,
	[RawMaterialId] [int] NOT NULL,
	[Price] [real] NOT NULL,
	[Discount] [real] NOT NULL,
	[PaymentType] [int] NOT NULL,
	[PaymentStatus] [tinyint] NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.ImportingInvoices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NColors]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NColors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.NColors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nomenclatures]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nomenclatures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Designation] [nvarchar](max) NOT NULL,
	[NormRef] [nvarchar](max) NOT NULL,
	[Condition] [nvarchar](max) NOT NULL,
	[ColorId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Nomenclatures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NomenclatureSequances]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NomenclatureSequances](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NomenclatureID] [int] NOT NULL,
	[SequenceId] [int] NOT NULL,
	[ComponentId] [int] NOT NULL,
	[Mass] [real] NOT NULL,
 CONSTRAINT [PK_dbo.NomenclatureSequances] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_dbo.Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProgressionChecks]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgressionChecks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OFID] [int] NOT NULL,
	[SeqID] [int] NOT NULL,
	[Progress] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ProgressionChecks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RawMaterials]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RawMaterials](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ComposantID] [int] NOT NULL,
	[Mass] [real] NOT NULL,
	[Lot] [nvarchar](max) NOT NULL,
	[ImpDate] [datetime] NOT NULL,
	[UpDate] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[RefNbr] [nvarchar](max) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_dbo.RawMaterials] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SellingInvoices]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellingInvoices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FabOrdId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[Price] [real] NOT NULL,
	[Discount] [real] NOT NULL,
	[PaymentType] [int] NOT NULL,
	[PaymentStatus] [tinyint] NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.SellingInvoices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sequences]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sequences](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Sequences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supliers]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Supliers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Company] [varchar](30) NOT NULL,
	[FirstName] [varchar](15) NOT NULL,
	[LastName] [varchar](15) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [int] NOT NULL,
	[Adress] [varchar](120) NOT NULL,
	[Category] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.Supliers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsedRawMaterials]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsedRawMaterials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FabOrdID] [int] NOT NULL,
	[RawMaterialID] [int] NOT NULL,
	[Weight] [real] NOT NULL,
 CONSTRAINT [PK_dbo.UsedRawMaterials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 20/09/2019 20:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileImage] [varbinary](max) NULL,
	[UserName] [nvarchar](4000) NOT NULL,
	[FullName] [nvarchar](4000) NOT NULL,
	[Adress] [nvarchar](4000) NOT NULL,
	[ZipCode] [int] NOT NULL,
	[Email] [nvarchar](4000) NOT NULL,
	[Phone] [int] NOT NULL,
	[Password] [nvarchar](4000) NOT NULL,
	[GroupId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Index [IX_ExpenceCatId]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_ExpenceCatId] ON [dbo].[Expences]
(
	[ExpenceCatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Expences]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_NomenclatureId]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_NomenclatureId] ON [dbo].[FabricationOrders]
(
	[NomenclatureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupId]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_GroupId] ON [dbo].[GroupPermissions]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PermissionId]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_PermissionId] ON [dbo].[GroupPermissions]
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RawMaterialId]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_RawMaterialId] ON [dbo].[ImportingInvoices]
(
	[RawMaterialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SuplierId]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_SuplierId] ON [dbo].[ImportingInvoices]
(
	[SuplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[ImportingInvoices]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ColorId]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_ColorId] ON [dbo].[Nomenclatures]
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ComponentId]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_ComponentId] ON [dbo].[NomenclatureSequances]
(
	[ComponentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_NomenclatureID]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_NomenclatureID] ON [dbo].[NomenclatureSequances]
(
	[NomenclatureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SequenceId]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_SequenceId] ON [dbo].[NomenclatureSequances]
(
	[SequenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OFID]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_OFID] ON [dbo].[ProgressionChecks]
(
	[OFID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SeqID]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_SeqID] ON [dbo].[ProgressionChecks]
(
	[SeqID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ComposantID]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_ComposantID] ON [dbo].[RawMaterials]
(
	[ComposantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[RawMaterials]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientId]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_ClientId] ON [dbo].[SellingInvoices]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FabOrdId]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_FabOrdId] ON [dbo].[SellingInvoices]
(
	[FabOrdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[SellingInvoices]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FabOrdID]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_FabOrdID] ON [dbo].[UsedRawMaterials]
(
	[FabOrdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RawMaterialID]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_RawMaterialID] ON [dbo].[UsedRawMaterials]
(
	[RawMaterialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupId]    Script Date: 20/09/2019 20:13:49 ******/
CREATE NONCLUSTERED INDEX [IX_GroupId] ON [dbo].[Users]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Expences]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Expences_dbo.ExpenceCats_ExpenceCatId] FOREIGN KEY([ExpenceCatId])
REFERENCES [dbo].[ExpenceCats] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Expences] CHECK CONSTRAINT [FK_dbo.Expences_dbo.ExpenceCats_ExpenceCatId]
GO
ALTER TABLE [dbo].[Expences]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Expences_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Expences] CHECK CONSTRAINT [FK_dbo.Expences_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[FabricationOrders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FabricationOrders_dbo.Nomenclatures_NomenclatureId] FOREIGN KEY([NomenclatureId])
REFERENCES [dbo].[Nomenclatures] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FabricationOrders] CHECK CONSTRAINT [FK_dbo.FabricationOrders_dbo.Nomenclatures_NomenclatureId]
GO
ALTER TABLE [dbo].[GroupPermissions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.GroupPermissions_dbo.Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupPermissions] CHECK CONSTRAINT [FK_dbo.GroupPermissions_dbo.Groups_GroupId]
GO
ALTER TABLE [dbo].[GroupPermissions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.GroupPermissions_dbo.Permissions_PermissionId] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permissions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupPermissions] CHECK CONSTRAINT [FK_dbo.GroupPermissions_dbo.Permissions_PermissionId]
GO
ALTER TABLE [dbo].[ImportingInvoices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ImportingInvoices_dbo.RawMaterials_RawMaterialId] FOREIGN KEY([RawMaterialId])
REFERENCES [dbo].[RawMaterials] ([ID])
GO
ALTER TABLE [dbo].[ImportingInvoices] CHECK CONSTRAINT [FK_dbo.ImportingInvoices_dbo.RawMaterials_RawMaterialId]
GO
ALTER TABLE [dbo].[ImportingInvoices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ImportingInvoices_dbo.Supliers_SuplierId] FOREIGN KEY([SuplierId])
REFERENCES [dbo].[Supliers] ([Id])
GO
ALTER TABLE [dbo].[ImportingInvoices] CHECK CONSTRAINT [FK_dbo.ImportingInvoices_dbo.Supliers_SuplierId]
GO
ALTER TABLE [dbo].[ImportingInvoices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ImportingInvoices_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImportingInvoices] CHECK CONSTRAINT [FK_dbo.ImportingInvoices_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Nomenclatures]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Nomenclatures_dbo.NColors_ColorId] FOREIGN KEY([ColorId])
REFERENCES [dbo].[NColors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Nomenclatures] CHECK CONSTRAINT [FK_dbo.Nomenclatures_dbo.NColors_ColorId]
GO
ALTER TABLE [dbo].[NomenclatureSequances]  WITH CHECK ADD  CONSTRAINT [FK_dbo.NomenclatureSequances_dbo.Components_ComponentId] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Components] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NomenclatureSequances] CHECK CONSTRAINT [FK_dbo.NomenclatureSequances_dbo.Components_ComponentId]
GO
ALTER TABLE [dbo].[NomenclatureSequances]  WITH CHECK ADD  CONSTRAINT [FK_dbo.NomenclatureSequances_dbo.Nomenclatures_NomenclatureID] FOREIGN KEY([NomenclatureID])
REFERENCES [dbo].[Nomenclatures] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NomenclatureSequances] CHECK CONSTRAINT [FK_dbo.NomenclatureSequances_dbo.Nomenclatures_NomenclatureID]
GO
ALTER TABLE [dbo].[NomenclatureSequances]  WITH CHECK ADD  CONSTRAINT [FK_dbo.NomenclatureSequances_dbo.Sequences_SequenceId] FOREIGN KEY([SequenceId])
REFERENCES [dbo].[Sequences] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NomenclatureSequances] CHECK CONSTRAINT [FK_dbo.NomenclatureSequances_dbo.Sequences_SequenceId]
GO
ALTER TABLE [dbo].[ProgressionChecks]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProgressionChecks_dbo.FabricationOrders_OFID] FOREIGN KEY([OFID])
REFERENCES [dbo].[FabricationOrders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProgressionChecks] CHECK CONSTRAINT [FK_dbo.ProgressionChecks_dbo.FabricationOrders_OFID]
GO
ALTER TABLE [dbo].[ProgressionChecks]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProgressionChecks_dbo.Sequences_SeqID] FOREIGN KEY([SeqID])
REFERENCES [dbo].[Sequences] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProgressionChecks] CHECK CONSTRAINT [FK_dbo.ProgressionChecks_dbo.Sequences_SeqID]
GO
ALTER TABLE [dbo].[RawMaterials]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RawMaterials_dbo.Components_ComposantID] FOREIGN KEY([ComposantID])
REFERENCES [dbo].[Components] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RawMaterials] CHECK CONSTRAINT [FK_dbo.RawMaterials_dbo.Components_ComposantID]
GO
ALTER TABLE [dbo].[RawMaterials]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RawMaterials_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RawMaterials] CHECK CONSTRAINT [FK_dbo.RawMaterials_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[SellingInvoices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SellingInvoices_dbo.Clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SellingInvoices] CHECK CONSTRAINT [FK_dbo.SellingInvoices_dbo.Clients_ClientId]
GO
ALTER TABLE [dbo].[SellingInvoices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SellingInvoices_dbo.FabricationOrders_FabOrdId] FOREIGN KEY([FabOrdId])
REFERENCES [dbo].[FabricationOrders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SellingInvoices] CHECK CONSTRAINT [FK_dbo.SellingInvoices_dbo.FabricationOrders_FabOrdId]
GO
ALTER TABLE [dbo].[SellingInvoices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SellingInvoices_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SellingInvoices] CHECK CONSTRAINT [FK_dbo.SellingInvoices_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[UsedRawMaterials]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UsedRawMaterials_dbo.FabricationOrders_FabOrdID] FOREIGN KEY([FabOrdID])
REFERENCES [dbo].[FabricationOrders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsedRawMaterials] CHECK CONSTRAINT [FK_dbo.UsedRawMaterials_dbo.FabricationOrders_FabOrdID]
GO
ALTER TABLE [dbo].[UsedRawMaterials]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UsedRawMaterials_dbo.RawMaterials_RawMaterialID] FOREIGN KEY([RawMaterialID])
REFERENCES [dbo].[RawMaterials] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsedRawMaterials] CHECK CONSTRAINT [FK_dbo.UsedRawMaterials_dbo.RawMaterials_RawMaterialID]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Users_dbo.Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_dbo.Users_dbo.Groups_GroupId]
GO
USE [master]
GO
ALTER DATABASE [VegaPlatform] SET  READ_WRITE 
GO
