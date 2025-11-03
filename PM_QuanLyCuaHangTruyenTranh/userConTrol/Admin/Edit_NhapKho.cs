using Guna.UI2.WinForms;
using PM.BUS.Helpers;
using PM.BUS.Services.Sachsv;
using PM.BUS.Services.VanChuyensv;
using PM.DAL.Models;
using PM.GUI.FormThongBao;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Admin
{
    public partial class Edit_NhapKho : UserControl
    {
        private NhapKhoService _nhapKhoService;
        private CT_NhapKhoService _ctNhapKhoService;
        private SachService _sachService;
        private KhoService _khoService;

        // controls chính
        private Guna2DataGridView dgvNhapKho;
        private Guna2DataGridView dgvCTNhap;
        private Guna2ComboBox cboKho;
        private Guna2TextBox txtSearch;
        private Guna2Button btnAdd, btnEdit, btnDelete, btnRefresh, btnToggleMode;
        private Guna2Panel pnlForm;
        private Guna2TextBox txtMaPhieu, txtGhiChu;
        private Guna2DateTimePicker dtpNgayNhap;
        private Guna2ComboBox cboSach;
        private Guna2NumericUpDown numSoLuong;
        private Guna2TextBox txtDonGia;
        private Guna2Button btnSave, btnCancel;
        private FlowLayoutPanel pnlTop;

        private bool _isAnimating = false;
        private bool _isDetailMode = false; // false = quản lý phiếu, true = quản lý chi tiết
        private NhapKho _currentPhieu = null; // phiếu đang chọn khi ở chế độ chi tiết
        private CT_NhapKho _currentDetail = null; // chi tiết đang chọn để sửa
        private readonly string chu;
        public Edit_NhapKho(string manv)
        {
            if (!DesignMode)
            {
                InitializeComponent();

                _nhapKhoService = new NhapKhoService();
                _ctNhapKhoService = new CT_NhapKhoService();
                _sachService = new SachService();
                _khoService = new KhoService();
                chu = manv;

                BuildUI();
                _ = LoadAllAsync();
                _ = AnimateTopPanelAsync();
            }
        }

        // === Dựng giao diện chính ===
        private void BuildUI()
        {
            guna2Panel1.Controls.Clear();

            // SEARCH
            txtSearch = new Guna2TextBox
            {
                PlaceholderText = "Tìm kiếm...",
                BorderRadius = 8,
                Width = 300,
                Margin = new Padding(10)
            };
            txtSearch.TextChanged += (s, e) => SearchData();

            // Buttons CRUD
            btnAdd = CreateButton("Thêm phiếu", Add_Click);
            btnEdit = CreateButton("Sửa phiếu", Edit_Click);
            btnDelete = CreateButton("Xóa phiếu", Delete_Click);
            btnRefresh = CreateButton("Làm mới", async (s, e) => await LoadAllAsync());
            btnToggleMode = CreateButton("→ Quản lý chi tiết", ToggleMode_Click);
            btnToggleMode.FillColor = Color.FromArgb(94, 148, 255);

            // Top panel
            pnlTop = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 56,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10, 8, 10, 8)
            };

            pnlTop.Controls.AddRange(new Control[] { txtSearch, btnAdd, btnEdit, btnDelete, btnRefresh, btnToggleMode });

            // DataGridView danh sách phiếu
            dgvNhapKho = new Guna2DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Margin = new Padding(0, 5, 0, 0)
            };
            dgvNhapKho.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã phiếu", DataPropertyName = "MaPhieuNhap", Width = 120 });
            dgvNhapKho.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày nhập", DataPropertyName = "NgayNhap", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvNhapKho.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên kho", DataPropertyName = "TenKho", Width = 250 });
            dgvNhapKho.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "NV", DataPropertyName = "MaNV", Width = 80 });
            dgvNhapKho.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ghi chú", DataPropertyName = "GhiChu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            dgvNhapKho.SelectionChanged += DgvNhapKho_SelectionChanged;

            // DataGridView chi tiết nhập
            dgvCTNhap = new Guna2DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Margin = new Padding(0, 5, 0, 0),
                Visible = false
            };
            dgvCTNhap.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã sách", DataPropertyName = "MaSach", Width = 100 });
            dgvCTNhap.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên sách", DataPropertyName = "TenSach", Width = 300 });
            dgvCTNhap.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số lượng", DataPropertyName = "SoLuong", Width = 100 });
            dgvCTNhap.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đơn giá", DataPropertyName = "DonGia", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });

            dgvCTNhap.SelectionChanged += DgvCTNhap_SelectionChanged;

            guna2Panel1.Controls.Add(dgvCTNhap);
            guna2Panel1.Controls.Add(dgvNhapKho);
            guna2Panel1.Controls.Add(pnlTop);
        }

        private Guna2Button CreateButton(string text, EventHandler click)
        {
            var btn = new Guna2Button
            {
                Text = text,
                BorderRadius = 8,
                Height = 36,
                Margin = new Padding(6),
                AutoSize = false
            };
            btn.Click += click;
            return btn;
        }

        // === Load dữ liệu ban đầu ===
        private async Task LoadAllAsync()
        {
            var listPhieu = await _nhapKhoService.GetAllAsync();
            
            // Map TenKho từ navigation property
            var phieuList = listPhieu.Select(p => new
            {
                p.MaPhieuNhap,
                p.NgayNhap,
                p.MaKho,
                TenKho = p.Kho?.TenKho ?? "",
                p.MaNV,
                p.GhiChu
            }).ToList();

            dgvNhapKho.DataSource = phieuList;
            dgvCTNhap.DataSource = null;
        }

        private void SearchData()
        {
            string kw = txtSearch.Text.Trim().ToLower();

            if (_isDetailMode)
            {
                // Tìm trong chi tiết
                if (_currentPhieu == null) return;
                
                var filtered = _ctNhapKhoService.GetAll()
                    .Where(c => c.MaPhieuNhap == _currentPhieu.MaPhieuNhap)
                    .Where(c => (c.MaSach ?? "").ToLower().Contains(kw)
                             || (c.Sach?.TenSach ?? "").ToLower().Contains(kw))
                    .Select(c => new
                    {
                        c.MaPhieuNhap,
                        c.MaSach,
                        TenSach = c.Sach?.TenSach ?? "",
                        c.SoLuong,
                        c.DonGia
                    })
                    .ToList();
                dgvCTNhap.DataSource = filtered;
            }
            else
            {
                // Tìm trong phiếu
                var filtered = _nhapKhoService.GetAll()
                    .Where(n => (n.MaPhieuNhap ?? "").ToLower().Contains(kw)
                             || (n.MaKho ?? "").ToLower().Contains(kw)
                             || (n.Kho?.TenKho ?? "").ToLower().Contains(kw)
                             || (n.GhiChu ?? "").ToLower().Contains(kw))
                    .Select(p => new
                    {
                        p.MaPhieuNhap,
                        p.NgayNhap,
                        p.MaKho,
                        TenKho = p.Kho?.TenKho ?? "",
                        p.MaNV,
                        p.GhiChu
                    })
                    .ToList();
                dgvNhapKho.DataSource = filtered;
            }
        }

        // === Khi chọn phiếu ===
        private void DgvNhapKho_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhapKho.SelectedRows.Count == 0) return;

            var row = dgvNhapKho.SelectedRows[0];
                string maPhieu = row.Cells[0].Value?.ToString();
                if (string.IsNullOrEmpty(maPhieu)) return;

            _currentPhieu = _nhapKhoService.GetById(maPhieu);
        }

        // === Khi chọn chi tiết ===
        private void DgvCTNhap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCTNhap.SelectedRows.Count == 0)
            {
                _currentDetail = null;
                return;
            }

            var row = dgvCTNhap.SelectedRows[0];
            string maPhieu = row.Cells[0].Value?.ToString();
            string maSach = row.Cells[0].Value?.ToString();
            
            if (!string.IsNullOrEmpty(maPhieu) && !string.IsNullOrEmpty(maSach))
            {
                _currentDetail = _ctNhapKhoService.GetById(maPhieu, maSach);
            }
        }

        // === Toggle giữa 2 chế độ ===
        private void ToggleMode_Click(object sender, EventArgs e)
        {
            _isDetailMode = !_isDetailMode;

            if (_isDetailMode)
            {
                // Chuyển sang chế độ quản lý chi tiết
                if (_currentPhieu == null)
                {
                    ShowMessage("Vui lòng chọn phiếu nhập trước!");
                    _isDetailMode = false;
                    return;
                }

                // Load chi tiết của phiếu đang chọn
                var ctList = _ctNhapKhoService.GetAll()
                    .Where(c => c.MaPhieuNhap == _currentPhieu.MaPhieuNhap)
                    .Select(c => new
                    {
                        c.MaPhieuNhap,
                        c.MaSach,
                        TenSach = c.Sach?.TenSach ?? "",
                        c.SoLuong,
                        c.DonGia
                    })
                    .ToList();
                dgvCTNhap.DataSource = ctList;

                // Đổi UI
                btnToggleMode.Text = "← Quay về phiếu";
                btnToggleMode.FillColor = Color.FromArgb(255, 128, 0);
                btnAdd.Text = "Thêm chi tiết";
                btnEdit.Text = "Sửa chi tiết";
                btnDelete.Text = "Xóa chi tiết";
                txtSearch.PlaceholderText = $"Tìm trong phiếu {_currentPhieu.MaPhieuNhap}...";

                dgvNhapKho.Visible = false;
                dgvCTNhap.Visible = true;
            }
            else
            {
                // Quay về chế độ quản lý phiếu
                btnToggleMode.Text = "→ Quản lý chi tiết";
                btnToggleMode.FillColor = Color.FromArgb(94, 148, 255);
                btnAdd.Text = "Thêm phiếu";
                btnEdit.Text = "Sửa phiếu";
                btnDelete.Text = "Xóa phiếu";
                txtSearch.PlaceholderText = "Tìm kiếm...";

                dgvCTNhap.Visible = false;
                dgvNhapKho.Visible = true;

                _ = LoadAllAsync();
            }
        }

        // === CRUD ===
        private void Add_Click(object sender, EventArgs e)
        {
            if (_isDetailMode)
            {
                ShowDetailForm("Thêm chi tiết", null);
            }
            else
            {
                ShowPhieuForm("Thêm phiếu nhập", null);
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (_isDetailMode)
            {
                if (_currentDetail == null)
                {
                    ShowMessage("Vui lòng chọn chi tiết để sửa!");
                    return;
                }
                ShowDetailForm("Sửa chi tiết", _currentDetail);
            }
            else
            {
                if (_currentPhieu == null)
                {
                    ShowMessage("Vui lòng chọn phiếu để sửa!");
                    return;
                }
                ShowPhieuForm("Sửa phiếu nhập", _currentPhieu);
            }
        }

        private async void Delete_Click(object sender, EventArgs e)
        {
            if (_isDetailMode)
            {
                // Xóa chi tiết
                if (_currentDetail == null)
                {
                    ShowMessage("Vui lòng chọn chi tiết để xóa!");
                    return;
                }

                if (MessageBox.Show($"Xóa chi tiết sách '{_currentDetail.MaSach}'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var success = await _ctNhapKhoService.DeleteAsync(_currentDetail.MaPhieuNhap, _currentDetail.MaSach);
                    if (success)
                    {
                        ShowMessage("Đã xóa chi tiết!");
                        // Reload chi tiết
                        var ctList = _ctNhapKhoService.GetAll()
                            .Where(c => c.MaPhieuNhap == _currentPhieu.MaPhieuNhap)
                            .Select(c => new
                            {
                                c.MaPhieuNhap,
                                c.MaSach,
                                TenSach = c.Sach?.TenSach ?? "",
                                c.SoLuong,
                                c.DonGia
                            })
                            .ToList();
                        dgvCTNhap.DataSource = ctList;
                    }
                }
            }
            else
            {
                // Xóa phiếu
                if (_currentPhieu == null)
                {
                    ShowMessage("Vui lòng chọn phiếu để xóa!");
                    return;
                }

                if (MessageBox.Show($"Xóa phiếu '{_currentPhieu.MaPhieuNhap}'? (Toàn bộ chi tiết sẽ bị xóa)", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await _ctNhapKhoService.DeleteByMaPhieuNhapAsync(_currentPhieu.MaPhieuNhap);
                    await _nhapKhoService.DeleteAsync(_currentPhieu.MaPhieuNhap);
                    await LoadAllAsync();
                    ShowMessage("Đã xóa phiếu!");
                }
            }
        }

        // === Form phiếu (panel phải) ===
        private async void ShowPhieuForm(string title, NhapKho phieu)
        {
            if (pnlForm != null && guna2Panel1.Controls.Contains(pnlForm))
            {
                await AnimatePanel(pnlForm, false);
            }

            bool isEdit = phieu != null;

            pnlForm = new Guna2Panel
            {
                Width = 0,
                Height = guna2Panel1.Height,
                BorderRadius = 12,
                BorderThickness = 1,
                BorderColor = Color.Gray,
                BackColor = Color.White,
                Dock = DockStyle.Right,
                Padding = new Padding(20),
                Visible = true
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(64, 64, 64)
            };

            txtMaPhieu = new Guna2TextBox
            {
                PlaceholderText = "Mã phiếu",
                Text = phieu?.MaPhieuNhap ?? RandHelper.TaoMa("PN"),
                ReadOnly = true,
                Width = 360,
                BorderRadius = 8,
                Margin = new Padding(0, 10, 0, 0)
            };

            dtpNgayNhap = new Guna2DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Value = phieu?.NgayNhap ?? DateTime.Now,
                Width = 360,
                BorderRadius = 8,
                Margin = new Padding(0, 10, 0, 0)
            };

            cboKho = new Guna2ComboBox
            {
                Width = 360,
                BorderRadius = 8,
                Margin = new Padding(0, 10, 0, 0),
                Enabled = !isEdit // Chỉ cho chọn kho khi thêm mới
            };

            var khoList = await _khoService.GetAllAsync();
            cboKho.DataSource = khoList.ToList();
            cboKho.DisplayMember = "TenKho";
            cboKho.ValueMember = "MaKho";
            if (phieu != null)
            {
                cboKho.SelectedValue = phieu.MaKho;
            }

            txtGhiChu = new Guna2TextBox
            {
                PlaceholderText = "Ghi chú",
                Text = phieu?.GhiChu,
                Multiline = true,
                Height = 80,
                Width = 360,
                BorderRadius = 8,
                Margin = new Padding(0, 10, 0, 0)
            };

            var pnlButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(40, 10, 40, 0)
            };

            btnSave = new Guna2Button
            {
                Text = "Lưu",
                Width = 130,
                Height = 40,
                BorderRadius = 8,
                FillColor = Color.FromArgb(94, 148, 255)
            };
            btnSave.Click += async (s, e) => await SavePhieu(phieu);

            btnCancel = new Guna2Button
            {
                Text = "Hủy",
                Width = 130,
                Height = 40,
                BorderRadius = 8,
                FillColor = Color.FromArgb(200, 200, 200),
                Margin = new Padding(20, 0, 0, 0)
            };
            btnCancel.Click += async (s, e) => await AnimatePanel(pnlForm, false);

            pnlButtons.Controls.AddRange(new Control[] { btnSave, btnCancel });

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                Padding = new Padding(10)
            };

            flow.Controls.Add(lblTitle);
            flow.Controls.Add(new Label { Text = "Mã phiếu:", AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold), Margin = new Padding(0, 10, 0, 2) });
            flow.Controls.Add(txtMaPhieu);
            flow.Controls.Add(new Label { Text = "Ngày nhập:", AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold), Margin = new Padding(0, 10, 0, 2) });
            flow.Controls.Add(dtpNgayNhap);
            flow.Controls.Add(new Label { Text = "Kho:" + (isEdit ? " (Không thể thay đổi)" : ""), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold), Margin = new Padding(0, 10, 0, 2) });
            flow.Controls.Add(cboKho);
            flow.Controls.Add(new Label { Text = "Ghi chú:", AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold), Margin = new Padding(0, 10, 0, 2) });
            flow.Controls.Add(txtGhiChu);

            pnlForm.Controls.Add(pnlButtons);
            pnlForm.Controls.Add(flow);
            guna2Panel1.Controls.Add(pnlForm);
            pnlForm.BringToFront();

            await AnimatePanel(pnlForm, true);
        }

        // === Form chi tiết (panel trái) ===
        private async void ShowDetailForm(string title, CT_NhapKho detail)
        {
            if (_currentPhieu == null)
            {
                ShowMessage("Không có phiếu nào được chọn!");
                return;
            }

            if (pnlForm != null && guna2Panel1.Controls.Contains(pnlForm))
            {
                await AnimatePanel(pnlForm, false);
            }

            bool isEdit = detail != null;

            pnlForm = new Guna2Panel
            {
                Width = 0,
                Height = guna2Panel1.Height,
                BorderRadius = 12,
                BorderThickness = 1,
                BorderColor = Color.Gray,
                BackColor = Color.White,
                Dock = DockStyle.Left, // MỞ TỪ TRÁI
                Padding = new Padding(20),
                Visible = true
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(64, 64, 64)
            };

            var lblPhieu = new Label
            {
                Text = $"Phiếu: {_currentPhieu.MaPhieuNhap}",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Height = 30,
                Width = 360,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(240, 248, 255),
                ForeColor = Color.FromArgb(94, 148, 255),
                Margin = new Padding(0, 10, 0, 10)
            };

            cboSach = new Guna2ComboBox
            {
                Width = 360,
                BorderRadius = 8,
                Margin = new Padding(0, 10, 0, 0),
                Enabled = !isEdit // Không cho đổi sách khi sửa
            };

            var sachList = await _sachService.GetAllAsync();
            cboSach.DataSource = sachList.ToList();
            cboSach.DisplayMember = "TenSach";
            cboSach.ValueMember = "MaSach";

            if (detail != null)
            {
                cboSach.SelectedValue = detail.MaSach;
            }

            numSoLuong = new Guna2NumericUpDown
            {
                Minimum = 1,
                Maximum = 1000000,
                Value = detail?.SoLuong ?? 1,
                Width = 360,
                BorderRadius = 8,
                Margin = new Padding(0, 10, 0, 0)
            };

            txtDonGia = new Guna2TextBox
            {
                PlaceholderText = "Đơn giá (VNĐ)",
                Text = detail?.DonGia.ToString() ?? "",
                Width = 360,
                BorderRadius = 8,
                Margin = new Padding(0, 10, 0, 0)
            };

            var pnlButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(40, 10, 40, 0)
            };

            btnSave = new Guna2Button
            {
                Text = "Lưu",
                Width = 130,
                Height = 40,
                BorderRadius = 8,
                FillColor = Color.FromArgb(94, 148, 255)
            };
            btnSave.Click += async (s, e) => await SaveDetail(detail);

            btnCancel = new Guna2Button
            {
                Text = "Hủy",
                Width = 130,
                Height = 40,
                BorderRadius = 8,
                FillColor = Color.FromArgb(200, 200, 200),
                Margin = new Padding(20, 0, 0, 0)
            };
            btnCancel.Click += async (s, e) => await AnimatePanel(pnlForm, false);

            pnlButtons.Controls.AddRange(new Control[] { btnSave, btnCancel });

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                Padding = new Padding(10)
            };

            flow.Controls.Add(lblTitle);
            flow.Controls.Add(lblPhieu);
            flow.Controls.Add(new Label { Text = "Sách:" + (isEdit ? " (Không thể thay đổi)" : ""), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold), Margin = new Padding(0, 10, 0, 2) });
            flow.Controls.Add(cboSach);
            flow.Controls.Add(new Label { Text = "Số lượng:", AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold), Margin = new Padding(0, 10, 0, 2) });
            flow.Controls.Add(numSoLuong);
            flow.Controls.Add(new Label { Text = "Đơn giá:", AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold), Margin = new Padding(0, 10, 0, 2) });
            flow.Controls.Add(txtDonGia);

            pnlForm.Controls.Add(pnlButtons);
            pnlForm.Controls.Add(flow);
            guna2Panel1.Controls.Add(pnlForm);
            pnlForm.BringToFront();

            await AnimatePanel(pnlForm, true);
        }

        // === Lưu phiếu ===
        private async Task SavePhieu(NhapKho phieu)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieu.Text) || cboKho.SelectedValue == null)
            {
                ShowMessage("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            bool success;
            if (phieu == null)
            {
                // Thêm mới
                var newPhieu = new NhapKho
                {
                    MaPhieuNhap = txtMaPhieu.Text.Trim(),
                    MaNV=chu,
                    NgayNhap = dtpNgayNhap.Value,
                    MaKho = cboKho.SelectedValue.ToString(),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                success = await _nhapKhoService.AddAsync(newPhieu);
            }
            else
            {
                // Chỉ sửa ngày nhập và ghi chú (không đổi kho)
                phieu.NgayNhap = dtpNgayNhap.Value;
                phieu.GhiChu = txtGhiChu.Text.Trim();
                success = await _nhapKhoService.UpdateAsync(phieu);
            }

            if (success)
            {
                ShowMessage("Lưu phiếu thành công!");
                await AnimatePanel(pnlForm, false);
                await LoadAllAsync();
            }
            else
            {
                ShowMessage("Có lỗi khi lưu phiếu!");
            }
        }

        // === Lưu chi tiết ===
        private async Task SaveDetail(CT_NhapKho detail)
        {
            if (cboSach.SelectedValue == null)
            {
                ShowMessage("Vui lòng chọn sách!");
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia) || donGia <= 0)
            {
                ShowMessage("Đơn giá không hợp lệ!");
                return;
            }

            bool success;
            if (detail == null)
            {
                // Thêm mới
                var newCT = new CT_NhapKho
                {
                    MaPhieuNhap = _currentPhieu.MaPhieuNhap,
                    MaSach = cboSach.SelectedValue.ToString(),
                    SoLuong = (int)numSoLuong.Value,
                    DonGia = donGia
                };

                success = await _ctNhapKhoService.AddAsync(newCT);
            }
            else
            {
                // Sửa (chỉ số lượng và đơn giá)
                detail.SoLuong = (int)numSoLuong.Value;
                detail.DonGia = donGia;
                success = await _ctNhapKhoService.UpdateAsync(detail);
            }

            if (success)
            {
                ShowMessage(detail == null ? "Đã thêm chi tiết!" : "Đã cập nhật chi tiết!");
                await AnimatePanel(pnlForm, false);
                
                // Reload chi tiết
                var ctList = _ctNhapKhoService.GetAll()
                    .Where(c => c.MaPhieuNhap == _currentPhieu.MaPhieuNhap)
                    .Select(c => new
                    {
                        c.MaPhieuNhap,
                        c.MaSach,
                        TenSach = c.Sach?.TenSach ?? "",
                        c.SoLuong,
                        c.DonGia
                    })
                    .ToList();
                dgvCTNhap.DataSource = ctList;
            }
            else
            {
                ShowMessage("Có lỗi khi lưu chi tiết!");
            }
        }

        // === Hiệu ứng slide panel ===
        private async Task AnimatePanel(Guna2Panel panel, bool show)
        {
            if (_isAnimating) return;
            _isAnimating = true;

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = btnToggleMode.Enabled = false;

            int targetWidth = 420;
            int frameRate = 120;
            int totalDuration = show ? 220 : 160;
            int frameDelay = 1000 / frameRate;
            int steps = Math.Max(1, totalDuration / frameDelay);

            panel.GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(panel, true, null);

            panel.SuspendLayout();

            if (show)
            {
                panel.Visible = true;
                panel.Width = 0;
                panel.BackColor = Color.FromArgb(0, 255, 255, 255);

                for (int i = 0; i <= steps; i++)
                {
                    double t = (double)i / steps;
                    double eased = 1 - Math.Pow(1 - t, 3);
                    panel.Width = (int)(targetWidth * eased);
                    int opacity = (int)(255 * eased);
                    panel.BackColor = Color.FromArgb(opacity, 255, 255, 255);
                    await Task.Delay(frameDelay);
                }

                panel.Width = targetWidth;
                panel.BackColor = Color.White;
            }
            else
            {
                panel.Visible = true;

                for (int i = steps; i >= 0; i--)
                {
                    double t = (double)i / steps;
                    double eased = t * t * t;
                    panel.Width = (int)(targetWidth * eased);
                    int opacity = (int)(255 * eased);
                    panel.BackColor = Color.FromArgb(opacity, 255, 255, 255);
                    await Task.Delay(frameDelay);
                }

                panel.Width = 0;
                panel.Visible = false;

                if (panel.Parent != null)
                    panel.Parent.Controls.Remove(panel);

                pnlForm = null;
            }

            panel.ResumeLayout();

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = btnToggleMode.Enabled = true;

            _isAnimating = false;
        }

        private async Task AnimateTopPanelAsync()
        {
            pnlTop.Top = -pnlTop.Height;
            await Task.Delay(80);
            for (int i = -pnlTop.Height; i < 0; i += 6)
            {
                pnlTop.Top = i;
                await Task.Delay(6);
            }
            pnlTop.Top = 0;
        }

        // === Hiển thị FormMessage ===
        private void ShowMessage(string text)
        {
            var fm = new FormMessage(text);
            fm.StartPosition = FormStartPosition.CenterScreen;
            fm.Show();
        }
    }
}