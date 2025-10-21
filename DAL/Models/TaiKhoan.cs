using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM.DAL.Models
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

        [Required, Column(TypeName = "nvarchar"), MaxLength(50)]
        public string Quyen { get; set; } // "Admin", "NhanVien", "Khach"

        public bool TrangThai { get; set; } = true;

        // Quan hệ 1-1 với KhachHang
        public virtual KhachHang KhachHang { get; set; }
    }
}
