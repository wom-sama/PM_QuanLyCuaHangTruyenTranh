using BUS.Services.LamViecsv;
using PM.DAL;
using PM.DAL.Models;
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

            LoadNhanVienCombo();  // Load nhân viên vào ComboBox
            LoadData();

            // Gán sự kiện
            dgvLuong.CellClick += DgvLuong_CellClick;
            btnTinhLuong.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnTongLuongThang.Click += BtnTongLuongThang_Click;
        }

        // ======================= LOAD DỮ LIỆU =======================
        private void LoadData()
        {
            dgvLuong.DataSource = null;
            dgvLuong.DataSource = _luongService.GetAll().ToList();

            if (dgvLuong.Columns["NhanVien"] != null)
                dgvLuong.Columns["NhanVien"].Visible = false;
        }

        // ======================= LOAD COMBOBOX NHÂN VIÊN =======================
        private void LoadNhanVienCombo()
        {
            using (var context = new AppDbContext())
            {
                var nhanViens = context.NhanViens
                    .Select(nv => new { nv.MaNV, nv.HoTen })
                    .ToList();

                cboNhanVien.DataSource = nhanViens;
                cboNhanVien.DisplayMember = "HoTen";   // Hiển thị tên nhân viên
                cboNhanVien.ValueMember = "MaNV";      // Lấy MaNV khi chọn
                cboNhanVien.SelectedIndex = -1;
            }
        }

        // ======================= LẤY DỮ LIỆU DONG CHỌN =======================
        private BangLuong GetSelectedBangLuong()
        {
            if (dgvLuong.CurrentRow == null) return null;
            return dgvLuong.CurrentRow.DataBoundItem as BangLuong;
        }

        // ======================= CLICK DATAGRIDVIEW =======================
        private void DgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = GetSelectedBangLuong();
            if (item == null) return;

            // Chọn nhân viên trong ComboBox
            cboNhanVien.SelectedValue = item.MaNV;

            txtLuongCoBan.Text = item.LuongCoBan.ToString();
            txtPhuCap.Text = item.PhuCap.ToString();
            txtThuong.Text = item.Thuong.ToString();
            txtKhauTru.Text = item.KhauTru.ToString();
            dtThang.Value = item.ThangTinhLuong;
        }

        // ======================= NÚT THÊM =======================
        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboNhanVien.SelectedValue == null)
                {
                    MessageBox.Show("⚠️ Vui lòng chọn nhân viên!");
                    return;
                }

                string maNV = cboNhanVien.SelectedValue.ToString();

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
                MessageBox.Show("❌ Lỗi thêm bảng lương: " + ex.Message);
            }
        }

        // ======================= NÚT SỬA =======================
        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GetSelectedBangLuong();
                if (selected == null)
                {
                    MessageBox.Show("⚠️ Chọn bảng lương để sửa!");
                    return;
                }

                if (cboNhanVien.SelectedValue == null)
                {
                    MessageBox.Show("⚠️ Vui lòng chọn nhân viên!");
                    return;
                }

                selected.MaNV = cboNhanVien.SelectedValue.ToString();
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
                MessageBox.Show("❌ Lỗi sửa bảng lương: " + ex.Message);
            }
        }

        // ======================= NÚT XÓA =======================
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
                MessageBox.Show("❌ Lỗi xóa bảng lương: " + ex.Message);
            }
        }

        // ======================= TÍNH TỔNG LƯƠNG THÁNG =======================
        private void BtnTongLuongThang_Click(object sender, EventArgs e)
        {
            var thang = dtThang.Value;
            decimal tong = _luongService.TongLuongTheoThang(thang);
            lblTongLuong.Text = $"Tổng lương tháng {thang:MM/yyyy}: {tong:n0} VNĐ";
        }
    }
}
