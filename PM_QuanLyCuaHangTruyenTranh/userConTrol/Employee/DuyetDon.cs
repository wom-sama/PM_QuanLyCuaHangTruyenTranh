using PM.BUS.Services.Facade;
using System;
using System.Windows.Forms;

namespace PM_QuanLyCuaHangTruyenTranh.userConTrol.Employee
{
    public partial class DuyetDon : UserControl
    {
        private readonly QuanLyDonHangBUS _bus;
        private string selectedMaDonHang = null;

        public DuyetDon()
        {
            InitializeComponent();
            _bus = new QuanLyDonHangBUS(); // ✅ Không còn tạo UnitOfWork ở GUI
            LoadDonHang();
        }

        private void LoadDonHang()
        {
            dgvDonHang.DataSource = _bus.LayDanhSachDonHang();
            dgvChiTiet.DataSource = null;
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedMaDonHang = dgvDonHang.Rows[e.RowIndex].Cells["MaDonHang"].Value.ToString();
                dgvChiTiet.DataSource = _bus.LayChiTiet(selectedMaDonHang);
            }
        }

        private void BtnDuyetDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaDonHang))
            {
                MessageBox.Show("⚠️ Vui lòng chọn đơn hàng trước!", "Thông báo");
                return;
            }

            bool thanhCong = _bus.DuyetDon(selectedMaDonHang);

            if (thanhCong)
                MessageBox.Show($"✅ Đơn {selectedMaDonHang} đã chuyển sang trạng thái 'Đang giao'!", "Thành công");
            else
                MessageBox.Show("❌ Không thể duyệt đơn hàng!", "Lỗi");

            LoadDonHang();
        }

        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDonHang();
        }
    }
}
