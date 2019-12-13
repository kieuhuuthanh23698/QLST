USE [QLST]
GO
/****** Object:  StoredProcedure [dbo].[NewSelectCommand]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NewSelectCommand]
AS
	SET NOCOUNT ON;
SELECT        QL_NguoiDung.TenDangNhap, QL_NguoiDung.MatKhau
FROM            QL_NguoiDung INNER JOIN
                         QL_NguoiDungNhomNguoiDung ON QL_NguoiDung.TenDangNhap = QL_NguoiDungNhomNguoiDung.TenDangNhap


GO
/****** Object:  StoredProcedure [dbo].[ScalarQuery]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ScalarQuery]
AS
	SET NOCOUNT ON;
SELECT        QL_NguoiDung.TenDangNhap, QL_NguoiDung.MatKhau
FROM            QL_NguoiDung INNER JOIN
                         QL_NguoiDungNhomNguoiDung ON QL_NguoiDung.TenDangNhap = QL_NguoiDungNhomNguoiDung.TenDangNhap
WHERE        (QL_NguoiDung.TenDangNhap = N'QL_NguoiDungNhomNguoiDung')


GO
/****** Object:  UserDefinedFunction [dbo].[getHangHoa]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[getHangHoa]()
returns @kq table(
	MASP char(10), MALOAI char(10),TENSP nvarchar(50),GIA_BAN float, GIAMGIA float, GIA_BAN_1 float,
	DVT nvarchar(20), SOLUONG int 
)
as
begin
	insert into @kq
	select bg.MASP, MALOAI, TENSP, GIA_BAN, ISNULL(GIAMGIA, 0) AS GIAMGIA, (GIA_BAN - 0.01* ISNULL(GIAMGIA, 0)*GIA_BAN) as GIA_BAN_1, DVT, SOLUONG
	 from 
	(select hh.*, bg.GIA_BAN from HANGHOA hh, BANG_GIA bg where hh.MASP = bg.MASP and hh.HIDDEN = 1
	and NGAYBD = (select MAX(NGAYBD) from BANG_GIA where MASP = bg.MASP))  bg
	left join 
	(select * from KHUYEN_MAI
	where GETDATE() between NGAYBD_KM and NGAYKT_KM) km
	on bg.MASP = km.MASP
	return
end

GO
/****** Object:  UserDefinedFunction [dbo].[getHangHoa_Loai]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[getHangHoa_Loai](@maLoai char(10))
returns @kq table (
	MASP char(10), TENSP nvarchar(50),GIA_BAN float, GIAMGIA float, GIA_BAN_1 float,
	DVT nvarchar(20), SOLUONG int 
)
as
begin
	if(@maLoai = '')
	begin
		insert into @kq
		select MASP, TENSP, GIA_BAN, GIAMGIA, GIA_BAN_1, DVT, SOLUONG from getHangHoa()
	end
	else
	begin
		insert into @kq
		select MASP, TENSP, GIA_BAN, GIAMGIA, GIA_BAN_1, DVT, SOLUONG from getHangHoa()	where MALOAI = @maLoai or MASP = @maLoai or TENSP like @maLoai
	end
	return
end

GO
/****** Object:  UserDefinedFunction [dbo].[getPhanQuyen]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE function [dbo].[getPhanQuyen](@manv char(10))
returns @kq table(maMH nvarchar(50))
as
begin
insert into @kq

	select DISTINCT PHAN_QUYEN.MaManHinh from TAI_KHOAN, NGUOIDUNG_NHOM_ND, NHOM_NGUOI_DUNG, PHAN_QUYEN
	where TAI_KHOAN.TENDN = NGUOIDUNG_NHOM_ND.TenDangNhap 
			and NGUOIDUNG_NHOM_ND.MaNhomNguoiDung = NHOM_NGUOI_DUNG.MaNhom
			and NHOM_NGUOI_DUNG.MaNhom = PHAN_QUYEN.MaNhomNguoiDung and TAI_KHOAN.MANV = @manv

return
end

GO
/****** Object:  UserDefinedFunction [dbo].[getQuyen_Nhom]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE function [dbo].[getQuyen_Nhom](@maNhom varchar(20))
returns @kq table (MaManHinh nvarchar(50),TenManHinh nvarchar(50), Quyen int)
as
begin
insert into @kq
select MaManHinh, TenManHinh, (case when MaManHinh = b.mh  then 1 else 0 end) as Quyen from
(
select mh.MaManHinh, TenManHinh, MaNhomNguoiDung, pq.MaManHinh as mh from MAN_HINH mh left join PHAN_QUYEN pq
on mh.MaManHinh = pq.MaManHinh and pq.MaNhomNguoiDung = @maNhom
) as b left join NHOM_NGUOI_DUNG
on b.MaNhomNguoiDung = NHOM_NGUOI_DUNG.MaNhom
return
end


GO
/****** Object:  UserDefinedFunction [dbo].[getTaiKhoan_Nhom]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE function [dbo].[getTaiKhoan_Nhom](@maNhom varchar(20))
returns @kq table (MANV char(10), TENNV nvarchar(50), Thuoc int)
as
begin
insert into @kq
--select NV.MANV, NV.TENNV, sum(case when NV.TENDN = NGUOIDUNG_NHOM_ND.TenDangNhap then 1 else 0 end) as Thuoc
--from NGUOIDUNG_NHOM_ND, (select TAI_KHOAN.TENDN, NHANVIEN.MANV, NHANVIEN.TENNV from NHANVIEN, TAI_KHOAN where NHANVIEN.MANV = TAI_KHOAN.MANV) as NV
--where NGUOIDUNG_NHOM_ND.MaNhomNguoiDung = @maNhom
--group by NV.MANV, NV.TENNV
--order by NV.MANV
select MANV, TENNV, (case when TENDN = TenDangNhap then 1 else 0 end) as Thuoc from 
(select * from (select NHANVIEN.MANV, TENNV, TENDN from NHANVIEN, TAI_KHOAN where NHANVIEN.MANV = TAI_KHOAN.MANV) as a left join NGUOIDUNG_NHOM_ND
on a.TENDN = NGUOIDUNG_NHOM_ND.TenDangNhap and NGUOIDUNG_NHOM_ND.MaNhomNguoiDung = @maNhom) as b left join (select * from NHOM_NGUOI_DUNG) as c
on b.MaNhomNguoiDung = c.MaNhom
return
end


GO
/****** Object:  Table [dbo].[BANG_GIA]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BANG_GIA](
	[MASP] [char](10) NOT NULL,
	[NGAYBD] [datetime] NOT NULL,
	[GIA_BAN] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHI_TIET_CC]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHI_TIET_CC](
	[MALOAI] [char](10) NOT NULL,
	[MANCC] [char](10) NOT NULL,
 CONSTRAINT [PK_CHI_TIET_CC] PRIMARY KEY CLUSTERED 
(
	[MALOAI] ASC,
	[MANCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHI_TIET_DDH]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHI_TIET_DDH](
	[MASP] [char](10) NOT NULL,
	[MADDH] [char](10) NOT NULL,
	[SOLUONGDAT] [int] NULL,
 CONSTRAINT [PK_CHI_TIET_DDH] PRIMARY KEY CLUSTERED 
(
	[MASP] ASC,
	[MADDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHITIET_HD]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHITIET_HD](
	[MAHD] [nchar](10) NOT NULL,
	[MASP] [char](10) NOT NULL,
	[SL_MUA] [int] NOT NULL,
 CONSTRAINT [PK_CHITIET_HD] PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC,
	[MASP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DANH_MUC_SP]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DANH_MUC_SP](
	[MALOAI] [char](10) NOT NULL,
	[HIDDEN] [int] NULL CONSTRAINT [DF_DANH_MUC_SP_HIDDEN]  DEFAULT ((1)),
	[TENLOAI] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DON_DAT_HANG_NCC]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DON_DAT_HANG_NCC](
	[MADDH] [char](10) NOT NULL,
	[MANCC] [char](10) NULL,
	[NGAYDAT] [datetime] NULL,
	[GHICHU_DDH] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HANGHOA]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HANGHOA](
	[MASP] [char](10) NOT NULL,
	[MALOAI] [char](10) NULL,
	[SOLUONG] [int] NULL,
	[DVT] [nvarchar](20) NULL,
	[HIDDEN] [int] NULL CONSTRAINT [DF_HANGHOA_HIDDEN]  DEFAULT ((1)),
	[TENSP] [nvarchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HOA_DON]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOA_DON](
	[MAHD] [nchar](10) NOT NULL,
	[MAKH] [char](10) NOT NULL,
	[MANV] [char](10) NOT NULL,
	[NGAYLAP] [datetime] NOT NULL,
	[TONGTIEN] [float] NOT NULL,
	[GIAMGIA] [float] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KHACH_HANG]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACH_HANG](
	[MAKH] [char](10) NOT NULL,
	[TENKH] [nvarchar](50) NOT NULL,
	[DIACHI] [varchar](100) NOT NULL,
	[SDT] [nvarchar](10) NOT NULL,
	[TICHLUY] [int] NULL CONSTRAINT [DF_KHACH_HANG_TICHLUY]  DEFAULT ((0)),
	[EMAIL] [nchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KHUYEN_MAI]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHUYEN_MAI](
	[MASP] [char](10) NOT NULL,
	[NGAYBD_KM] [datetime] NOT NULL,
	[NGAYKT_KM] [datetime] NULL,
	[GIAMGIA] [float] NULL,
 CONSTRAINT [PK_KHUYEN_MAI_1] PRIMARY KEY CLUSTERED 
(
	[MASP] ASC,
	[NGAYBD_KM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LO_HANG]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LO_HANG](
	[MALO] [char](10) NOT NULL,
	[MASP] [char](10) NOT NULL,
	[MAPN] [char](10) NOT NULL,
	[NGAYSX] [datetime] NULL,
	[HANSD] [datetime] NULL,
	[SOLUONGNHAP] [int] NULL,
	[SOLUONG_TRENQUAY] [int] NULL,
	[DONGIA_NHAP] [float] NULL,
 CONSTRAINT [PK_LO_HANG_1] PRIMARY KEY CLUSTERED 
(
	[MALO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MAN_HINH]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAN_HINH](
	[MaManHinh] [nvarchar](50) NOT NULL,
	[TenManHinh] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DM_] PRIMARY KEY CLUSTERED 
(
	[MaManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NGUOIDUNG_NHOM_ND]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NGUOIDUNG_NHOM_ND](
	[TenDangNhap] [varchar](50) NOT NULL,
	[MaNhomNguoiDung] [varchar](20) NOT NULL,
 CONSTRAINT [PK_QL_NguoiDungNhomNguoiDung] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC,
	[MaNhomNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHA_CUNG_CAP]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHA_CUNG_CAP](
	[MANCC] [char](10) NOT NULL,
	[TEN_NCC] [varchar](50) NULL,
	[DIACHI_NCC] [varchar](100) NULL,
	[EMAIL_NCC] [varchar](50) NULL,
	[SDT_NCC] [numeric](10, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MANV] [char](10) NOT NULL,
	[TENNV] [nvarchar](50) NOT NULL,
	[CHUCVU] [varchar](50) NOT NULL,
	[PHAI_NV] [int] NOT NULL,
	[DIACHI_NV] [varchar](100) NOT NULL,
	[EMAIL] [nchar](20) NOT NULL,
	[NGAY_SINH] [datetime] NULL,
	[LUONG] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHOM_NGUOI_DUNG]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHOM_NGUOI_DUNG](
	[MaNhom] [varchar](20) NOT NULL,
	[TenNhom] [nvarchar](50) NOT NULL,
	[GhiChu] [nvarchar](200) NULL,
 CONSTRAINT [PK_QL_NhomNguoiDung] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHAN_QUYEN]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHAN_QUYEN](
	[MaNhomNguoiDung] [varchar](20) NOT NULL,
	[MaManHinh] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_QL_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[MaNhomNguoiDung] ASC,
	[MaManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHIEUNHAP]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHIEUNHAP](
	[MAPN] [char](10) NOT NULL,
	[MADDH] [char](10) NULL,
	[NGAYLAP_PN] [datetime] NULL,
	[TONGTIEN_PN] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TAI_KHOAN]    Script Date: 13/12/2019 8:18:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TAI_KHOAN](
	[TENDN] [varchar](50) NOT NULL,
	[MANV] [char](10) NOT NULL,
	[MATKHAU] [char](20) NOT NULL,
	[HOATDONG] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'BANH01    ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 39900)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'BANH02    ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 5000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'BANH03    ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 55800)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'BANH04    ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 63600)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'BANH05    ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 41400)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'BG01      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 101000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'BG02      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 89000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'BG03      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 54900)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'BG04      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 167800)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'BG05      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 219000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DAN01     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 4000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DH01      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 20000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DH02      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 155000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DH03      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 99000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DH04      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 69000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DH05      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 58000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DH06      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 100000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DH07      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 65000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DH08      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 95000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DH09      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 21500)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DH10      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 37800)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DOUONG01  ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 44900)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DOUONG02  ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 14900)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DOUONG03  ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 9900)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DOUONG04  ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 5500)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DOUONG05  ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 9500)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DOUONG06  ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 31500)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DOUONG07  ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 117900)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DOUONG08  ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 6500)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DOUONG09  ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 7500)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'DOUONG10  ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 14700)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'GIAVI01   ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 15000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'GIAVI02   ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 9000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'GIAVI03   ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 46500)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'GIAVI04   ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 11700)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'GIAVI05   ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 23000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'GIAVI06   ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 11000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'GIAVI07   ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 20200)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'KEO01     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 37500)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'KEO02     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 32300)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'KEO03     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 5600)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'KEO04     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 24800)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'KEO05     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 56100)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'KEO06     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 13200)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'KEO07     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 9200)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'KEO08     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 35500)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'KEO09     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 10200)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'KEO10     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 307500)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'MP01      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 169000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'MP02      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 34000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'MP03      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 131000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'MP04      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 246000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'MP05      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 345000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'MP06      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 280000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'MP07      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 230000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'MP08      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 250000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'MP09      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 158000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'MP10      ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 50000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'RAUCU01   ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 17500)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'RAUCU02   ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 49000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'RAUCU03   ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 105000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'RAUCU04   ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 185900)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'RAUCU05   ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 180500)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'RAUCU06   ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 79000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'SUA01     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 54000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'SUA02     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 26000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'SUA03     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 54000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'SUA04     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 231000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'SUA05     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 4000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'SUA06     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 282000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'SUA07     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 50000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'SUA08     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 136000)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'SUA09     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 15500)
INSERT [dbo].[BANG_GIA] ([MASP], [NGAYBD], [GIA_BAN]) VALUES (N'SUA10     ', CAST(N'2019-01-01 00:00:00.000' AS DateTime), 206000)
INSERT [dbo].[DANH_MUC_SP] ([MALOAI], [HIDDEN], [TENLOAI]) VALUES (N'BANH      ', 1, N'BÁNH')
INSERT [dbo].[DANH_MUC_SP] ([MALOAI], [HIDDEN], [TENLOAI]) VALUES (N'BG        ', 1, N'BỘT GIẶT')
INSERT [dbo].[DANH_MUC_SP] ([MALOAI], [HIDDEN], [TENLOAI]) VALUES (N'DAN       ', 1, N'ĐỒ ĂN NHANH')
INSERT [dbo].[DANH_MUC_SP] ([MALOAI], [HIDDEN], [TENLOAI]) VALUES (N'DH        ', 1, N'ĐỒ HỘP')
INSERT [dbo].[DANH_MUC_SP] ([MALOAI], [HIDDEN], [TENLOAI]) VALUES (N'DOUONG    ', 1, N'ĐỒ UỐNG')
INSERT [dbo].[DANH_MUC_SP] ([MALOAI], [HIDDEN], [TENLOAI]) VALUES (N'GIAVI     ', 1, N'GIA VỊ')
INSERT [dbo].[DANH_MUC_SP] ([MALOAI], [HIDDEN], [TENLOAI]) VALUES (N'KEO       ', 1, N'KẸO')
INSERT [dbo].[DANH_MUC_SP] ([MALOAI], [HIDDEN], [TENLOAI]) VALUES (N'KHAC      ', 1, N'KHÁC')
INSERT [dbo].[DANH_MUC_SP] ([MALOAI], [HIDDEN], [TENLOAI]) VALUES (N'MP        ', 1, N'MỸ PHẨM')
INSERT [dbo].[DANH_MUC_SP] ([MALOAI], [HIDDEN], [TENLOAI]) VALUES (N'RAUCU     ', 1, N'RAU CỦ')
INSERT [dbo].[DANH_MUC_SP] ([MALOAI], [HIDDEN], [TENLOAI]) VALUES (N'SUA       ', 1, N'SỮA')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'BANH01    ', N'BANH      ', 0, N'Gói', 1, N'Bánh gạo Want Want vị phô mai 108g')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'BANH02    ', N'BANH      ', 27, N'hộp', 1, N'Bánh quế Cosy nhân kem phô mai 462g')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'BANH03    ', N'BANH      ', 20, N'gói', 1, N'Bánh kem sữa hạt chia Rosio 276g')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'BANH04    ', N'BANH      ', 42, N'hộp', 1, N'Bánh bông lan Apollo cốm hộp 360g')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'BANH05    ', N'BANH      ', 11, N'hộp', 1, N'Bánh quy Cosy dừa Marie 320g')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'BG01      ', N'BG        ', 29, N'bịch', 1, N'Bột Giặt APA 3kg')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'BG02      ', N'BG        ', 44, N'túi', 1, N'Nước giặt khử mùi Attack hương anh đào 14kg')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'BG03      ', N'BG        ', 10, N'bịch', 1, N'Nước giặt Surf hương cỏ hoa 18kg')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'BG04      ', N'BG        ', 15, N'bịch', 1, N'Nước xả vải Comfort hương nước hoa')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'BG05      ', N'BG        ', 20, N'bịch', 1, N'Bột giặt Lix hương nước hoa 55kg')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DAN01     ', N'DAN       ', 44, N'gói', 1, N'Phở bò Như Ý')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DH01      ', N'DH        ', 55, N'hộp', 1, N'Xúc xích dinh dưỡng bò')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DH02      ', N'DH        ', 43, N'hộp', 1, N'Khô gà cay lá chanh')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DH03      ', N'DH        ', 17, N'hộp', 1, N'Thập cẩm sấy')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DH04      ', N'DH        ', 32, N'hộp', 1, N'Chuối sấy dẻo')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DH05      ', N'DH        ', 42, N'hộp', 1, N'Hạt điều sấy rang tỏi ớt')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DH06      ', N'DH        ', 34, N'hộp', 1, N'Mứt dừa sấy giòn')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DH07      ', N'DH        ', 14, N'hộp', 1, N'Lương khô bô binh BB702')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DH08      ', N'DH        ', 36, N'hộp', 1, N'Cá mực Rim me cán Nha Trang')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DH09      ', N'DH        ', 44, N'hộp', 1, N'Chà bông gà Hương Việt 60g')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DH10      ', N'DH        ', 18, N'hộp', 1, N'Cá sốt cà Hạ Long 175g')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DOUONG01  ', N'DOUONG    ', 45, N'chai', 1, N'Coca Cola Nhật 300ml')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DOUONG02  ', N'DOUONG    ', 38, N'gói', 1, N'Yummy Panda Thạch uống trái cây vị xoài')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DOUONG03  ', N'DOUONG    ', 25, N'chai', 1, N'Nước giải khát Latte Đào 345ml')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DOUONG04  ', N'DOUONG    ', 50, N'chai', 1, N'Wonderfarm Trà bí đao')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DOUONG05  ', N'DOUONG    ', 45, N'chai', 1, N'Trà Ô Long Tea Plus 500ml')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DOUONG06  ', N'DOUONG    ', 60, N'chai', 1, N'Nước khoáng AVIAN 500ml')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DOUONG07  ', N'DOUONG    ', 45, N'chai', 1, N'Sinh Tố Phúc Bồn Tử 350ml')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DOUONG08  ', N'DOUONG    ', 24, N'chai', 1, N'Fanta Saxi 390ml')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DOUONG09  ', N'DOUONG    ', 35, N'chai', 1, N'Ice Đào')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'DOUONG10  ', N'DOUONG    ', 64, N'chai', 1, N'Pepsi chai 15l')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'GIAVI01   ', N'GIAVI     ', 14, N'chai', 1, N'Nước mắm rồng vàng')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'GIAVI02   ', N'GIAVI     ', 18, N'chai', 1, N'Tương ớt chisu')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'GIAVI03   ', N'GIAVI     ', 34, N'bịch', 1, N'Bột canh ajinomoto')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'GIAVI04   ', N'GIAVI     ', 24, N'chai', 1, N'Nước tương Maggi đậm đặc 300ml')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'GIAVI05   ', N'GIAVI     ', 14, N'bịch', 1, N'Bột bánh  chuối Hương Xưa 250g')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'GIAVI06   ', N'GIAVI     ', 28, N'bịch', 1, N'Bột tẩm khô chiên giòn Aji-Quick 84g')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'GIAVI07   ', N'GIAVI     ', 10, N'chai', 1, N'Sa tế Vị Hảo 250g')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'KEO01     ', N'KEO       ', 26, N'gói', 1, N'Kẹo mận Thái Lan')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'KEO02     ', N'KEO       ', 16, N'gói', 1, N'Kẹo Lotte Anytime Bluemarine 74g')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'KEO03     ', N'KEO       ', 36, N'gói', 1, N'Kẹo cứng hương Cherry Bonbon 80g')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'KEO04     ', N'KEO       ', 45, N'gói', 1, N'Kẹo Socola viên bi Choco-Rock-Marble 65g')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'KEO05     ', N'KEO       ', 14, N'gói', 1, N'Kẹo ngậm ho không đường Pulmoll Krish')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'KEO06     ', N'KEO       ', 14, N'gói', 1, N'Kẹo nhai Mentos hương trái cây 40 viên')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'KEO07     ', N'KEO       ', 58, N'gói', 1, N'Kẹo Chupa Chups vitamin C 100g')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'KEO08     ', N'KEO       ', 34, N'gói', 1, N'Kẹo Socola nhân hạt hạnh nhân Choco-Rock-Almond')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'KEO09     ', N'KEO       ', 22, N'gói', 1, N'Kẹo Socola Trà xanh Dars Morinaga 21g')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'KEO10     ', N'KEO       ', 26, N'gói', 1, N'Kẹo mận Thái Lan')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'MP01      ', N'MP        ', 38, N'chai', 1, N'Dầu gội đầu Tresemme Detox')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'MP02      ', N'MP        ', 18, N'lọ', 1, N'Sữa rửa mặt Nivia tẩy trang')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'MP03      ', N'MP        ', 48, N'chai', 1, N'Sữa tắm Enchanter 650')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'MP04      ', N'MP        ', 24, N'lọ', 1, N'Nước tẩy trang Bioderma hồng 100ml')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'MP05      ', N'MP        ', 15, N'lọ', 1, N'Sữa rửa mặt Laroche-Posay Pháp 200ml')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'MP06      ', N'MP        ', 45, N'lọ', 1, N'Toner Bioderma 100ml da nhạy cảm')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'MP07      ', N'MP        ', 14, N'lọ', 1, N'Son dưỡng môi lemonade đỏ cam')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'MP08      ', N'MP        ', 42, N'lọ', 1, N'Nước hoa Enchater hương hoa oải hương')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'MP09      ', N'MP        ', 12, N'lọ', 1, N'Sữa dưỡng thể Nivia')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'MP10      ', N'MP        ', 18, N'lọ', 1, N'Gel lột mặt Nha đam')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'RAUCU01   ', N'RAUCU     ', 10, N'05kg', 1, N'Bắp Mỹ siêu ngọt')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'RAUCU02   ', N'RAUCU     ', 20, N'1kg', 1, N'Cam Úc')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'RAUCU03   ', N'RAUCU     ', 15, N'1kg', 1, N'Kiwi xanh New Zealand')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'RAUCU04   ', N'RAUCU     ', 26, N'1kg', 1, N'Nho xanh không hạt Mỹ')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'RAUCU05   ', N'RAUCU     ', 8, N'1kg', 1, N'Cherry đỏ Mỹ')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'RAUCU06   ', N'RAUCU     ', 14, N'1kg', 1, N'Táo Jazz New Zealand')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'SUA01     ', N'SUA       ', 20, N'bịch', 1, N'BAD Gạo sữa dinh dưỡng')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'SUA02     ', N'SUA       ', 50, N'bịch', 1, N'Sữa Vinasoy nguyên chất')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'SUA03     ', N'SUA       ', 30, N'bịch', 1, N'BAD sữa gạo lức')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'SUA04     ', N'SUA       ', 28, N'hộp', 1, N'sữa Friso Gold 2')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'SUA05     ', N'SUA       ', 26, N'hộp', 1, N'Sữa Kun vị cam 110ml')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'SUA06     ', N'SUA       ', 22, N'hộp', 1, N'Nuti IQ 456 Gold')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'SUA07     ', N'SUA       ', 20, N'bịch', 1, N'BAD lúa mì')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'SUA08     ', N'SUA       ', 32, N'hộp', 1, N'Dielac Gold Step 2 400g')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'SUA09     ', N'SUA       ', 25, N'lon', 1, N'Sữa ông thọ')
INSERT [dbo].[HANGHOA] ([MASP], [MALOAI], [SOLUONG], [DVT], [HIDDEN], [TENSP]) VALUES (N'SUA10     ', N'SUA       ', 16, N'hộp', 1, N'Nuti Vita')
INSERT [dbo].[KHACH_HANG] ([MAKH], [TENKH], [DIACHI], [SDT], [TICHLUY], [EMAIL]) VALUES (N'KH1       ', N'Khách vãng lai', N'0', N'0', 0, N'0                                                 ')
INSERT [dbo].[KHACH_HANG] ([MAKH], [TENKH], [DIACHI], [SDT], [TICHLUY], [EMAIL]) VALUES (N'KH2       ', N'Tôn Võ Thủy Tiên', N'TP.HCM', N'1826371236', 123, N'thuytien@gmail.com                                ')
INSERT [dbo].[KHACH_HANG] ([MAKH], [TENKH], [DIACHI], [SDT], [TICHLUY], [EMAIL]) VALUES (N'KH3       ', N'Đại', N'HCM', N'0732467', 0, N'@mail                                             ')
INSERT [dbo].[KHACH_HANG] ([MAKH], [TENKH], [DIACHI], [SDT], [TICHLUY], [EMAIL]) VALUES (N'KH4       ', N'Hiếu Nhỏ', N'? Tr?n', N'023748', 0, N'@mail                                             ')
INSERT [dbo].[KHACH_HANG] ([MAKH], [TENKH], [DIACHI], [SDT], [TICHLUY], [EMAIL]) VALUES (N'KH5       ', N'Công', N'12aas', N'011123', 0, N't@gmail.com                                       ')
INSERT [dbo].[MAN_HINH] ([MaManHinh], [TenManHinh]) VALUES (N'frmBH', N'Form bán hàng')
INSERT [dbo].[MAN_HINH] ([MaManHinh], [TenManHinh]) VALUES (N'frmDM_KH', N'Form danh mục khách hàng')
INSERT [dbo].[MAN_HINH] ([MaManHinh], [TenManHinh]) VALUES (N'frmDM_MH', N'Form danh mục mặt hàng')
INSERT [dbo].[MAN_HINH] ([MaManHinh], [TenManHinh]) VALUES (N'frmDM_NV', N'Form danh mục nhân viên')
INSERT [dbo].[MAN_HINH] ([MaManHinh], [TenManHinh]) VALUES (N'frmHD', N'Form thống kê thu nhập')
INSERT [dbo].[NGUOIDUNG_NHOM_ND] ([TenDangNhap], [MaNhomNguoiDung]) VALUES (N'1', N'N1')
INSERT [dbo].[NGUOIDUNG_NHOM_ND] ([TenDangNhap], [MaNhomNguoiDung]) VALUES (N'1', N'N2')
INSERT [dbo].[NHA_CUNG_CAP] ([MANCC], [TEN_NCC], [DIACHI_NCC], [EMAIL_NCC], [SDT_NCC]) VALUES (N'NCC1      ', NULL, NULL, NULL, NULL)
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [CHUCVU], [PHAI_NV], [DIACHI_NV], [EMAIL], [NGAY_SINH], [LUONG]) VALUES (N'NV1       ', N'Kiều Hữu Thành', N'ban hang', 0, N'tphcm', N'email@              ', CAST(N'1998-01-01 00:00:00.000' AS DateTime), 6000000)
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [CHUCVU], [PHAI_NV], [DIACHI_NV], [EMAIL], [NGAY_SINH], [LUONG]) VALUES (N'NV2       ', N'Dương Ngọc Huy', N'nhap kho         ', 1, N'ha noi     ', N'email@              ', CAST(N'1998-01-02 00:00:00.000' AS DateTime), 6000000)
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [CHUCVU], [PHAI_NV], [DIACHI_NV], [EMAIL], [NGAY_SINH], [LUONG]) VALUES (N'NV3       ', N'Nguyễn Quốc Đại', N'ke toan', 1, N'da nang', N'email@              ', CAST(N'1998-01-01 00:00:00.000' AS DateTime), 6000000)
INSERT [dbo].[NHOM_NGUOI_DUNG] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'N1', N'Bán hàng', N'Bán hàng')
INSERT [dbo].[NHOM_NGUOI_DUNG] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'N2', N'Kho hàng', N'Quản lý kho hàng')
INSERT [dbo].[NHOM_NGUOI_DUNG] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'N3', N'Thống kê', N'Thống kê')
INSERT [dbo].[PHAN_QUYEN] ([MaNhomNguoiDung], [MaManHinh]) VALUES (N'N1', N'frmBH')
INSERT [dbo].[PHAN_QUYEN] ([MaNhomNguoiDung], [MaManHinh]) VALUES (N'N1', N'frmHD')
INSERT [dbo].[PHAN_QUYEN] ([MaNhomNguoiDung], [MaManHinh]) VALUES (N'N2', N'frmBH')
INSERT [dbo].[PHAN_QUYEN] ([MaNhomNguoiDung], [MaManHinh]) VALUES (N'N2', N'frmDM_MH')
INSERT [dbo].[PHAN_QUYEN] ([MaNhomNguoiDung], [MaManHinh]) VALUES (N'N3', N'frmHD')
INSERT [dbo].[PHIEUNHAP] ([MAPN], [MADDH], [NGAYLAP_PN], [TONGTIEN_PN]) VALUES (N'          ', NULL, NULL, NULL)
INSERT [dbo].[TAI_KHOAN] ([TENDN], [MANV], [MATKHAU], [HOATDONG]) VALUES (N'1                   ', N'NV1       ', N'1                   ', 1)
INSERT [dbo].[TAI_KHOAN] ([TENDN], [MANV], [MATKHAU], [HOATDONG]) VALUES (N'2                   ', N'NV2       ', N'2                   ', 1)
INSERT [dbo].[TAI_KHOAN] ([TENDN], [MANV], [MATKHAU], [HOATDONG]) VALUES (N'3                   ', N'NV3       ', N'3                   ', 1)
SET ANSI_PADDING ON

GO
/****** Object:  Index [PK_BANG_GIA]    Script Date: 13/12/2019 8:18:19 CH ******/
ALTER TABLE [dbo].[BANG_GIA] ADD  CONSTRAINT [PK_BANG_GIA] PRIMARY KEY NONCLUSTERED 
(
	[MASP] ASC,
	[NGAYBD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [PK_DANH_MUC_SP]    Script Date: 13/12/2019 8:18:19 CH ******/
ALTER TABLE [dbo].[DANH_MUC_SP] ADD  CONSTRAINT [PK_DANH_MUC_SP] PRIMARY KEY NONCLUSTERED 
(
	[MALOAI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [PK_DON_DAT_HANG_NCC]    Script Date: 13/12/2019 8:18:19 CH ******/
ALTER TABLE [dbo].[DON_DAT_HANG_NCC] ADD  CONSTRAINT [PK_DON_DAT_HANG_NCC] PRIMARY KEY NONCLUSTERED 
(
	[MADDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [PK_HANGHOA]    Script Date: 13/12/2019 8:18:19 CH ******/
ALTER TABLE [dbo].[HANGHOA] ADD  CONSTRAINT [PK_HANGHOA] PRIMARY KEY NONCLUSTERED 
(
	[MASP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [PK_HOA_DON]    Script Date: 13/12/2019 8:18:19 CH ******/
ALTER TABLE [dbo].[HOA_DON] ADD  CONSTRAINT [PK_HOA_DON] PRIMARY KEY NONCLUSTERED 
(
	[MAHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [PK_KHACH_HANG]    Script Date: 13/12/2019 8:18:19 CH ******/
ALTER TABLE [dbo].[KHACH_HANG] ADD  CONSTRAINT [PK_KHACH_HANG] PRIMARY KEY NONCLUSTERED 
(
	[MAKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [PK_NHA_CUNG_CAP]    Script Date: 13/12/2019 8:18:19 CH ******/
ALTER TABLE [dbo].[NHA_CUNG_CAP] ADD  CONSTRAINT [PK_NHA_CUNG_CAP] PRIMARY KEY NONCLUSTERED 
(
	[MANCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [PK_NHANVIEN]    Script Date: 13/12/2019 8:18:19 CH ******/
ALTER TABLE [dbo].[NHANVIEN] ADD  CONSTRAINT [PK_NHANVIEN] PRIMARY KEY NONCLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [PK_PHIEUNHAP]    Script Date: 13/12/2019 8:18:19 CH ******/
ALTER TABLE [dbo].[PHIEUNHAP] ADD  CONSTRAINT [PK_PHIEUNHAP] PRIMARY KEY NONCLUSTERED 
(
	[MAPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [PK_TAI_KHOAN]    Script Date: 13/12/2019 8:18:19 CH ******/
ALTER TABLE [dbo].[TAI_KHOAN] ADD  CONSTRAINT [PK_TAI_KHOAN] PRIMARY KEY NONCLUSTERED 
(
	[TENDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BANG_GIA]  WITH CHECK ADD  CONSTRAINT [FK_BANG_GIA_RELATIONS_HANGHOA] FOREIGN KEY([MASP])
REFERENCES [dbo].[HANGHOA] ([MASP])
GO
ALTER TABLE [dbo].[BANG_GIA] CHECK CONSTRAINT [FK_BANG_GIA_RELATIONS_HANGHOA]
GO
ALTER TABLE [dbo].[CHI_TIET_CC]  WITH CHECK ADD  CONSTRAINT [FK_CHI_TIET_RELATIONS_DANH_MUC] FOREIGN KEY([MALOAI])
REFERENCES [dbo].[DANH_MUC_SP] ([MALOAI])
GO
ALTER TABLE [dbo].[CHI_TIET_CC] CHECK CONSTRAINT [FK_CHI_TIET_RELATIONS_DANH_MUC]
GO
ALTER TABLE [dbo].[CHI_TIET_CC]  WITH CHECK ADD  CONSTRAINT [FK_CHI_TIET_RELATIONS_NHA_CUNG] FOREIGN KEY([MANCC])
REFERENCES [dbo].[NHA_CUNG_CAP] ([MANCC])
GO
ALTER TABLE [dbo].[CHI_TIET_CC] CHECK CONSTRAINT [FK_CHI_TIET_RELATIONS_NHA_CUNG]
GO
ALTER TABLE [dbo].[CHI_TIET_DDH]  WITH CHECK ADD  CONSTRAINT [FK_CHI_TIET_RELATIONS_DON_DAT_] FOREIGN KEY([MADDH])
REFERENCES [dbo].[DON_DAT_HANG_NCC] ([MADDH])
GO
ALTER TABLE [dbo].[CHI_TIET_DDH] CHECK CONSTRAINT [FK_CHI_TIET_RELATIONS_DON_DAT_]
GO
ALTER TABLE [dbo].[CHI_TIET_DDH]  WITH CHECK ADD  CONSTRAINT [FK_CHI_TIET_RELATIONS_HANGHOA] FOREIGN KEY([MASP])
REFERENCES [dbo].[HANGHOA] ([MASP])
GO
ALTER TABLE [dbo].[CHI_TIET_DDH] CHECK CONSTRAINT [FK_CHI_TIET_RELATIONS_HANGHOA]
GO
ALTER TABLE [dbo].[CHITIET_HD]  WITH CHECK ADD  CONSTRAINT [FK_CHITIET_HD_HANGHOA] FOREIGN KEY([MASP])
REFERENCES [dbo].[HANGHOA] ([MASP])
GO
ALTER TABLE [dbo].[CHITIET_HD] CHECK CONSTRAINT [FK_CHITIET_HD_HANGHOA]
GO
ALTER TABLE [dbo].[CHITIET_HD]  WITH CHECK ADD  CONSTRAINT [FK_CHITIET_HD_HOA_DON] FOREIGN KEY([MAHD])
REFERENCES [dbo].[HOA_DON] ([MAHD])
GO
ALTER TABLE [dbo].[CHITIET_HD] CHECK CONSTRAINT [FK_CHITIET_HD_HOA_DON]
GO
ALTER TABLE [dbo].[DON_DAT_HANG_NCC]  WITH CHECK ADD  CONSTRAINT [FK_DON_DAT__RELATIONS_NHA_CUNG] FOREIGN KEY([MANCC])
REFERENCES [dbo].[NHA_CUNG_CAP] ([MANCC])
GO
ALTER TABLE [dbo].[DON_DAT_HANG_NCC] CHECK CONSTRAINT [FK_DON_DAT__RELATIONS_NHA_CUNG]
GO
ALTER TABLE [dbo].[HANGHOA]  WITH CHECK ADD  CONSTRAINT [FK_HANGHOA_DANH_MUC_SP] FOREIGN KEY([MALOAI])
REFERENCES [dbo].[DANH_MUC_SP] ([MALOAI])
GO
ALTER TABLE [dbo].[HANGHOA] CHECK CONSTRAINT [FK_HANGHOA_DANH_MUC_SP]
GO
ALTER TABLE [dbo].[HOA_DON]  WITH CHECK ADD  CONSTRAINT [FK_HOA_DON_KHACH_HANG] FOREIGN KEY([MAKH])
REFERENCES [dbo].[KHACH_HANG] ([MAKH])
GO
ALTER TABLE [dbo].[HOA_DON] CHECK CONSTRAINT [FK_HOA_DON_KHACH_HANG]
GO
ALTER TABLE [dbo].[HOA_DON]  WITH CHECK ADD  CONSTRAINT [FK_HOA_DON_RELATIONS_NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[HOA_DON] CHECK CONSTRAINT [FK_HOA_DON_RELATIONS_NHANVIEN]
GO
ALTER TABLE [dbo].[KHUYEN_MAI]  WITH CHECK ADD  CONSTRAINT [FK_KHUYEN_MAI_HANGHOA] FOREIGN KEY([MASP])
REFERENCES [dbo].[HANGHOA] ([MASP])
GO
ALTER TABLE [dbo].[KHUYEN_MAI] CHECK CONSTRAINT [FK_KHUYEN_MAI_HANGHOA]
GO
ALTER TABLE [dbo].[LO_HANG]  WITH CHECK ADD  CONSTRAINT [FK_LO_HANG_HANGHOA] FOREIGN KEY([MASP])
REFERENCES [dbo].[HANGHOA] ([MASP])
GO
ALTER TABLE [dbo].[LO_HANG] CHECK CONSTRAINT [FK_LO_HANG_HANGHOA]
GO
ALTER TABLE [dbo].[LO_HANG]  WITH CHECK ADD  CONSTRAINT [FK_LO_HANG_RELATIONS_PHIEUNHA] FOREIGN KEY([MAPN])
REFERENCES [dbo].[PHIEUNHAP] ([MAPN])
GO
ALTER TABLE [dbo].[LO_HANG] CHECK CONSTRAINT [FK_LO_HANG_RELATIONS_PHIEUNHA]
GO
ALTER TABLE [dbo].[NGUOIDUNG_NHOM_ND]  WITH CHECK ADD  CONSTRAINT [FK_NGUOIDUNG_NHOM_ND_NHOM_NGUOI_DUNG] FOREIGN KEY([MaNhomNguoiDung])
REFERENCES [dbo].[NHOM_NGUOI_DUNG] ([MaNhom])
GO
ALTER TABLE [dbo].[NGUOIDUNG_NHOM_ND] CHECK CONSTRAINT [FK_NGUOIDUNG_NHOM_ND_NHOM_NGUOI_DUNG]
GO
ALTER TABLE [dbo].[NGUOIDUNG_NHOM_ND]  WITH CHECK ADD  CONSTRAINT [FK_NGUOIDUNG_NHOM_ND_TAI_KHOAN] FOREIGN KEY([TenDangNhap])
REFERENCES [dbo].[TAI_KHOAN] ([TENDN])
GO
ALTER TABLE [dbo].[NGUOIDUNG_NHOM_ND] CHECK CONSTRAINT [FK_NGUOIDUNG_NHOM_ND_TAI_KHOAN]
GO
ALTER TABLE [dbo].[PHAN_QUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHAN_QUYEN_MAN_HINH] FOREIGN KEY([MaManHinh])
REFERENCES [dbo].[MAN_HINH] ([MaManHinh])
GO
ALTER TABLE [dbo].[PHAN_QUYEN] CHECK CONSTRAINT [FK_PHAN_QUYEN_MAN_HINH]
GO
ALTER TABLE [dbo].[PHAN_QUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHAN_QUYEN_NHOM_NGUOI_DUNG] FOREIGN KEY([MaNhomNguoiDung])
REFERENCES [dbo].[NHOM_NGUOI_DUNG] ([MaNhom])
GO
ALTER TABLE [dbo].[PHAN_QUYEN] CHECK CONSTRAINT [FK_PHAN_QUYEN_NHOM_NGUOI_DUNG]
GO
ALTER TABLE [dbo].[PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUNHAP_DON_DAT_HANG_NCC] FOREIGN KEY([MADDH])
REFERENCES [dbo].[DON_DAT_HANG_NCC] ([MADDH])
GO
ALTER TABLE [dbo].[PHIEUNHAP] CHECK CONSTRAINT [FK_PHIEUNHAP_DON_DAT_HANG_NCC]
GO
ALTER TABLE [dbo].[TAI_KHOAN]  WITH CHECK ADD  CONSTRAINT [FK_TAI_KHOA_RELATIONS_NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[TAI_KHOAN] CHECK CONSTRAINT [FK_TAI_KHOA_RELATIONS_NHANVIEN]
GO
