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
        [Column(TypeName = "varchar"),MaxLength(20) ]
        public string MaNV { get; set; }

        [Required, Column(TypeName = "varchar"), MaxLength(50)]
        public string TenDangNhap { get; set; }

        [Required, Column(TypeName = "varchar"), MaxLength(50)]
        public string MatKhau { get; set; }

        [Required, Column(TypeName = "varchar"), MaxLength(50)]
        public string Email { get; set; }
    }
}
