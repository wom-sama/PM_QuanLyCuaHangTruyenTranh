using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Models
{
    public class TheLoai
    {

        [Key]
        public string MaTheLoai { get; set; }

        [Required]
        public string TenTheLoai { get; set; }

        public string GhiChu { get; set; }

        // Navigation
        public virtual ICollection<Sach> Sachs { get; set; }

        public TheLoai()
        {
            Sachs = new HashSet<Sach>();
        }


    }
}
