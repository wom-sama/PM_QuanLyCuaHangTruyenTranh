using BUS.DTOs;
using PM.BUS.Helpers;
using PM.DAL;
using PM.DAL.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.TaiKhoansv
{
    public class AuthService
    {
        private readonly UnitOfWork _uow;
        private  TaiKhoanService _taiKhoanService;
        private KhachHangService _khachHangService;
        public AuthService()
        {
            _uow = new UnitOfWork(new AppDbContext());
        }

        /// <summary>
        /// Xử lý đăng nhập (hỗ trợ cả Nhân viên và Khách hàng)
        /// </summary>
        public async Task<TaiKhoanDTO> LoginAsync(string username, string password, string role)
        {
            var list = await _uow.TaiKhoanRepository.FindAsync(t =>
                t.TenDangNhap == username &&
                t.Quyen == role &&
                t.TrangThai);

            var tk = list.FirstOrDefault();

            if (tk == null || !PasswordHelper.VerifyPassword(password, tk.MatKhau))
                return null;

            string hoTen = tk.Quyen == "NhanVien" ? tk.NhanVien?.HoTen : tk.KhachHang?.HoTen;

            return new TaiKhoanDTO
            {
                TenDangNhap = tk.TenDangNhap,
                Quyen = tk.Quyen,
                TrangThai = tk.TrangThai,
                HoTen = hoTen
            };
        }

        public async Task<KhachHang> DangNhapVaLayKhachHang(string username, string password)
        {
            // ✅ Nếu 2 service bị null thì khởi tạo lại
            if (_taiKhoanService == null)
                _taiKhoanService = new TaiKhoanService(_uow);
            if (_khachHangService == null)
                _khachHangService = new KhachHangService();

            var tk = await _taiKhoanService.GetByIdAsync(username);

            if (tk == null || !PasswordHelper.VerifyPassword(password, tk.MatKhau))
                return null;

            var kh = _khachHangService.TimTheoTenDangNhap(username);
            return kh;
        }
        
        public async Task<NhanVien> DangNhapVaLayNhanVien(string username, string password)
        {
            // ✅ Nếu 2 service bị null thì khởi tạo lại
            if (_taiKhoanService == null)
                _taiKhoanService = new TaiKhoanService(_uow);
            if (_khachHangService == null)
                _khachHangService = new KhachHangService();
            var tk = await _taiKhoanService.GetByIdAsync(username);
            if (tk == null || !PasswordHelper.VerifyPassword(password, tk.MatKhau))
                return null;
            var nv = await _uow.NhanVienRepository.GetByIdAsync(tk.MaNhanVien);
            return nv;
        }


        /// <summary>
        /// Tạo tài khoản mới cho khách hàng
        /// </summary>
        public async Task<string> DangKyKhachAsync(string username, string password, string repass, string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
                    return "Vui lòng nhập đầy đủ thông tin.";

                if (password != repass)
                    return "Mật khẩu không trùng khớp.";

                var tonTaiUser = (await _uow.TaiKhoanRepository.FindAsync(t => t.TenDangNhap == username)).Any();
                if (tonTaiUser)
                    return "Tên đăng nhập đã tồn tại.";

                var tonTaiEmail = (await _uow.KhachHangRepository.FindAsync(k => k.Email == email)).Any();
                if (tonTaiEmail)
                    return "Email đã được sử dụng.";

                var tk = new TaiKhoan
                {
                    TenDangNhap = username,
                    MatKhau = PasswordHelper.HashPassword(password),
                    Quyen = "Khach",
                    TrangThai = true
                };

                var kh = new KhachHang
                {
                    TenDangNhap = username,
                    HoTen = username,
                    Email = email,
                    NgayDangKy = DateTime.Now
                };

                _uow.TaiKhoanRepository.Add(tk);
                _uow.KhachHangRepository.Add(kh);

                await _uow.SaveAsync();

                return "Tạo tài khoản thành công!";
            }
            catch (Exception ex)
            {
                return $"Lỗi khi tạo tài khoản: {ex.Message}";
            }
        }
    }
}
