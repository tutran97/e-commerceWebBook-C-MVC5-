USE [master]
GO
/****** Object:  Database [QuanLyBanSach]    Script Date: 7/5/2019 6:28:58 PM ******/
CREATE DATABASE [QuanLyBanSach]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyBanSach', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyBanSach.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyBanSach_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyBanSach_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyBanSach] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyBanSach].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyBanSach] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyBanSach] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyBanSach] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyBanSach] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyBanSach] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyBanSach] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyBanSach] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyBanSach] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyBanSach] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyBanSach] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyBanSach] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyBanSach', N'ON'
GO
USE [QuanLyBanSach]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 7/5/2019 6:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[MaDonHang] [int] NOT NULL,
	[MaSach] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [float] NULL,
 CONSTRAINT [PK_ChiTietDonHang] PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietGioHang]    Script Date: 7/5/2019 6:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietGioHang](
	[MaGioHang] [int] NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietGioHang] PRIMARY KEY CLUSTERED 
(
	[MaGioHang] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChuDe]    Script Date: 7/5/2019 6:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuDe](
	[MaChuDe] [int] IDENTITY(1,1) NOT NULL,
	[TenChuDe] [nvarchar](50) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_ChuDe] PRIMARY KEY CLUSTERED 
(
	[MaChuDe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 7/5/2019 6:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDonHang] [int] IDENTITY(1,1) NOT NULL,
	[TinhTrangGiaoHang] [bit] NULL,
	[NgayDat] [datetime] NULL,
	[NgayGiao] [datetime] NULL,
	[MaKH] [int] NULL,
	[HoTen] [nvarchar](50) NULL,
	[SDT] [varchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](200) NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 7/5/2019 6:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[MaGioHang] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NULL,
	[NgayTao] [datetime] NOT NULL,
 CONSTRAINT [PK_GioHang] PRIMARY KEY CLUSTERED 
(
	[MaGioHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 7/5/2019 6:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[TaiKhoan] [varchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[DienThoai] [varchar](50) NULL,
	[GioiTinh] [nchar](3) NULL,
	[NgaySinh] [datetime] NULL,
	[TrangThai] [bit] NULL,
	[MaLoaiKH] [int] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiKhachHang]    Script Date: 7/5/2019 6:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiKhachHang](
	[MaLoaiKH] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_LoaiKhachHang] PRIMARY KEY CLUSTERED 
(
	[MaLoaiKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 7/5/2019 6:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhaXuatBan](
	[MaNXB] [int] IDENTITY(1,1) NOT NULL,
	[TenNXB] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[DienThoai] [varchar](50) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_NhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[MaNXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 7/5/2019 6:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [int] IDENTITY(1,1) NOT NULL,
	[TenSach] [nvarchar](max) NULL,
	[GiaBan] [float] NULL,
	[MoTa] [nvarchar](max) NULL,
	[AnhBia] [nvarchar](50) NULL,
	[NgayCapNhat] [datetime] NULL CONSTRAINT [DF_Sach_NgayCapNhat]  DEFAULT (getdate()),
	[MaTacGia] [int] NULL,
	[SoLuongTon] [int] NULL,
	[MaNXB] [int] NULL,
	[MaChuDe] [int] NULL,
	[TrangThai] [bit] NULL,
	[GiaGiam] [float] NULL,
	[GiaCu] [float] NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 7/5/2019 6:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TacGia](
	[MaTacGia] [int] IDENTITY(1,1) NOT NULL,
	[TenTacGia] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](200) NULL,
	[TieuSu] [nvarchar](max) NULL,
	[DienThoai] [varchar](50) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_TacGia] PRIMARY KEY CLUSTERED 
(
	[MaTacGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (60, 48, 1, 10000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (60, 58, 1, 20000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (61, 48, 1, 10000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (62, 62, 30, 25000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (62, 69, 21, 75000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (63, 69, 1, 75000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (64, 59, 1, 20000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (64, 60, 1, 20000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (64, 65, 1, 15000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (65, 62, 1, 25000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (66, 62, 2, 25000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (67, 69, 1, 75000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (68, 69, 1, 75000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (69, 62, 1, 25000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (70, 69, 1, 75000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (71, 69, 1, 75000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (72, 69, 1, 75000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (73, 69, 1, 75000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (74, 68, 2, 90000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (75, 69, 1, 75000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (76, 69, 1, 75000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (77, 68, 2, 90000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (78, 69, 1, 75000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (79, 69, 1, 75000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (80, 68, 2, 90000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (81, 69, 1, 75000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (82, 69, 1, 75000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (83, 68, 1, 90000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (84, 68, 1, 90000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (85, 64, 1, 60000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (85, 65, 1, 15000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (85, 69, 1, 75000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (85, 93, 1, 26600)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (86, 99, 1, 55000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (87, 117, 2, 10000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (87, 118, 1, 10000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (87, 119, 1, 10000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (88, 112, 1, 65000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (88, 113, 2, 62000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (89, 114, 1, 69000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (89, 115, 1, 70000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (90, 118, 2, 10000)
INSERT [dbo].[ChiTietDonHang] ([MaDonHang], [MaSach], [SoLuong], [DonGia]) VALUES (91, 121, 1, 25000)
SET IDENTITY_INSERT [dbo].[ChuDe] ON 

INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [TrangThai]) VALUES (17, N'TRUYỆN TRANH', 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [TrangThai]) VALUES (18, N'GIÁO DỤC', 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [TrangThai]) VALUES (19, N'TIỂU THUYẾT', 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [TrangThai]) VALUES (21, N'SÁCH GIÁO KHOA', 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [TrangThai]) VALUES (22, N'KHOA HỌC', 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [TrangThai]) VALUES (23, N'NGOẠI NGỮ', 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [TrangThai]) VALUES (24, N'TIN HỌC', 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [TrangThai]) VALUES (25, N'CÔNG NGHỆ', 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [TrangThai]) VALUES (26, N'SỨC KHỎE', 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [TrangThai]) VALUES (27, N'TÂM LÝ - KỸ NĂNG SỐNG', 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [TrangThai]) VALUES (28, N'KINH TẾ', 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [TrangThai]) VALUES (30, N'TÔ MÀU - LUYỆN CHỮ', 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [TrangThai]) VALUES (31, N'NUÔI DẠY CON', 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [TrangThai]) VALUES (32, N'LỊCH SỬ - ĐỊA LÝ', 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [TrangThai]) VALUES (33, N'VĂN HỌC', 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [TrangThai]) VALUES (35, N'KHÁC', 1)
SET IDENTITY_INSERT [dbo].[ChuDe] OFF
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (60, 0, CAST(N'2019-06-21 00:12:01.237' AS DateTime), NULL, NULL, N'tên mua hàng A', N'0961421396', N'a@gmail.com', N'123tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (61, 0, CAST(N'2019-06-21 00:12:53.427' AS DateTime), NULL, 1, N'tú trần', N'0961421396', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (62, 0, CAST(N'2019-06-21 13:49:17.450' AS DateTime), NULL, 1, N'tú trần', N'0961421396', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (63, 0, CAST(N'2019-06-21 16:38:30.383' AS DateTime), NULL, 1, N'tú trần', N'0961421396', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (64, 0, CAST(N'2019-06-22 10:09:31.843' AS DateTime), NULL, 1, N'tú trần', N'0961421396', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (65, 0, CAST(N'2019-06-24 21:55:41.587' AS DateTime), NULL, NULL, N'tu24-6', N'0961421396', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (66, 1, CAST(N'2019-06-24 21:56:15.907' AS DateTime), NULL, 1, N'tú trần', N'0961421396', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (67, 1, CAST(N'2019-06-25 11:28:51.083' AS DateTime), NULL, 1, N'tú trần', N'0961421396', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (68, 1, CAST(N'2019-06-25 11:31:35.203' AS DateTime), NULL, 17, N'abc', N'321', N'aaaaaaa@gmail.com', N'123')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (69, 1, CAST(N'2019-06-25 11:44:48.883' AS DateTime), NULL, NULL, N'nguyễn văn A', N'0961421396', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (70, 1, CAST(N'2019-06-25 17:06:00.867' AS DateTime), NULL, 1, N'tú trần', N'0961421396', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (71, 1, CAST(N'2019-06-25 17:07:46.673' AS DateTime), NULL, NULL, N'tú', N'0961421396', N'a@gmail.com', N'12asda')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (72, 1, CAST(N'2019-06-25 17:10:40.473' AS DateTime), NULL, 1, N'tú trần', N'0961421396', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (73, 1, CAST(N'2019-06-25 17:18:26.987' AS DateTime), NULL, 1, N'tú trần', N'0961421396', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (74, 1, CAST(N'2019-06-25 18:02:52.260' AS DateTime), NULL, 17, N'abc', N'321', N'aaaaaaa@gmail.com', N'123')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (75, 1, CAST(N'2019-06-25 18:06:59.597' AS DateTime), NULL, 1, N'tú trần', N'0961421396', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (76, 1, CAST(N'2019-06-25 18:07:13.767' AS DateTime), NULL, 17, N'abc', N'321', N'aaaaaaa@gmail.com', N'123')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (77, 1, CAST(N'2019-06-25 18:07:53.537' AS DateTime), NULL, 17, N'abc', N'321', N'aaaaaaa@gmail.com', N'123')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (78, 1, CAST(N'2019-06-25 18:10:50.367' AS DateTime), NULL, 1, N'tú trần', N'0961421396', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (79, 1, CAST(N'2019-06-25 18:11:18.810' AS DateTime), NULL, NULL, N'tú123', N'0961421396', N'a@gmail.com', N'123 asda')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (80, 0, CAST(N'2019-06-25 18:12:05.853' AS DateTime), NULL, 1, N'tú trần', N'0961421396', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (81, 1, CAST(N'2019-06-26 12:36:20.923' AS DateTime), NULL, 1, N'tú trần', N'0961421396', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (82, 1, CAST(N'2019-06-26 12:37:42.740' AS DateTime), NULL, 17, N'abc', N'321', N'aaaaaaa@gmail.com', N'123')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (83, 1, CAST(N'2019-06-26 14:41:18.303' AS DateTime), NULL, NULL, N'nguyen van B', N'0123456789', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (84, 0, CAST(N'2019-06-26 14:42:49.800' AS DateTime), NULL, NULL, N'nguyen van c', N'0961421396', N'a@gmail.com', N'123 asda')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (85, 0, CAST(N'2019-06-26 21:53:54.897' AS DateTime), NULL, NULL, N'test26/6', N'0123456789', N'taikhoana@gmail.com', N'123 le loi p1 q10 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (86, 1, CAST(N'2019-06-27 10:08:53.060' AS DateTime), NULL, 1, N'tú trần', N'0961421396', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (87, 1, CAST(N'2019-06-28 15:01:47.097' AS DateTime), NULL, NULL, N'Duy Quang', N'0842618847', N'quang@gmail.com', N'so11 võ thị sáu p1 Q3 tpHCM')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (88, 0, CAST(N'2019-07-04 16:55:03.097' AS DateTime), NULL, NULL, N'trần thanh tú', N'0961421396', N'xichlong19997@gmail.com', N'931tran hung dao p1 q5 tphcm')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (89, 1, CAST(N'2019-07-04 16:55:48.340' AS DateTime), NULL, 21, N'nguyễn văn A', N'0923456789', N'taikhoan1@gmail.com', N'so111 duong Phuong Quan tp HCM')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (90, 1, CAST(N'2019-07-04 20:40:50.710' AS DateTime), NULL, NULL, N'tú trần', N'0961421396', N'abc@gmail.com', N'Đức Hòa Thượng,Huyện Đức Hòa,Tỉnh Long An')
INSERT [dbo].[DonHang] ([MaDonHang], [TinhTrangGiaoHang], [NgayDat], [NgayGiao], [MaKH], [HoTen], [SDT], [Email], [DiaChi]) VALUES (91, 0, CAST(N'2019-07-04 22:25:02.447' AS DateTime), NULL, 21, N'nguyễn văn A', N'0923456789', N'taikhoan1@gmail.com', N'so111 duong Phuong Quan tp HCM')
SET IDENTITY_INSERT [dbo].[DonHang] OFF
SET IDENTITY_INSERT [dbo].[GioHang] ON 

INSERT [dbo].[GioHang] ([MaGioHang], [MaKH], [NgayTao]) VALUES (29, NULL, CAST(N'2019-06-19 23:08:09.627' AS DateTime))
INSERT [dbo].[GioHang] ([MaGioHang], [MaKH], [NgayTao]) VALUES (30, NULL, CAST(N'2019-06-21 00:22:00.970' AS DateTime))
INSERT [dbo].[GioHang] ([MaGioHang], [MaKH], [NgayTao]) VALUES (31, NULL, CAST(N'2019-06-22 10:06:59.610' AS DateTime))
INSERT [dbo].[GioHang] ([MaGioHang], [MaKH], [NgayTao]) VALUES (32, NULL, CAST(N'2019-06-22 10:07:43.127' AS DateTime))
INSERT [dbo].[GioHang] ([MaGioHang], [MaKH], [NgayTao]) VALUES (33, NULL, CAST(N'2019-06-25 11:26:18.300' AS DateTime))
INSERT [dbo].[GioHang] ([MaGioHang], [MaKH], [NgayTao]) VALUES (34, NULL, CAST(N'2019-06-25 11:26:55.407' AS DateTime))
INSERT [dbo].[GioHang] ([MaGioHang], [MaKH], [NgayTao]) VALUES (35, NULL, CAST(N'2019-06-25 11:27:51.100' AS DateTime))
INSERT [dbo].[GioHang] ([MaGioHang], [MaKH], [NgayTao]) VALUES (36, NULL, CAST(N'2019-07-04 20:24:08.580' AS DateTime))
SET IDENTITY_INSERT [dbo].[GioHang] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [DiaChi], [DienThoai], [GioiTinh], [NgaySinh], [TrangThai], [MaLoaiKH]) VALUES (1, N'tú trần', N'admin', N'e10adc3949ba59abbe56e057f20f883e', N'abc@gmail.com', N'931tran hung dao p1 q5 tphcm', N'0961421396', N'nữ ', CAST(N'1997-09-19 00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [DiaChi], [DienThoai], [GioiTinh], [NgaySinh], [TrangThai], [MaLoaiKH]) VALUES (17, N'abc', N'abc', N'e10adc3949ba59abbe56e057f20f883e', N'abc@gmail.com', N'so123 đường xã phường quận tphcm', N'0987654321', N'nữ ', CAST(N'1997-04-17 00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [DiaChi], [DienThoai], [GioiTinh], [NgaySinh], [TrangThai], [MaLoaiKH]) VALUES (20, N'tutran', N'taikhoan', N'4297f44b13955235245b2497399d7a93', N'zxc@gmail.com', N'123 xa duoc hoa thuong, huyen duoc hoa,long an', N'0961421397', N'nu ', CAST(N'1997-11-11 00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [DiaChi], [DienThoai], [GioiTinh], [NgaySinh], [TrangThai], [MaLoaiKH]) VALUES (21, N'nguyễn văn A', N'taikhoan1', N'e10adc3949ba59abbe56e057f20f883e', N'taikhoan1@gmail.com', N'so111 duong Phuong Quan tp HCM', N'0923456789', N'nam', CAST(N'1996-05-07 00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [DiaChi], [DienThoai], [GioiTinh], [NgaySinh], [TrangThai], [MaLoaiKH]) VALUES (22, N'Trần Thanh Tú', N'taikhoan2', N'e10adc3949ba59abbe56e057f20f883e', N'tutran@gmail.com', N'Đức Hòa Thượng,Huyện Đức Hòa,Tỉnh Long An', N'0982618837', N'nữ ', CAST(N'1998-04-04 00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [DiaChi], [DienThoai], [GioiTinh], [NgaySinh], [TrangThai], [MaLoaiKH]) VALUES (23, N'Phạm Phú Duy Quang', N'quangpham', N'2dd1fc44cbddfdb49c15bf820f428b13', N'quangpham@gmail.com', N'Miami', N'0420 420 420', N'Nam', CAST(N'2019-06-03 21:01:39.137' AS DateTime), 1, 1)
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [DiaChi], [DienThoai], [GioiTinh], [NgaySinh], [TrangThai], [MaLoaiKH]) VALUES (24, N'Trân Văn Ba', N'taikhoan3', N'e10adc3949ba59abbe56e057f20f883e', N'taikhoan3@gmail.com', N'123 le loi p1 q10 tphcm', N'0123456789', N'nữ ', CAST(N'1994-07-07 00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [DiaChi], [DienThoai], [GioiTinh], [NgaySinh], [TrangThai], [MaLoaiKH]) VALUES (25, N'trần văn bốn', N'taikhoan4', N'e10adc3949ba59abbe56e057f20f883e', N'taikhoan4@gmail.com', N'Đức Hòa Thượng,Huyện Đức Hòa,Tỉnh Long An', N'0962145963', N'nữ ', CAST(N'1997-07-07 00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [DiaChi], [DienThoai], [GioiTinh], [NgaySinh], [TrangThai], [MaLoaiKH]) VALUES (26, N'nguyễn văn năm', N'taikhoan5', N'e10adc3949ba59abbe56e057f20f883e', N'taikhoan5@gmail.com', N'Đức Hòa Thượng,Huyện Đức Hòa,Tỉnh Long An', N'0965123654', N'nam', CAST(N'1998-08-08 00:00:00.000' AS DateTime), 0, 2)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[LoaiKhachHang] ON 

INSERT [dbo].[LoaiKhachHang] ([MaLoaiKH], [TenLoai], [TrangThai]) VALUES (1, N'admin', 1)
INSERT [dbo].[LoaiKhachHang] ([MaLoaiKH], [TenLoai], [TrangThai]) VALUES (2, N'user', 1)
SET IDENTITY_INSERT [dbo].[LoaiKhachHang] OFF
SET IDENTITY_INSERT [dbo].[NhaXuatBan] ON 

INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai], [TrangThai]) VALUES (8, N'ĐH SƯ PHẠM TP.HCM', N'‎280 An Dương Vương hcm', N'0123456789', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai], [TrangThai]) VALUES (9, N'Kim Đồng', N'55 Quang Trung, Nguyễn Du, Hai Bà Trưng, Hà Nội', N'0243 943 4490', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai], [TrangThai]) VALUES (10, N'NXB Đà Nẵng', N'Số 108 Bạch Đằng, Q.Hải Châu, TP.Đà Nẵng', N'0236 381 2964', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai], [TrangThai]) VALUES (11, N'NXB Tổng Hợp TPHCM', N'62 Nguyễn Thị Minh Khai, Đa Kao, Quận 1, Hồ Chí Minh', N'028 3822 5340', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai], [TrangThai]) VALUES (12, N'NXB Trẻ', N'161B Lý Chính Thắng, Phường 7, Quận 3, Hồ Chí Minh', N'028 3931 6289', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai], [TrangThai]) VALUES (13, N'NXB Thế Giới', N'7 Nguyễn Thị Minh Khai, Bến Nghé, Quận 1, Hồ Chí Minh', N'028 3822 0102', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai], [TrangThai]) VALUES (14, N'NXB Giáo Dục Việt Nam', N'Số 81 Trần Hưng Đạo, Hoàn Kiếm, Hà Nội ', N'0243 8220 801', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai], [TrangThai]) VALUES (15, N'Trí Việt - First News', N'11H Nguyễn Thị Minh Khai, Bến Nghé, Quận 1, Hồ Chí Minh', N'028 3822 7979', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai], [TrangThai]) VALUES (16, N'Nhã Nam', N' 59 Đỗ Quang, phường Trung Hoà, quận Cầu Giấy, Hà Nội ', N'090 324 4248 ', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai], [TrangThai]) VALUES (17, N'NXB Văn Học', NULL, NULL, 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai], [TrangThai]) VALUES (18, N'NXB Phụ Nữ', NULL, NULL, 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai], [TrangThai]) VALUES (19, N'Hồng Bàng', NULL, NULL, 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai], [TrangThai]) VALUES (20, N'NXB Dân Trí', NULL, NULL, 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai], [TrangThai]) VALUES (22, N'KHÁC', N'nothing', N'0961421396', 1)
SET IDENTITY_INSERT [dbo].[NhaXuatBan] OFF
SET IDENTITY_INSERT [dbo].[Sach] ON 

INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (48, N'Thần đồng đất Việt - Tập 1: Pháp sư gọi bưởi', 10000, N'Tập 1: Pháp sư gọi bưởi', N'Than_dong_dat_viet1.jpg', CAST(N'2019-06-20 00:00:00.000' AS DateTime), 9, 48, 8, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (49, N'Thần đồng đất Việt - Tập 3: Voi đất biết đi', 10000, N'Tập 3: Voi đất biết đi', N'tddv-t3.jpg', CAST(N'2019-06-20 00:00:00.000' AS DateTime), 9, 50, 8, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (50, N'Thần Đồng Đất Việt - Tập 4: Thánh chỉ bằng đá', 10000, N'Tập 4: Thánh chỉ bằng đá', N'tddv-t4.jpg', CAST(N'2019-06-20 00:00:00.000' AS DateTime), 9, 50, 8, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (51, N'Thần Đồng Đất Việt - Tập 5: Dấu tay xóa nợ', 10000, N' Tập 5: Dấu tay xóa nợ', N'tddv-t4 (1).jpg', CAST(N'2019-06-20 00:00:00.000' AS DateTime), 9, 20, 8, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (52, N'Thần Đồng Đất Việt - Tập 6: Hạ gục thầy đồ', 10000, N'Tập 6: Hạ gục thầy đồ', N'tddv-t6.jpg', CAST(N'2019-06-20 00:00:00.000' AS DateTime), 9, 30, 8, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (53, N'Thần Đồng Đất Việt - Tập 7: Trừng trị gian thương', 10000, N'Tập 7: Trừng trị gian thương', N'untitled-1.jpg', CAST(N'2019-06-20 00:00:00.000' AS DateTime), 9, 20, 8, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (54, N'Thần Đồng Đất Việt - Tập 8: Món ăn hạnh phúc', 10000, N'Tập 8: Món ăn hạnh phúc', N'5zdwx8p.jpg', CAST(N'2019-06-20 00:00:00.000' AS DateTime), 9, 30, 8, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (55, N'Thần Đồng Đất Việt - Tập 9: Thầy đồ mắc nạn', 10000, N' Tập 9: Thầy đồ mắc nạn', N'than-dong-dat-viet-9-thay-do-mac-nan_1406_1043.png', CAST(N'2019-06-20 00:00:00.000' AS DateTime), 9, 20, 8, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (56, N'Thần Đồng Đất Việt - Tập 10: Thắng đại lực sĩ', 10000, N'Tập 10: Thắng đại lực sĩ', N'than-dong-dat-viet-tap-10_1_2.jpg', CAST(N'2019-06-20 00:00:00.000' AS DateTime), 9, 30, 8, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (57, N'Thần Đồng Đất Việt - Tập 11: Đồng tiền hạnh phúc', 10000, N'Tập 11: Đồng tiền hạnh phúc', N'tddv-t11.jpg', CAST(N'2019-06-20 00:00:00.000' AS DateTime), 9, 20, 8, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (58, N'NARUTO - TẬP 1', 20000, N'Chuyện xảy ra ở làng Lá với nhân vật chính là Naruto, học sinh trường đào tạo Ninja, chuyên đi quấy rối khắp làng!!Naruto có một ước mơ to lớn là đạt được danh hiệu Hokage - Một vị trí dành cho Ninja ưu tú nhất - Và vượt qua các Ninja tiền nhiệm.Tuy nhiên, bí mật về thân thế của Naruto là..', N'naruto1-2-page-001.jpg', CAST(N'2019-06-21 00:00:00.000' AS DateTime), 10, 29, 9, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (59, N'NARUTO TẬP 2: VỊ KHÁCH KHÓ ƯA ', 20000, N'Naruto là một trong những series truyện tranh nổi tiếng nhất Nhật Bản. Cùng với Dragon Ball và One Piece, Bleach…, tác phẩm đã sớm vươn ra ngoài thế giới và trở thành một trong những “tượng đài” trong lòng độc giả.. Chuyện xảy ra ở làng Lá với nhân vật chính là Naruto, học sinh trường đào tạo Ninja, chuyên đi quấy rối khắp làng!! Naruto có một ước mơ to lớn là ..', N'naruto1-2-page-001.jpg', CAST(N'2019-06-21 00:00:00.000' AS DateTime), 10, 29, 9, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (60, N'NARUTO - TẬP 3', 20000, N'Chuyện xảy ra ở làng Lá với nhân vật chính là Naruto, học sinh trường đào tạo Ninja, chuyên đi quấy rối khắp làng!!Naruto có một ước mơ to lớn là đạt được danh hiệu Hokage - Một vị trí dành cho Ninja ưu tú nhất - Và vượt qua các Ninja tiền nhiệm.Tuy nhiên, bí mật về thân thế của Naruto là…!', N'naruto---tap-3_1_2.jpg', CAST(N'2019-06-21 00:00:00.000' AS DateTime), 10, 29, 9, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (61, N'NARUTO TẬP 4: CÂY CẦU MANG TÊN NGƯỜI ANH HÙNG!!', 20000, N'Naruto là một trong những series truyện tranh nổi tiếng nhất Nhật Bản. Cùng với Dragon Ball và One Piece, Bleach…, tác phẩm đã sớm vươn ra ngoài thế giới và trở thành một trong những “tượng đài” trong lòng độc giả.. Chuyện xảy ra ở làng Lá với nhân vật chính là Naruto, học sinh trường đào tạo Ninja, chuyên đi quấy rối khắp làng!! Naruto có một ước mơ to lớn là .', N'image_187313.jpg', CAST(N'2019-06-21 00:00:00.000' AS DateTime), 10, 30, 9, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (62, N'LUYỆN VIẾT VÀ HỌC TỪ VỰNG TIẾNG ANH - LỚP 1 (THEO GIÁO TRÌNH FAMILY ANH FRIENDS)', 25000, N'Luyện viết và học từ vựng tiếng anh lớp 1, là vở bài tập được biên soạn theo giáo trình Family and  Friends (special edition) của nhà xuất bản Giáo Dục Việt Nam kết hợp với nhà sản xuất Oxford.. Cuốn sách được biên soạn nhằm giúp các em học sinh lớp 1 bước đầu làm quen với các từ vựng tiếng anh đơn giản. Các em sẽ luyện viết và học từ tiếng anh bằng các hình ảnh minh ..', N'image_180164_1_5.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 11, 16, 10, 23, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (63, N'LUYỆN VIẾT VÀ HỌC TỪ VỰNG TIẾNG ANH 2', 30000, N'Luyện Viết Và Học Từ Vựng Tiếng Anh 2', N'1540630112531.jpeg', CAST(N'2019-06-21 00:00:00.000' AS DateTime), 11, 20, 10, 23, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (64, N'ĐI TÌM LẼ SỐNG (TÁI BẢN 2018)', 60000, N'Đi Tìm Lẽ Sống (Tái Bản 2018). Cuốn sách ĐI TÌM LẼ SỐNG theo Harold S. Kushner: “Đây đúng là một trong những cuốn sách kinh điển của thời đại”. Tác giả Viktor E. Frankl (1905-1997) và cả gia đình bị phát xít Đức bắt. Năm 1945 khi được giải thoát khỏi trại tập trung, ông là người duy nhất sống sót trong gia đình. Ông làm việc tại Vienna với tư cách .', N'ditimlesong20161.u84.d20161125.t134037.152104.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 12, 19, 11, 19, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (65, N'DORAEMON TRUYỆN NGẮN - TẬP 1 ', 15000, N'Chuyện nổi tiếng về chú mèo máy thông minh Doraemon và các bạn', N'doremon1.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 13, 28, 9, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (66, N'DORAEMON: NGÔI NHÀ NHỎ TRÊN NÚI BĂNG TO', 35000, N'Doraemon là bộ truyện tranh Nhật Bản được họa sĩ Fujiko F Fujio sáng tác từ năm 1969. Sau đó, tác phẩm được chuyển thể thành các tập phim hoạt hình ngắn, dài cùng các thể loại khác như kịch, trò chơi điện tử và sách tranh. Bộ truyện kể về một chú mèo máy tên là Doraemon đến từ thế kỉ 22 để giúp một cậu bé hậu đậu tên là Nobita.. Doraemon  ..', N'image_185917.jpg', CAST(N'2016-06-22 00:00:00.000' AS DateTime), 13, 30, 9, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (67, N'DORAEMON TẬP 21: NOBITA VÀ NHỮNG DŨNG SĨ CÓ CÁNH', 15000, N'Mỗi tập truyện là một cuộc phưu lưu khám phá những chân trời mới lạ. Hãy để trí tưởng tượng của bạn bay bổng cùng nhóm bạn Doraemon, Nobita, Shizuka, Jaian, Suneo đến các vùng đất xa xôi, kì bí và cảm nhận những khoảnh khắc tình bạn tươi đẹp của cuộc đời!. 24 tập Doraemon truyện dài phiên bản mới với nội dung và hình thức trung thành với nguyên tác của hoạ ..', N'image_183236.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 13, 20, 9, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (68, N'D.TRUMP NGHỆ THUẬT ĐÀM PHÁN', 90000, N'D.Trump Nghệ Thuật Đàm Phán. Quyển sách cho chúng ta thấy cách Trump làm việc mỗi ngày - cách ông điều hành công việc kinh doanh và cuộc sống - cũng như cách ông trò chuyện với bạn bè và gia đình, làm ăn với đối thủ, mua thành công những sòng bạc hàng đầu ở thành phố Atlantic, thay đổi bộ mặt của những cao ốc ở thành phố New York...', N'trump.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 14, 2, 12, 19, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (69, N'LÀ NGƯỜI PHỤ NỮ NHƯ TÔI MONG MUỐN', 75000, N'Là Người Phụ Nữ Như Tôi Mong Muốn. Câu chuyện cuộc đời của nữ cường nhân đình đám trong làng thời trang thế giới. Diane von Furstenberg được mệnh danh là nhà thiết kế có tầm ảnh hưởng nhất nhì làng thời trang đương đại - "mẹ đẻ" của chiếc đầm quấn (wrap dress) huyền thoại làm mê say biết bao phụ nữ trong suốt hơn 4 thập kỷ qua..', N'l_ng_i_ph_n_nh_t_i_mong_mu_n_full.png', CAST(N'2019-06-23 00:00:00.000' AS DateTime), 15, 1, 13, 19, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (70, N'TIỀN KHÔNG MUA ĐƯỢC GÌ?', 85000, N'rong cuốn sách này, Michael J. Sandel đặt ra một trong những câu hỏi về đạo đức quan trọng nhất của thời đại chúng ta: có vấn đề gì đang xảy ra với thế giới này khi mọi thứ đều có thể mua được bằng tiền? Làm sao chúng ta có thể ngăn các giá trị thị trường khỏi xâm nhập vào những lĩnh vực của đời sống vốn không bị chi phối bởi các giá trị thị trường? Đâu là giới hạn đạo đức của thị trường?

Trong những thập niên gần đây, các giá trị thị trường ngày càng lấn át các chuẩn mực phi thị trường trong hầu hết các mặt đời sống. Sandel lập luận rằng, nếu chúng ta không sớm nhận ra điều này, chúng ta sẽ biến từ có một nền kinh tế thị trường sang trở thành một nền kinh tế thị trường.

Trong Phải trái đúng sai, Sandel đã cho thấy khả năng bậc thầy trong việc mô tả một cách sáng tỏ mà hùng hồn những vấn đề đạo đức hóc búa mà chúng ta phải đối mặt trong cuộc sống hàng ngày. Giờ đây, trong Tiền không mua được gì?, tác giả lại một lần nữa làm dấy lên cuộc tranh luận mà kỷ nguyên do thị trường định hướng của chúng ta chưa nghĩ tới, đó là: vai trò đích thực của thị trường trong một xã hội dân chủ là gì, và chúng ta phải làm gì để bảo vệ các giá trị đạo đức mà thị trường không coi trọng và tiền không thể mua được? ', N'tien-khong-mua-duoc-gi.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 22, 266, 12, 27, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (71, N'ĐI TÌM LẼ SỐNG (TÁI BẢN)', 60000, N'Cuốn sách ĐI TÌM LẼ SỐNG theo Harold S. Kushner: “Đây đúng là một trong những cuốn sách kinh điển của thời đại”. Tác giả Viktor E. Frankl (1905-1997) và cả gia đình bị phát xít Đức bắt. Năm 1945 khi được giải thoát khỏi trại tập trung, ông là người duy nhất sống sót trong gia đình. Ông làm việc tại Vienna với tư cách chuyên gia tâm thần học chữa trị cho các nạn nhân chiến tranh. Năm 1946, chỉ trong 9 ngày ông viết xong ĐI TÌM LẼ SỐNG. Ông được mời diễn thuyết khắp các châu lục, giảng dạy tại các trường đại học như Harvard, Stanford, Pittsburgh...  

Cuốn sách kể về những ngày ông sống trong trại tập trung Đức quốc xã - là cơn ác mộng của con người, là sự khốn cùng của thể xác và tâm hồn. Đâu là con đường sống sót trong những giây phút hoang mang, sợ hãi, đớn đau, mất hi vọng, và lầm lạc lẽ sống... Người trở về được thì sao? Trở về và biết rằng không còn ai chờ đợi mình, trở về với những vết sẹo tâm hồn, những giằng xé nội tâm, những ẩn ức tâm lý và hoàn toàn mất đi lẽ sống, rồi sẽ bị biến dạng nhân tính, trở nên cay đắng với cuộc đời.

Với tư cách là một bác sĩ tâm lý, sau khi trải qua cảnh địa ngục trần gian đó, Viktor E. Frankl kết luận ngay cả trong hoàn cảnh vô nghĩa, đau đớn, và nhẫn tâm nhất, cuộc sống vẫn tiềm ẩn ý nghĩa. Ông dạy mình và người khác không bao giờ được quên rằng chúng ta vẫn có thể tìm thấy ý nghĩa của cuộc đời ngay cả khi đối diện với một tình huống vô vọng, một số phận không thể thay đổi. Bởi lẽ, ý nghĩa của cuộc sống có thể tìm thấy trong mọi khoảnh khắc cuộc sống không bao giờ mất hết ý nghĩa, ngay cả khi phải chịu đau đớn và cái chết.    

ĐI TÌM LẼ SỐNG đã trở thành một cuốn sách kinh điển và sẽ luôn là phương thuốc hữu hiệu nâng đỡ tinh thần con người, nhất là trong cuộc sống ngày nay. Khi đối mặt với cảm giác tuyệt vọng vì mất đi tất cả, hãy nhớ rằng đã có những người như Frankl.     ', N'ditimlesong20161.u84.d20161125.t134037.152104.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 12, 554, 11, 27, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (72, N'ĐỜI NGẮN ĐỪNG NGỦ DÀI (TÁI BẢN 2018)', 60000, N'“Mọi lựa chọn đều giá trị. Mọi bước đi đều quan trọng. Cuộc sống vẫn diễn ra theo cách của nó, không phải theo cách của ta. Hãy kiên nhẫn. Tin tưởng. Hãy giống như người thợ cắt đá, đều đặn từng nhịp, ngày qua ngày. Cuối cùng, một nhát cắt duy nhất sẽ phá vỡ tảng đá và lộ ra viên kim cương. Người tràn đầy nhiệt huyết và tận tâm với việc mình làm không bao giờ bị chối bỏ. Sự thật là thế.”

Bằng những lời chia sẻ thật ngắn gọn, dễ hiểu về những trải nghiệm và suy ngẫm trong đời, Robin Sharma tiếp tục phong cách viết của ông từ cuốn sách Điều vĩ đại đời thường để mang đến cho độc giả những bài viết như lời tâm sự, vừa chân thành vừa sâu sắc.', N'dungngu.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 21, 129, 12, 27, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (73, N'TRÊN ĐƯỜNG BĂNG (TÁI BẢN 2017)', 56000, N'TRÊN ĐƯỜNG BĂNG là cuốn sách tập hợp những bài viết truyền cảm hứng và hướng dẫn kỹ năng cho các bạn trẻ khi chuẩn bị bước vào đời.

Cuốn Trên Đường Băng được chia làm 3 phần: “Chuẩn bị hành trang”, “Trong phòng chờ sân bay” và “Lên máy bay”, tương ứng với những quá trình một bạn trẻ phải trải qua trước khi “cất cánh” trên đường băng cuộc đời, bay vào bầu trời cao rộng.

Xuất phát từ cái tâm trong sáng của người đi trước dày dặn kinh nghiệm, kiến thức, Tony Buổi Sáng mang đến đọc giả những bài viết hài ước, tinh tế, sinh động và đầy thiết thực. Cuốn Trên Đường Băng với những bài viết về thái độ với sự học và kiến thức nói chung, cách ứng phó với những trắc trở thử thách khi đi làm, cách sống hào sảng nghĩa tình văn minh… truyền cảm hứng cho các bạn trẻ sống hết mình, trọn vẹn từng phút giây và sẵn sàng cho hành trang cuộc sống.

Trên Đường Băng của Tony Buổi Sáng tuy hướng đến những đọc giả là những người trẻ nhưng những người lớn hơn vẫn để hiểu hơn, và có cách nhìn nhận cũng như giáo dục con em mình tốt nhất thay vì bảo vệ con quá kĩ trở nên yếu ớt và thiếu tự lập. Và để yêu thương “khoa học” nhất. Đây cũng là cuốn sách mà những người đi làm nên sở hữu để nhìn lại chặng đường mình đã đi qua, suy ngẫm và thay đổi vì chưa bao giờ là quá muộn.

Một cuốn sách với nhiều điều để bạn học hỏi, suy ngẫm và chuẩn bị tốt nhất cho hành trang trên con đường tuổi trẻ của chính mình.', N'trenduongbang.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 18, 49, 12, 27, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (74, N'SÁCH GIÁO KHOA BỘ LỚP 1 (BỘ 13 CUỐN + VỞ TẬP VẼ)', 99360, N'Sách Giáo Khoa Bộ Lớp 1 (Bộ 13 Cuốn + Vở Tập Vẽ)', N'lop1.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 8, 232, 14, 21, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (75, N'SÁCH GIÁO KHOA BỘ LỚP 2 (BỘ 13 CUỐN + VỞ TẬP VẼ)', 102240, N'Sách Giáo Khoa Bộ Lớp 2 (Bộ 13 Cuốn + Vở Tập Vẽ)', N'lop2.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 8, 555, 14, 21, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (76, N'D.TRUMP NGHỆ THUẬT ĐÀM PHÁN', 84000, N'công những sòng bạc hàng đầu ở thành phố Atlantic, thay đổi bộ mặt của những cao ốc ở thành phố New York... và xây dựng những tòa nhà chọc trời trên thế giới. Quyển sách đi sâu vào đầu óc của một doanh nhân xuất sắc và khám phá một cách khoa học chưa từng thấy về cách đàm phán một thương vụ thành công. Đây là một cuốn sách thú vị về đàm phán và kinh doanh – và là một cuốn sách nên đọc cho bất kỳ ai quan tâm đến đầu tư, bất động sản và thành công.', N'trump.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 8, 200, 12, 28, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (77, N'TRƯỜNG SA - NƠI TA ĐẾN - HERE WERE COME', 147600, N'Tác phẩm mới nhất thuộc Tủ sách Biển đảo của NXB Kim Đồng - ấn phẩm sách ảnh song ngữ của nữ nhà báo – tác giả Nguyễn Mỹ Trà.

Trường Sa – Nơi ta đến là một bộ sách ảnh giàu nữ tính, mang tới cho chúng ta những thông điệp dịu dàng về tình yêu Tổ quốc. Cuốn sách tập hợp khoảng 150 bức ảnh nghệ thuật, tái hiện vẻ đẹp trong trẻo, tráng lệ của Trường Sa qua nhiều thời khắc: một cơn giông, một cầu vồng, một khung trời qua ô cửa,

một mầm cây đang vươn mình ra ánh sáng, một cơn mưa chập chờn phía xa khơi... Nhưng bên cạnh đó là cuộc sống khắc nghiệt in hằn trên làn da của người lính đảo, là cảm xúc nhớ đất liền và nhớ về những người đã ngã xuống.

Cuốn sách cũng khiến bất cứ ai trong chúng ta, những người đã từng đặt chân đến Trường Sa hoặc chỉ biết Trường Sa trong những câu chuyện kể, đều rung lên những xúc cảm đẹp lạ thường.
Trường Sa - Nơi ta đến thể hiện ở dạng song ngữ Anh - Việt của nhà báo Nguyễn Mỹ Trà, phóng viên VOV, phần dịch do các BTV CT Tiếng Anh 24/7 VOV5 đảm nhận.', N'truongsa.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 32, 332, 9, 32, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (78, N'SÁCH GIÁO KHOA BỘ LỚP 3 (BỘ 13 CUỐN + VỞ TẬP VẼ)', 112410, N'Sách giáo khoa bộ lớp 3 (Bộ 13 cuốn + vở tập vẽ)', N'lop3.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 8, 562, 14, 21, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (79, N'SÁCH GIÁO KHOA BỘ LỚP 3 (BỘ 13 CUỐN + VỞ TẬP VẼ)', 92970, N'Sách Giáo Khoa Bộ Lớp 4 - Sách Bài Tập + Vở Tập Vẽ (Bộ 12 Cuốn)', N'lop4.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 8, 444, 14, 21, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (80, N'SÁCH GIÁO KHOA BỘ LỚP 5 - SÁCH BÀI TẬP + VỞ TẬP VẼ (BỘ 12 CUỐN)', 99450, N'Sách Giáo Khoa Bộ Lớp 5 - Sách Bài Tập + Vở Tập Vẽ (Bộ 12 Cuốn)', N'lop5.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 8, 656, 14, 21, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (81, N'SÁCH GIÁO KHOA BỘ LỚP 6 - SÁCH BÀI HỌC (BỘ 12 CUỐN)', 103500, N'SÁCH GIÁO KHOA BỘ LỚP 6 - SÁCH BÀI HỌC (BỘ 12 CUỐN)', N'lop6.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 8, 231, 14, 21, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (82, N'SÁCH GIÁO KHOA BỘ LỚP 7 - SÁCH BÀI HỌC (BỘ 12 CUỐN)', 120600, N'SÁCH GIÁO KHOA BỘ LỚP 7 - SÁCH BÀI HỌC (BỘ 12 CUỐN)
', N'lop7.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 8, 154, 14, 21, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (83, N'SÁCH GIÁO KHOA BỘ LỚP 8 - SÁCH BÀI HỌC (BỘ 13 CUỐN)', 134100, N'SÁCH GIÁO KHOA BỘ LỚP 8 - SÁCH BÀI HỌC (BỘ 13 CUỐN)', N'lop8.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 8, 98, 14, 21, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (84, N'SÁCH GIÁO KHOA BỘ LỚP 9 - SÁCH BÀI HỌC (BỘ 12 CUỐN)', 122000, N'SÁCH GIÁO KHOA BỘ LỚP 9 - SÁCH BÀI HỌC (BỘ 12 CUỐN)
', N'lop9.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 8, 150, 14, 21, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (85, N'SÁCH GIÁO KHOA BỘ LỚP 10 CƠ BẢN - SÁCH BÀI HỌC (BỘ 14 CUỐN)', 147600, N'SÁCH GIÁO KHOA BỘ LỚP 10 CƠ BẢN - SÁCH BÀI HỌC (BỘ 14 CUỐN)
', N'lop10.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 8, 421, 14, 21, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (86, N'SÁCH GIÁO KHOA BỘ LỚP 11 CƠ BẢN - SÁCH BÀI HỌC (BỘ 14 CUỐN)', 152100, N'SÁCH GIÁO KHOA BỘ LỚP 11 CƠ BẢN - SÁCH BÀI HỌC (BỘ 14 CUỐN)
', N'lop11.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 8, 162, 14, 21, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (87, N'SÁCH GIÁO KHOA BỘ LỚP 12 CƠ BẢN - SÁCH BÀI HỌC (BỘ 14 CUỐN)', 162000, N'SÁCH GIÁO KHOA BỘ LỚP 12 CƠ BẢN - SÁCH BÀI HỌC (BỘ 14 CUỐN)
', N'lop12.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 8, 521, 14, 21, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (92, N'BÍ ẨN MÃI MÃI LÀ BÍ ẨN - TẬP 1', 26600, N'É', N'bian1.jpg', NULL, 8, 222, 12, 22, 0, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (93, N'BÍ ẨN MÃI MÃI LÀ BÍ ẨN - TẬP 1', 26600, N'Bí Ẩn Mãi Mãi Là Bí Ẩn (Tập 1) giới thiệu cùng các bạn những điều bí ẩn đã và đang tồn tại xung quanh cuộc sống của chúng ta; những điều mà khoa học còn chưa có lời giải thích.

Cuốn sách gồm một số nội dung chính như sau:

Bí ẩn hiện tượng xác ướp tự nhiên ở colombia

Vì sao chúng ta sợ?

Sự lựa chọn bí ẩn của tự nhiên

Bí ẩn về những ngọn đèn vĩnh cửu

Bí ẩn của những tượng đá trên đảo phục sinh

Bí ẩn của hiện tượng đa phu

Vũ trụ luôn chống lại chúng ta?

Tảng đá biết đi

Dấu chân kỳ quặc
Hóa giải huyền thoại tam giác quỷ Bermuda?

Những vòng tròn bí ẩn trên cánh đồng

Mỗi người chúng ta là một nhà bác học

Lý giải khoa học

Bí ẩn cuốn di cảo Voynich thế kỷ 13

Bí ẩn về người cụt đầu

...
', N'bian1.jpg', CAST(N'2019-06-23 00:00:00.000' AS DateTime), 8, 241, 12, 22, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (94, N'LÁ NẰM TRONG LÁ (BÌA MỀM) - TÁI BẢN 2017', 64000, N'Mở cuốn sách mới của tác giả Nguyễn Nhật Ánh, bạn sẽ gặp những cái tên quen thuộc của những người nổi tiếng ngay trang 5 trang trọng đề tặng “các bạn văn hữu”: nhà thơ Bùi Chí Vinh, Phạm Sỹ Sáu, Lê Minh Quốc, nhà văn Nguyễn Đông Thức, nhà phê bình Huỳnh Như Phương, nhà báo Nguyễn Công Khế, Kim Hạnh, … Tuổi niên thiếu của “những thằng quỷ nhỏ” trong truyện có gắn gì với họ không, có phải là họ không, chỉ họ và tác giả mới biết, nhưng bạn đọc thì có thể tưởng tượng ra một nhóm “thằng” thân thiết, bắt đầu lớn, biết thinh thích con gái và ngập mộng văn chương.

Chuyện của bút nhóm học trò, truyện nằm trong truyện, những cơn giận dỗi ghen tuông bạn gái bạn trai với nhau, nhiều nhất vẫn là chuyện nhà trường có các cô giáo hơn trò vài tuổi coi trò như bạn, có thầy hiệu trưởng tâm lý và yêu thương học trò coi trò như con…Trở lại với đề tài học trò, hóm hỉnh và gần gũi như chính các em, Nguyễn Nhật Ánh chắc chắn sẽ được các bạn trẻ vui mừng đón nhận. Cứ lật đằng cuối sách, đọc bài thơ tình trong veo là có thể thấy điều đó “…Khi mùa xuân đến / Tình anh lại đầy / Lá nằm trong lá / Tay nằm trong tay”.

“Viết cho trẻ con giờ khó hơn xưa. Có hàng bao nhiêu là món giải trí rầm rộ, hoành tráng và lộng lẫy dọn sẵn, muốn thu phục “lũ tiểu yêu” thế kỷ 21 này, nhà văn không chỉ thông thuộc mặt bằng hiểu biết của chúng, mà còn phải tâm tình được với chúng bằng tốc độ của chúng. Có thể nói Nguyễn Nhật Ánh là một người lớn chấp nhận tham dự món du hành tốc độ cao cùng lũ trẻ. Thời thong thả đạp xe, từ tốn khuyên bảo đã qua rồi. Thực ra Nguyễn Nhật Ánh đã biết đi tàu tốc hành từ hai thập niên trước, khi nhữngKính vạn hoa, Thằng quỷ nhỏ, Bàn có năm chỗ ngồi… đem lại cho văn học thiếu nhi một diện mạo mới mẻ, những câu chuyện tưởng như ấm ớ ngày này qua tháng khác nhưng sao hôm nay nhìn lại, những người đã từng là trẻ con thấy nhớ quá..” (VIỆT TRUNG, báo Thanh Niên).

“Bước vào khoảng trời của tuổi biết buồn, Nguyễn Nhật Ánh đã ghi lại những bâng khuâng rung cảm đầu đời. Trong tâm tưởng của các em, bây giờ không chỉ nghĩ về cái gì mà còn nghĩ về ai, về một người khác giới cụ thể nào, và về cả bản thân, thế giới ấy tràn ngập những câu hỏi xôn xao về cái-gọi-là-tình-yêu. Truyện của Nguyễn Nhật Ánh đã đưa vào những câu hỏi lớn, muôn thuở, quen thuộc - những câu hỏi mà dường như trong đời ai cũng từng đối diện ít nhất một lần. Vì thế, trong khi độc giả thiếu niên phục lăn vì nhà văn đi guốc vào bụng họ, thì độc giả người lớn mỉm cười mơ màng nhớ lại một thời thơ dại...'' (TS. NGUYỄN THỊ THANH XUÂN, nhà nghiên cứu văn học).', N'lanamtrongla.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 19, 123, 12, 33, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (95, N'THIÊN TÀI LÃNH ĐẠO -LEADERSHIP GENIUS', 102000, N'Ngày nay, các nghiên cứu cũng như khóa học về lãnh đạo tràn ngập khắp nơi, nhưng làm thế nào để ứng dụng hiệu quả những nghiên cứu và kiến thức ấy vào thực tế?

Cuốn sách Thiên tài lãnh đạo là câu trả lời cho câu hỏi trên. Cuốn sổ tay thực hành này sẽ khiến việc áp dụng các nghiên cứu mang tính khoa học về lãnh đạo vào đời thực thật dễ dàng, và chỉ ra chính xác điều bạn cần làm để có thể trở thành một “thiên tài lãnh đạo”.

Mỗi chương sách được thiết kế như một khóa học ngắn, tập trung phân tích và chỉ ra cho bạn thấy điểm mấu chốt của các nghiên cứu về lãnh đạo, và cách ứng dụng chúng. Việc tích lũy từng bài học sẽ dần giúp bạn trở nên một lãnh đạo tài năng và thấu suốt.

“Lãnh đạo không chỉ đơn giản là việc khiến cho mọi người đi theo... mà còn là việc có được kiến thức và năng lực để cân bằng phong cách của bạn.”

“Thiên tài lãnh đạo là một cuốn sách nghiên cứu công phu, kết hợp được các tài liệu truyền thống và hiện đại một cách hấp dẫn và hài hước, với những quan sát dễ tiếp cận về nghệ thuật lãnh đạo. Cuốn sách phù hợp cho cả những người mới nhập môn khoa học lãnh đạo và những người đã dày dạn kinh nghiệm trong nghệ thuật này.”

- Mark Heywood, Ngân hàng Lloyds', N'thientailanhdao.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 24, 323, 13, 28, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (96, N'VẦNG TRĂNG QUÊN LÃNG', 65570, N'"Có phải không thấy trăng, là trăng không tồn tại?"

Vào một đêm nọ, vầng trăng không mọc nữa...

Không ai biết vầng trăng đã đi đâu? Mang theo tất cả thứ ánh sáng lung linh huyền diệu, nhấn chìm nhân loại vào màn đêm tối thẫm.

Kỉ nguyên của nỗi cô đơn đằng đẵng và ám ảnh bóng tối đã bắt đầu.

Liệu vầng trăng thiên nhiên tuyệt đẹp có thể bị lãng quên?

Hay ai sẽ là người tìm lại vầng trăng thật sự?

Một tác phẩm tuyệt đẹp và đầy rung cảm chiêm nghiệm về nỗi cô đơn của nhân loại sẽ chạm vào sâu thẳm trái tim mỗi chúng ta.

-----

Jimmy Liao bắt đầu sáng tác từ năm 1998 và là hoạ sĩ tiên phong trong phong trào sách tranh dành cho người lớn. Các tác phẩm của ông nổi tiếng ở cả trong và ngoài nước, được xuất bản tại nhiều quốc gia như Mĩ, Pháp, Đức, Tây Ban Nha, Hàn Quốc, Nhật Bản, Thái Lan…

Nhiều tác phẩm của ông đã được chuyển thể thành nhạc kịch, phim truyền hình, phim điện ảnh. Trong số đó, bộ phim hoạt hình chuyển thể từ tác phẩm “The fish that smiled at me” đã đạt giải đặc biệt của Ban giám khảo tại Liên hoan phim quốc tế Berlin năm 2006.

Năm 2003, ông lọt vào danh sách “55 nhân vật châu Á sáng tạo nhất” do tạp chí Studio Voice bình chọn.

Năm 2007, ông được kênh truyền hình Discovery bình chọn là một trong sáu nhân vật có ảnh hưởng nhất Đài Loan.', N'vangtrang.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 26, 333, 9, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (97, N'VUI HỌC TIẾNG ANH CÙNG TRẺ (TẬP 1)', 88000, N'Sách dựa trên chương trình giảng dạy tiếng Anh quốc tế nổi tiếng tại Nhật.
Tập trung vào việc phát triển khả năng phản xạ thông qua các hoạt động thường ngày.
Ba mẹ có thể dễ dàng dạy con học tiếng Anh mà không cần đến trung tâm ngoại ngữ.
Thông qua hoạt động dạy tiếng Anh từ những hoạt động thường ngày, ba mẹ có nhiều cơ hội tiếp xúc với con hơn, hiểu tâm tư tình cảm và khả năng tiếp thu của con hơn là phó thác cho các trung tâm ngoại ngữ.', N'vuihoctienganh1.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 20, 111, 12, 23, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (98, N'VUI HỌC TIẾNG ANH CÙNG TRẺ (TẬP 2)', 88000, N'Sách dựa trên chương trình giảng dạy tiếng Anh quốc tế nổi tiếng tại Nhật.
Tập trung vào việc phát triển khả năng phản xạ thông qua các hoạt động thường ngày.
Ba mẹ có thể dễ dàng dạy con học tiếng Anh mà không cần đến trung tâm ngoại ngữ.
Thông qua hoạt động dạy tiếng Anh từ những hoạt động thường ngày, ba mẹ có nhiều cơ hội tiếp xúc với con hơn, hiểu tâm tư tình cảm và khả năng tiếp thu của con hơn là phó thác cho các trung tâm ngoại ngữ.', N'vuihoctienganh2.jpg', CAST(N'2019-06-22 00:00:00.000' AS DateTime), 20, 123, 12, 23, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (99, N'NHÀ GIẢ KIM (TÁI BẢN 2017)', 55000, N'Nhà Giả Kim (Tái Bản 2017). NHÀ GIẢ KIM là cuốn sách được in nhiều nhất chỉ sau Kinh Thánh. Cuốn sách của Paulo Coelho có sự hấp dẫn ra sao khiến độc giả không chỉ các xứ dùng ngôn ngữ Bồ Đào Nha mà các ngôn ngữ khác say mê như vậy?. Tiểu thuyết NHÀ GIẢ KIM của Paulo Coelho như một câu chuyện cổ tích giản dị, nhân ái, giàu chất ..', N'tieuthuyet1.jpg', CAST(N'2019-06-26 00:00:00.000' AS DateTime), 33, 49, 17, 19, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (100, N'DORAEMON TRANH TRUYỆN MÀU - ĐỘI QUÂN DORAEMON: VƯƠNG QUỐC BÁNH KẸO OKASHINANA', 21000, N'Câu chuyện bắt đầu khi Dora Vương và Dora - The - Kid lên đường tới Vương quốc Okashinana, nơi được mệnh danh là "Nhà máy bánh kẹo lớn nhất thế giới". Ở đó có Jedora - bạn học cùng Trường đào tạo robot và cũng là một thợ làm bánh tài ba. Jedora đã nhờ nhóm Doraemon chuyển tới những nguyên liệu làm bánh tươi ngon nhất để cậu có thể tham gia Lễ hội .', N'doraemonThem.jpg', CAST(N'2019-06-26 00:00:00.000' AS DateTime), 13, 50, 9, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (101, N'DORAEMON TRANH TRUYỆN MÀU - ĐỘI QUÂN DORAEMON: CHUYẾN TÀU LỬA TỐC HÀNH', 22000, N'Viên nhộng năng lượng đột nhiên bị đánh cắp khỏi Trung tâm năng lượng khiến mọi hoạt động của thành phố tương lai đều bị ngưng trệ. Đội quân Doraemon nhận nhiệm vụ áp tải viên nhộng dự bị đến Trung tâm năng lượng trên một chiếc tàu hỏa cổ lỗ có tên là "Roko". Suốt cuộc hành trình, nhà khoa học xấu xa Achimov đã dùng mọi thủ đoạn phá hoại... Liệu Đội ...', N'doraemonThem2.jpg', CAST(N'2019-06-26 00:00:00.000' AS DateTime), 13, 50, 9, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (102, N'DORAEMON TRANH TRUYỆN MÀU - DORAMI VÀ ĐỘI QUÂN DORAEMON - 7 BÍ ẨN CỦA TRƯỜNG ĐÀO TẠO ROBOT (TÁI BẢN 2018)', 23000, N'Thế kỉ 22, Doraemon trở lại Trường đào tạo robot để dự lễ tốt nghiệp của em gái Dorami. Đúng lúc đó, mây đen bao phủ, rất nhiều sự việc kì lạ xảy ra, ngay cả Doraemon cũng bị hút vào một vật bí ẩn. Quá hoảng sợ, Dorami phải sử dụng thẻ tình bạn để cầu cứu sự giúp đỡ của các thành viên Đội quân Doraemon... Mời các bạn cùng theo dõi diễn biến câu chuyện! ..', N'doraemonThem3.jpg', CAST(N'2019-06-26 00:00:00.000' AS DateTime), 13, 50, 9, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (103, N'GIÁO DỤC VIỆT NAM HỌC GÌ TỪ NHẬT BẢN', 73000, N'Giáo Dục Việt Nam Học Gì Từ Nhật Bản. "Cải cách giáo dục là công việc hệ trọng có quan hệ mật thiết đến sự suy thịnh quốc gia dân tộc và tương lai của nhiều thế hệ, vì vậy cần phải được tiến hành dựa trên nghiên cứu khoa học có cơ sở lý luận và thực tiễn thuyết phục thay vì tiến hành theo kinh nghiệm, ý chí chủ quan hoặc chỉ chú trọng du nhập phần kỹ ..', N'giaoduc.jpg', CAST(N'2019-06-27 00:00:00.000' AS DateTime), 34, 50, 18, 18, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (104, N'PHƯƠNG PHÁP GIÁO DỤC CON CỦA NGƯỜI MỸ', 45000, N'Trong quan niệm của chúng ta, trẻ con Mỹ luôn rất thông minh, tài năng, tự lập và dũng cảm. Các bé không chỉ thông minh trong học tập mà còn rất sáng tạo trong công việc. Hẳn bạn đã từng ngạc nhiên khi biết trẻ em Mỹ thường ngủ một mình vào ban đêm, đi ra ngoài mà không sợ bóng tối hay côn trùng, thậm chí các bé có thể tự mình sửa chữa ..', N'giaoduc1.jpg', CAST(N'2019-06-27 00:00:00.000' AS DateTime), 35, 40, 19, 18, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (105, N'KHOA HỌC KHÁM PHÁ - CUỘC CHIẾN LỖ ĐEN', 145000, N' Ngọc hoàng và anh học trò nghèo', N'khoahoc.jpg', CAST(N'2019-06-27 00:00:00.000' AS DateTime), 36, 50, 12, 22, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (106, N'PHÁT TRIỂN NĂNG LỰC TRONG MÔN TIN HỌC - DÀNH CHO THCS - QUYỂN 1', 35000, N'Bộ sách "Phát triển năng lực trong dạy học môn Tin học" được biên soạn nhằm đáp ứng việc triển khai thực hiện chương trình giáo dục phổ thông hiện hành theo định hướng phát triển năng lực và phẩm chất học sinh được Bộ Giáo dục và Đào tạo hướng dẫn tại Công văn số 4612/BGDĐT-GDTrH ngày 03/10/2017.. Nội dung của sách đảm bảo đúng chuẩn kiến thức, kĩ năng của chương .', N'tinhoc1.jpg', CAST(N'2019-06-27 00:00:00.000' AS DateTime), 8, 50, 14, 24, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (107, N'PHÁT TRIỂN NĂNG LỰC TRONG MÔN TIN HỌC - DÀNH CHO THCS - QUYỂN 3', 34000, N'Phát Triển Năng Lực Trong Môn Tin Học - Dành Cho Thcs - Quyển 3', N'tinhoc3.jpg', CAST(N'2019-06-24 00:00:00.000' AS DateTime), 8, 40, 14, 24, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (108, N'PHÁT TRIỂN NĂNG LỰC TRONG MÔN TIN HỌC - DÀNH CHO THCS - QUYỂN 4', 32000, N'PHÁT TRIỂN NĂNG LỰC TRONG MÔN TIN HỌC - DÀNH CHO THCS - QUYỂN 4', N'tinhoc4.jpg', CAST(N'2019-06-27 00:00:00.000' AS DateTime), 8, 40, 14, 24, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (109, N'STEM - CÔNG NGHỆ SIÊU THÔNG MINH', 47000, N'STEM - Công Nghệ Siêu Thông Minh. STEM là thuật ngữ viết tắt của Science, Technology, Engineering, Mathematics (Khoa học, Công nghệ, Kỹ thuật, Toán học). Bốn lĩnh vực này liên kết với nhau một cách chặt chẽ, không tách rời. Công nghệ và Kỹ thuật lấy ý tưởng từ những phát kiến mới về Khoa học để cuộc sống của chúng ta được dễ dàng và giúp thế giới trở nên tươi đẹp hơn. Tuy .', N'congnghe.jpg', CAST(N'2019-06-27 00:00:00.000' AS DateTime), 37, 50, 20, 25, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (110, N'BÁCH KHOA CÔNG NGHỆ - MỞ MANG KIẾN THỨC, KHƠI DẬY TIỀM NĂNG', 115000, N'BÁCH KHOA CÔNG NGHỆ - MỞ MANG KIẾN THỨC, KHƠI DẬY TIỀM NĂNG', N'congnghe2.jpg', CAST(N'2019-06-27 00:00:00.000' AS DateTime), 38, 50, 20, 25, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (111, N'TIẾP THỊ 4.0 - DỊCH CHUYỂN TỪ TRUYỀN THỐNG SANG CÔNG NGHỆ SỐ', 80000, N'Tiếp Thị 4.0 - Dịch Chuyển Từ Truyền Thống Sang Công Nghệ Số. Quyển cẩm nang vô cùng cần thiết cho những người làm tiếp thị trong thời đại số. Được viết bởi cha đẻ ngành tiếp thị hiện đại, cùng hai đồng tác giả là lãnh đạo của công ty MarkPlus, quyển sách sẽ giúp bạn lèo lái thế giới không ngừng kết nối và khách hàng không ngừng thay đổi để có được nhiều ..', N'congnghe3.jpg', CAST(N'2019-06-27 00:00:00.000' AS DateTime), 39, 50, 12, 25, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (112, N'CHĂM SÓC SỨC KHỎE TRẺ EM - TẬP 1: SỮA MẸ - SỮA CÔNG THỨC', 65000, N'Chăm Sóc Sức Khỏe Trẻ Em - Tập 1: Sữa Mẹ - Sữa Công Thức. Cuốn sách nằm trong bộ sách “Chăm sóc sức khỏa trẻ em” của Bác sĩ Thôi Ngọc Đào – Chuyên gia nhi khoa hàng đầu tại Trung Quốc, đúc kết từ 27 năm kinh nghiệm, cung cấp cho các mẹ các kiến thức cơ bản và toàn diện về việc nuôi con bằng sữa mẹ và sữa công thức.. Lựa chọn giọt sữa đầu tiên cho trẻ mới ..', N'suckhoe1.jpg', CAST(N'2019-06-28 00:00:00.000' AS DateTime), 40, 49, 18, 26, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (113, N'CHĂM SÓC SỨC KHỎE TRẺ EM - TẬP 2: VACCINE - TIÊM CHỦNG', 62000, N'Chăm Sóc Sức Khỏe Trẻ Em - Tập 2: Vaccine - Tiêm Chủng. Cuốn sách nằm trong bộ sách “Chăm sóc sức khỏa trẻ em” của Bác sĩ Thôi Ngọc Đào – Chuyên gia nhi khoa hàng đầu tại Trung Quốc, đúc kết từ 27 năm kinh nghiệm, cung cấp cho các mẹ các kiến thức cơ bản và toàn diện về vaccine và vấn đề tiêm chủng của trẻ.. Trẻ đang bị bệnh có ảnh hưởng đến việc tiêm ..', N'suckhoe2.jpg', CAST(N'2019-06-28 00:00:00.000' AS DateTime), 40, 48, 18, 26, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (114, N'CHĂM SÓC SỨC KHỎE TRẺ EM - TẬP 3 - DINH DƯỠNG - ĂN DẶM', 69000, N'Chăm Sóc Sức Khỏe Trẻ Em - Tập 3 - Dinh Dưỡng - Ăn Dặm. Dinh dưỡng cho trẻ là vấn đề mà cha mẹ nào cũng quan tâm nhưng không phải ai cũng có đủ kiến thức về dinh dưỡng, đặc biệt là giai đoạn ăn dặm của trẻ. Ăn dặm là giai đoạn hết sức nhạy cảm, trẻ sẽ bắt đầu tiếp nhận những loại  thực  phẩm  ngoài  sữamẹ, sữa công thức. Một cơ thể vẫn còn non ..', N'suckhoe3.jpg', CAST(N'2019-06-28 00:00:00.000' AS DateTime), 40, 49, 18, 26, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (115, N'CHĂM SÓC SỨC KHỎE TRẺ EM - TẬP 4 - BỆNH ĐƯỜNG RUỘT', 70000, N'Chăm Sóc Sức Khỏe Trẻ Em - Tập 4 - Bệnh Đường Ruột. Tập 4 của bộ “Chăm sóc sức khỏe trẻ em” cung cấp thông tin về bệnh đường ruột ở trẻ. Một vấn đề mà gần như trẻ em nào cũng từng gặp phải.. Mặc dù bố mẹ đã rất thận trọng trong quá trình cho trẻ ăn dặm, nhưng chắc chắn sẽ gặp phải tình  trạng trẻ táo bón hoặc tiêu chảy. Cuốn sách này sẽ giúp bố .', N'suckhoe4.jpg', CAST(N'2019-06-28 00:00:00.000' AS DateTime), 40, 49, 18, 26, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (116, N'Thần Đồng Đất Việt - Tập 12: Bạn gái bá hộ', 10000, N'Thần Đồng Đất Việt - Tập 12: Bạn gái bá hộ', N'tddv12.jpg', CAST(N'2019-06-28 00:00:00.000' AS DateTime), 9, 50, 8, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (117, N'Thần Đồng Đất Việt - Tập 13: Lớp học hà tiện', 10000, N'Thần Đồng Đất Việt - Tập 13: Lớp học hà tiện', N'tddv-t13.jpg', CAST(N'2019-06-29 00:00:00.000' AS DateTime), 9, 48, 8, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (118, N'Thần Đồng Đất Việt Tập - 14: Sư ông mắc lỡm', 10000, N'Thần Đồng Đất Việt Tập - 14: Sư ông mắc lỡm', N'tddv14.png', CAST(N'2019-06-29 00:00:00.000' AS DateTime), 9, 47, 8, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (119, N'Thần Đồng Đất Việt - Tập 15: Vô địch chọi trâu', 10000, N'Thần Đồng Đất Việt - Tập 15: Vô địch chọi trâu', N'tddv15.jpg', CAST(N'2019-06-29 00:00:00.000' AS DateTime), 9, 49, 8, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (120, N'Thần Đồng Đất Việt - Tập 16: Súc vật nổi loạn', 10000, N'Thần Đồng Đất Việt - Tập 16: Súc vật nổi loạn', N'tddv16.jpg', CAST(N'2019-06-29 00:00:00.000' AS DateTime), 9, 50, 8, 17, 1, NULL, NULL)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (121, N'testEdit', 25000, N'đây là mô tả Edit', N'8936071672582_1.jpg', CAST(N'2019-07-04 00:00:00.000' AS DateTime), 41, 14, 22, 35, 0, NULL, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (122, N'test Giam Gia', 2000, N'1231212312123113', N'bian.jpg', CAST(N'2019-05-07 00:00:00.000' AS DateTime), 8, 10, 8, 17, 1, NULL, 10000)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (123, N'testGiam2', 10000, N'123121213212121', N'conan.jpg', CAST(N'2019-07-05 00:00:00.000' AS DateTime), 42, 10, 22, 17, 1, NULL, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [MaTacGia], [SoLuongTon], [MaNXB], [MaChuDe], [TrangThai], [GiaGiam], [GiaCu]) VALUES (124, N'test3', 5000, N'123121', N'bian.jpg', CAST(N'2019-07-05 00:00:00.000' AS DateTime), 8, 10, 8, 17, 1, NULL, 10000)
SET IDENTITY_INSERT [dbo].[Sach] OFF
SET IDENTITY_INSERT [dbo].[TacGia] ON 

INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (8, N'Nhiều tác giả', NULL, NULL, N'0123456789', 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (9, N'Phan Thị', NULL, NULL, N'0961421396', 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (10, N'Masashi Kishimoto', N'nhật bản', NULL, N'0326598963', 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (11, N'Mai Lan Hương, Hà Thanh Uyên', N'931tran hung dao p1 q5 tphcm', NULL, N'0961424789', 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (12, N'Viktor E. Frankl', NULL, NULL, N'5086839553', 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (13, N'Fujiko F Fujio', NULL, NULL, N'0961421311', 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (14, N'Donald J.Trump và Tony', N'931tran hung dao p1 q5 tphcm', NULL, N'1231421396', 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (15, N'Diane von Furstenberg', NULL, NULL, N'0961421310', 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (17, N'Stephenie Meyer', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (18, N'Tony Buổi Sáng', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (19, N'Nguyễn Nhật Ánh', NULL, N'Nguyễn Nhật Ánh là nhà văn Việt Nam chuyên viết cho tuổi mới lớn. Ông sinh ngày 7 tháng 5 năm 1955 tại làng Đo Đo, xã Bình Quế, huyện Thăng Bình, tỉnh Quảng Nam.', NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (20, N'Mariko Shimizu', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (21, N'Robin Sharma', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (22, N'Michael Sandel', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (23, N'Moon Huyng Jin', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (24, N'Rus Slater', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (25, N'Martin Dorey', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (26, N'Jimmy Liao', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (27, N'Lâm Hoàng Trúc', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (28, N'Phạm Quang Vinh', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (29, N'Jacqueline Harris', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (30, N'Zhao Li Rong', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (31, N'Johnny Ong', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (32, N'Nguyễn Mỹ Trà', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (33, N'Paulo Coelho', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (34, N'Nguyễn Quốc Vương', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (35, N'Trần Hân, Thanh Nhã', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (36, N'Leoard Susskind', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (37, N'Catherine Bruzzone viết lời Vicky', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (38, N'Dorling Kindersley', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (39, N'Philip Kotler, Hermawan Kartajaya, Iwan Setiawan', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (40, N'BS. Thôi Ngọc Đào', NULL, NULL, NULL, 1)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (41, N'testEdit', NULL, NULL, NULL, 0)
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DiaChi], [TieuSu], [DienThoai], [TrangThai]) VALUES (42, N'KHÁC', NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[TacGia] OFF
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_DonHang] FOREIGN KEY([MaDonHang])
REFERENCES [dbo].[DonHang] ([MaDonHang])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_DonHang]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_Sach]
GO
ALTER TABLE [dbo].[ChiTietGioHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietGioHang_GioHang] FOREIGN KEY([MaGioHang])
REFERENCES [dbo].[GioHang] ([MaGioHang])
GO
ALTER TABLE [dbo].[ChiTietGioHang] CHECK CONSTRAINT [FK_ChiTietGioHang_GioHang]
GO
ALTER TABLE [dbo].[ChiTietGioHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietGioHang_Sach] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[ChiTietGioHang] CHECK CONSTRAINT [FK_ChiTietGioHang_Sach]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_KhachHang]
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK_GioHang_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[GioHang] CHECK CONSTRAINT [FK_GioHang_KhachHang]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_LoaiKhachHang] FOREIGN KEY([MaLoaiKH])
REFERENCES [dbo].[LoaiKhachHang] ([MaLoaiKH])
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_KhachHang_LoaiKhachHang]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_ChuDe1] FOREIGN KEY([MaChuDe])
REFERENCES [dbo].[ChuDe] ([MaChuDe])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_ChuDe1]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_NhaXuatBan] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[NhaXuatBan] ([MaNXB])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_NhaXuatBan]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TacGia] FOREIGN KEY([MaTacGia])
REFERENCES [dbo].[TacGia] ([MaTacGia])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_TacGia]
GO
USE [master]
GO
ALTER DATABASE [QuanLyBanSach] SET  READ_WRITE 
GO
