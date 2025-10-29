using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM.DAL.Models
{
    public class BangLuong
    {
        [Key]
        public int MaBangLuong { get; set; }

        [Required, ForeignKey("NhanVien")]
        public string MaNV { get; set; }
        public virtual NhanVien NhanVien { get; set; }

        [Required]
        public decimal LuongCoBan { get; set; }

        public decimal PhuCap { get; set; }
        public decimal Thuong { get; set; }
        public decimal KhauTru { get; set; }

        [NotMapped]
        public decimal TongLuong => LuongCoBan + PhuCap + Thuong - KhauTru;

        [Required]
        public DateTime ThangTinhLuong { get; set; }
    }
}
