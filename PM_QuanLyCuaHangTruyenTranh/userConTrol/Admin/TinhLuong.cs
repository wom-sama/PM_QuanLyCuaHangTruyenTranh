using BUS.Services.LamViecsv;
using PM.DAL;
using PM.DAL.Models;
using PM.GUI.userConTrol.Client;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Admin
{
    public partial class TinhLuong : UserControl
    {
        private readonly LuongService _luongService;

        public TinhLuong()
        {
            InitializeComponent();
            _luongService = new LuongService();

            LoadData();

            // Gán sự kiện
            dgvLuong.CellClick += DgvLuong_CellClick;
            btnTinhLuong.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnTongLuongThang.Click += BtnTongLuongThang_Click;
        }

        private void LoadData()
        {
            dgvLuong.DataSource = null;
            dgvLuong.DataSource = _luongService.GetAll().ToList();
            if (dgvLuong.Columns["NhanVien"] != null)
                dgvLuong.Columns["NhanVien"].Visible = false;
        }

        private BangLuong GetSelectedBangLuong()
        {
            if (dgvLuong.CurrentRow == null) return null;
            return dgvLuong.CurrentRow.DataBoundItem as BangLuong;
        }

        private void DgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = GetSelectedBangLuong();
            if (item == null) return;

            txtMaNV.Text = item.MaNV;
            txtLuongCoBan.Text = item.LuongCoBan.ToString();
            txtPhuCap.Text = item.PhuCap.ToString();
            txtThuong.Text = item.Thuong.ToString();
            txtKhauTru.Text = item.KhauTru.ToString();
            dtThang.Value = item.ThangTinhLuong;
        }

        private bool IsMaNVExists(string maNV)
        {
            // Cú pháp cũ cho C# 7.3
            var unit = new UnitOfWork();
            try
            {
                return unit.NhanVienRepository.GetAll().Any(n => n.MaNV == maNV);
            }
            finally
            {
                if (unit != null)
                    unit.Dispose();
            }
        }


        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text.Trim();
                if (!IsMaNVExists(maNV))
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!");
                    return;
                }

                var bl = new BangLuong
                {
                    MaNV = maNV,
                    LuongCoBan = decimal.Parse(txtLuongCoBan.Text),
                    PhuCap = decimal.Parse(txtPhuCap.Text),
                    Thuong = decimal.Parse(txtThuong.Text),
                    KhauTru = decimal.Parse(txtKhauTru.Text),
                    ThangTinhLuong = dtThang.Value
                };

                _luongService.Add(bl);
                LoadData();
                MessageBox.Show("✅ Thêm bảng lương thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm bảng lương: " + ex.Message);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GetSelectedBangLuong();
                if (selected == null)
                {
                    MessageBox.Show("Chọn bảng lương để sửa!");
                    return;
                }

                string maNV = txtMaNV.Text.Trim();
                if (!IsMaNVExists(maNV))
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!");
                    return;
                }

                selected.MaNV = maNV;
                selected.LuongCoBan = decimal.Parse(txtLuongCoBan.Text);
                selected.PhuCap = decimal.Parse(txtPhuCap.Text);
                selected.Thuong = decimal.Parse(txtThuong.Text);
                selected.KhauTru = decimal.Parse(txtKhauTru.Text);
                selected.ThangTinhLuong = dtThang.Value;

                _luongService.Update(selected);
                LoadData();
                MessageBox.Show("✅ Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GetSelectedBangLuong();
                if (selected == null) return;

                if (MessageBox.Show("Xác nhận xóa bảng lương này?", "Xóa", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                _luongService.Delete(selected.MaBangLuong);
                LoadData();
                MessageBox.Show("✅ Xóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        private void BtnTongLuongThang_Click(object sender, EventArgs e)
        {
            var thang = dtThang.Value;
            decimal tong = _luongService.TongLuongTheoThang(thang);
            lblTongLuong.Text = $"Tổng lương tháng {thang:MM/yyyy}: {tong:n0} VNĐ";
        }
    }
}