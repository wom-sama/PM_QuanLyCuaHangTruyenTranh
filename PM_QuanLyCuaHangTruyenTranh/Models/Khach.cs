using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Models
{
    public class Khach
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string MaKhach { get; set; }

        [Required, Column(TypeName = "varchar"), MaxLength(50)]
        public string TenDangNhap { get; set; }

        [Required, Column(TypeName = "varchar"), MaxLength(255)]
        public string MatKhau { get; set; }

        [Required, Column(TypeName = "varchar"), MaxLength(100)]
        public string Email { get; set; }
    }
}
