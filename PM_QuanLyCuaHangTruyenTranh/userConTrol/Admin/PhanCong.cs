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
            _maChiNhanh = maChiNhanh;

            SetupGrid();
            LoadComboBox();
            LoadData();
        }

        // ======================= CẤU HÌNH DATAGRIDVIEW =======================
        private void SetupGrid()
        {
            dgvPhanCong.AutoGenerateColumns = false;
            dgvPhanCong.Columns.Clear();

            dgvPhanCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaPhanCong",
                HeaderText = "Mã Phân Công",
                Visible = false
            });

            dgvPhanCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaNV",
                HeaderText = "Mã NV",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            });

            dgvPhanCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenNhanVien",
                HeaderText = "Tên Nhân Viên",
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
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvPhanCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayKetThuc",
                HeaderText = "Ngày Kết Thúc",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvPhanCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhanCong.MultiSelect = false;
            dgvPhanCong.AllowUserToAddRows = false;

            dgvPhanCong.CellClick -= dgvPhanCong_CellClick;
            dgvPhanCong.CellClick += dgvPhanCong_CellClick;
        }

        // ======================= LOAD DỮ LIỆU PHÂN CÔNG =======================
        private void LoadData()
        {
            try
            {
                var list = _phanCongService.GetAll()
                    .Where(pc => pc.NhanVien.MaChiNhanh == _maChiNhanh)
                    .Select(pc => new
                    {
                        pc.MaPhanCong,
                        pc.MaNV,
                        TenNhanVien = pc.NhanVien?.HoTen ?? "(Chưa có)",
                        pc.TenCongViec,
                        pc.MoTa,
                        pc.NgayBatDau,
                        pc.NgayKetThuc
                    })
                    .ToList();

                dgvPhanCong.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi load dữ liệu: " + ex.Message);
            }
        }

        // ======================= LOAD COMBOBOX =======================
        private void LoadComboBox()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    // Load nhân viên theo chi nhánh
                    var nhanViens = context.NhanViens
                        .Where(nv => nv.MaChiNhanh == _maChiNhanh)
                        .Select(nv => new
                        {
                            nv.MaNV,
                            nv.HoTen
                        })
                        .ToList();

                    cboNhanVien.DataSource = nhanViens;
                    cboNhanVien.DisplayMember = "HoTen";
                    cboNhanVien.ValueMember = "MaNV";
                    cboNhanVien.SelectedIndex = -1;

                    // Load tất cả công việc
                    var congViecs = context.CongViecs
                        .Select(cv => new
                        {
                            cv.MaCongViec,
                            cv.TenCongViec
                        })
                        .ToList();

                    cboCongViec.DataSource = congViecs;
                    cboCongViec.DisplayMember = "TenCongViec";
                    cboCongViec.ValueMember = "MaCongViec";
                    cboCongViec.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi load combobox: " + ex.Message);
            }
        }

        // ======================= LẤY DÒNG ĐANG CHỌN =======================
        private PM.DAL.Models.PhanCong GetSelectedPhanCong()
        {
            var selected = dgvPhanCong.CurrentRow?.DataBoundItem;
            if (selected == null) return null;

            int maPC = (int)selected.GetType().GetProperty("MaPhanCong").GetValue(selected);
            return _phanCongService.GetById(maPC);
        }

        // ======================= CLICK DGV =======================
        private void dgvPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var pc = GetSelectedPhanCong();
            if (pc == null) return;

            cboNhanVien.SelectedValue = pc.MaNV;
            cboCongViec.Text = pc.TenCongViec;
            txtMoTa.Text = pc.MoTa;
            dtpBatDau.Value = pc.NgayBatDau;
            dtpKetThuc.Value = pc.NgayKetThuc ?? DateTime.Now;
        }

        // ======================= NÚT THÊM =======================
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboNhanVien.SelectedValue == null || cboCongViec.SelectedValue == null)
                {
                    MessageBox.Show("⚠️ Vui lòng chọn Nhân viên và Công việc!");
                    return;
                }

                var pc = new PM.DAL.Models.PhanCong
                {
                    MaNV = cboNhanVien.SelectedValue.ToString(),
                    TenCongViec = cboCongViec.Text,
                    MoTa = txtMoTa.Text.Trim(),
                    NgayBatDau = dtpBatDau.Value,
                    NgayKetThuc = dtpKetThuc.Value
                };

                if (_phanCongService.Add(pc))
                {
                    MessageBox.Show("✅ Thêm phân công thành công!");
                    LoadData();
                    ClearInput();
                }
                else
                    MessageBox.Show("❌ Thêm thất bại!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi thêm: " + ex.Message);
            }
        }

        // ======================= NÚT SỬA =======================
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GetSelectedPhanCong();
                if (selected == null)
                {
                    MessageBox.Show("⚠️ Vui lòng chọn một phân công để sửa!");
                    return;
                }

                selected.MaNV = cboNhanVien.SelectedValue?.ToString();
                selected.TenCongViec = cboCongViec.Text;
                selected.MoTa = txtMoTa.Text.Trim();
                selected.NgayBatDau = dtpBatDau.Value;
                selected.NgayKetThuc = dtpKetThuc.Value;

                if (_phanCongService.Update(selected))
                {
                    MessageBox.Show("✅ Cập nhật thành công!");
                    LoadData();
                    ClearInput();
                }
                else
                    MessageBox.Show("❌ Cập nhật thất bại!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi sửa: " + ex.Message);
            }
        }

        // ======================= NÚT XÓA =======================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GetSelectedPhanCong();
                if (selected == null)
                {
                    MessageBox.Show("⚠️ Vui lòng chọn một phân công để xóa!");
                    return;
                }

                if (MessageBox.Show($"Xóa phân công của {selected.TenCongViec}?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_phanCongService.Delete(selected.MaPhanCong))
                    {
                        MessageBox.Show("✅ Xóa thành công!");
                        LoadData();
                        ClearInput();
                    }
                    else
                        MessageBox.Show("❌ Xóa thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi xóa: " + ex.Message);
            }
        }

        // ======================= XÓA TRẮNG INPUT =======================
        private void ClearInput()
        {
            cboCongViec.SelectedIndex = -1;
            txtMoTa.Clear();
            dtpBatDau.Value = DateTime.Now;
            dtpKetThuc.Value = DateTime.Now;
        }
    }
}
