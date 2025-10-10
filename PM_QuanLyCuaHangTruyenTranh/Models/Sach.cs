using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Models
{
    public class Sach
    {
        [Key]
        public string MaSach { get; set; }

        [Required, StringLength(100)]
        public string TenSach { get; set; }

        public int SoTrang { get; set; }

        public string GioiThieu { get; set; }

        public string TacGia { get; set; }
        public byte[] BiaSach { get; set; }

        public virtual ICollection<TheLoai> TheLoais { get; set; }
        




    }
}
