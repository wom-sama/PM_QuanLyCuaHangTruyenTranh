using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Models
{
    public class TaiKhoan
    {
        [Key]
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string TenDangNhap { get; set; }

        [Required, Column(TypeName = "varchar"), MaxLength(255)]
        public string MatKhau { get; set; } // bcrypt hash

        [Column(TypeName = "varchar"), MaxLength(20)]
        public string MaNhanVien { get; set; }

        [ForeignKey("MaNhanVien")]
        public virtual NhanVien NhanVien { get; set; }

        [Column(TypeName = "varchar"), MaxLength(20)]
        public string MaKH { get; set; }

        [ForeignKey("MaKH")]
        public virtual KhachHang KhachHang { get; set; }

        [Required, Column(TypeName = "nvarchar"), MaxLength(50)]
        public string Quyen { get; set; } // "Admin", "NhanVien", "Khach"

        public bool TrangThai { get; set; } = true;
    }
}
