using PM.BUS.Services.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Employee
{
    public partial class GiaoHang : UserControl
    {
        private readonly QuanLyDonHangBUS _bus;

        public GiaoHang()
        {
            InitializeComponent();
            _bus = new QuanLyDonHangBUS();
            LoadDonHang();
        }

        private void LoadDonHang()
        {
            var dsDangGiao = _bus.LayDanhSachDonHangTheoTrangThai("Đang giao");
            dgvDonHang.DataSource = dsDangGiao.ToList();
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maDonHang = dgvDonHang.CurrentRow.Cells["MaDonHang"].Value.ToString();

            // Xác nhận giao
            bool success = _bus.HoanTatGiao(maDonHang);
            if (success)
            {
                MessageBox.Show($"Đơn hàng {maDonHang} đã được xác nhận giao!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDonHang(); // reload danh sách
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, không thể xác nhận giao!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyGiao_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maDonHang = dgvDonHang.CurrentRow.Cells["MaDonHang"].Value.ToString();

            // Hủy giao
            bool success = _bus.HuyGiaoDon(maDonHang);
            if (success)
            {
                MessageBox.Show($"Đơn hàng {maDonHang} đã được hủy giao!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDonHang(); // reload danh sách
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, không thể hủy giao!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
