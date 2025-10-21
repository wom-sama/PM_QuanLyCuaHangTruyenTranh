using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL.Models
{
    public class KhuyenMai
    {
        [Key, StringLength(20)]
        public string MaKM { get; set; }

        [Required, StringLength(100)]
        public string TenKM { get; set; }

        public decimal PhanTramGiam { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string DieuKien { get; set; }

        public bool TrangThai { get; set; }
    }
}
