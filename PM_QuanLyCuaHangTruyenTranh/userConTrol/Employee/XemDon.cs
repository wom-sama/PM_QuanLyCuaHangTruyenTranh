using PM.BUS.Services.Facade;
using System;
using System.Windows.Forms;

namespace PM_QuanLyCuaHangTruyenTranh.userConTrol.Employee
{
    public partial class XemDon : UserControl
    {
        private readonly QuanLyDonHangBUS _bus;

        public XemDon()
        {
            InitializeComponent();
            _bus = new QuanLyDonHangBUS();
        }

        private void XemDon_Load(object sender, EventArgs e)
        {
            LoadDonHang();
        }

        private void LoadDonHang(string trangThai = null)
        {
            try
            {
                guna2DataGridView1.DataSource = _bus.LayDanhSachDonHang(trangThai);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đơn hàng: " + ex.Message);
            }
        }

        private void btnDangGiao_Click(object sender, EventArgs e)
        {
            LoadDonHang("Đang giao");
        }

        private void btnDaban_Click(object sender, EventArgs e)
        {
            LoadDonHang("Đã bán");
        }
    }
}
