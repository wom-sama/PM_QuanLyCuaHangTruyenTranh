using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL.Models
{
    public class VanChuyen
    {
        [Key, Column(TypeName = "varchar"), MaxLength(20)]
        public string MaVanChuyen { get; set; }

        [ForeignKey("DonHang")]
        public string MaDonHang { get; set; }
        public virtual DonHang DonHang { get; set; }

        public string DonViVanChuyen { get; set; }
        public DateTime NgayGiao { get; set; }
        public string TrangThai { get; set; }
    }
}
