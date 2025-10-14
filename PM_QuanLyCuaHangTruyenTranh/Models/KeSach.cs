using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Models
{
    public class KeSach
    {
        [Key, Column(TypeName = "varchar"), MaxLength(20)]
        public string MaKe { get; set; }

        [Required, StringLength(100)]
        public string TenKe { get; set; }

        [ForeignKey("Kho")]
        public string MaKho { get; set; }
        public virtual Kho Kho { get; set; }
    }
}
