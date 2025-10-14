using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Models
{
    public class TacGia
    {

        [Key, StringLength(20)]
        public string MaTacGia { get; set; }

        [Required, StringLength(100)]
        public string TenTacGia { get; set; }

        [StringLength(50)]
        public string QuocTich { get; set; }

        public string GhiChu { get; set; }

        public virtual ICollection<Sach> Sachs { get; set; }
    }
}
