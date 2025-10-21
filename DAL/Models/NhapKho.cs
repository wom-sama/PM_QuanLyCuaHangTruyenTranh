using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL.Models
{
    public class NhapKho
    {
        [Key, Column(TypeName = "varchar"), MaxLength(20)]
        public string MaPhieuNhap { get; set; }

        public DateTime NgayNhap { get; set; }

        [ForeignKey("NhanVien")]
        public string MaNV { get; set; }
        public virtual NhanVien NhanVien { get; set; }

        [ForeignKey("Kho")]
        public string MaKho { get; set; }
        public virtual Kho Kho { get; set; }

        public string GhiChu { get; set; }

        public virtual ICollection<CT_NhapKho> CT_NhapKhos { get; set; }
    }
}
