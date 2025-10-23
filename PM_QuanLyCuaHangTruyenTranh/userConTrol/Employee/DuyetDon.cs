using PM.BUS.Services.Facade;
using System;
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

            _bus = new QuanLyDonHangBUS(); // ✅ KHỞI TẠO BUS TRƯỚC

            // Lấy danh sách đơn hàng có trạng thái "Đang chờ duyệt"
            dgvDonHang.DataSource = _bus.LayDanhSachDonHangTheoTrangThai("Đang xử lý");
            dgvChiTiet.DataSource = null;
            selectedMaDonHang = null;
        }

        private void LoadDonHang()
        {
            // Chỉ tải lại các đơn hàng đang chờ duyệt
            dgvDonHang.DataSource = _bus.LayDanhSachDonHangTheoTrangThai("Đang xử lý");
            dgvChiTiet.DataSource = null;
            selectedMaDonHang = null;
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

            // Kiểm tra trạng thái hiện tại của đơn hàng
            var donHang = _bus.LayDonHangTheoMa(selectedMaDonHang);
            if (donHang == null)
            {
                MessageBox.Show("❌ Không tìm thấy đơn hàng!", "Lỗi");
                return;
            }

            if (donHang.TrangThai != "Đang xử lý")
            {
                MessageBox.Show("⚠️ Chỉ có thể duyệt các đơn hàng đang chờ duyệt!", "Thông báo");
                return;
            }

            // Thực hiện duyệt đơn
            bool thanhCong = _bus.DuyetDon(selectedMaDonHang);

            if (thanhCong)
                MessageBox.Show($"✅ Đơn {selectedMaDonHang} đã chuyển sang trạng thái 'Đang giao'!", "Thành công");
            else
                MessageBox.Show("❌ Không thể duyệt đơn hàng!", "Lỗi");

            LoadDonHang(); // làm mới danh sách sau khi duyệt
        }

        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDonHang();
        }
    }
}
