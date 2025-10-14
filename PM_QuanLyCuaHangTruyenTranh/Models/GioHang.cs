using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Models
{
    public class GioHang
    {
        [Key, Column(TypeName = "varchar"), MaxLength(20)]
        public string MaGioHang { get; set; }

        [ForeignKey("Khach")]
        public string MaKhach { get; set; }
        public virtual KhachHang Khach { get; set; }

        public virtual ICollection<CT_GioHang> CT_GioHangs { get; set; }
    }
}
