using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL.Models
{
    public class ChiNhanh
    {
        [Key, Column(TypeName = "varchar"), MaxLength(20)]
        public string MaChiNhanh { get; set; }

        [Required, StringLength(100)]
        public string TenChiNhanh { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public bool TrangThai { get; set; }

        // Navigation
        public virtual ICollection<Kho> Khos { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
