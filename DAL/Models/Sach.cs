using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM.DAL.Models
{
    [Table("Saches")] 
    public class Sach
    {
        [Key, Column(TypeName = "varchar"), MaxLength(20)]
        public string MaSach { get; set; }

        [Required, StringLength(200)]
        public string TenSach { get; set; }

        [StringLength(20)]
        public string ISBN { get; set; }

        // ====== NHÀ XUẤT BẢN ======
        public string MaNXB { get; set; }
        [ForeignKey(nameof(MaNXB))]
        public virtual NhaXuatBan NhaXuatBan { get; set; }

        // ====== TÁC GIẢ ======
        public string MaTacGia { get; set; }
        [ForeignKey(nameof(MaTacGia))]
        public virtual TacGia TacGia { get; set; }

        // ====== THỂ LOẠI ======
        public string MaTheLoai { get; set; }
        [ForeignKey(nameof(MaTheLoai))]
        public virtual TheLoai TheLoai { get; set; }

        // ====== THÔNG TIN KHÁC ======
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public int SoTrang { get; set; }
        public int NamXuatBan { get; set; }
        public string MoTa { get; set; }
        public bool TrangThai { get; set; }
        public byte[] BiaSach { get; set; }
        public int LuotBan { get; set; } = 0;

        // ====== NAVIGATION COLLECTION ======

        public virtual ICollection<CT_NhapKho> CT_NhapKhos { get; set; }
        public virtual ICollection<CT_DonHang> CT_DonHangs { get; set; }

    }
}
