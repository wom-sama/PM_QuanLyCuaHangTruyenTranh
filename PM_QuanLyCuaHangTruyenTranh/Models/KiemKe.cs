using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Models
{
    public class KiemKe
    {
        [Key, Column(TypeName = "varchar"), MaxLength(20)]
        public string MaKiemKe { get; set; }

        public DateTime NgayKiemKe { get; set; }

        [ForeignKey("Kho")]
        public string MaKho { get; set; }
        public virtual Kho Kho { get; set; }

        [ForeignKey("NhanVien")]
        public string MaNV { get; set; }
        public virtual NhanVien NhanVien { get; set; }

        public string GhiChu { get; set; }
    }
}
