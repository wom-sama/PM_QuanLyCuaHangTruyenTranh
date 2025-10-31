using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM.DAL.Models
{
    public class DonHang
    {
        [Key, Column(TypeName = "varchar"), MaxLength(20)]
        public string MaDonHang { get; set; }

        [ForeignKey("Khach")]
        public string MaKhach { get; set; }
        public virtual KhachHang Khach { get; set; }

        [ForeignKey("NhanVien")]
        public string MaNV { get; set; }
        public virtual NhanVien NhanVien { get; set; }

        public DateTime NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }

        public decimal TongTien { get; set; }

        [StringLength(20)]
        public string LoaiDon { get; set; } // "Online" hoặc "Trực tiếp"

        [StringLength(50)]
        public string TrangThai { get; set; }

        // 🔹 Mỗi đơn có thể có 1 phiếu vận chuyển (nếu là Online)
        public virtual VanChuyen VanChuyen { get; set; }
        [StringLength(50)]
        public string HinhThucThanhToan { get; set; }


        public virtual ICollection<CT_DonHang> CT_DonHangs { get; set; }

    }
}
