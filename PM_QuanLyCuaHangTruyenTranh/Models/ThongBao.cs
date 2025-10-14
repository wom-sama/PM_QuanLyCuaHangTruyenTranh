using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Models
{
    public class ThongBao
    {
        [Key, StringLength(20)]
        public string MaThongBao { get; set; }

        [Required, StringLength(200)]
        public string TieuDe { get; set; }

        public string NoiDung { get; set; }
        public DateTime NgayGui { get; set; }

        public string NguoiNhan { get; set; } // Mã khách hoặc nhân viên
    }
}
