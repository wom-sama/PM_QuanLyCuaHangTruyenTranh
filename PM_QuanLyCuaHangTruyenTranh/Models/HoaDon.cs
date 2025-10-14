using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Models
{
    public class HoaDon
    {
        [Key, Column(TypeName = "varchar"), MaxLength(20)]
        public string MaHoaDon { get; set; }

        [ForeignKey("DonHang")]
        public string MaDonHang { get; set; }
        public virtual DonHang DonHang { get; set; }

        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public string HinhThucThanhToan { get; set; }
    }
}
