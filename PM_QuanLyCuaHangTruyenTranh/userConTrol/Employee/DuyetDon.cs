using PM_QuanLyCuaHangTruyenTranh.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PM_QuanLyCuaHangTruyenTranh.userConTrol.Employee
{
    public partial class DuyetDon : UserControl
    {
        private AppDbContext db = new AppDbContext();
        private string selectedMaDonHang = null;

        public DuyetDon()
        {
            InitializeComponent();
            LoadDonHang();
        }

        private void LoadDonHang()
        {
            var data = db.DonHangs
                .Where(d => d.TrangThai == "Đã bán")
                .Select(d => new
                {
                    d.MaDonHang,
                    KháchHàng = d.Khach.HoTen,
                    NhânViên = d.NhanVien.HoTen,
                    NgàyĐặt = d.NgayDat,
                    d.TongTien,
                    d.TrangThai
                })
                .ToList();

            dgvDonHang.DataSource = data;
            dgvChiTiet.DataSource = null;
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedMaDonHang = dgvDonHang.Rows[e.RowIndex].Cells["MaDonHang"].Value.ToString();
                LoadChiTiet(selectedMaDonHang);
            }
        }

        private void LoadChiTiet(string maDonHang)
        {
            var chiTiet = db.CT_DonHangs
                .Where(ct => ct.MaDonHang == maDonHang)
                .Select(ct => new
                {
                    MãSách = ct.MaSach,
                    TênSách = ct.Sach.TenSach,
                    ct.SoLuong,
                    ct.DonGia,
                    ct.ThanhTien
                })
                .ToList();

            dgvChiTiet.DataSource = chiTiet;
        }

        private void BtnDuyetDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaDonHang))
            {
                MessageBox.Show("⚠️ Vui lòng chọn đơn hàng trước!", "Thông báo");
                return;
            }

            var don = db.DonHangs.FirstOrDefault(d => d.MaDonHang == selectedMaDonHang);
            if (don == null) return;

            don.TrangThai = "Đang giao";
            don.NgayGiao = DateTime.Now;

            var vanChuyen = new VanChuyen
            {
                MaVanChuyen = "VC" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                MaDonHang = don.MaDonHang,
                DonViVanChuyen = "Giao nội bộ",
                NgayGiao = DateTime.Now,
                TrangThai = "Đang giao"
            };

            db.VanChuyens.Add(vanChuyen);
            db.SaveChanges();

            MessageBox.Show($"✅ Đơn {don.MaDonHang} đã chuyển sang trạng thái 'Đang giao'!", "Thành công");
            LoadDonHang();
        }

        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDonHang();
        }

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
