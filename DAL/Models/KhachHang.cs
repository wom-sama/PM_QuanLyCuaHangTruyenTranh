using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM.DAL.Models
{
    public class KhachHang
    {
        [Key, ForeignKey("TaiKhoan")]
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string TenDangNhap { get; set; }

        [Required, Column(TypeName = "nvarchar"), MaxLength(100)]
        public string HoTen { get; set; }

        [Column(TypeName = "varchar"), MaxLength(15)]
        public string SoDienThoai { get; set; }

        [Required, Column(TypeName = "varchar"), MaxLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(255)]
        public string DiaChi { get; set; }

        public DateTime NgayDangKy { get; set; } = DateTime.Now;

        // Quan hệ 1-1 tới TaiKhoan
        public virtual TaiKhoan TaiKhoan { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; } = new HashSet<HoaDon>();
    }
}
