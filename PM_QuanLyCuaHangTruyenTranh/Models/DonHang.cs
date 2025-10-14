using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Models
{
    public class DonHang
    {
        [Key, Column(TypeName = "varchar"), MaxLength(20)]
        public string MaDonHang { get; set; }

        [ForeignKey("Khach")]
        public string MaKhach { get; set; }
        public virtual KhachHang Khach { get; set; }

        [ForeignKey("NhanVien")]
        public string MaNV { get; set; }
        public virtual NhanVien NhanVien { get; set; }

        public DateTime NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }

        public virtual ICollection<CT_DonHang> CT_DonHangs { get; set; }
    }
}
