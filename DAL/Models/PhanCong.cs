using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM.DAL.Models
{
    public class PhanCong
    {
        [Key]
        public int MaPhanCong { get; set; }

        [Required, ForeignKey("NhanVien")]
        public string MaNV { get; set; }
        public virtual NhanVien NhanVien { get; set; }

        [ForeignKey("CongViec")]
        public int? MaCongViec { get; set; }
        public virtual CongViec CongViec { get; set; }

        [Required, StringLength(100)]
        public string TenCongViec { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }

        public DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }

        public bool HoanThanh { get; set; }
    }
}
