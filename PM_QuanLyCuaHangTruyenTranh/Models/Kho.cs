    using PM_QuanLyCuaHangTruyenTranh.userConTrol.Client;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace PM_QuanLyCuaHangTruyenTranh.Models
    {
        public class Kho
        {
            [Key, Column(TypeName = "varchar"), MaxLength(20)]
            public string MaKho { get; set; }

            [Required, StringLength(100)]
            public string TenKho { get; set; }

            [ForeignKey("ChiNhanh")]
            public string MaChiNhanh { get; set; }
            public virtual ChiNhanh ChiNhanh { get; set; }

            [StringLength(50)]
            public string LoaiKho { get; set; }

            public bool TrangThai { get; set; }

            // Navigation
            public virtual ICollection<KeSach> KeSachs { get; set; }
            public virtual ICollection<NhapKho> NhapKhos { get; set; }
            public virtual ICollection<ChuyenKho> ChuyenKhoXuats { get; set; }
            public virtual ICollection<ChuyenKho> ChuyenKhoNhaps { get; set; }
            public virtual ICollection<KiemKe> KiemKes { get; set; }
        }
    }
