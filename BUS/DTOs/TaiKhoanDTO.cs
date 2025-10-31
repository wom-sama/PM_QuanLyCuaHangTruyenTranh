using PM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.DTOs
{
    public class TaiKhoanDTO
    {
        public string TenDangNhap { get; set; }
        public string Quyen { get; set; }
        public bool TrangThai { get; set; }

        // Nếu cần hiển thị thêm thông tin
        public string HoTen { get; set; } // Từ NhanVien hoặc KhachHang
        public KhachHang KhachHang { get; set; }
    }
}
