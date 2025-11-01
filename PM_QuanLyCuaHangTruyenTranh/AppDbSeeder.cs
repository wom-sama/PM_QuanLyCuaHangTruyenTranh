// Paste vào Program.cs (trong hàm Main hoặc một method seed và gọi nó)
using PM.BUS;
using PM.BUS.Helpers;
using PM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
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
                // ----- Kho -----
                var kho1 = new Kho { MaKho = "KHO01", TenKho = "Kho HCM - Trung Tâm", MaChiNhanh = chiNhanh1.MaChiNhanh, LoaiKho = "Chính", TrangThai = true };
                var kho2 = new Kho { MaKho = "KHO02", TenKho = "Kho HN - Trung Tâm", MaChiNhanh = chiNhanh2.MaChiNhanh, LoaiKho = "Chính", TrangThai = true };
                db.Khos.AddRange(new[] { kho1, kho2 });
                db.SaveChanges();
                // -----ke sach -----
                var ke1 = new KeSach { MaKe = "KE01", TenKe = "Kệ A1", MaKho = kho1.MaKho };
                var ke2 = new KeSach { MaKe = "KE02", TenKe = "Kệ B1", MaKho = kho2.MaKho };
                db.KeSachs.AddRange(new[] { ke1, ke2 });
                db.SaveChanges();

                // ----- 5. Chuc Vu + Nhan Vien -----
                var cvQuanLy = new ChucVu { MaChucVu = "CV01", TenChucVu = "Quản lý", MoTa = "Quản lý cửa hàng" };
                var cvNhanVien = new ChucVu { MaChucVu = "CV02", TenChucVu = "Nhân viên bán hàng", MoTa = "Tiếp đón và bán hàng" };
                var cvOnline = new ChucVu { MaChucVu = "CV_ONLINE", TenChucVu = "Nhân viên xử lý đơn hàng online", MoTa = "Dùng cho các nghiệp vụ hệ thống, không đại diện cá nhân thực tế" };
                db.ChucVus.AddRange(new[] { cvQuanLy, cvNhanVien, cvOnline });
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
                var nvOnlineHCM = new NhanVien
                {
                    MaNV = "NV_ONLINE_HCM",
                    HoTen = "Nhân viên Online - HCM",
                    GioiTinh = "Khác",
                    NgaySinh = new DateTime(2000, 1, 1),
                    SoDienThoai = "0000000000",
                    Email = "online.hcm@cuahangg.com",
                    DiaChi = "TP.HCM",
                    TrangThai = true,
                    MaChucVu = cvOnline.MaChucVu,
                    MaChiNhanh = chiNhanh1.MaChiNhanh
                };

                var nvOnlineHN = new NhanVien
                {
                    MaNV = "NV_ONLINE_HN",
                    HoTen = "Nhân viên Online - HN",
                    GioiTinh = "Khác",
                    NgaySinh = new DateTime(2000, 1, 1),
                    SoDienThoai = "0000000000",
                    Email = "online.hn@cuahangg.com",
                    DiaChi = "Hà Nội",
                    TrangThai = true,
                    MaChucVu = cvOnline.MaChucVu,
                    MaChiNhanh = chiNhanh2.MaChiNhanh
                }   ;
                db.NhanViens.AddRange(new[] { nv1, nv2, nv3 , nvOnlineHCM, nvOnlineHN});
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
                  new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S005", SoLuong = 25, DonGia = 25000 },
                  new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S006", SoLuong = 35, DonGia = 27000 },
                  new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S007", SoLuong = 45, DonGia = 29000 },
                  new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S008", SoLuong = 30, DonGia = 31000 },
                  new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S009", SoLuong = 40, DonGia = 33000 },
                  new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S010", SoLuong = 20, DonGia = 35000 },
                  new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S011", SoLuong = 25, DonGia = 26000 },
                  new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S012", SoLuong = 28, DonGia = 24000 },
                  new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S013", SoLuong = 32, DonGia = 30000 },
                  new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S014", SoLuong = 38, DonGia = 28000 },
                  new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S015", SoLuong = 40, DonGia = 26000 },
                  new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S016", SoLuong = 22, DonGia = 27000 },
                  new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S017", SoLuong = 26, DonGia = 31000 },
                  new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S018", SoLuong = 34, DonGia = 33000 },
                  new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S019", SoLuong = 28, DonGia = 29000 },
                  new CT_NhapKho { MaPhieuNhap = phieuNhap1.MaPhieuNhap, MaSach = "S020", SoLuong = 36, DonGia = 32000 }
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







                // -----------------------------
                // SỬA LẠI & BỔ SUNG DỮ LIỆU CHI TIẾT (PHÙ HỢP MODEL)
                // -----------------------------

                // ===== CongViec =====
                if (!db.CongViecs.Any())
                {
                    db.CongViecs.AddRange(new[]
                    {
        new CongViec { MaCongViec = 1, TenCongViec = "Kiểm kê kho", MoTa = "Kiểm tra và ghi nhận hàng tồn kho", LuongTheoGio = 0 },
        new CongViec { MaCongViec = 2, TenCongViec = "Giao hàng", MoTa = "Giao đơn hàng đến khách", LuongTheoGio = 0 },
        new CongViec { MaCongViec = 3, TenCongViec = "Bán hàng", MoTa = "Tư vấn và bán hàng tại quầy", LuongTheoGio = 0 },
        new CongViec { MaCongViec = 4, TenCongViec = "Quản lý tồn kho", MoTa = "Theo dõi nhập - xuất - tồn kho", LuongTheoGio = 0 }
    });
                    db.SaveChanges();
                }

                // ===== PhanCong =====
                // Lưu ý dùng MaNV trùng với MaNV bạn đã seed trước (NV01, NV02, NV03)
                if (!db.PhanCongs.Any())
                {
                    db.PhanCongs.AddRange(new[]
                    {
        new PhanCong { MaNV = "NV01", MaCongViec = 1, TenCongViec = "Kiểm kê sách", MoTa = "Kiểm tra sách trong kho KHO01 - Ke A1", NgayBatDau = DateTime.Now.AddDays(-5), NgayKetThuc = null, HoanThanh = false },
        new PhanCong { MaNV = "NV02", MaCongViec = 2, TenCongViec = "Giao hàng DH001", MoTa = "Giao đơn DH001 tới khách", NgayBatDau = DateTime.Now.AddDays(-4), NgayKetThuc = DateTime.Now.AddDays(-3), HoanThanh = true },
        new PhanCong { MaNV = "NV03", MaCongViec = 3, TenCongViec = "Bán hàng ca sáng", MoTa = "Phụ trách quầy HCM ca sáng", NgayBatDau = DateTime.Now.AddDays(-2), HoanThanh = false },
        new PhanCong { MaNV = "NV01", MaCongViec = 4, TenCongViec = "Quản lý tồn kho tháng", MoTa = "Theo dõi tồn kho đầu tháng", NgayBatDau = DateTime.Now.AddDays(-30), HoanThanh = true },
        new PhanCong { MaNV = "NV03", MaCongViec = 2, TenCongViec = "Giao hàng COD DH002", MoTa = "Giao đơn DH002", NgayBatDau = DateTime.Now.AddDays(-7), HoanThanh = true }
    });
                    db.SaveChanges();
                }

                // ===== BangLuong =====
                // Chú ý: model của bạn dùng ThangTinhLuong, PhuCap, Thuong, KhauTru
                if (!db.BangLuongs.Any())
                {
                    db.BangLuongs.AddRange(new[]
                    {
        new BangLuong { MaNV = "NV01", LuongCoBan = 8000000m, PhuCap = 200000m, Thuong = 500000m, KhauTru = 200000m, ThangTinhLuong = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) },
        new BangLuong { MaNV = "NV02", LuongCoBan = 7500000m, PhuCap = 150000m, Thuong = 300000m, KhauTru = 0m, ThangTinhLuong = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) },
        new BangLuong { MaNV = "NV03", LuongCoBan = 7000000m, PhuCap = 100000m, Thuong = 400000m, KhauTru = 150000m, ThangTinhLuong = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) }
    });
                    db.SaveChanges();
                }

                // ===== DonViVanChuyen =====
                // Dùng tên thuộc tính đúng: MaDVVC, TenDonVi, SoDienThoai, PhiCoBan, MoTa
                if (!db.DonViVanChuyens.Any())
                {
                    db.DonViVanChuyens.AddRange(new[]
                    {
        new DonViVanChuyen { MaDVVC = "DVVC01", TenDonVi = "Giao Hàng Nhanh (GHN)", SoDienThoai = "0901234567", PhiCoBan = 30000m, MoTa = "Giao hàng nhanh trong nội thành" },
        new DonViVanChuyen { MaDVVC = "DVVC02", TenDonVi = "Giao Hàng Tiết Kiệm (GHTK)", SoDienThoai = "0907654321", PhiCoBan = 25000m, MoTa = "Giá rẻ, giao vận toàn quốc" },
        new DonViVanChuyen { MaDVVC = "DVVC03", TenDonVi = "VNPost Express", SoDienThoai = "1900545481", PhiCoBan = 20000m, MoTa = "Bưu điện nhanh" }
    });
                    db.SaveChanges();
                }

                // ===== Thêm đơn hàng (DH003..DH010) - dùng MaKhach đúng (kh_anh, kh_huong, kh_minh) và MaNV có thực =====
                if (db.DonHangs.Count() < 10)
                {
                    var moreOrders = new[]
                    {
        new DonHang { MaDonHang = "DH003", MaKhach = "kh_anh", MaNV = "NV03", NgayDat = DateTime.Now.AddDays(-5), NgayGiao = null, TongTien = 320000m, LoaiDon = "Online", TrangThai = "Đang giao" },
        new DonHang { MaDonHang = "DH004", MaKhach = "kh_huong", MaNV = "NV02", NgayDat = DateTime.Now.AddDays(-4), NgayGiao = DateTime.Now.AddDays(-2), TongTien = 520000m, LoaiDon = "Online", TrangThai = "Đã giao" },
        new DonHang { MaDonHang = "DH005", MaKhach = "kh_minh", MaNV = "NV01", NgayDat = DateTime.Now.AddDays(-3), NgayGiao = null, TongTien = 780000m, LoaiDon = "Online", TrangThai = "Chờ xác nhận" },
        new DonHang { MaDonHang = "DH006", MaKhach = "kh_anh", MaNV = "NV01", NgayDat = DateTime.Now.AddDays(-2), NgayGiao = null, TongTien = 450000m, LoaiDon = "Online", TrangThai = "Đã hủy" },
        new DonHang { MaDonHang = "DH007", MaKhach = "kh_huong", MaNV = "NV03", NgayDat = DateTime.Now.AddDays(-2), NgayGiao = null, TongTien = 610000m, LoaiDon = "Online", TrangThai = "Đang xử lý" },
        new DonHang { MaDonHang = "DH008", MaKhach = "kh_minh", MaNV = "NV02", NgayDat = DateTime.Now.AddDays(-1), NgayGiao = null, TongTien = 970000m, LoaiDon = "Online", TrangThai = "Đang giao" },
        new DonHang { MaDonHang = "DH009", MaKhach = "kh_anh", MaNV = "NV02", NgayDat = DateTime.Now, NgayGiao = null, TongTien = 1120000m, LoaiDon = "Trực tiếp", TrangThai = "Đã giao" },
        new DonHang { MaDonHang = "DH010", MaKhach = "kh_huong", MaNV = "NV01", NgayDat = DateTime.Now, NgayGiao = null, TongTien = 830000m, LoaiDon = "Online", TrangThai = "Chờ thanh toán" }
    };
                    db.DonHangs.AddRange(moreOrders);
                    db.SaveChanges();
                }

                // ===== CT_DonHang cho các đơn mới =====
                // Thêm vài dòng CT_DonHang minh họa (đảm bảo MaSach tồn tại: S001..S020)
                if (!db.CT_DonHangs.Any(ct => ct.MaDonHang.StartsWith("DH00")))
                {
                    var ctList = new List<CT_DonHang>
    {
        new CT_DonHang { MaDonHang = "DH003", MaSach = "S003", SoLuong = 1, DonGia = 65000m, ThanhTien = 65000m },
        new CT_DonHang { MaDonHang = "DH003", MaSach = "S005", SoLuong = 2, DonGia = 90000m, ThanhTien = 180000m },

        new CT_DonHang { MaDonHang = "DH004", MaSach = "S007", SoLuong = 1, DonGia = 75000m, ThanhTien = 75000m },
        new CT_DonHang { MaDonHang = "DH004", MaSach = "S010", SoLuong = 4, DonGia = 72000m, ThanhTien = 288000m },

        new CT_DonHang { MaDonHang = "DH005", MaSach = "S012", SoLuong = 3, DonGia = 82000m, ThanhTien = 246000m },
        new CT_DonHang { MaDonHang = "DH005", MaSach = "S013", SoLuong = 2, DonGia = 74000m, ThanhTien = 148000m },

        new CT_DonHang { MaDonHang = "DH006", MaSach = "S002", SoLuong = 1, DonGia = 85000m, ThanhTien = 85000m },

        new CT_DonHang { MaDonHang = "DH007", MaSach = "S008", SoLuong = 1, DonGia = 80000m, ThanhTien = 80000m },
        new CT_DonHang { MaDonHang = "DH007", MaSach = "S011", SoLuong = 1, DonGia = 76000m, ThanhTien = 76000m },

        new CT_DonHang { MaDonHang = "DH008", MaSach = "S014", SoLuong = 5, DonGia = 88000m, ThanhTien = 440000m },

        new CT_DonHang { MaDonHang = "DH009", MaSach = "S015", SoLuong = 2, DonGia = 80000m, ThanhTien = 160000m },
        new CT_DonHang { MaDonHang = "DH009", MaSach = "S016", SoLuong = 3, DonGia = 72000m, ThanhTien = 216000m },

        new CT_DonHang { MaDonHang = "DH010", MaSach = "S017", SoLuong = 1, DonGia = 60000m, ThanhTien = 60000m },
        new CT_DonHang { MaDonHang = "DH010", MaSach = "S018", SoLuong = 2, DonGia = 76000m, ThanhTien = 152000m }
    };
                    db.CT_DonHangs.AddRange(ctList);
                    db.SaveChanges();
                }

                // ===== VanChuyen cho các đơn hàng mới =====
                // VanChuyen.MaDonHang là key chính, và MaDVVC phải tồn tại
                if (!db.VanChuyens.Any(v => v.MaDonHang.StartsWith("DH00")))
                {
                    var vans = new[]
                    {
        new VanChuyen { MaDonHang = "DH003", MaDVVC = "DVVC01", NgayTao = DateTime.Now.AddDays(-5), NgayGiao = null, TrangThai = "Đang giao", GhiChu = "Giao nhanh" },
        new VanChuyen { MaDonHang = "DH004", MaDVVC = "DVVC02", NgayTao = DateTime.Now.AddDays(-4), NgayGiao = DateTime.Now.AddDays(-2), TrangThai = "Đã giao", GhiChu = "Đã hoàn tất" },
        new VanChuyen { MaDonHang = "DH005", MaDVVC = "DVVC03", NgayTao = DateTime.Now.AddDays(-3), NgayGiao = null, TrangThai = "Chờ lấy hàng", GhiChu = "" },
        new VanChuyen { MaDonHang = "DH006", MaDVVC = "DVVC02", NgayTao = DateTime.Now.AddDays(-2), NgayGiao = null, TrangThai = "Đã hủy", GhiChu = "Khách hủy" },
        new VanChuyen { MaDonHang = "DH007", MaDVVC = "DVVC01", NgayTao = DateTime.Now.AddDays(-2), NgayGiao = null, TrangThai = "Đang xử lý", GhiChu = "" },
        new VanChuyen { MaDonHang = "DH008", MaDVVC = "DVVC03", NgayTao = DateTime.Now.AddDays(-1), NgayGiao = null, TrangThai = "Đang giao", GhiChu = "" },
        new VanChuyen { MaDonHang = "DH009", MaDVVC = "DVVC01", NgayTao = DateTime.Now, NgayGiao = DateTime.Now, TrangThai = "Đã giao", GhiChu = "" },
        new VanChuyen { MaDonHang = "DH010", MaDVVC = "DVVC02", NgayTao = DateTime.Now, NgayGiao = null, TrangThai = "Chờ lấy hàng", GhiChu = "" }
    };
                    db.VanChuyens.AddRange(vans);
                    db.SaveChanges();
                }

                // ===== KiemKe (bổ sung thêm) =====
                if (!db.KiemKes.Any(k => k.MaKiemKe == "KK002"))
                {
                    db.KiemKes.AddRange(new[]
                    {
        new KiemKe { MaKiemKe = "KK002", MaNV = "NV02", MaKho = "KHO02", NgayKiemKe = DateTime.Now.AddDays(-3), GhiChu = "Kiểm kê bổ sung chi nhánh HN" },
        new KiemKe { MaKiemKe = "KK003", MaNV = "NV03", MaKho = "KHO01", NgayKiemKe = DateTime.Now.AddDays(-1), GhiChu = "Kiểm tra tồn cuối tuần" }
    });
                    db.SaveChanges();
                }

                // ===== ChuyenKho (ghi đúng tên thuộc tính MaPhieuChuyen) =====
                if (!db.ChuyenKhos.Any(c => c.MaPhieuChuyen == "CK001"))
                {
                    db.ChuyenKhos.AddRange(new[]
                    {
        new ChuyenKho { MaPhieuChuyen = "CK001", MaKhoXuat = "KHO01", MaKhoNhap = "KHO02", NgayChuyen = DateTime.Now.AddDays(-10), GhiChu = "Chuyển bổ sung hàng" },
        new ChuyenKho { MaPhieuChuyen = "CK002", MaKhoXuat = "KHO02", MaKhoNhap = "KHO01", NgayChuyen = DateTime.Now.AddDays(-4), GhiChu = "Điều chuyển đáp ứng đơn" }
    });
                    db.SaveChanges();
                }

                // ===== ThongBao (một vài thông báo thêm) =====
                if (!db.ThongBaos.Any(tb => tb.MaThongBao == "TB001"))
                {
                    db.ThongBaos.AddRange(new[]
                    {
        new ThongBao { MaThongBao = "TB001", TieuDe = "Khuyến mãi tháng 11", NoiDung = "Giảm 20% cho đơn hàng > 500k", NgayGui = DateTime.Now, NguoiNhan = "ALL" },
        new ThongBao { MaThongBao = "TB002", TieuDe = "Lịch kiểm kê", NoiDung = "Kiểm kê toàn kho ngày 30/11", NgayGui = DateTime.Now, NguoiNhan = "NV01" },
        new ThongBao { MaThongBao = "TB003", TieuDe = "Thông báo nghỉ lễ", NoiDung = "Cửa hàng nghỉ lễ 2 ngày", NgayGui = DateTime.Now, NguoiNhan = "ALL" }
    });
                    db.SaveChanges();
                }

















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
