using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PM.DAL.Models
{
    public class CongViec
    {
        [Key]
        public int MaCongViec { get; set; }

        [Required, StringLength(100)]
        public string TenCongViec { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }

        public decimal LuongTheoGio { get; set; }

        // Navigation
        public virtual ICollection<PhanCong> PhanCongs { get; set; }
    }
}
