using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.DTOs
{
    public class DonHangDTO
    {
        public string MaDonHang { get; set; }
        public string TenKhachHang { get; set; }
        public string SDT { get; set; }
        public string TenNhanVien { get; set; }
        public string LoaiDon { get; set; }  // Online / Trực tiếp
        public DateTime NgayTao { get; set; }
        public DateTime? NgayGiao { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
    }
}
