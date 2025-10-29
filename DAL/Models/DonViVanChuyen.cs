using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM.DAL.Models
{
    public class DonViVanChuyen
    {
        [Key, Column(TypeName = "varchar"), MaxLength(20)]
        public string MaDVVC { get; set; }

        [Required, StringLength(100)]
        public string TenDonVi { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        public decimal PhiCoBan { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }

        // 🔹 Một đơn vị giao hàng có thể phụ trách nhiều phiếu vận chuyển
        public virtual ICollection<VanChuyen> VanChuyens { get; set; }
    }
}
