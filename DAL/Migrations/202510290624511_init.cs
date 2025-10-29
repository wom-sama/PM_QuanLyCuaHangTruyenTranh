namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BangLuongs",
                c => new
                    {
                        MaBangLuong = c.Int(nullable: false, identity: true),
                        MaNV = c.String(nullable: false, maxLength: 20, unicode: false),
                        LuongCoBan = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PhuCap = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Thuong = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KhauTru = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThangTinhLuong = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaBangLuong)
                .ForeignKey("dbo.NhanViens", t => t.MaNV)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 20, unicode: false),
                        HoTen = c.String(nullable: false, maxLength: 100),
                        GioiTinh = c.String(maxLength: 10),
                        NgaySinh = c.DateTime(nullable: false),
                        SoDienThoai = c.String(maxLength: 15),
                        Email = c.String(maxLength: 100),
                        DiaChi = c.String(maxLength: 255),
                        TrangThai = c.Boolean(nullable: false),
                        AnhDaiDien = c.Binary(),
                        MaChucVu = c.String(nullable: false, maxLength: 20),
                        MaChiNhanh = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.MaNV)
                .ForeignKey("dbo.ChiNhanhs", t => t.MaChiNhanh)
                .ForeignKey("dbo.ChucVus", t => t.MaChucVu)
                .Index(t => t.MaChucVu)
                .Index(t => t.MaChiNhanh);
            
            CreateTable(
                "dbo.ChiNhanhs",
                c => new
                    {
                        MaChiNhanh = c.String(nullable: false, maxLength: 20, unicode: false),
                        TenChiNhanh = c.String(nullable: false, maxLength: 100),
                        DiaChi = c.String(maxLength: 255),
                        SoDienThoai = c.String(maxLength: 15),
                        Email = c.String(maxLength: 100),
                        TrangThai = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaChiNhanh);
            
            CreateTable(
                "dbo.Khoes",
                c => new
                    {
                        MaKho = c.String(nullable: false, maxLength: 20, unicode: false),
                        TenKho = c.String(nullable: false, maxLength: 100),
                        MaChiNhanh = c.String(maxLength: 20, unicode: false),
                        LoaiKho = c.String(maxLength: 50),
                        TrangThai = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaKho)
                .ForeignKey("dbo.ChiNhanhs", t => t.MaChiNhanh)
                .Index(t => t.MaChiNhanh);
            
            CreateTable(
                "dbo.ChuyenKhoes",
                c => new
                    {
                        MaPhieuChuyen = c.String(nullable: false, maxLength: 20, unicode: false),
                        NgayChuyen = c.DateTime(nullable: false),
                        MaKhoXuat = c.String(maxLength: 20, unicode: false),
                        MaKhoNhap = c.String(maxLength: 20, unicode: false),
                        GhiChu = c.String(maxLength: 255),
                        Kho_MaKho = c.String(maxLength: 20, unicode: false),
                        Kho_MaKho1 = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.MaPhieuChuyen)
                .ForeignKey("dbo.Khoes", t => t.MaKhoNhap)
                .ForeignKey("dbo.Khoes", t => t.MaKhoXuat)
                .ForeignKey("dbo.Khoes", t => t.Kho_MaKho)
                .ForeignKey("dbo.Khoes", t => t.Kho_MaKho1)
                .Index(t => t.MaKhoXuat)
                .Index(t => t.MaKhoNhap)
                .Index(t => t.Kho_MaKho)
                .Index(t => t.Kho_MaKho1);
            
            CreateTable(
                "dbo.KeSaches",
                c => new
                    {
                        MaKe = c.String(nullable: false, maxLength: 20, unicode: false),
                        TenKe = c.String(nullable: false, maxLength: 100),
                        MaKho = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.MaKe)
                .ForeignKey("dbo.Khoes", t => t.MaKho)
                .Index(t => t.MaKho);
            
            CreateTable(
                "dbo.KiemKes",
                c => new
                    {
                        MaKiemKe = c.String(nullable: false, maxLength: 20, unicode: false),
                        NgayKiemKe = c.DateTime(nullable: false),
                        MaKho = c.String(maxLength: 20, unicode: false),
                        MaNV = c.String(maxLength: 20, unicode: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaKiemKe)
                .ForeignKey("dbo.Khoes", t => t.MaKho)
                .ForeignKey("dbo.NhanViens", t => t.MaNV)
                .Index(t => t.MaKho)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.NhapKhoes",
                c => new
                    {
                        MaPhieuNhap = c.String(nullable: false, maxLength: 20, unicode: false),
                        NgayNhap = c.DateTime(nullable: false),
                        MaNV = c.String(maxLength: 20, unicode: false),
                        MaKho = c.String(maxLength: 20, unicode: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaPhieuNhap)
                .ForeignKey("dbo.Khoes", t => t.MaKho)
                .ForeignKey("dbo.NhanViens", t => t.MaNV)
                .Index(t => t.MaNV)
                .Index(t => t.MaKho);
            
            CreateTable(
                "dbo.CT_NhapKho",
                c => new
                    {
                        MaPhieuNhap = c.String(nullable: false, maxLength: 20, unicode: false),
                        MaSach = c.String(nullable: false, maxLength: 20, unicode: false),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.MaPhieuNhap, t.MaSach })
                .ForeignKey("dbo.NhapKhoes", t => t.MaPhieuNhap, cascadeDelete: true)
                .ForeignKey("dbo.Saches", t => t.MaSach, cascadeDelete: true)
                .Index(t => t.MaPhieuNhap)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.Saches",
                c => new
                    {
                        MaSach = c.String(nullable: false, maxLength: 20, unicode: false),
                        TenSach = c.String(nullable: false, maxLength: 200),
                        ISBN = c.String(maxLength: 20),
                        MaNXB = c.String(maxLength: 20),
                        MaTacGia = c.String(maxLength: 20),
                        MaTheLoai = c.String(maxLength: 128),
                        GiaNhap = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GiaBan = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SoTrang = c.Int(nullable: false),
                        NamXuatBan = c.Int(nullable: false),
                        MoTa = c.String(),
                        TrangThai = c.Boolean(nullable: false),
                        BiaSach = c.Binary(),
                    })
                .PrimaryKey(t => t.MaSach)
                .ForeignKey("dbo.NhaXuatBans", t => t.MaNXB)
                .ForeignKey("dbo.TacGias", t => t.MaTacGia)
                .ForeignKey("dbo.TheLoais", t => t.MaTheLoai)
                .Index(t => t.MaNXB)
                .Index(t => t.MaTacGia)
                .Index(t => t.MaTheLoai);
            
            CreateTable(
                "dbo.CT_DonHang",
                c => new
                    {
                        MaDonHang = c.String(nullable: false, maxLength: 20, unicode: false),
                        MaSach = c.String(nullable: false, maxLength: 20, unicode: false),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThanhTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.MaDonHang, t.MaSach })
                .ForeignKey("dbo.DonHangs", t => t.MaDonHang, cascadeDelete: true)
                .ForeignKey("dbo.Saches", t => t.MaSach, cascadeDelete: true)
                .Index(t => t.MaDonHang)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.DonHangs",
                c => new
                    {
                        MaDonHang = c.String(nullable: false, maxLength: 20, unicode: false),
                        MaKhach = c.String(maxLength: 50, unicode: false),
                        MaNV = c.String(maxLength: 20, unicode: false),
                        NgayDat = c.DateTime(nullable: false),
                        NgayGiao = c.DateTime(),
                        TongTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoaiDon = c.String(maxLength: 20),
                        TrangThai = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaDonHang)
                .ForeignKey("dbo.KhachHangs", t => t.MaKhach)
                .ForeignKey("dbo.NhanViens", t => t.MaNV)
                .Index(t => t.MaKhach)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        TenDangNhap = c.String(nullable: false, maxLength: 50, unicode: false),
                        HoTen = c.String(nullable: false, maxLength: 100),
                        SoDienThoai = c.String(maxLength: 15, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        DiaChi = c.String(maxLength: 255),
                        NgayDangKy = c.DateTime(nullable: false),
                        AnhDaiDien = c.Binary(),
                        NgaySinh = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TenDangNhap)
                .ForeignKey("dbo.TaiKhoans", t => t.TenDangNhap)
                .Index(t => t.TenDangNhap);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        MaHoaDon = c.String(nullable: false, maxLength: 20, unicode: false),
                        MaDonHang = c.String(maxLength: 20, unicode: false),
                        NgayLap = c.DateTime(nullable: false),
                        TongTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HinhThucThanhToan = c.String(),
                        KhachHang_TenDangNhap = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.DonHangs", t => t.MaDonHang)
                .ForeignKey("dbo.KhachHangs", t => t.KhachHang_TenDangNhap)
                .Index(t => t.MaDonHang)
                .Index(t => t.KhachHang_TenDangNhap);
            
            CreateTable(
                "dbo.TaiKhoans",
                c => new
                    {
                        TenDangNhap = c.String(nullable: false, maxLength: 50, unicode: false),
                        MatKhau = c.String(nullable: false, maxLength: 255, unicode: false),
                        MaNhanVien = c.String(maxLength: 20, unicode: false),
                        Quyen = c.String(nullable: false, maxLength: 50),
                        TrangThai = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TenDangNhap)
                .ForeignKey("dbo.NhanViens", t => t.MaNhanVien)
                .Index(t => t.MaNhanVien);
            
            CreateTable(
                "dbo.VanChuyens",
                c => new
                    {
                        MaDonHang = c.String(nullable: false, maxLength: 20, unicode: false),
                        MaDVVC = c.String(nullable: false, maxLength: 20, unicode: false),
                        NgayTao = c.DateTime(nullable: false),
                        NgayGiao = c.DateTime(),
                        TrangThai = c.String(maxLength: 100),
                        GhiChu = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.MaDonHang)
                .ForeignKey("dbo.DonViVanChuyens", t => t.MaDVVC)
                .ForeignKey("dbo.DonHangs", t => t.MaDonHang)
                .Index(t => t.MaDonHang)
                .Index(t => t.MaDVVC);
            
            CreateTable(
                "dbo.DonViVanChuyens",
                c => new
                    {
                        MaDVVC = c.String(nullable: false, maxLength: 20, unicode: false),
                        TenDonVi = c.String(nullable: false, maxLength: 100),
                        SoDienThoai = c.String(maxLength: 15),
                        PhiCoBan = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MoTa = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.MaDVVC);
            
            CreateTable(
                "dbo.NhaXuatBans",
                c => new
                    {
                        MaNXB = c.String(nullable: false, maxLength: 20),
                        TenNXB = c.String(nullable: false, maxLength: 100),
                        DiaChi = c.String(maxLength: 255),
                        SoDienThoai = c.String(maxLength: 15),
                        Email = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.MaNXB);
            
            CreateTable(
                "dbo.TacGias",
                c => new
                    {
                        MaTacGia = c.String(nullable: false, maxLength: 20),
                        TenTacGia = c.String(nullable: false, maxLength: 100),
                        QuocTich = c.String(maxLength: 50),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaTacGia);
            
            CreateTable(
                "dbo.TheLoais",
                c => new
                    {
                        MaTheLoai = c.String(nullable: false, maxLength: 128),
                        TenTheLoai = c.String(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaTheLoai);
            
            CreateTable(
                "dbo.ChucVus",
                c => new
                    {
                        MaChucVu = c.String(nullable: false, maxLength: 20),
                        TenChucVu = c.String(nullable: false, maxLength: 50),
                        MoTa = c.String(),
                    })
                .PrimaryKey(t => t.MaChucVu);
            
            CreateTable(
                "dbo.PhanCongs",
                c => new
                    {
                        MaPhanCong = c.Int(nullable: false, identity: true),
                        MaNV = c.String(nullable: false, maxLength: 20, unicode: false),
                        MaCongViec = c.Int(),
                        TenCongViec = c.String(nullable: false, maxLength: 100),
                        MoTa = c.String(maxLength: 255),
                        NgayBatDau = c.DateTime(nullable: false),
                        NgayKetThuc = c.DateTime(),
                        HoanThanh = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhanCong)
                .ForeignKey("dbo.CongViecs", t => t.MaCongViec)
                .ForeignKey("dbo.NhanViens", t => t.MaNV)
                .Index(t => t.MaNV)
                .Index(t => t.MaCongViec);
            
            CreateTable(
                "dbo.CongViecs",
                c => new
                    {
                        MaCongViec = c.Int(nullable: false, identity: true),
                        TenCongViec = c.String(nullable: false, maxLength: 100),
                        MoTa = c.String(maxLength: 255),
                        LuongTheoGio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaCongViec);
            
            CreateTable(
                "dbo.CT_GioHang",
                c => new
                    {
                        MaGioHang = c.String(nullable: false, maxLength: 20, unicode: false),
                        MaSach = c.String(nullable: false, maxLength: 20, unicode: false),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaGioHang, t.MaSach })
                .ForeignKey("dbo.GioHangs", t => t.MaGioHang, cascadeDelete: true)
                .ForeignKey("dbo.Saches", t => t.MaSach, cascadeDelete: true)
                .Index(t => t.MaGioHang)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        MaGioHang = c.String(nullable: false, maxLength: 20, unicode: false),
                        MaKhach = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaGioHang)
                .ForeignKey("dbo.KhachHangs", t => t.MaKhach)
                .Index(t => t.MaKhach);
            
            CreateTable(
                "dbo.KhuyenMais",
                c => new
                    {
                        MaKM = c.String(nullable: false, maxLength: 20),
                        TenKM = c.String(nullable: false, maxLength: 100),
                        PhanTramGiam = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NgayBatDau = c.DateTime(nullable: false),
                        NgayKetThuc = c.DateTime(nullable: false),
                        DieuKien = c.String(),
                        TrangThai = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaKM);
            
            CreateTable(
                "dbo.ThongBaos",
                c => new
                    {
                        MaThongBao = c.String(nullable: false, maxLength: 20),
                        TieuDe = c.String(nullable: false, maxLength: 200),
                        NoiDung = c.String(),
                        NgayGui = c.DateTime(nullable: false),
                        NguoiNhan = c.String(),
                    })
                .PrimaryKey(t => t.MaThongBao);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CT_GioHang", "MaSach", "dbo.Saches");
            DropForeignKey("dbo.GioHangs", "MaKhach", "dbo.KhachHangs");
            DropForeignKey("dbo.CT_GioHang", "MaGioHang", "dbo.GioHangs");
            DropForeignKey("dbo.PhanCongs", "MaNV", "dbo.NhanViens");
            DropForeignKey("dbo.PhanCongs", "MaCongViec", "dbo.CongViecs");
            DropForeignKey("dbo.NhanViens", "MaChucVu", "dbo.ChucVus");
            DropForeignKey("dbo.NhanViens", "MaChiNhanh", "dbo.ChiNhanhs");
            DropForeignKey("dbo.NhapKhoes", "MaNV", "dbo.NhanViens");
            DropForeignKey("dbo.NhapKhoes", "MaKho", "dbo.Khoes");
            DropForeignKey("dbo.Saches", "MaTheLoai", "dbo.TheLoais");
            DropForeignKey("dbo.Saches", "MaTacGia", "dbo.TacGias");
            DropForeignKey("dbo.Saches", "MaNXB", "dbo.NhaXuatBans");
            DropForeignKey("dbo.CT_NhapKho", "MaSach", "dbo.Saches");
            DropForeignKey("dbo.CT_DonHang", "MaSach", "dbo.Saches");
            DropForeignKey("dbo.VanChuyens", "MaDonHang", "dbo.DonHangs");
            DropForeignKey("dbo.VanChuyens", "MaDVVC", "dbo.DonViVanChuyens");
            DropForeignKey("dbo.DonHangs", "MaNV", "dbo.NhanViens");
            DropForeignKey("dbo.DonHangs", "MaKhach", "dbo.KhachHangs");
            DropForeignKey("dbo.KhachHangs", "TenDangNhap", "dbo.TaiKhoans");
            DropForeignKey("dbo.TaiKhoans", "MaNhanVien", "dbo.NhanViens");
            DropForeignKey("dbo.HoaDons", "KhachHang_TenDangNhap", "dbo.KhachHangs");
            DropForeignKey("dbo.HoaDons", "MaDonHang", "dbo.DonHangs");
            DropForeignKey("dbo.CT_DonHang", "MaDonHang", "dbo.DonHangs");
            DropForeignKey("dbo.CT_NhapKho", "MaPhieuNhap", "dbo.NhapKhoes");
            DropForeignKey("dbo.KiemKes", "MaNV", "dbo.NhanViens");
            DropForeignKey("dbo.KiemKes", "MaKho", "dbo.Khoes");
            DropForeignKey("dbo.KeSaches", "MaKho", "dbo.Khoes");
            DropForeignKey("dbo.ChuyenKhoes", "Kho_MaKho1", "dbo.Khoes");
            DropForeignKey("dbo.ChuyenKhoes", "Kho_MaKho", "dbo.Khoes");
            DropForeignKey("dbo.ChuyenKhoes", "MaKhoXuat", "dbo.Khoes");
            DropForeignKey("dbo.ChuyenKhoes", "MaKhoNhap", "dbo.Khoes");
            DropForeignKey("dbo.Khoes", "MaChiNhanh", "dbo.ChiNhanhs");
            DropForeignKey("dbo.BangLuongs", "MaNV", "dbo.NhanViens");
            DropIndex("dbo.GioHangs", new[] { "MaKhach" });
            DropIndex("dbo.CT_GioHang", new[] { "MaSach" });
            DropIndex("dbo.CT_GioHang", new[] { "MaGioHang" });
            DropIndex("dbo.PhanCongs", new[] { "MaCongViec" });
            DropIndex("dbo.PhanCongs", new[] { "MaNV" });
            DropIndex("dbo.VanChuyens", new[] { "MaDVVC" });
            DropIndex("dbo.VanChuyens", new[] { "MaDonHang" });
            DropIndex("dbo.TaiKhoans", new[] { "MaNhanVien" });
            DropIndex("dbo.HoaDons", new[] { "KhachHang_TenDangNhap" });
            DropIndex("dbo.HoaDons", new[] { "MaDonHang" });
            DropIndex("dbo.KhachHangs", new[] { "TenDangNhap" });
            DropIndex("dbo.DonHangs", new[] { "MaNV" });
            DropIndex("dbo.DonHangs", new[] { "MaKhach" });
            DropIndex("dbo.CT_DonHang", new[] { "MaSach" });
            DropIndex("dbo.CT_DonHang", new[] { "MaDonHang" });
            DropIndex("dbo.Saches", new[] { "MaTheLoai" });
            DropIndex("dbo.Saches", new[] { "MaTacGia" });
            DropIndex("dbo.Saches", new[] { "MaNXB" });
            DropIndex("dbo.CT_NhapKho", new[] { "MaSach" });
            DropIndex("dbo.CT_NhapKho", new[] { "MaPhieuNhap" });
            DropIndex("dbo.NhapKhoes", new[] { "MaKho" });
            DropIndex("dbo.NhapKhoes", new[] { "MaNV" });
            DropIndex("dbo.KiemKes", new[] { "MaNV" });
            DropIndex("dbo.KiemKes", new[] { "MaKho" });
            DropIndex("dbo.KeSaches", new[] { "MaKho" });
            DropIndex("dbo.ChuyenKhoes", new[] { "Kho_MaKho1" });
            DropIndex("dbo.ChuyenKhoes", new[] { "Kho_MaKho" });
            DropIndex("dbo.ChuyenKhoes", new[] { "MaKhoNhap" });
            DropIndex("dbo.ChuyenKhoes", new[] { "MaKhoXuat" });
            DropIndex("dbo.Khoes", new[] { "MaChiNhanh" });
            DropIndex("dbo.NhanViens", new[] { "MaChiNhanh" });
            DropIndex("dbo.NhanViens", new[] { "MaChucVu" });
            DropIndex("dbo.BangLuongs", new[] { "MaNV" });
            DropTable("dbo.ThongBaos");
            DropTable("dbo.KhuyenMais");
            DropTable("dbo.GioHangs");
            DropTable("dbo.CT_GioHang");
            DropTable("dbo.CongViecs");
            DropTable("dbo.PhanCongs");
            DropTable("dbo.ChucVus");
            DropTable("dbo.TheLoais");
            DropTable("dbo.TacGias");
            DropTable("dbo.NhaXuatBans");
            DropTable("dbo.DonViVanChuyens");
            DropTable("dbo.VanChuyens");
            DropTable("dbo.TaiKhoans");
            DropTable("dbo.HoaDons");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.DonHangs");
            DropTable("dbo.CT_DonHang");
            DropTable("dbo.Saches");
            DropTable("dbo.CT_NhapKho");
            DropTable("dbo.NhapKhoes");
            DropTable("dbo.KiemKes");
            DropTable("dbo.KeSaches");
            DropTable("dbo.ChuyenKhoes");
            DropTable("dbo.Khoes");
            DropTable("dbo.ChiNhanhs");
            DropTable("dbo.NhanViens");
            DropTable("dbo.BangLuongs");
        }
    }
}
