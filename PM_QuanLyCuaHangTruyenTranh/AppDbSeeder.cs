// Paste vào Program.cs (trong hàm Main hoặc một method seed và gọi nó)
using PM.BUS;
using PM.BUS.Helpers;
using PM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace PM.GUI
{
    public static class AppDbSeeder
    {
        public static void Seed()
        {
            using (var db = new AppDbContext())
            {
                // tránh seed lại nếu đã có dữ liệu
                if (db.Sachs.Any()) return;

                // ----- 1. TheLoai -----
                var theLoais = new[]
                {
                    new TheLoai { MaTheLoai = "TL01", TenTheLoai = "Hành Động", GhiChu = "Truyện có yếu tố chiến đấu, phiêu lưu" },
                    new TheLoai { MaTheLoai = "TL02", TenTheLoai = "Hài Hước", GhiChu = "Truyện giải trí, hài" },
                    new TheLoai { MaTheLoai = "TL03", TenTheLoai = "Tình Cảm", GhiChu = "Tập trung cảm xúc, tình yêu" },
                    new TheLoai { MaTheLoai = "TL04", TenTheLoai = "Kinh Dị", GhiChu = "Rùng rợn, bí ẩn" },
                    new TheLoai { MaTheLoai = "TL05", TenTheLoai = "Học Đường", GhiChu = "Đời sống học sinh/sinh viên" },
                    new TheLoai { MaTheLoai = "TL06", TenTheLoai = "Phiêu Lưu", GhiChu = "Hành trình khám phá" },
                    new TheLoai { MaTheLoai = "TL07", TenTheLoai = "Giả Tưởng", GhiChu = "Thế giới tưởng tượng, phép thuật" },
                    new TheLoai { MaTheLoai = "TL08", TenTheLoai = "Khoa Học Viễn Tưởng", GhiChu = "Tương lai, công nghệ" },
                    new TheLoai { MaTheLoai = "TL09", TenTheLoai = "Trinh Thám", GhiChu = "Phá án, điều tra" },
                };
                db.TheLoais.AddRange(theLoais);
                db.SaveChanges();

                // ----- 2. TacGia -----
                var tacGias = new[]
                {
                    new TacGia { MaTacGia = "TG01", TenTacGia = "Eiichiro Oda", QuocTich = "Nhật Bản" },
                    new TacGia { MaTacGia = "TG02", TenTacGia = "Masashi Kishimoto", QuocTich = "Nhật Bản" },
                    new TacGia { MaTacGia = "TG03", TenTacGia = "Makoto Shinkai", QuocTich = "Nhật Bản" },
                    new TacGia { MaTacGia = "TG04", TenTacGia = "Hajime Isayama", QuocTich = "Nhật Bản" },
                    new TacGia { MaTacGia = "TG05", TenTacGia = "Koyoharu Gotouge", QuocTich = "Nhật Bản" },
                    new TacGia { MaTacGia = "TG06", TenTacGia = "Tatsuya Endo", QuocTich = "Nhật Bản" },
                    new TacGia { MaTacGia = "TG07", TenTacGia = "Tsugumi Ohba", QuocTich = "Nhật Bản" },
                    new TacGia { MaTacGia = "TG08", TenTacGia = "Gosho Aoyama", QuocTich = "Nhật Bản" },
                    new TacGia { MaTacGia = "TG09", TenTacGia = "Sui Ishida", QuocTich = "Nhật Bản" },
                    new TacGia { MaTacGia = "TG10", TenTacGia = "Muneyuki Kaneshiro", QuocTich = "Nhật Bản" }
                };
                db.TacGias.AddRange(tacGias);
                db.SaveChanges();

                // ----- 3. NhaXuatBan -----
                var nxb = new[]
                {
                    new NhaXuatBan { MaNXB = "NXB01", TenNXB = "Kim Đồng", DiaChi = "Hà Nội" },
                    new NhaXuatBan { MaNXB = "NXB02", TenNXB = "Trẻ", DiaChi = "Hồ Chí Minh" },
                    new NhaXuatBan { MaNXB = "NXB03", TenNXB = "Nhã Nam", DiaChi = "Hà Nội" },
                    new NhaXuatBan { MaNXB = "NXB04", TenNXB = "Đông A", DiaChi = "Hà Nội" },
                    new NhaXuatBan { MaNXB = "NXB05", TenNXB = "Thái Hà Books", DiaChi = "Hà Nội" }
                };
                db.NhaXuatBans.AddRange(nxb);
                db.SaveChanges();

                // ----- 4. Chi Nhanh + Kho + KeSach -----
                var chiNhanh1 = new ChiNhanh
                {
                    MaChiNhanh = "CN01",
                    TenChiNhanh = "Chi nhánh TP.HCM",
                    DiaChi = "123 Lê Lợi, Quận 1, TP.HCM",
                    SoDienThoai = "0909123456",
                    Email = "hcm@cuahangg.com",
                    TrangThai = true
                };
                var chiNhanh2 = new ChiNhanh
                {
                    MaChiNhanh = "CN02",
                    TenChiNhanh = "Chi nhánh Hà Nội",
                    DiaChi = "45 Tràng Tiền, Hoàn Kiếm, Hà Nội",
                    SoDienThoai = "0912345678",
                    Email = "hn@cuahangg.com",
                    TrangThai = true
                };
                db.ChiNhanhs.AddRange(new[] { chiNhanh1, chiNhanh2 });
                db.SaveChanges();

                var kho1 = new Kho { MaKho = "KHO01", TenKho = "Kho HCM - Trung Tâm", MaChiNhanh = chiNhanh1.MaChiNhanh, LoaiKho = "Chính", TrangThai = true };
                var kho2 = new Kho { MaKho = "KHO02", TenKho = "Kho HN - Trung Tâm", MaChiNhanh = chiNhanh2.MaChiNhanh, LoaiKho = "Chính", TrangThai = true };
                db.Khos.AddRange(new[] { kho1, kho2 });
                db.SaveChanges();

                var ke1 = new KeSach { MaKe = "KE01", TenKe = "Kệ A1", MaKho = kho1.MaKho };
                var ke2 = new KeSach { MaKe = "KE02", TenKe = "Kệ B1", MaKho = kho2.MaKho };
                db.KeSachs.AddRange(new[] { ke1, ke2 });
                db.SaveChanges();

                // ----- 5. Chuc Vu + Nhan Vien -----
                var cvQuanLy = new ChucVu { MaChucVu = "CV01", TenChucVu = "Quản lý", MoTa = "Quản lý cửa hàng" };
                var cvNhanVien = new ChucVu { MaChucVu = "CV02", TenChucVu = "Nhân viên bán hàng", MoTa = "Tiếp đón và bán hàng" };
                db.ChucVus.AddRange(new[] { cvQuanLy, cvNhanVien });
                db.SaveChanges();

                var nv1 = new NhanVien
                {
                    MaNV = "NV01",
                    HoTen = "Nguyễn Văn A",
                    GioiTinh = "Nam",
                    NgaySinh = new DateTime(1990, 5, 20),
                    SoDienThoai = "0901001001",
                    Email = "nv.a@cuahangg.com",
                    DiaChi = "TP.HCM",
                    TrangThai = true,
                    MaChucVu = cvQuanLy.MaChucVu,
                    MaChiNhanh = chiNhanh1.MaChiNhanh
                };
                var nv2 = new NhanVien
                {
                    MaNV = "NV02",
                    HoTen = "Trần Thị B",
                    GioiTinh = "Nữ",
                    NgaySinh = new DateTime(1995, 6, 15),
                    SoDienThoai = "0902002002",
                    Email = "nv.b@cuahangg.com",
                    DiaChi = "Hà Nội",
                    TrangThai = true,
                    MaChucVu = cvNhanVien.MaChucVu,
                    MaChiNhanh = chiNhanh2.MaChiNhanh
                };
                var nv3 = new NhanVien
                {
                    MaNV = "NV03",
                    HoTen = "Lê Văn C",
                    GioiTinh = "Nam",
                    NgaySinh = new DateTime(1992, 8, 1),
                    SoDienThoai = "0903003003",
                    Email = "nv.c@cuahangg.com",
                    DiaChi = "TP.HCM",
                    TrangThai = true,
                    MaChucVu = cvNhanVien.MaChucVu,
                    MaChiNhanh = chiNhanh1.MaChiNhanh
                };
                db.NhanViens.AddRange(new[] { nv1, nv2, nv3 });
                db.SaveChanges();

                // ----- 6. Tai Khoan (admin, staff, customers) -----
                var tkAdmin = new TaiKhoan { TenDangNhap = "admin", MatKhau = PM.BUS.Helpers.PasswordHelper.HashPassword("123"), Quyen = "Admin", TrangThai = true, MaNhanVien = nv1.MaNV };
                var tkNv2 = new TaiKhoan { TenDangNhap = "nv_b", MatKhau = PM.BUS.Helpers.PasswordHelper.HashPassword("123"), Quyen = "NhanVien", TrangThai = true, MaNhanVien = nv2.MaNV };
                var tkKh1 = new TaiKhoan { TenDangNhap = "kh_anh", MatKhau = PM.BUS.Helpers.PasswordHelper.HashPassword("123"), Quyen = "Khach", TrangThai = true };
                var tkKh2 = new TaiKhoan { TenDangNhap = "kh_huong", MatKhau = PM.BUS.Helpers.PasswordHelper.HashPassword("123"), Quyen = "Khach", TrangThai = true };
                var tkKh3 = new TaiKhoan { TenDangNhap = "kh_minh", MatKhau = PM.BUS.Helpers.PasswordHelper.HashPassword("123"), Quyen = "Khach", TrangThai = true };
                db.TaiKhoans.AddRange(new[] { tkAdmin, tkNv2, tkKh1, tkKh2, tkKh3 });
                db.SaveChanges();

                // ----- 7. KhachHang -----
                var kh1 = new KhachHang { TenDangNhap = tkKh1.TenDangNhap, HoTen = "Anh Nguyễn", SoDienThoai = "0911222333", Email = "anh@example.com", DiaChi = "Quận 3, TP.HCM",AnhDaiDien=null ,NgayDangKy = DateTime.Now, NgaySinh = DateTime.Now, TaiKhoan = tkKh1 };
                var kh2 = new KhachHang { TenDangNhap = tkKh2.TenDangNhap, HoTen = "Hương Lê", SoDienThoai = "0911333444", Email = "huong@example.com", DiaChi = "Cầu Giấy, Hà Nội", AnhDaiDien=null,NgayDangKy = DateTime.Now, NgaySinh = DateTime.Now, TaiKhoan = tkKh2 };
                var kh3 = new KhachHang { TenDangNhap = tkKh3.TenDangNhap, HoTen = "Minh Trần", SoDienThoai = "0911444555", Email = "minh@example.com", DiaChi = "Phú Nhuận, TP.HCM", AnhDaiDien=null,NgayDangKy = DateTime.Now,NgaySinh=DateTime.Now, TaiKhoan = tkKh3 };
                db.KhachHangs.AddRange(new[] { kh1, kh2, kh3 });
                db.SaveChanges();

               
                db.SaveChanges();

                // ----- 8. Sach (20 cuon theo ban dau, gán 1 theloai/tacgia/nxb co logic) -----
                var sachs = new List<Sach>
                {
                    new Sach { MaSach = "S001", TenSach = "One Piece", SoTrang = 200, MoTa = "Hành trình của Luffy trên Grand Line", TacGia = null, MaTacGia = tacGias.First(t=>t.TenTacGia.Contains("Eiichiro")).MaTacGia, MaTheLoai = "TL06", MaNXB = "NXB01", GiaNhap = 30000, GiaBan = 90000, NamXuatBan = 1997, TrangThai = true, BiaSach = null },
                    new Sach { MaSach = "S002", TenSach = "Naruto", SoTrang = 190, MoTa = "Hành trình trở thành Hokage", MaTacGia = tacGias.First(t=>t.TenTacGia.Contains("Masashi")).MaTacGia, MaTheLoai = "TL01", MaNXB = "NXB02", GiaNhap = 28000, GiaBan = 85000, NamXuatBan = 1999, TrangThai = true, BiaSach = null },
                    new Sach { MaSach = "S003", TenSach = "Your Name", SoTrang = 150, MoTa = "Tình cảm, hoán đổi thân xác", MaTacGia = tacGias.First(t=>t.TenTacGia.Contains("Makoto")).MaTacGia, MaTheLoai = "TL03", MaNXB = "NXB03", GiaNhap = 20000, GiaBan = 65000, NamXuatBan = 2016, TrangThai = true },
                    new Sach { MaSach = "S004", TenSach = "Attack on Titan", SoTrang = 230, MoTa = "Cuộc chiến chống Titan", MaTacGia = tacGias.First(t=>t.TenTacGia.Contains("Hajime")).MaTacGia, MaTheLoai = "TL01", MaNXB = "NXB04", GiaNhap = 32000, GiaBan = 95000, NamXuatBan = 2009, TrangThai = true },
                    new Sach { MaSach = "S005", TenSach = "Demon Slayer", SoTrang = 210, MoTa = "Tiêu diệt quỷ", MaTacGia = tacGias.First(t=>t.TenTacGia.Contains("Koyoharu")).MaTacGia, MaTheLoai = "TL01", MaNXB = "NXB02", GiaNhap = 30000, GiaBan = 90000, NamXuatBan = 2016, TrangThai = true },
                    new Sach { MaSach = "S006", TenSach = "Spy x Family", SoTrang = 160, MoTa = "Gia đình điệp viên giả", MaTacGia = tacGias.First(t=>t.TenTacGia.Contains("Tatsuya")).MaTacGia, MaTheLoai = "TL02", MaNXB = "NXB05", GiaNhap = 22000, GiaBan = 70000, NamXuatBan = 2019, TrangThai = true },
                    new Sach { MaSach = "S007", TenSach = "Death Note", SoTrang = 180, MoTa = "Cuốn sổ tử thần", MaTacGia = tacGias.First(t=>t.TenTacGia.Contains("Tsugumi")).MaTacGia, MaTheLoai = "TL09", MaNXB = "NXB01", GiaNhap = 24000, GiaBan = 75000, NamXuatBan = 2003, TrangThai = true },
                    new Sach { MaSach = "S008", TenSach = "Detective Conan", SoTrang = 250, MoTa = "Thám tử học sinh", MaTacGia = tacGias.First(t=>t.TenTacGia.Contains("Gosho")).MaTacGia, MaTheLoai = "TL09", MaNXB = "NXB03", GiaNhap = 26000, GiaBan = 80000, NamXuatBan = 1994, TrangThai = true },
                    new Sach { MaSach = "S009", TenSach = "Tokyo Ghoul", SoTrang = 220, MoTa = "Bán quỷ", MaTacGia = tacGias.First(t=>t.TenTacGia.Contains("Sui")).MaTacGia, MaTheLoai = "TL04", MaNXB = "NXB04", GiaNhap = 25000, GiaBan = 78000, NamXuatBan = 2011, TrangThai = true },
                    new Sach { MaSach = "S010", TenSach = "Blue Lock", SoTrang = 200, MoTa = "Đào tạo tiền đạo bóng đá", MaTacGia = tacGias.First(t=>t.TenTacGia.Contains("Muneyuki")).MaTacGia, MaTheLoai = "TL05", MaNXB = "NXB05", GiaNhap = 21000, GiaBan = 72000, NamXuatBan = 2018, TrangThai = true },
                    new Sach { MaSach = "S011", TenSach = "Jujutsu Kaisen", SoTrang = 190, MoTa = "Học sinh đánh lời nguyền", MaTacGia = "TG11", MaTheLoai = "TL01", MaNXB = "NXB02", GiaNhap = 24000, GiaBan = 76000, NamXuatBan = 2018, TrangThai = true },
                    new Sach { MaSach = "S012", TenSach = "Chainsaw Man", SoTrang = 210, MoTa = "Thợ săn quỷ Denji", MaTacGia = "TG12", MaTheLoai = "TL04", MaNXB = "NXB01", GiaNhap = 26000, GiaBan = 82000, NamXuatBan = 2018, TrangThai = true },
                    new Sach { MaSach = "S013", TenSach = "Dr. Stone", SoTrang = 170, MoTa = "Tái thiết nền văn minh", MaTacGia = "TG13", MaTheLoai = "TL08", MaNXB = "NXB03", GiaNhap = 23000, GiaBan = 74000, NamXuatBan = 2017, TrangThai = true },
                    new Sach { MaSach = "S014", TenSach = "My Hero Academia", SoTrang = 210, MoTa = "Hành trình trở thành anh hùng", MaTacGia = "TG14", MaTheLoai = "TL01", MaNXB = "NXB04", GiaNhap = 27000, GiaBan = 88000, NamXuatBan = 2014, TrangThai = true },
                    new Sach { MaSach = "S015", TenSach = "Fairy Tail", SoTrang = 230, MoTa = "Hội pháp sư Fairy Tail", MaTacGia = "TG15", MaTheLoai = "TL07", MaNXB = "NXB02", GiaNhap = 25000, GiaBan = 80000, NamXuatBan = 2006, TrangThai = true },
                    new Sach { MaSach = "S016", TenSach = "Sword Art Online", SoTrang = 180, MoTa = "Người chơi mắc kẹt trong game", MaTacGia = "TG16", MaTheLoai = "TL08", MaNXB = "NXB05", GiaNhap = 22000, GiaBan = 72000, NamXuatBan = 2009, TrangThai = true },
                    new Sach { MaSach = "S017", TenSach = "A Silent Voice", SoTrang = 160, MoTa = "Chuộc lỗi vì bắt nạt", MaTacGia = "TG17", MaTheLoai = "TL03", MaNXB = "NXB03", GiaNhap = 19000, GiaBan = 60000, NamXuatBan = 2013, TrangThai = true },
                    new Sach { MaSach = "S018", TenSach = "Parasyte", SoTrang = 200, MoTa = "Sinh vật ký sinh", MaTacGia = "TG18", MaTheLoai = "TL04", MaNXB = "NXB01", GiaNhap = 24000, GiaBan = 76000, NamXuatBan = 1990, TrangThai = true },
                    new Sach { MaSach = "S019", TenSach = "Black Clover", SoTrang = 220, MoTa = "Cậu bé không phép", MaTacGia = "TG19", MaTheLoai = "TL07", MaNXB = "NXB02", GiaNhap = 23000, GiaBan = 73000, NamXuatBan = 2015, TrangThai = true },
                    new Sach { MaSach = "S020", TenSach = "Haikyuu!!", SoTrang = 200, MoTa = "Đội bóng chuyền Karasuno", MaTacGia = "TG20", MaTheLoai = "TL05", MaNXB = "NXB03", GiaNhap = 21000, GiaBan = 70000, NamXuatBan = 2012, TrangThai = true }
                };

                // NOTE: Some TacGia codes TG11..TG20 were referenced above but not created earlier.
                // Create simple placeholder authors for them:
                for (int i = 11; i <= 20; i++)
                {
                    var code = "TG" + i.ToString("00");
                    if (!db.TacGias.Any(t => t.MaTacGia == code))
                    {
                        db.TacGias.Add(new TacGia { MaTacGia = code, TenTacGia = "Tác giả " + code, QuocTich = "Khác" });
                    }
                }
                db.SaveChanges();

                db.Sachs.AddRange(sachs);
                db.SaveChanges();

                // ----- 9. Nhập kho + CT_NhapKho -----
                var phieuNhap1 = new NhapKho
                {
                    MaPhieuNhap = "PN001",
                    NgayNhap = DateTime.Now.AddDays(-30),
                    MaNV = nv1.MaNV,
                    MaKho = kho1.MaKho,
                    GhiChu = "Nhập lô sách đầu tiên"
                };
                db.NhapKhos.Add(phieuNhap1);
                db.SaveChanges();

                var ctNhap = new[]
                {
                    new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S001", SoLuong = 50, DonGia = 30000 },
                    new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S002", SoLuong = 40, DonGia = 28000 },
                    new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S003", SoLuong = 30, DonGia = 20000 },
                    new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S004", SoLuong = 20, DonGia = 32000 },
                };
                db.CT_NhapKhos.AddRange(ctNhap);
                db.SaveChanges();

                // ----- 10. GioHang + CT_GioHang -----
                var gh1 = new GioHang { MaGioHang = "GH001", MaKhach = kh1.TenDangNhap };
                db.GioHangs.Add(gh1);
                db.SaveChanges();

                db.CT_GioHangs.Add(new CT_GioHang { MaGioHang = gh1.MaGioHang, MaSach = "S001", SoLuong = 1 });
                db.CT_GioHangs.Add(new CT_GioHang { MaGioHang = gh1.MaGioHang, MaSach = "S006", SoLuong = 2 });
                db.SaveChanges();

                // ----- 11. DonHang + CT_DonHang + HoaDon + VanChuyen -----
                var dh1 = new DonHang
                {
                    MaDonHang = "DH001",
                    MaKhach = kh1.TenDangNhap,
                    MaNV = nv2.MaNV,
                    NgayDat = DateTime.Now.AddDays(-7),
                    NgayGiao = DateTime.Now.AddDays(-3),
                    TongTien = 90000 + 2 * 70000,
                    TrangThai = "Đã giao"
                };
                var dh2 = new DonHang
                {
                    MaDonHang = "DH002",
                    MaKhach = kh2.TenDangNhap,
                    MaNV = nv3.MaNV,
                    NgayDat = DateTime.Now.AddDays(-2),
                    NgayGiao = null,
                    TongTien = 76000,
                    TrangThai = "Đang xử lý"
                };
                db.DonHangs.AddRange(new[] { dh1, dh2 });
                db.SaveChanges();

                var ctDh = new[]
                {
                    new CT_DonHang { MaDonHang = dh1.MaDonHang, MaSach = "S001", SoLuong = 1, DonGia = 90000, ThanhTien = 90000 },
                    new CT_DonHang { MaDonHang = dh1.MaDonHang, MaSach = "S006", SoLuong = 2, DonGia = 70000, ThanhTien = 140000 },
                    new CT_DonHang { MaDonHang = dh2.MaDonHang, MaSach = "S007", SoLuong = 1, DonGia = 76000, ThanhTien = 76000 }
                };
                db.CT_DonHangs.AddRange(ctDh);
                db.SaveChanges();

                // HoaDon cho DH001
                var hd1 = new HoaDon
                {
                    MaHoaDon = "HD001",
                    MaDonHang = dh1.MaDonHang,
                    NgayLap = dh1.NgayDat.AddDays(0),
                    TongTien = dh1.TongTien,
                    HinhThucThanhToan = "Tiền mặt"
                };
                db.HoaDons.Add(hd1);
                db.SaveChanges();

                // VanChuyen
                var vc1 = new VanChuyen { MaVanChuyen = "VC001", MaDonHang = dh1.MaDonHang, DonViVanChuyen = "Giao hàng nhanh", NgayGiao = dh1.NgayGiao ?? DateTime.Now, TrangThai = "Đã giao" };
                var vc2 = new VanChuyen { MaVanChuyen = "VC002", MaDonHang = dh2.MaDonHang, DonViVanChuyen = "VNPost", NgayGiao = DateTime.Now.AddDays(3), TrangThai = "Đang vận chuyển" };
                db.VanChuyens.AddRange(new[] { vc1, vc2 });
                db.SaveChanges();

                // ----- 12. KhuyenMai -----
                var km = new KhuyenMai
                {
                    MaKM = "KM01",
                    TenKM = "Giảm 20% Lễ",
                    PhanTramGiam = 20,
                    NgayBatDau = DateTime.Now.AddDays(-10),
                    NgayKetThuc = DateTime.Now.AddDays(20),
                    DieuKien = "Áp dụng cho đơn hàng >= 200000",
                    TrangThai = true
                };
                db.KhuyenMais.Add(km);
                db.SaveChanges();

                // ----- 13. ThongBao -----
                var tb1 = new ThongBao { MaThongBao = "TB01", TieuDe = "Khuyến mãi Lễ", NoiDung = "Giảm 20% cho đơn hàng lớn", NgayGui = DateTime.Now, NguoiNhan = "ALL" };
                var tb2 = new ThongBao { MaThongBao = "TB02", TieuDe = "Bảo trì hệ thống", NoiDung = "Hệ thống sẽ bảo trì lúc 23:00", NgayGui = DateTime.Now, NguoiNhan = nv1.MaNV };
                db.ThongBaos.AddRange(new[] { tb1, tb2 });
                db.SaveChanges();

               

                // ----- 15. KiemKe -----
                var kk1 = new KiemKe { MaKiemKe = "KK001", NgayKiemKe = DateTime.Now.AddDays(-2), MaKho = kho1.MaKho, MaNV = nv1.MaNV, GhiChu = "Kiểm kê định kỳ" };
                db.KiemKes.Add(kk1);
                db.SaveChanges();

                // ----- 16. ChuyenKho (ví dụ) -----
                var ck1 = new ChuyenKho { MaPhieuChuyen = "CK001", NgayChuyen = DateTime.Now.AddDays(-5), MaKhoXuat = kho1.MaKho, MaKhoNhap = kho2.MaKho, GhiChu = "Chuyển bổ sung sách" };
                db.ChuyenKhos.Add(ck1);
                db.SaveChanges();

                // commit
                db.SaveChanges();

                System.Windows.Forms.MessageBox.Show("Đã thêm dữ liệu mẫu thành công!", "Khởi tạo dữ liệu", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
              
                    // Danh sách ảnh + ISBN tương ứng
                    var sachData = new Dictionary<string, (string url, string isbn)>
                    {
                        ["S001"] = ("https://static0.srcdn.com/wordpress/wp-content/uploads/2023…/one-piece-franchise-poster.jpg?q=70&fit=contain&w=280&dpr=1", "9784098516813"),
                        ["S002"] = ("https://upload.wikimedia.org/wikipedia/en/9/94/NarutoCoverTankobon1.jpg", "9781569319000"),
                        ["S003"] = ("https://upload.wikimedia.org/wikipedia/en/0/0b/Your_Name_poster.png", "9780316472861"),
                        ["S004"] = ("https://i.ebayimg.com/images/g/fqEAAOSwB-1YtiGV/s-l400.jpg", "9781632364103"),
                        ["S005"] = ("https://i.pinimg.com/originals/86/1d/95/861d95dc646bec1dedde1586adf896e3.jpg", "9781974700523"),
                        ["S006"] = ("https://mixmangastore.com/cdn/shop/files/12.jpg?v=1691219705", "9781974715466"),
                        ["S007"] = ("https://upload.wikimedia.org/wikipedia/en/6/6f/Death_Note_Vol_1.jpg", "9781421501680"),
                        ["S008"] = ("https://www.manga-news.com/public/images/vols/detective-conan-97-kana.jpg", "9784091252527"),
                        ["S009"] = ("http://www.manga-sanctuary.com/imageslesseries2/tokyo-ghoul-manga-volume-1-francaise-73492[1].jpg", "9781421580364"),
                        ["S010"] = ("https://cdn.kobo.com/book-images/d0259d14-58b5-443a-b4a3-f59ebd47a85b/1200/1200/False/blue-lock-20.jpg", "9781646516543"),
                        ["S011"] = ("https://images.fineartamerica.com/images/artworkimages/mediumlarge/3/jujutsu-kaisen-manga-cover-4-william-stratton.jpg", "9781974710027"),
                        ["S012"] = ("https://i.pinimg.com/736x/5b/56/78/5b5678fc43d0cf4566e65546efd2cfa5.jpg", "9781974709939"),
                        ["S013"] = ("https://www.manga-news.com/public/images/vols/Dr_Stone_-_Tome_24_-_Gl_nat.jpg", "9781974702619"),
                        ["S014"] = ("https://i.pinimg.com/736x/c8/41/e7/c841e78626b3cf416ce1bc185e1543f6.jpg", "9781421582696"),
                        ["S015"] = ("https://i.pinimg.com/originals/10/f6/85/10f68546e22d27fc4df8c6d221bbdcc6.png", "9781612622767"),
                        ["S016"] = ("https://i.pinimg.com/originals/e3/fa/75/e3fa753ceabf2095350e89f849485ca7.png", "9780316371249"),
                        ["S017"] = ("https://images.fineartamerica.com/images/artworkimages/mediumlarge/3/a-silent-voice-anime-poster-elizabeth-king.jpg", "9781632360563"),
                        ["S018"] = ("https://i.pinimg.com/originals/e3/5a/e8/e35ae8083a43c49729d206bfe9036507.jpg", "9781612620732"),
                        ["S019"] = ("https://i.pinimg.com/originals/55/b3/4e/55b34ed676329d360be068d576e9098a.jpg", "9781974703319"),
                        ["S020"] = ("https://i.pinimg.com/originals/ce/a7/98/cea7987217ebc08748342c83c77f3208.jpg", "9781421587660")
                    };

                    int updatedCount = 0;

                    foreach (var sach in db.Sachs.ToList())
                    {
                        if (sachData.TryGetValue(sach.MaSach, out var data))
                        {
                            // Cập nhật ISBN nếu đang NULL hoặc rỗng
                            if (string.IsNullOrEmpty(sach.ISBN))
                                sach.ISBN = data.isbn;

                            // Cập nhật BiaSach nếu chưa có
                            if (sach.BiaSach == null)
                                sach.BiaSach = TaiAnhTuInternet(data.url);

                            updatedCount++;
                        }
                    }

                    db.SaveChanges();
                    MessageBox.Show($"✅ Đã cập nhật {updatedCount} sách có ISBN & Bìa!",
                                    "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
                
        
        public static byte[] TaiAnhTuInternet(string url)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    // Giả lập trình duyệt để tránh bị chặn 403
                    webClient.Headers.Add("User-Agent",
                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) " +
                        "AppleWebKit/537.36 (KHTML, like Gecko) " +
                        "Chrome/124.0.0.0 Safari/537.36");

                    return webClient.DownloadData(url);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải ảnh từ {url}:\n{ex.Message}",
                    "Lỗi tải ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
