using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Models
{
    public class BanQuyen
    {
        [Key, Column(TypeName = "varchar"), MaxLength(20)]
        public string MaBanQuyen { get; set; }

        [ForeignKey("Sach")]
        public string MaSach { get; set; }
        public virtual Sach Sach { get; set; }

        public DateTime NgayCap { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public string GhiChu { get; set; }
    }
}
