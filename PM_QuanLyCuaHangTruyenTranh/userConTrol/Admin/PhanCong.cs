using PM.BUS.Services.LamViecsv;
using PM.DAL;
using PM.DAL.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Admin
{
    public partial class PhanCong : UserControl
    {
        private readonly PhanCongService _phanCongService;
        private string _maChiNhanh; 

        public PhanCong(string maChiNhanh)
        {
            InitializeComponent();
            _phanCongService = new PhanCongService(new UnitOfWork());
            SetupGrid();
            LoadData();
            _maChiNhanh = maChiNhanh;
        }

        private void SetupGrid()
        {
            dgvPhanCong.AutoGenerateColumns = false;
            dgvPhanCong.Columns.Clear();

            // Ẩn mã phân công (vẫn bind DataPropertyName nhưng không cần Name)
            dgvPhanCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaPhanCong",
                HeaderText = "Mã Phân Công",
                Visible = false
            });

            dgvPhanCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaNV",
                HeaderText = "Mã Nhân Viên",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvPhanCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenCongViec",
                HeaderText = "Tên Công Việc",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvPhanCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MoTa",
                HeaderText = "Mô Tả",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvPhanCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayBatDau",
                HeaderText = "Ngày Bắt Đầu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            });

            dgvPhanCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayKetThuc",
                HeaderText = "Ngày Kết Thúc",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            });

            dgvPhanCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhanCong.MultiSelect = false;
            dgvPhanCong.AllowUserToAddRows = false;

            dgvPhanCong.CellClick -= dgvPhanCong_CellClick; // tránh bind đôi
            dgvPhanCong.CellClick += dgvPhanCong_CellClick;
        }

        private void LoadData()
        {
            try
            {
                // bind trực tiếp danh sách PhanCong (mỗi dòng DataBoundItem là PhanCong)
                dgvPhanCong.DataSource = _phanCongService.GetAll().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        // Lấy đối tượng PhanCong từ hàng đã chọn
        private DAL.Models.PhanCong GetSelectedPhanCong()
        {
            if (dgvPhanCong.CurrentRow == null) return null;
            return dgvPhanCong.CurrentRow.DataBoundItem as DAL.Models.PhanCong;
        }

        private void dgvPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var pc = dgvPhanCong.Rows[e.RowIndex].DataBoundItem as DAL.Models.PhanCong;
            if (pc == null) return;

            // Đổ dữ liệu lên control
            txtMaNV.Text = pc.MaNV;
            txtTenCV.Text = pc.TenCongViec;
            txtMoTa.Text = pc.MoTa;
            dtpBatDau.Value = pc.NgayBatDau;
            dtpKetThuc.Value = pc.NgayKetThuc ?? DateTime.Now;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var pc = new DAL.Models.PhanCong
                {
                    MaNV = txtMaNV.Text.Trim(),
                    TenCongViec = txtTenCV.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim(),
                    NgayBatDau = dtpBatDau.Value,
                    NgayKetThuc = dtpKetThuc.Value
                };

                var ok = _phanCongService.Add(pc);
                if (ok)
                {
                    MessageBox.Show("✅ Thêm thành công!");
                    LoadData();
                }
                else MessageBox.Show("❌ Thêm thất bại (service trả về false).");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GetSelectedPhanCong();
                if (selected == null)
                {
                    MessageBox.Show("Vui lòng chọn phân công để sửa.");
                    return;
                }

                // Lấy lại bản ghi thực từ DB (đảm bảo context đúng)
                var pc = _phanCongService.GetById(selected.MaPhanCong);
                if (pc == null)
                {
                    MessageBox.Show("Không tìm thấy bản ghi trong DB.");
                    return;
                }

                pc.MaNV = txtMaNV.Text.Trim();
                pc.TenCongViec = txtTenCV.Text.Trim();
                pc.MoTa = txtMoTa.Text.Trim();
                pc.NgayBatDau = dtpBatDau.Value;
                pc.NgayKetThuc = dtpKetThuc.Value;

                var ok = _phanCongService.Update(pc);
                if (ok)
                {
                    MessageBox.Show("✅ Cập nhật thành công!");
                    LoadData();
                }
                else MessageBox.Show("❌ Cập nhật thất bại (service trả về false).");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GetSelectedPhanCong();
                if (selected == null)
                {
                    MessageBox.Show("Vui lòng chọn phân công để xóa.");
                    return;
                }

                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa phân công (ID={selected.MaPhanCong})?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm != DialogResult.Yes) return;

                var ok = _phanCongService.Delete(selected.MaPhanCong);
                if (ok)
                {
                    MessageBox.Show("✅ Xóa thành công!");
                    LoadData();
                }
                else MessageBox.Show("❌ Xóa thất bại (service trả về false).");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        private void panel_tmp_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}