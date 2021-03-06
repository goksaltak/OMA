USE [master]
GO
/****** Object:  Database [OMADB]    Script Date: 07.07.2021 17:15:20 ******/
CREATE DATABASE [OMADB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OMADB', FILENAME = N'C:\Users\GÖKSAL TAK\OMADB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OMADB_log', FILENAME = N'C:\Users\GÖKSAL TAK\OMADB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [OMADB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OMADB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OMADB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OMADB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OMADB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OMADB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OMADB] SET ARITHABORT OFF 
GO
ALTER DATABASE [OMADB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OMADB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OMADB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OMADB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OMADB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OMADB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OMADB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OMADB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OMADB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OMADB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OMADB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OMADB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OMADB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OMADB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OMADB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OMADB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OMADB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OMADB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OMADB] SET  MULTI_USER 
GO
ALTER DATABASE [OMADB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OMADB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OMADB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OMADB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OMADB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OMADB] SET QUERY_STORE = OFF
GO
USE [OMADB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [OMADB]
GO
/****** Object:  Table [dbo].[tb_customer]    Script Date: 07.07.2021 17:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](90) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NULL,
	[CreatedUser] [varchar](50) NOT NULL,
	[ModifiedUser] [varchar](50) NULL,
 CONSTRAINT [PK_tb_customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_order]    Script Date: 07.07.2021 17:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderAddress] [nvarchar](90) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NULL,
	[CreatedUser] [varchar](50) NOT NULL,
	[ModifiedUser] [varchar](50) NULL,
 CONSTRAINT [PK_tb_order_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_orderDetail]    Script Date: 07.07.2021 17:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_orderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](16, 2) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NULL,
	[CreatedUser] [varchar](50) NOT NULL,
	[ModifiedUser] [varchar](50) NULL,
 CONSTRAINT [PK_tb_orderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_product]    Script Date: 07.07.2021 17:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Barcode] [varchar](13) NOT NULL,
	[Description] [nvarchar](20) NOT NULL,
	[Price] [decimal](16, 2) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NULL,
	[CreatedUser] [varchar](50) NOT NULL,
	[ModifiedUser] [varchar](50) NULL,
 CONSTRAINT [PK_tb_product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tb_customer] ON 

INSERT [dbo].[tb_customer] ([Id], [FirstName], [LastName], [Address], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (1, N'Göksal', N'TAK', N'Çaykara/Dernekpazarı', CAST(N'2021-07-06T12:03:00.000' AS DateTime), CAST(N'2021-07-06T13:39:00.000' AS DateTime), N'Goksaltak', N'gtak6')
INSERT [dbo].[tb_customer] ([Id], [FirstName], [LastName], [Address], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (5, N'Engin', N'Albayrak', N'Ümraniye', CAST(N'2021-07-06T14:43:00.000' AS DateTime), NULL, N'Gtak', NULL)
INSERT [dbo].[tb_customer] ([Id], [FirstName], [LastName], [Address], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (6, N'Gökmen', N'Tak', N'Küçükyalı', CAST(N'2021-07-06T14:50:00.000' AS DateTime), NULL, N'Gtak', NULL)
INSERT [dbo].[tb_customer] ([Id], [FirstName], [LastName], [Address], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (9, N'Derya', N'Altay', N'Yakacık', CAST(N'2021-07-06T14:53:00.000' AS DateTime), NULL, N'Gtak', NULL)
INSERT [dbo].[tb_customer] ([Id], [FirstName], [LastName], [Address], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (13, N'Fatma', N'Uzun', N'Kabataş', CAST(N'2021-07-07T15:28:16.010' AS DateTime), CAST(N'2021-07-07T15:31:51.703' AS DateTime), N'Gtak', N'Gtak')
SET IDENTITY_INSERT [dbo].[tb_customer] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_order] ON 

INSERT [dbo].[tb_order] ([Id], [CustomerId], [OrderAddress], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (2, 1, N'Bahçelievler/İstanbul', CAST(N'2021-07-06T12:03:00.000' AS DateTime), CAST(N'2021-07-06T14:39:00.000' AS DateTime), N'Gtak', N'Gtak')
INSERT [dbo].[tb_order] ([Id], [CustomerId], [OrderAddress], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (7, 5, N'adana', CAST(N'2021-07-06T12:00:00.000' AS DateTime), CAST(N'2021-07-06T12:00:00.000' AS DateTime), N'Gtak', NULL)
INSERT [dbo].[tb_order] ([Id], [CustomerId], [OrderAddress], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (8, 1, N'Bahçelievler/İstanbul', CAST(N'2021-07-07T15:35:01.803' AS DateTime), NULL, N'Gtak', NULL)
INSERT [dbo].[tb_order] ([Id], [CustomerId], [OrderAddress], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (10, 9, N'Bağcılar/İstanbul', CAST(N'2021-07-07T15:36:57.883' AS DateTime), CAST(N'2021-07-07T15:42:19.273' AS DateTime), N'Gtak', N'Gtak')
INSERT [dbo].[tb_order] ([Id], [CustomerId], [OrderAddress], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (11, 5, N'Ankara', CAST(N'2021-07-07T15:37:01.817' AS DateTime), NULL, N'Gtak', NULL)
INSERT [dbo].[tb_order] ([Id], [CustomerId], [OrderAddress], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (13, 9, N'İzmir', CAST(N'2021-07-07T15:37:22.753' AS DateTime), NULL, N'Gtak', NULL)
INSERT [dbo].[tb_order] ([Id], [CustomerId], [OrderAddress], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (14, 13, N'Başakşehir/İstanbul', CAST(N'2021-07-07T15:37:31.513' AS DateTime), CAST(N'2021-07-07T15:42:55.113' AS DateTime), N'Gtak', N'Gtak')
SET IDENTITY_INSERT [dbo].[tb_order] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_orderDetail] ON 

INSERT [dbo].[tb_orderDetail] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (2, 2, 8, 2, CAST(119.90 AS Decimal(16, 2)), CAST(N'2021-07-06T12:03:00.000' AS DateTime), CAST(N'2021-07-06T15:03:00.000' AS DateTime), N'Gtak', N'Gtak')
INSERT [dbo].[tb_orderDetail] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (3, 2, 10, 2, CAST(69.90 AS Decimal(16, 2)), CAST(N'2021-07-06T12:03:00.000' AS DateTime), CAST(N'2021-07-06T12:03:00.000' AS DateTime), N'Gtak', N'Gtak')
INSERT [dbo].[tb_orderDetail] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (4, 7, 5, 1, CAST(69.99 AS Decimal(16, 2)), CAST(N'2021-07-07T15:46:39.727' AS DateTime), NULL, N'Gtak', NULL)
INSERT [dbo].[tb_orderDetail] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (5, 8, 5, 1, CAST(69.99 AS Decimal(16, 2)), CAST(N'2021-07-07T15:47:00.170' AS DateTime), NULL, N'Gtak', NULL)
INSERT [dbo].[tb_orderDetail] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (6, 8, 8, 1, CAST(89.99 AS Decimal(16, 2)), CAST(N'2021-07-07T15:48:06.030' AS DateTime), NULL, N'Gtak', NULL)
INSERT [dbo].[tb_orderDetail] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (7, 10, 8, 1, CAST(89.99 AS Decimal(16, 2)), CAST(N'2021-07-07T15:50:00.330' AS DateTime), NULL, N'Gtak', NULL)
INSERT [dbo].[tb_orderDetail] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (8, 10, 5, 1, CAST(89.99 AS Decimal(16, 2)), CAST(N'2021-07-07T15:50:03.350' AS DateTime), NULL, N'Gtak', NULL)
INSERT [dbo].[tb_orderDetail] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (9, 11, 5, 1, CAST(89.99 AS Decimal(16, 2)), CAST(N'2021-07-07T15:50:07.487' AS DateTime), NULL, N'Gtak', NULL)
INSERT [dbo].[tb_orderDetail] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (10, 13, 5, 1, CAST(89.99 AS Decimal(16, 2)), CAST(N'2021-07-07T15:50:14.170' AS DateTime), NULL, N'Gtak', NULL)
INSERT [dbo].[tb_orderDetail] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (11, 14, 5, 1, CAST(89.99 AS Decimal(16, 2)), CAST(N'2021-07-07T15:50:17.513' AS DateTime), NULL, N'Gtak', NULL)
INSERT [dbo].[tb_orderDetail] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (12, 14, 8, 1, CAST(189.99 AS Decimal(16, 2)), CAST(N'2021-07-07T15:50:23.943' AS DateTime), NULL, N'Gtak', NULL)
SET IDENTITY_INSERT [dbo].[tb_orderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_product] ON 

INSERT [dbo].[tb_product] ([Id], [Barcode], [Description], [Price], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (5, N'4065717562902', N'PNT,REVER-KSA', CAST(69.90 AS Decimal(16, 2)), CAST(N'2021-07-06T07:05:05.147' AS DateTime), NULL, N'OMA', NULL)
INSERT [dbo].[tb_product] ([Id], [Barcode], [Description], [Price], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (8, N'4065717562919', N'PNT,REVER-KSA', CAST(69.90 AS Decimal(16, 2)), CAST(N'2021-07-06T07:05:05.147' AS DateTime), NULL, N'SDM', NULL)
INSERT [dbo].[tb_product] ([Id], [Barcode], [Description], [Price], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (10, N'4065717567167', N'ATL,COOL-SD ', CAST(119.90 AS Decimal(16, 2)), CAST(N'2021-07-06T07:05:05.147' AS DateTime), NULL, N'OMA', NULL)
INSERT [dbo].[tb_product] ([Id], [Barcode], [Description], [Price], [CreatedOn], [ModifiedOn], [CreatedUser], [ModifiedUser]) VALUES (11, N'4065717586588', N'KBN,PARLA', CAST(39.90 AS Decimal(16, 2)), CAST(N'2021-07-06T07:05:05.147' AS DateTime), NULL, N'KBN', NULL)
SET IDENTITY_INSERT [dbo].[tb_product] OFF
GO
ALTER TABLE [dbo].[tb_order]  WITH CHECK ADD  CONSTRAINT [FK_tb_order_tb_customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[tb_customer] ([Id])
GO
ALTER TABLE [dbo].[tb_order] CHECK CONSTRAINT [FK_tb_order_tb_customer]
GO
ALTER TABLE [dbo].[tb_orderDetail]  WITH CHECK ADD  CONSTRAINT [FK_tb_orderDetail_tb_order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[tb_order] ([Id])
GO
ALTER TABLE [dbo].[tb_orderDetail] CHECK CONSTRAINT [FK_tb_orderDetail_tb_order]
GO
ALTER TABLE [dbo].[tb_orderDetail]  WITH CHECK ADD  CONSTRAINT [FK_tb_orderDetail_tb_product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[tb_product] ([Id])
GO
ALTER TABLE [dbo].[tb_orderDetail] CHECK CONSTRAINT [FK_tb_orderDetail_tb_product]
GO
USE [master]
GO
ALTER DATABASE [OMADB] SET  READ_WRITE 
GO
