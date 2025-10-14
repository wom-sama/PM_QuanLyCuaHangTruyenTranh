using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Models
{
   public class NhaXuatBan
    {
        [Key, StringLength(20)]
        public string MaNXB { get; set; }

        [Required, StringLength(100)]
        public string TenNXB { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public virtual ICollection<Sach> Sachs { get; set; }
    }
}
