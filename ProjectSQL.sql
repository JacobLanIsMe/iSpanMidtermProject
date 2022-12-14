USE [master]
GO
/****** Object:  Database [iSpanProject]    Script Date: 2022/8/30 上午 01:05:26 ******/
CREATE DATABASE [iSpanProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'iSpanProject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\iSpanProject.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'iSpanProject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\iSpanProject_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [iSpanProject] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [iSpanProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [iSpanProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [iSpanProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [iSpanProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [iSpanProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [iSpanProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [iSpanProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [iSpanProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [iSpanProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [iSpanProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [iSpanProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [iSpanProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [iSpanProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [iSpanProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [iSpanProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [iSpanProject] SET  ENABLE_BROKER 
GO
ALTER DATABASE [iSpanProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [iSpanProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [iSpanProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [iSpanProject] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [iSpanProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [iSpanProject] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [iSpanProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [iSpanProject] SET RECOVERY FULL 
GO
ALTER DATABASE [iSpanProject] SET  MULTI_USER 
GO
ALTER DATABASE [iSpanProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [iSpanProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [iSpanProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [iSpanProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [iSpanProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [iSpanProject] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'iSpanProject', N'ON'
GO
ALTER DATABASE [iSpanProject] SET QUERY_STORE = ON
GO
ALTER DATABASE [iSpanProject] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [iSpanProject]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
USE [iSpanProject]
GO
/****** Object:  Table [dbo].[AD]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AD](
	[AdID] [int] NOT NULL,
	[AdName] [nvarchar](50) NOT NULL,
	[AdFee] [money] NOT NULL,
 CONSTRAINT [PK_AD] PRIMARY KEY CLUSTERED 
(
	[AdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArguePic]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArguePic](
	[ArguePicID] [int] NOT NULL,
	[ArguementID] [int] NOT NULL,
	[ArguePic] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_ArguePic] PRIMARY KEY CLUSTERED 
(
	[ArguePicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Argument]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Argument](
	[OrderID] [int] NOT NULL,
	[ArgumentID] [int] NOT NULL,
	[ChangeorReturn] [bit] NULL,
	[Reason] [nvarchar](max) NOT NULL,
	[ArgumentTypeID] [int] NOT NULL,
 CONSTRAINT [PK_Argument] PRIMARY KEY CLUSTERED 
(
	[ArgumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArgumentType]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArgumentType](
	[ArgumentTypeID] [int] NOT NULL,
	[ArgumentTypeName] [nvarchar](500) NULL,
 CONSTRAINT [PK_ArgumentType] PRIMARY KEY CLUSTERED 
(
	[ArgumentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BigType]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BigType](
	[BigTypeID] [int] IDENTITY(1,1) NOT NULL,
	[BigTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[BigTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[ProductID] [int] NOT NULL,
	[MemberID] [int] NOT NULL,
	[Comment] [nvarchar](500) NOT NULL,
	[Star] [tinyint] NOT NULL,
	[CommentID] [int] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentPic]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentPic](
	[CommentPicID] [int] NOT NULL,
	[CommentID] [int] NOT NULL,
	[CommentPic] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_CommentPic] PRIMARY KEY CLUSTERED 
(
	[CommentPicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coupons]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coupons](
	[CouponID] [int] IDENTITY(1,1) NOT NULL,
	[CouponName] [nvarchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[ExpiredDate] [date] NOT NULL,
	[Discount] [real] NOT NULL,
 CONSTRAINT [PK_Coupons] PRIMARY KEY CLUSTERED 
(
	[CouponID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FAQ]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAQ](
	[FAQID] [int] NOT NULL,
	[Answer] [nvarchar](500) NOT NULL,
	[Question] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_FAQ] PRIMARY KEY CLUSTERED 
(
	[FAQID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Follows]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Follows](
	[MemberID] [int] NOT NULL,
	[FollowID] [int] NOT NULL,
	[FollowedMemID] [int] NOT NULL,
 CONSTRAINT [PK_Follows] PRIMARY KEY CLUSTERED 
(
	[FollowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Likes]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Likes](
	[MemberID] [int] NOT NULL,
	[LikeID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_Likes] PRIMARY KEY CLUSTERED 
(
	[LikeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberAccount]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberAccount](
	[MemberID] [int] IDENTITY(1,1) NOT NULL,
	[MemberAcc] [nvarchar](10) NOT NULL,
	[MemberPw] [nvarchar](10) NOT NULL,
	[TWorNOT] [bit] NOT NULL,
	[RegionID] [int] NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[BackUpEmail] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NOT NULL,
	[NickName] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Birthday] [date] NOT NULL,
	[Bio] [nvarchar](max) NOT NULL,
	[MemPic] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_MemberAccount] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OfficialCoupons]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfficialCoupons](
	[MemberID] [int] NOT NULL,
	[CouponID] [int] NOT NULL,
	[ExpireN_A] [datetime] NOT NULL,
	[OffCouponsID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Wallet] PRIMARY KEY CLUSTERED 
(
	[OffCouponsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductDetailID] [int] NOT NULL,
	[ShipperID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ShippingDate] [date] NOT NULL,
	[RecieveDate] [datetime] NOT NULL,
	[OutAdr] [nvarchar](50) NOT NULL,
	[ShippingStatusID] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetails_1] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NOT NULL,
	[OrderDatetime] [datetime] NOT NULL,
	[RecieveAdr] [nvarchar](50) NOT NULL,
	[ProductID] [int] NOT NULL,
	[FinishDate] [date] NOT NULL,
	[CouponID] [int] NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentID] [int] NOT NULL,
	[PaymentName] [nvarchar](50) NOT NULL,
	[Fee] [money] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[SmallTypeID] [int] NOT NULL,
	[MemberID] [int] NOT NULL,
	[RegionID] [int] NOT NULL,
	[AdFee] [money] NOT NULL,
	[Description] [nvarchar](600) NOT NULL,
	[ShipperID] [int] NOT NULL,
 CONSTRAINT [PK_Saler] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDetail]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetail](
	[ProductDetailID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Style] [nvarchar](10) NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Pic] [varbinary](max) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductPic]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPic](
	[ProductID] [int] NOT NULL,
	[PicID] [int] NOT NULL,
	[picture] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_ProductPic] PRIMARY KEY CLUSTERED 
(
	[PicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegionList]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegionList](
	[RegionID] [int] IDENTITY(1,1) NOT NULL,
	[Region] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RegionList] PRIMARY KEY CLUSTERED 
(
	[RegionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipper]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipper](
	[ShipperID] [int] IDENTITY(1,1) NOT NULL,
	[ShipperName] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Shipper] PRIMARY KEY CLUSTERED 
(
	[ShipperID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShippingStatuses]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShippingStatuses](
	[ShippingStatusID] [int] IDENTITY(1,1) NOT NULL,
	[ShipStatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ShippingStatuses] PRIMARY KEY CLUSTERED 
(
	[ShippingStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SmallType]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SmallType](
	[SmallTypeID] [int] IDENTITY(1,1) NOT NULL,
	[SmallTypeName] [nvarchar](50) NOT NULL,
	[BigTypeID] [int] NOT NULL,
 CONSTRAINT [PK_SmallType] PRIMARY KEY CLUSTERED 
(
	[SmallTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 2022/8/30 上午 01:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statuses](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_MemberAccount]    Script Date: 2022/8/30 上午 01:05:26 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_MemberAccount] ON [dbo].[MemberAccount]
(
	[MemberAcc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_SalesCourt_AdFee]  DEFAULT ((0)) FOR [AdFee]
GO
ALTER TABLE [dbo].[ArguePic]  WITH CHECK ADD  CONSTRAINT [FK_ArguePic_Argument] FOREIGN KEY([ArguementID])
REFERENCES [dbo].[Argument] ([ArgumentID])
GO
ALTER TABLE [dbo].[ArguePic] CHECK CONSTRAINT [FK_ArguePic_Argument]
GO
ALTER TABLE [dbo].[Argument]  WITH CHECK ADD  CONSTRAINT [FK_Argument_ArgumentType] FOREIGN KEY([ArgumentTypeID])
REFERENCES [dbo].[ArgumentType] ([ArgumentTypeID])
GO
ALTER TABLE [dbo].[Argument] CHECK CONSTRAINT [FK_Argument_ArgumentType]
GO
ALTER TABLE [dbo].[Argument]  WITH CHECK ADD  CONSTRAINT [FK_Argument_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Argument] CHECK CONSTRAINT [FK_Argument_Orders]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_MemberAccount] FOREIGN KEY([MemberID])
REFERENCES [dbo].[MemberAccount] ([MemberID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_MemberAccount]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_SalesCourt] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_SalesCourt]
GO
ALTER TABLE [dbo].[CommentPic]  WITH CHECK ADD  CONSTRAINT [FK_CommentPic_Comment] FOREIGN KEY([CommentID])
REFERENCES [dbo].[Comment] ([CommentID])
GO
ALTER TABLE [dbo].[CommentPic] CHECK CONSTRAINT [FK_CommentPic_Comment]
GO
ALTER TABLE [dbo].[Follows]  WITH CHECK ADD  CONSTRAINT [FK_Follows_MemberAccount] FOREIGN KEY([MemberID])
REFERENCES [dbo].[MemberAccount] ([MemberID])
GO
ALTER TABLE [dbo].[Follows] CHECK CONSTRAINT [FK_Follows_MemberAccount]
GO
ALTER TABLE [dbo].[Follows]  WITH CHECK ADD  CONSTRAINT [FK_Follows_MemberAccount1] FOREIGN KEY([FollowedMemID])
REFERENCES [dbo].[MemberAccount] ([MemberID])
GO
ALTER TABLE [dbo].[Follows] CHECK CONSTRAINT [FK_Follows_MemberAccount1]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_Likes_MemberAccount] FOREIGN KEY([MemberID])
REFERENCES [dbo].[MemberAccount] ([MemberID])
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_Likes_MemberAccount]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_Likes_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_Likes_Product]
GO
ALTER TABLE [dbo].[MemberAccount]  WITH CHECK ADD  CONSTRAINT [FK_MemberAccount_RegionList] FOREIGN KEY([RegionID])
REFERENCES [dbo].[RegionList] ([RegionID])
GO
ALTER TABLE [dbo].[MemberAccount] CHECK CONSTRAINT [FK_MemberAccount_RegionList]
GO
ALTER TABLE [dbo].[OfficialCoupons]  WITH CHECK ADD  CONSTRAINT [FK_OfficialCoupons_Coupons] FOREIGN KEY([CouponID])
REFERENCES [dbo].[Coupons] ([CouponID])
GO
ALTER TABLE [dbo].[OfficialCoupons] CHECK CONSTRAINT [FK_OfficialCoupons_Coupons]
GO
ALTER TABLE [dbo].[OfficialCoupons]  WITH CHECK ADD  CONSTRAINT [FK_Wallet_MemberAccount] FOREIGN KEY([MemberID])
REFERENCES [dbo].[MemberAccount] ([MemberID])
GO
ALTER TABLE [dbo].[OfficialCoupons] CHECK CONSTRAINT [FK_Wallet_MemberAccount]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Product] FOREIGN KEY([ProductDetailID])
REFERENCES [dbo].[ProductDetail] ([ProductDetailID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Product]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Shipper] FOREIGN KEY([ShipperID])
REFERENCES [dbo].[Shipper] ([ShipperID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Shipper]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_ShippingStatuses] FOREIGN KEY([ShippingStatusID])
REFERENCES [dbo].[ShippingStatuses] ([ShippingStatusID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_ShippingStatuses]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Coupons] FOREIGN KEY([CouponID])
REFERENCES [dbo].[Coupons] ([CouponID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Coupons]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_MemberAccount] FOREIGN KEY([MemberID])
REFERENCES [dbo].[MemberAccount] ([MemberID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_MemberAccount]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_SalesCourt] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_SalesCourt]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Statuses] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Statuses] ([StatusID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Statuses]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Shipper] FOREIGN KEY([ShipperID])
REFERENCES [dbo].[Shipper] ([ShipperID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Shipper]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_SmallType] FOREIGN KEY([SmallTypeID])
REFERENCES [dbo].[SmallType] ([SmallTypeID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_SmallType]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_SalesCourt_MemberAccount] FOREIGN KEY([MemberID])
REFERENCES [dbo].[MemberAccount] ([MemberID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_SalesCourt_MemberAccount]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_SalesCourt_RegionList] FOREIGN KEY([RegionID])
REFERENCES [dbo].[RegionList] ([RegionID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_SalesCourt_RegionList]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [FK_Product_SalesCourt] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [FK_Product_SalesCourt]
GO
ALTER TABLE [dbo].[ProductPic]  WITH CHECK ADD  CONSTRAINT [FK_ProductPic_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[ProductPic] CHECK CONSTRAINT [FK_ProductPic_Product]
GO
ALTER TABLE [dbo].[SmallType]  WITH CHECK ADD  CONSTRAINT [FK_SmallType_BigType] FOREIGN KEY([BigTypeID])
REFERENCES [dbo].[BigType] ([BigTypeID])
GO
ALTER TABLE [dbo].[SmallType] CHECK CONSTRAINT [FK_SmallType_BigType]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [CK_ProductQqt0] CHECK  (([Quantity]>=(0)))
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [CK_ProductQqt0]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [CK_ProductUPgt0] CHECK  (([UnitPrice]>=(0)))
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [CK_ProductUPgt0]
GO
USE [master]
GO
ALTER DATABASE [iSpanProject] SET  READ_WRITE 
GO
