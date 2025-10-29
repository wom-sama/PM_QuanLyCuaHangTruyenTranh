using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM.DAL.Models
{
    public class VanChuyen
    {
        // 🔹 KHÓA CHÍNH đồng thời là KHÓA NGOẠI đến DonHang
        [Key, ForeignKey("DonHang"), Column(TypeName = "varchar"), MaxLength(20)]
        public string MaDonHang { get; set; }

        public virtual DonHang DonHang { get; set; }

        [ForeignKey("DonViVanChuyen")]
        public string MaDVVC { get; set; }
        public virtual DonViVanChuyen DonViVanChuyen { get; set; }

        public DateTime NgayTao { get; set; }
        public DateTime? NgayGiao { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }
        [NotMapped]
        public string TenDonVi => DonViVanChuyen != null ? DonViVanChuyen.TenDonVi : "(Chưa có đơn vị)";
    }
}
