using PM_QuanLyCuaHangTruyenTranh.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PM_QuanLyCuaHangTruyenTranh.userConTrol.Employee
{
    public partial class DuyetDon : UserControl
    {
        AppDbContext db = new AppDbContext();
        private string selectedMaDonHang = null;

        public DuyetDon()
        {
            InitializeComponent();
            LoadDonHang();
            // Gán sự kiện cho nút
            btnDuyetDon.Click += BtnDuyetDon_Click;
            btnTaiLai.Click += BtnTaiLai_Click;
        }

        // Load danh sách đơn chưa duyệt
        private void LoadDonHang()
        {
            var donHangList = db.DonHangs
                .Where(d => d.TrangThai == "Đã bán") // chưa duyệt
                .Select(d => new
                {
                    d.MaDonHang,
                    KhachHang = d.Khach.HoTen,
                    NhanVien = d.NhanVien.HoTen,
                    d.NgayDat,
                    d.TongTien,
                    d.TrangThai
                })
                .ToList();

            dgvDonHang.DataSource = donHangList;
            dgvChiTiet.DataSource = null;
            selectedMaDonHang = null;
        }

        // Khi click vào 1 đơn → load chi tiết
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
            var chiTietList = db.CT_DonHangs
                .Where(ct => ct.MaDonHang == maDonHang)
                .Select(ct => new
                {
                    ct.MaSach,
                    TenSach = ct.Sach.TenSach,
                    ct.SoLuong,
                    ct.DonGia,
                    ct.ThanhTien
                })
                .ToList();

            dgvChiTiet.DataSource = chiTietList;
        }

        // Duyệt đơn
        private void BtnDuyetDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaDonHang))
            {
                MessageBox.Show("Vui lòng chọn đơn hàng trước khi duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var donHang = db.DonHangs.FirstOrDefault(d => d.MaDonHang == selectedMaDonHang);
            if (donHang != null)
            {
                donHang.TrangThai = "Đang giao";
                donHang.NgayGiao = DateTime.Now;

                // Tạo bản ghi vận chuyển
                var vanChuyen = new VanChuyen
                {
                    MaVanChuyen = "VC" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                    MaDonHang = donHang.MaDonHang,
                    DonViVanChuyen = "Nội bộ",
                    NgayGiao = DateTime.Now,
                    TrangThai = "Đang giao"
                };
                db.VanChuyens.Add(vanChuyen);

                db.SaveChanges();
                MessageBox.Show($"Đơn {donHang.MaDonHang} đã được duyệt và chuyển sang 'Đang giao'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDonHang();
            }
        }

        // Tải lại danh sách
        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDonHang();
        }

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đây là dgvChiTiet, hiện tại không cần xử lý
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            // Không cần xử lý gì
        }
    }
}
