using BUS.DTOs;
using PM.BUS.Services.Facade;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PM.GUI.UserControls.Client
{
    public partial class DonHang : UserControl
    {
        private readonly QuanLyDonHangBUS _bus;

        public DonHang()
        {
            InitializeComponent();
            _bus = new QuanLyDonHangBUS();
        }

        // ================== FORM LOAD ==================
        private void DonHang_Load(object sender, EventArgs e)
        {
            // Tải toàn bộ đơn hàng ban đầu
            TaiDonHang();
        }

        // ================== TẢI DỮ LIỆU ==================
        public void TaiDonHang(string trangThai = null)
        {
            try
            {
                var ds = _bus.LayDanhSachDonHangDTO(trangThai);

                dgvDonHang.Rows.Clear();
                foreach (var d in ds)
                {
                    dgvDonHang.Rows.Add(
                        d.MaDonHang,
                        d.TenKhachHang,
                        d.SDT,
                        d.TenNhanVien,
                        d.NgayTao.ToString("dd/MM/yyyy"),
                        d.NgayGiao?.ToString("dd/MM/yyyy") ?? "—",
                        d.TongTien.ToString("N0") + " đ",
                        d.TrangThai
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================== SỰ KIỆN ==================

        private void btnReload_Click(object sender, EventArgs e)
        {
            TaiDonHang();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maDon = dgvDonHang.SelectedRows[0].Cells["colMaDonHang"].Value.ToString();

            // ⚠️ Nếu bạn chưa có form chi tiết, có thể comment 2 dòng dưới
            // FormChiTietDon f = new FormChiTietDon(maDon);
            // f.ShowDialog();
        }

        private void btnDuyetDon_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maDon = dgvDonHang.SelectedRows[0].Cells["colMaDonHang"].Value.ToString();

            var confirm = MessageBox.Show("Xác nhận duyệt đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                if (_bus.DuyetDon(maDon))
                {
                    MessageBox.Show("Đơn hàng đã được duyệt thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDonHang();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đơn hàng hoặc lỗi xử lý.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
