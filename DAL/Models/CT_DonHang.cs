using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL.Models
{
    public class CT_DonHang
    {
        [Key, Column(Order = 0)]
        public string MaDonHang { get; set; }

        [Key, Column(Order = 1)]
        public string MaSach { get; set; }

        [ForeignKey(nameof(MaDonHang))]
        public virtual DonHang DonHang { get; set; }

        [ForeignKey(nameof(MaSach))]
        public virtual Sach Sach { get; set; }

        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
