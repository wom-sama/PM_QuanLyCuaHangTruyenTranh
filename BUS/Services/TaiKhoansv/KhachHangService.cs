using PM.DAL;
using PM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PM.BUS.Services.TaiKhoansv
{
    public class KhachHangService
    {
        private readonly UnitOfWork _uow = new UnitOfWork(new AppDbContext());

        /// <summary>
        /// Lấy toàn bộ khách hàng
        /// </summary>
        public List<KhachHang> LayTatCa()
        {
            return _uow.KhachHangRepository.GetAll().ToList();
        }

        /// <summary>
        /// Tìm khách hàng theo tên đăng nhập
        /// </summary>
        public KhachHang TimTheoTenDangNhap(string username)
        {
            return _uow.KhachHangRepository.GetById(username);
        }

        /// <summary>
        /// Tìm khách hàng theo tên hiển thị
        /// </summary>
        public List<KhachHang> TimTheoTen(string ten)
        {
            return _uow.KhachHangRepository.Find(k => k.HoTen.Contains(ten)).ToList();
        }

        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        public string CapNhatThongTin(KhachHang khach)
        {
            try
            {
                var existing = _uow.KhachHangRepository.GetById(khach.TenDangNhap);
                if (existing == null)
                    return "Không tìm thấy khách hàng.";

                existing.HoTen = khach.HoTen;
                existing.Email = khach.Email;
                existing.DiaChi = khach.DiaChi;
                existing.SoDienThoai = khach.SoDienThoai;
                existing.NgayDangKy = khach.NgayDangKy;

                _uow.KhachHangRepository.Update(existing);
                _uow.Save();

                return "Cập nhật thành công!";
            }
            catch (Exception ex)
            {
                return $"Lỗi cập nhật: {ex.Message}";
            }
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        public string XoaKhachHang(string tenDangNhap)
        {
            try
            {
                var kh = _uow.KhachHangRepository.GetById(tenDangNhap);
                if (kh == null)
                    return "Không tìm thấy khách hàng.";

                _uow.KhachHangRepository.Delete(kh);
                _uow.Save();

                return "Đã xóa khách hàng.";
            }
            catch (Exception ex)
            {
                return $"Lỗi khi xóa: {ex.Message}";
            }
        }
    }
}
