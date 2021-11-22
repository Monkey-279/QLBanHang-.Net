Create database QLBanHang
use QLBanHang

create table KhachHang(
	MaKH char(4) primary key,
	TenKh nvarchar(50),
	SDT varchar(20),
	DiaChi nvarchar(50))

create table HoaDon(
	MaHD char(4) primary key,
	NgayLap date,
	MaKH char(4) references KhachHang(MaKH) on update cascade on delete cascade,
	NguoiLap varchar(10))

create table LoaiSanPham(
	MaLoai char(4) primary key,
	TenLoai nvarchar(50) not null)

create table NguoiDung(
	TenDangNhap varchar(30) primary key,
	MatKhau varchar(20) not null,
	HoTen varchar(30) not null)

create table SanPham(
	MaSP char(4) primary key,
	TenSP nvarchar(50) not null, 
	MaLoai char(4) references LoaiSanPham(MaLoai) on update cascade on delete cascade,
	SoLuong int,
	DonGia int)

create table HoaDonChiTiet(
	MaHD char(4) references HoaDon(MaHD) on update cascade on delete cascade,
	MaSP char(4) references SanPham(MaSP) on update cascade on delete cascade,
	SoLuongMua int,
	Primary key(MaHD, MaSP))

--Insert dữ liệu
insert into KhachHang values('KH01', N'Nguyễn Văn A', '0123456789', N'Hà Nội'),
('KH02', N'Tạ Văn H', '0123456789', N'Hà Tây'),
('KH03', N'Nguyễn Văn B', '0123456789', N'Hà Nam')

insert into HoaDon values('HD01', '2021/11/21', 'KH01', 'NhanVien A'),
('HD02', '2021/11/21', 'KH02', 'NhanVien B'),
('HD03', '2021/11/21', 'KH03', 'NhanVien C')

insert into LoaiSanPham values('L01', N'Loại A'),('L02', N'Loại B'),('L03', N'Loại C')

insert into NguoiDung values('dangnhap1', 'abcde', 'Ta Van H'), ('dangnhap2', '12345', 'Nguyen Van A'), ('dangnhap3', 'abcde', 'Nguyen Van B')

insert into SanPham values('SP01', N'Sản Phẩm A', 'L01', 100, 20000),
('SP02', N'Sản Phẩm A', 'L02', 50, 80000),
('SP03', N'Sản Phẩm A', 'L03', 100, 15000)

insert into HoaDonChiTiet values('HD01', 'SP01', 40), ('HD02', 'SP03', 60), ('HD01', 'SP02', 150)