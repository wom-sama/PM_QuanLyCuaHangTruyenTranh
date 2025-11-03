using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.DTOs
{
    public class DoanhThuDto
    {
        public string MaDonHang { get; set; }
        public DateTime NgayDat { get; set; }
        public string TenSach { get; set; }
        public int SoLuongBan { get; set; }
        public decimal DoanhThu { get; set; }
        public decimal ChiPhi { get; set; }
        public decimal LoiNhuan { get; set; }
    }

}
