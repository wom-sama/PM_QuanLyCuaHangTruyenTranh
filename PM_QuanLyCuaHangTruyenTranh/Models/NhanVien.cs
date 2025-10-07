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
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string MaNV { get; set; }

        [Required, Column(TypeName = "varchar(50)")]
        public string TenDangNhap { get; set; }

        [Required, Column(TypeName = "varchar(255)")]
        public string MatKhau { get; set; }

        [Required, Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
    }
}
