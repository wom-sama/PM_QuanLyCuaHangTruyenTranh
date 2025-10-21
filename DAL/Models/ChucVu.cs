using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL.Models
{
    public class ChucVu
    {
        [Key, StringLength(20)]
        public string MaChucVu { get; set; }

        [Required, StringLength(50)]
        public string TenChucVu { get; set; }

        public string MoTa { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
