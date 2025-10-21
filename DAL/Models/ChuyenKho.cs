using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL.Models
{
    public class ChuyenKho
    {
        [Key, Column(TypeName = "varchar"), MaxLength(20)]
        public string MaPhieuChuyen { get; set; }

        public DateTime NgayChuyen { get; set; }

        [ForeignKey("KhoXuat")]
        public string MaKhoXuat { get; set; }
        public virtual Kho KhoXuat { get; set; }

        [ForeignKey("KhoNhap")]
        public string MaKhoNhap { get; set; }
        public virtual Kho KhoNhap { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }
    }
}
