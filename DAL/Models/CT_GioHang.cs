using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL.Models
{
    public class CT_GioHang
    {
        [Key, Column(Order = 0)]
        public string MaGioHang { get; set; }

        [Key, Column(Order = 1)]
        public string MaSach { get; set; }

        [ForeignKey(nameof(MaGioHang))]
        public virtual GioHang GioHang { get; set; }

        [ForeignKey(nameof(MaSach))]
        public virtual Sach Sach { get; set; }

        public int SoLuong { get; set; }
    }
}
