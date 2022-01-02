USE [QUANLYBANHANG]
GO
/****** Object:  Table [dbo].[DONHANG]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONHANG](
	[MaDH] [varchar](10) NOT NULL,
	[NgayBan] [varchar](50) NULL,
	[KHACHHANG_FK] [varchar](10) NULL,
	[NHANVIEN_FK] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DONHANG_SANPHAM]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONHANG_SANPHAM](
	[MaDH] [varchar](10) NOT NULL,
	[MaSP] [varchar](10) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
	[DVT] [char](10) NULL,
 CONSTRAINT [PK_BANHANG_SANPHAM] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DONVITINH]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONVITINH](
	[MaDVT] [varchar](10) NOT NULL,
	[TenDVT] [nvarchar](20) NULL,
 CONSTRAINT [PK_DONVITINH] PRIMARY KEY CLUSTERED 
(
	[MaDVT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [varchar](10) NOT NULL,
	[TenKH] [nvarchar](100) NULL,
	[Diachi] [nvarchar](100) NULL,
	[SoDT] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[MaNCC] [varchar](10) NOT NULL,
	[TenNCC] [nvarchar](100) NULL,
	[Diachi] [nvarchar](100) NULL,
	[SoDT] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNv] [varchar](10) NOT NULL,
	[HoNv] [nvarchar](30) NULL,
	[TenNV] [nvarchar](100) NULL,
	[NgaySinh] [varchar](15) NULL,
	[dienthoai] [varchar](10) NULL,
	[CCCD] [varchar](12) NULL,
	[diachi] [nvarchar](100) NULL,
	[MaTrinhDo] [varchar](10) NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaNv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHAPHANG]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHAPHANG](
	[MaPN] [varchar](10) NOT NULL,
	[NgayNhap] [varchar](50) NULL,
	[NCC_FK] [varchar](10) NULL,
	[Nhanvien_FK] [varchar](10) NULL,
 CONSTRAINT [PK_NHAPHANG] PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHAPHANG_SANPHAM]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHAPHANG_SANPHAM](
	[MaPN] [varchar](10) NOT NULL,
	[MaSP] [varchar](10) NOT NULL,
	[Soluong] [int] NULL,
	[dongia] [int] NULL,
	[thanhtien] [int] NULL,
	[DVT] [nvarchar](20) NULL,
	[DONGIANHAP] [varchar](200) NULL,
	[DONGIA_NHAP] [float] NULL,
	[DONGIA_BAN] [float] NULL,
 CONSTRAINT [PK_NHAPHANG_SANPHAM] PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[MaSP] [varchar](10) NOT NULL,
	[TenSP] [nvarchar](300) NULL,
	[DVT] [varchar](10) NULL,
	[DONGIA_NHAP] [float] NULL,
	[DONGIA_BAN] [float] NULL,
 CONSTRAINT [PK__SANPHAM__2725081C24F6F7C3] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRINHDO]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRINHDO](
	[MATRINHDO] [varchar](10) NOT NULL,
	[TENTRINHDO] [nvarchar](50) NULL,
 CONSTRAINT [PK_TRINHDO] PRIMARY KEY CLUSTERED 
(
	[MATRINHDO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DONHANG] ([MaDH], [NgayBan], [KHACHHANG_FK], [NHANVIEN_FK]) VALUES (N'DH001', N'17-09-2021', N'01A13', N'00004')
GO
INSERT [dbo].[DONHANG] ([MaDH], [NgayBan], [KHACHHANG_FK], [NHANVIEN_FK]) VALUES (N'DH002', N'15-09-2021', N'01A6', N'00001')
GO
INSERT [dbo].[DONHANG] ([MaDH], [NgayBan], [KHACHHANG_FK], [NHANVIEN_FK]) VALUES (N'DH003', N'20-09-2021', N'01A8', N'00000')
GO
INSERT [dbo].[DONHANG] ([MaDH], [NgayBan], [KHACHHANG_FK], [NHANVIEN_FK]) VALUES (N'DH004', N'01-09-2021', N'01A12', N'00003')
GO
INSERT [dbo].[DONHANG] ([MaDH], [NgayBan], [KHACHHANG_FK], [NHANVIEN_FK]) VALUES (N'DH005', N'17-09-2021', N'01A13', N'00004')
GO
INSERT [dbo].[DONHANG_SANPHAM] ([MaDH], [MaSP], [SoLuong], [DonGia], [DVT]) VALUES (N'DH001', N'BDX05A', 3, 45000, N'Kg        ')
GO
INSERT [dbo].[DONHANG_SANPHAM] ([MaDH], [MaSP], [SoLuong], [DonGia], [DVT]) VALUES (N'DH001', N'SRR03A', 1, 80000, N'Kg        ')
GO
INSERT [dbo].[DONHANG_SANPHAM] ([MaDH], [MaSP], [SoLuong], [DonGia], [DVT]) VALUES (N'DH002', N'CCT07A', 4, 25000, N'Kg        ')
GO
INSERT [dbo].[DONHANG_SANPHAM] ([MaDH], [MaSP], [SoLuong], [DonGia], [DVT]) VALUES (N'DH002', N'NHM09A', 2, 90000, N'Kg        ')
GO
INSERT [dbo].[DONHANG_SANPHAM] ([MaDH], [MaSP], [SoLuong], [DonGia], [DVT]) VALUES (N'DH003', N'CCT07A', 8, 25000, N'Kg        ')
GO
INSERT [dbo].[DONHANG_SANPHAM] ([MaDH], [MaSP], [SoLuong], [DonGia], [DVT]) VALUES (N'DH004', N'BDX05A', 2, 45000, N'Kg        ')
GO
INSERT [dbo].[DONVITINH] ([MaDVT], [TenDVT]) VALUES (N'HOP', N'Hộp')
GO
INSERT [dbo].[DONVITINH] ([MaDVT], [TenDVT]) VALUES (N'Kg', N'Kg')
GO
INSERT [dbo].[DONVITINH] ([MaDVT], [TenDVT]) VALUES (N'THUNG', N'Thùng')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Diachi], [SoDT]) VALUES (N'01A1', N'Võ Thanh Thư', N'123/8  Phan Chu Trinh, phường 12 Quận 1, HCM', N'0984001123')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Diachi], [SoDT]) VALUES (N'01A10', N'Nguyễn Văn Minh', N'765/2 Bình Lợi , P13, Bình Thạnh, HCm', N'0984866132')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Diachi], [SoDT]) VALUES (N'01A11', N'Phan Thị Thanh', N'456 Nơ Trang Long , P12, Bình Thạnh. HCM', N'0984456133')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Diachi], [SoDT]) VALUES (N'01A12', N'Lê Ngọc Nga', N'358 Bùi Đình Túy, P13, Bình Thạnh, HCM', N'0984666134')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Diachi], [SoDT]) VALUES (N'01A13', N'Đỗ Phi Hải', N'566 Phan Chu Trinh , P 12, Bình Thạnh, HCM', N'0984456135')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Diachi], [SoDT]) VALUES (N'01A14', N'Phan Ân Hào', N' 238/7 Trần Quý Cáp, P13, Bình Thạnh, HCM', N'0984756136')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Diachi], [SoDT]) VALUES (N'01A2', N'Lê Hoài', N'5/7 Phan Chu Trinh , P 12, Bình Thạnh, HCM', N'0984000124')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Diachi], [SoDT]) VALUES (N'01A3', N'Phan Minh Phúc', N' 23 Trần Quý Cáp, P13, Bình Thạnh, HCM', N'0984456125')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Diachi], [SoDT]) VALUES (N'01A4', N'Đỗ Tâm An', N'111 Phan Xích Long, P2 , Phú Nhuận, HCM', N'0988966126')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Diachi], [SoDT]) VALUES (N'01A5', N'Trần Đại Lộc', N'336/90 Phan Văn Trị , P14, Bình Thạnh, HCM', N'0984456127')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Diachi], [SoDT]) VALUES (N'01A6', N'Ngô Cẩm Nga', N'69 Phan Văn Trị , P14, Bình Thạnh, HCM', N'0981236128')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Diachi], [SoDT]) VALUES (N'01A7', N'Lâm Ngọc Nhi', N'56 Hoa Sứ , Phú Nhuận, HCM', N'0984456129')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Diachi], [SoDT]) VALUES (N'01A8', N'Thái Quân Hào', N'432 Bùi Đình Túy, P13, Bình Thạnh, HCM', N'0982356130')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Diachi], [SoDT]) VALUES (N'01A9', N'Trịnh Gia văn', N'888 Cô Giang, P1, Quận 1, HCM', N'0984456131')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Diachi], [SoDT]) VALUES (N'TEST', N'sadsadas', N'asdsadsa', N'1234567890')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [Diachi], [SoDT]) VALUES (N'01490024K', N'Công ty TNHH Hồng Anh Hạ Long', N'Tổ 1 khu 6, phường Hồng Hà, TP Hạ Long, tỉnh Quảng Ninh, VN', N'0984167823')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [Diachi], [SoDT]) VALUES (N'01490025K', N'Công ty TNHH thương mại dịch vụ Hoàng Lê Dương', N'Ô sô 38-39 khu mở rộng, tổ 11, khu 6, P. Hồng Hà, TP hạ Long, tỉnh Quảng Ninh', N'0919898989')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [Diachi], [SoDT]) VALUES (N'01490026K', N'Công ty TNHH Long Nhu', N'Khu 8 - Hải Hòa - Móng Cái - Quảng Ninh', N'0919568742')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [Diachi], [SoDT]) VALUES (N'01490027K', N'CN công ty CP xăng dầu Thành Phúc tại Quảng Ninh', N'Thôn Tân Yên, X. Hồng Thái Đông, TX. Đồng Triều, tỉnh Quảng Ninh', N'0902789456')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [Diachi], [SoDT]) VALUES (N'01490028K', N'Công ty xăng dầu B12 - Xí nghiệp xăng dầu Quảng Ninh', N'Khu I, P. Bãi Cháy, TP Hạ Long, tỉnh Quảng Ninh, Việt Nam', N'0913191919')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [Diachi], [SoDT]) VALUES (N'01490029K', N'Công ty cổ phần đầu tư thương mại và dịch vụ du lịch Bài Thơ', N'Ô C15, khu đô thị Nam Tuần Châu, P Tuần Châu, TP Hạ Long, tỉnh Quảng Ninh, Việt Nam', N'0902878987')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [Diachi], [SoDT]) VALUES (N'01490030K', N'Doanh nghiệp tư nhân Hoàng Nhật Minh', N'Tổ 92, khu đồn điền, P Hà Khẩu, Tp Hạ Long, tỉnh Quảng Ninh', N'0979123456')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [Diachi], [SoDT]) VALUES (N'01490032K', N'Công Ty TNHH TMDV Lữ Hành Duy Minh', N'Số 65, tổ 8, Thị Trấn  Sóc Sơn, H.Sóc Sơn, TP Hà Nội, Việt Nam', N'0913564852')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [Diachi], [SoDT]) VALUES (N'01490033Y', N'Công Ty TNHH Dược Phẩm Hồng Dương', N'Tổ 1, khu I, phường Trần Hưng Đạo, TP Hạ Long, tỉnh Quảng Ninh', N'0979454545')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [Diachi], [SoDT]) VALUES (N'01490034K', N'CÔNG TY TNHH VẬT LIỆU CHỊU LỬA 79', N'Số 138, Đường Hậu Cần, Phường Bãi Cháy, Thành phố Hạ Long, Tỉnh Quảng Ninh', N'0902654789')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [Diachi], [SoDT]) VALUES (N'01490034Y', N'Viện Y Học Hải Quân', N'Số 13 đường Phạm Văn Đồng, Phường Anh Dũng, Quận Dương Kinh, Tp Hải Phòng', N'0984563214')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [Diachi], [SoDT]) VALUES (N'01490035C', N'CÔNG TY CỔ PHẦN TÂM ĐỨC CẨM PHẢ ', N'SN 20, Tổ 1, Khu Hai Giếng 1, P. Cẩm Thủy, TP. Cẩm Phả, Quảng Ninh', N'0902452399')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [Diachi], [SoDT]) VALUES (N'01490035K', N'CÔNG TY CỔ PHẦN THƯƠNG MẠI VÀ DƯỢC PHẨM NAM VIỆT', N'Số 159 Lê Chuẩn, Tổ 1, Khu 2, P. Hồng Hà, Tp. Hạ Long, Tỉnh Quảng Ninh', N'0902999999')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [Diachi], [SoDT]) VALUES (N'01490036K', N'CT CP TM LOGISTIC TRUNG THÀNH', N'Số nhà 22, Ngõ 411, Khu 7, TT Cái Rồng, H Vân Đồn, Tỉnh Quảng Ninh, VN', N'0902555555')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [Diachi], [SoDT]) VALUES (N'01550004K', N'Công Ty TNHH Xăng Dầu Mạnh Quỳnh', N'SN 151, Tiểu khu Cầu Trắng, Thị Trấn Du, H. Phú Lương, T. Thái Nguyên', N'0913131313')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [Diachi], [SoDT]) VALUES (N'TEST', N'sadsadsad', N'sadsadsada', N'1234567890')
GO
INSERT [dbo].[NHANVIEN] ([MaNv], [HoNv], [TenNV], [NgaySinh], [dienthoai], [CCCD], [diachi], [MaTrinhDo]) VALUES (N'00000', N'Huỳnh Văn', N'Danh', N'21-09-1982', N'0999999991', N'011225445123', N'Lô 7 Đinh Độc Lập', N'CD')
GO
INSERT [dbo].[NHANVIEN] ([MaNv], [HoNv], [TenNV], [NgaySinh], [dienthoai], [CCCD], [diachi], [MaTrinhDo]) VALUES (N'00001', N'Quang Minh', N'Tám', N'16-09-1983', N'0903686666', N'023444000123', N'số 1 nơ trang long,p 25, bình thạnh', N'CD')
GO
INSERT [dbo].[NHANVIEN] ([MaNv], [HoNv], [TenNV], [NgaySinh], [dienthoai], [CCCD], [diachi], [MaTrinhDo]) VALUES (N'00002', N'Đinh Quốc', N'Em', N'10-11-2009', N'0998333654', N'145988764123', N'số 2 lê quang định,p3,bỉnh thạnh', N'DH')
GO
INSERT [dbo].[NHANVIEN] ([MaNv], [HoNv], [TenNV], [NgaySinh], [dienthoai], [CCCD], [diachi], [MaTrinhDo]) VALUES (N'00003', N'Ngô Quang Thành', N'Thật', N'01-07-2001', N'1832088896', N'784213345123', N'số 3 morning star, phạm ngũ lão, q1', N'ts')
GO
INSERT [dbo].[NHANVIEN] ([MaNv], [HoNv], [TenNV], [NgaySinh], [dienthoai], [CCCD], [diachi], [MaTrinhDo]) VALUES (N'00004', N'Lê Thị Tuyết', N'Bạch', N'10-11-2005', N'0605478966', N'002145879123', N'số 5 lầu 5 gốc,qua sinh tơn, hoa kỳ', N'ths')
GO
INSERT [dbo].[NHANVIEN] ([MaNv], [HoNv], [TenNV], [NgaySinh], [dienthoai], [CCCD], [diachi], [MaTrinhDo]) VALUES (N'00005', N'Khơ U', N'Ly', N'22-07-2010', N'0215478964', N'901512593123', N'số 6 cổng ga Chợ Lớn, quận 5', N'Tc')
GO
INSERT [dbo].[NHAPHANG] ([MaPN], [NgayNhap], [NCC_FK], [Nhanvien_FK]) VALUES (N'00001', N'01-09-2021', N'01490024K', N'00001')
GO
INSERT [dbo].[NHAPHANG] ([MaPN], [NgayNhap], [NCC_FK], [Nhanvien_FK]) VALUES (N'00002', N'08-07-2021', N'01490028K', N'00002')
GO
INSERT [dbo].[NHAPHANG] ([MaPN], [NgayNhap], [NCC_FK], [Nhanvien_FK]) VALUES (N'00003', N'07-10-2021', N'01490030K', N'00001')
GO
INSERT [dbo].[NHAPHANG] ([MaPN], [NgayNhap], [NCC_FK], [Nhanvien_FK]) VALUES (N'00004', N'20-12-2021', N'01490035K', N'00001')
GO
INSERT [dbo].[NHAPHANG] ([MaPN], [NgayNhap], [NCC_FK], [Nhanvien_FK]) VALUES (N'00005', N'01-08-2021', N'01490024K', N'00002')
GO
INSERT [dbo].[NHAPHANG] ([MaPN], [NgayNhap], [NCC_FK], [Nhanvien_FK]) VALUES (N'00006', N'01-08-2021', N'01490034Y', N'00002')
GO
INSERT [dbo].[NHAPHANG_SANPHAM] ([MaPN], [MaSP], [Soluong], [dongia], [thanhtien], [DVT], [DONGIANHAP], [DONGIA_NHAP], [DONGIA_BAN]) VALUES (N'00001', N'BDX05A', 6, 45000, 270000, N'kg', NULL, 35, 45)
GO
INSERT [dbo].[NHAPHANG_SANPHAM] ([MaPN], [MaSP], [Soluong], [dongia], [thanhtien], [DVT], [DONGIANHAP], [DONGIA_NHAP], [DONGIA_BAN]) VALUES (N'00002', N'SRR03A', 10, 80000, 800000, N'kg', NULL, 60, 80)
GO
INSERT [dbo].[NHAPHANG_SANPHAM] ([MaPN], [MaSP], [Soluong], [dongia], [thanhtien], [DVT], [DONGIANHAP], [DONGIA_NHAP], [DONGIA_BAN]) VALUES (N'00003', N'NHM09A', 5, 90000, 450000, N'kg', NULL, 60, 90)
GO
INSERT [dbo].[NHAPHANG_SANPHAM] ([MaPN], [MaSP], [Soluong], [dongia], [thanhtien], [DVT], [DONGIANHAP], [DONGIA_NHAP], [DONGIA_BAN]) VALUES (N'00004', N'CCT07A', 20, 25000, 500000, N'kg', NULL, 15, 25)
GO
INSERT [dbo].[NHAPHANG_SANPHAM] ([MaPN], [MaSP], [Soluong], [dongia], [thanhtien], [DVT], [DONGIANHAP], [DONGIA_NHAP], [DONGIA_BAN]) VALUES (N'00005', N'BDX05A', 10, 45000, 450000, N'kg', NULL, 35, 45)
GO
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [DVT], [DONGIA_NHAP], [DONGIA_BAN]) VALUES (N'BDX05A', N'Bưởi da xanh ', N'Kg', 35000, 45000)
GO
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [DVT], [DONGIA_NHAP], [DONGIA_BAN]) VALUES (N'BNR06A', N'Bưởi 5 roi ', N'Kg', 35000, 50000)
GO
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [DVT], [DONGIA_NHAP], [DONGIA_BAN]) VALUES (N'CCT07A', N'Chôm chôm thái', N'Kg', 15000, 25000)
GO
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [DVT], [DONGIA_NHAP], [DONGIA_BAN]) VALUES (N'CHS10A', N'Chuối sứ', N'Kg', 10000, 16000)
GO
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [DVT], [DONGIA_NHAP], [DONGIA_BAN]) VALUES (N'DHL04A', N'Dưa hấu Long An', N'Kg', 10000, 15000)
GO
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [DVT], [DONGIA_NHAP], [DONGIA_BAN]) VALUES (N'MCL08A', N'Măng cụt', N'Kg', 50000, 80000)
GO
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [DVT], [DONGIA_NHAP], [DONGIA_BAN]) VALUES (N'NHM09A', N'Nho Mỹ', N'Kg', 60000, 90000)
GO
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [DVT], [DONGIA_NHAP], [DONGIA_BAN]) VALUES (N'SRR03A', N'Sầu riêng ri 6', N'Kg', 60000, 80000)
GO
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [DVT], [DONGIA_NHAP], [DONGIA_BAN]) VALUES (N'TLD01A', N'Thanh long ruột đỏ', N'Kg', 20000, 30000)
GO
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [DVT], [DONGIA_NHAP], [DONGIA_BAN]) VALUES (N'TLT02A', N'Thanh long ruột trắng', N'Kg', 15000, 25000)
GO
INSERT [dbo].[TRINHDO] ([MATRINHDO], [TENTRINHDO]) VALUES (N'CD', N'Cao Đẳng')
GO
INSERT [dbo].[TRINHDO] ([MATRINHDO], [TENTRINHDO]) VALUES (N'DH', N'Đại Học')
GO
INSERT [dbo].[TRINHDO] ([MATRINHDO], [TENTRINHDO]) VALUES (N'TC', N'Trung Cấp')
GO
INSERT [dbo].[TRINHDO] ([MATRINHDO], [TENTRINHDO]) VALUES (N'ThS', N'Thạc Sĩ')
GO
INSERT [dbo].[TRINHDO] ([MATRINHDO], [TENTRINHDO]) VALUES (N'TS', N'Tiến Sĩ')
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_DONHANG_KHACHHANG] FOREIGN KEY([KHACHHANG_FK])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[DONHANG] CHECK CONSTRAINT [FK_DONHANG_KHACHHANG]
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_DONHANG_NHANVIEN] FOREIGN KEY([NHANVIEN_FK])
REFERENCES [dbo].[NHANVIEN] ([MaNv])
GO
ALTER TABLE [dbo].[DONHANG] CHECK CONSTRAINT [FK_DONHANG_NHANVIEN]
GO
ALTER TABLE [dbo].[DONHANG_SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_BANHANG_SANPHAM_DONHANG] FOREIGN KEY([MaDH])
REFERENCES [dbo].[DONHANG] ([MaDH])
GO
ALTER TABLE [dbo].[DONHANG_SANPHAM] CHECK CONSTRAINT [FK_BANHANG_SANPHAM_DONHANG]
GO
ALTER TABLE [dbo].[DONHANG_SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_BANHANG_SANPHAM_SANPHAM] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SANPHAM] ([MaSP])
GO
ALTER TABLE [dbo].[DONHANG_SANPHAM] CHECK CONSTRAINT [FK_BANHANG_SANPHAM_SANPHAM]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_TRINHDO] FOREIGN KEY([MaTrinhDo])
REFERENCES [dbo].[TRINHDO] ([MATRINHDO])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_TRINHDO]
GO
ALTER TABLE [dbo].[NHAPHANG]  WITH CHECK ADD  CONSTRAINT [FK_NHAPHANG_NHACUNGCAP] FOREIGN KEY([NCC_FK])
REFERENCES [dbo].[NHACUNGCAP] ([MaNCC])
GO
ALTER TABLE [dbo].[NHAPHANG] CHECK CONSTRAINT [FK_NHAPHANG_NHACUNGCAP]
GO
ALTER TABLE [dbo].[NHAPHANG]  WITH CHECK ADD  CONSTRAINT [FK_NHAPHANG_NHANVIEN] FOREIGN KEY([Nhanvien_FK])
REFERENCES [dbo].[NHANVIEN] ([MaNv])
GO
ALTER TABLE [dbo].[NHAPHANG] CHECK CONSTRAINT [FK_NHAPHANG_NHANVIEN]
GO
ALTER TABLE [dbo].[NHAPHANG_SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_NHAPHANG_SANPHAM_NHAPHANG] FOREIGN KEY([MaPN])
REFERENCES [dbo].[NHAPHANG] ([MaPN])
GO
ALTER TABLE [dbo].[NHAPHANG_SANPHAM] CHECK CONSTRAINT [FK_NHAPHANG_SANPHAM_NHAPHANG]
GO
ALTER TABLE [dbo].[NHAPHANG_SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_NHAPHANG_SANPHAM_SANPHAM] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SANPHAM] ([MaSP])
GO
ALTER TABLE [dbo].[NHAPHANG_SANPHAM] CHECK CONSTRAINT [FK_NHAPHANG_SANPHAM_SANPHAM]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_DONVITINH] FOREIGN KEY([DVT])
REFERENCES [dbo].[DONVITINH] ([MaDVT])
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_SANPHAM_DONVITINH]
GO
/****** Object:  StoredProcedure [dbo].[KiemTraMaDH]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[KiemTraMaDH] (@DHID nvarchar(10))
as
	declare @n int;

	if exists (select top 1 MaDH from donhang where MaDH=@DHID)
	set @n=1;
	
	else
		set @n=0;
	return @n
GO
/****** Object:  StoredProcedure [dbo].[KiemTraMaKH]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[KiemTraMaKH] (@customerID nvarchar(10))
as
	declare @n int;

	if exists (select top 1 MaKH from khachhang where MaKH=@customerID)
	set @n=1;
	
	else
		set @n=0;
	return @n
GO
/****** Object:  StoredProcedure [dbo].[KiemTraMaNCC]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[KiemTraMaNCC] (@vendorID nvarchar(10))
as
	declare @n int;

	if exists (select top 1 MaNCC from Nhacungcap where MaNCC=@vendorID)
	set @n=1;
	
	else
		set @n=0;
	return @n
GO
/****** Object:  StoredProcedure [dbo].[KiemTraMaNV]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[KiemTraMaNV] (@customerID nvarchar(10))
as
	declare @n int;

	if exists (select top 1 MaNV from nhanvien where MaNv=@customerID)
	set @n=1;
	
	else
		set @n=0;
	return @n
GO
/****** Object:  StoredProcedure [dbo].[KiemTraMaPN]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[KiemTraMaPN] (@PNID nvarchar(10))
as
	declare @n int;

	if exists (select top 1 MaPN from Nhaphang where MaPN=@PNID)
	set @n=1;
	
	else
		set @n=0;
	return @n
GO
/****** Object:  StoredProcedure [dbo].[KiemTraMaSP]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[KiemTraMaSP] (@ProductID nvarchar(10))
as
	declare @n int;

	if exists (select top 1 MaSP from SANPHAM where MaSP=@ProductID)
	set @n=1;
	
	else
		set @n=0;
	return @n
GO
/****** Object:  StoredProcedure [dbo].[KiemTraTonKho]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[KiemTraTonKho] ( @MaSp varchar(10))
as

	declare  @slton varchar(10)
	declare @n int;

	select  @slton=sum(isnull(a.Soluong, 0) - isnull(b.SoLuong, 0)) 
	 from NHAPHANG_SANPHAM a 
		left join DONHANG_SANPHAM b on a.MaSP = b.MaSP		
	 where a.MaSP = @MaSp

	 if(@slton >=0)

	 set @n=1;
	
	else
		set @n=0;
	return @n
GO
/****** Object:  StoredProcedure [dbo].[KiemTraXoaDH]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[KiemTraXoaDH] (@DHID nvarchar(10))
as
	declare @n int;

	if exists (select top 1 MaDH from DONHANG_SANPHAM where MADH=@DHID)
	set @n=1;
	
	else
		set @n=0;
	return @n
GO
/****** Object:  StoredProcedure [dbo].[KiemTraXoaPN]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[KiemTraXoaPN] (@PNID nvarchar(10))
as
	declare @n int;

	if exists (select top 1 MaPN from NHAPHANG_SANPHAM where MaPN=@PNID)
	set @n=1;
	
	else
		set @n=0;
	return @n
GO
/****** Object:  StoredProcedure [dbo].[TonKho]    Script Date: Tue 21 09 2021 5:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[TonKho] (@dFrom smalldatetime, @dTo smalldatetime, @Item varchar(33))
as

		select d.MaPN,c.MaSP, c.TenSP, c.DVT , NgayNhap,e.MaDH,e.NgayBan 
	, SUM(isnull(a.Soluong,0)) as sl_nhap,SUM(isnull(b.Soluong,0)) sl_xuat, SUM(isnull(a.Soluong, 0) - isnull(b.SoLuong, 0)) as sl_ton
	 from NHAPHANG_SANPHAM a 
		left join DONHANG_SANPHAM b on a.MaSP = b.MaSP
		left join SANPHAM c on a.MaSP = c.MaSP
		left join nhaphang d on a.mapn = d.mapn
		left join DONHANG e on e.MaDH=b.MaDH
		where convert(smalldatetime, convert(datetime, left(NgayNhap, 10), 103), 112) between @dFrom and @dTo
			and a.MaSP = @Item
		GROUP BY d.MaPN,c.MaSP, c.TenSP, c.DVT , NgayNhap,e.MaDH,e.NgayBan 
		order by d.MaPN,e.NgayBan
GO
