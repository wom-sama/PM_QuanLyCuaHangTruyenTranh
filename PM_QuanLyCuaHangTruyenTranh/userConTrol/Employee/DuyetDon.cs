using PM.BUS.Services.Facade;
using PM.DAL.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Employee
{
    public partial class DuyetDon : UserControl
    {
        private readonly QuanLyDonHangBUS _bus;
        private string selectedMaDonHang = null;

        public DuyetDon()
        {
            InitializeComponent();
            _bus = new QuanLyDonHangBUS();

            // 🌈 Định dạng label sau khi InitializeComponent()
            var labels = new[] { lblTenKhach, lblSDT, lblEmail, lblDiaChi, lblDonViVC, lblTongTien, lblNgayDat, lblNgayGiao };
            int x = 20, y = 15, spacing = 22;
            foreach (var lbl in labels)
            {
                lbl.Font = new System.Drawing.Font("Segoe UI", 10.5F);
                lbl.ForeColor = System.Drawing.Color.DimGray;
                lbl.Location = new System.Drawing.Point(x, y);
                lbl.AutoSize = true;
                y += spacing;
            }

            // Nạp danh sách đơn hàng
            dgvDonHang.DataSource = _bus.LayDanhSachDonHangTheoTrangThai("Đang xử lý");
            dgvChiTiet.DataSource = null;
        }

        private void LoadDonHang()
        {
            dgvDonHang.DataSource = _bus.LayDanhSachDonHangTheoTrangThai("Đang xử lý");
            dgvChiTiet.DataSource = null;
            selectedMaDonHang = null;
            XoaThongTinChiTiet();
        }

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedMaDonHang = dgvDonHang.Rows[e.RowIndex].Cells["MaDonHang"].Value.ToString();
            HienThiChiTietDonHang(selectedMaDonHang);
        }

        private void HienThiChiTietDonHang(string maDonHang)
        {
            var don = _bus.LayDonHangTheoMa(maDonHang);
            if (don == null)
            {
                MessageBox.Show("Không tìm thấy đơn hàng!");
                return;
            }

            // 🧍 Thông tin khách hàng
            var kh = don.Khach;
            lblTenKhach.Text = $"👤 Khách hàng: {kh?.HoTen ?? "N/A"}";
            lblSDT.Text = $"☎️ SĐT: {kh?.SoDienThoai ?? "N/A"}";
            lblEmail.Text = $"✉️ Email: {kh?.Email ?? "N/A"}";
            lblDiaChi.Text = $"🏠 Địa chỉ: {kh?.DiaChi ?? "N/A"}";

            // 🚚 Đơn vị vận chuyển
            var vc = don.VanChuyen?.DonViVanChuyen;
            lblDonViVC.Text = vc != null
                ? $"🚚 ĐVVC: {vc.TenDonVi} ({vc.SoDienThoai})"
                : "🚚 ĐVVC: Chưa có";

            // 💰 Tổng tiền, ngày
            lblTongTien.Text = $"💰 Tổng tiền: {don.TongTien:C0}";
            lblNgayDat.Text = $"📅 Ngày đặt: {don.NgayDat:dd/MM/yyyy}";
            lblNgayGiao.Text = don.NgayGiao != null
                ? $"📦 Ngày giao: {don.NgayGiao:dd/MM/yyyy}"
                : $"📦 Ngày giao: Chưa giao";

            // 📦 Danh sách sản phẩm
            dgvChiTiet.DataSource = don.CT_DonHangs
                .Select(ct => new
                {
                    Tên_sách = ct.Sach.TenSach,
                    Số_lượng = ct.SoLuong,
                    Đơn_giá = ct.DonGia,
                    Thành_tiền = ct.ThanhTien
                })
                .ToList();
        }

        private void XoaThongTinChiTiet()
        {
            lblTenKhach.Text = lblSDT.Text = lblEmail.Text =
                lblDiaChi.Text = lblDonViVC.Text =
                lblTongTien.Text = lblNgayDat.Text = lblNgayGiao.Text = "";
            dgvChiTiet.DataSource = null;
        }

        private void BtnDuyetDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaDonHang))
            {
                MessageBox.Show("⚠️ Vui lòng chọn đơn hàng trước!", "Thông báo");
                return;
            }

            var donHang = _bus.LayDonHangTheoMa(selectedMaDonHang);
            if (donHang == null)
            {
                MessageBox.Show("❌ Không tìm thấy đơn hàng!");
                return;
            }

            if (donHang.TrangThai != "Đang xử lý")
            {
                MessageBox.Show("⚠️ Chỉ duyệt các đơn đang xử lý!");
                return;
            }

            bool ok = _bus.DuyetDon(selectedMaDonHang);
            if (ok)
                MessageBox.Show($"✅ Đơn {selectedMaDonHang} đã chuyển sang trạng thái 'Đang giao'!");
            else
                MessageBox.Show("❌ Duyệt đơn thất bại!");

            LoadDonHang();
        }

        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDonHang();
        }

        private void dgvDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDonHang_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
