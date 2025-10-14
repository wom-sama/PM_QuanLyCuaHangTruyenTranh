using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Models
{
    public class NhanVien
    {
        [Key, Column(TypeName = "varchar"), MaxLength(20)]
        public string MaNV { get; set; }

        [Required, StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        public bool TrangThai { get; set; }

        [ForeignKey("ChucVu")]
        public string MaChucVu { get; set; }
        public virtual ChucVu ChucVu { get; set; }

        [ForeignKey("ChiNhanh")]
        public string MaChiNhanh { get; set; }
        public virtual ChiNhanh ChiNhanh { get; set; }

        // Navigation
        public virtual ICollection<NhapKho> NhapKhos { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
