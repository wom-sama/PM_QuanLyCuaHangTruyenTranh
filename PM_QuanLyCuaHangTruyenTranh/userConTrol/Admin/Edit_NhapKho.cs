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
        private Guna2Button btnAdd, btnEdit, btnDelete, btnRefresh, btnAddDetail;
        private Guna2Panel pnlForm;
        private Guna2TextBox txtMaPhieu, txtGhiChu;
        private Guna2DateTimePicker dtpNgayNhap;
        private Guna2ComboBox cboNhanVien; // optional: giả sử có list NV
        private Guna2ComboBox cboSach;
        private Guna2NumericUpDown numSoLuong;
        private Guna2TextBox txtDonGia;
        private Guna2Button btnSave, btnCancel;
        private FlowLayoutPanel pnlTop;

        private bool _isAnimating = false;

        public Edit_NhapKho()
        {
            if (!DesignMode)
            {
                InitializeComponent();

                // khởi tạo service (đổi theo DI/ cách bạn dùng)
                _nhapKhoService = new NhapKhoService();
                _ctNhapKhoService = new CT_NhapKhoService();
                _sachService = new SachService();
                _khoService = new KhoService();

                BuildUI();
                _ = LoadAllAsync();
                _ = AnimateTopPanelAsync();
            }
        }

        // === Dựng giao diện chính ===
        private void BuildUI()
        {
            // xóa nội dung panel chính từ designer nếu cần
            guna2Panel1.Controls.Clear();

            // SEARCH
            txtSearch = new Guna2TextBox
            {
                PlaceholderText = "Tìm kiếm phiếu / mã / kho ...",
                BorderRadius = 8,
                Width = 300,
                Margin = new Padding(10)
            };
            txtSearch.TextChanged += (s, e) => SearchNhapKho();

            // Buttons CRUD
            btnAdd = CreateButton("Thêm phiếu", Add_Click);
            btnEdit = CreateButton("Sửa phiếu", Edit_Click);
            btnDelete = CreateButton("Xóa phiếu", Delete_Click);
            btnRefresh = CreateButton("Làm mới", async (s, e) => await LoadAllAsync());
            btnAddDetail = CreateButton("Thêm chi tiết", AddDetail_Click);

            // Top panel
            pnlTop = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 56,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10, 8, 10, 8)
            };
            pnlTop.Controls.AddRange(new Control[] { txtSearch, btnAdd, btnEdit, btnDelete, btnRefresh, btnAddDetail });

            // DataGridView danh sách phiếu
            dgvNhapKho = new Guna2DataGridView
            {
                Dock = DockStyle.Left,
                Width = 520,
                AutoGenerateColumns = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Margin = new Padding(0, 5, 0, 0)
            };
            dgvNhapKho.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã phiếu", DataPropertyName = "MaPhieuNhap", Width = 100 });
            dgvNhapKho.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày nhập", DataPropertyName = "NgayNhap", Width = 110 });
            dgvNhapKho.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Kho", DataPropertyName = "TenKho", Width = 140 });
            dgvNhapKho.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "NV", DataPropertyName = "MaNV", Width = 80 });
            dgvNhapKho.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ghi chú", DataPropertyName = "GhiChu", Width = 200 });

            dgvNhapKho.SelectionChanged += DgvNhapKho_SelectionChanged;

            // DataGridView chi tiết nhập (sách trong phiếu)
            dgvCTNhap = new Guna2DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Margin = new Padding(10, 5, 0, 0)
            };
            dgvCTNhap.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã sách", DataPropertyName = "MaSach" });
            dgvCTNhap.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên sách", DataPropertyName = "TenSach", Width = 220 });
            dgvCTNhap.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số lượng", DataPropertyName = "SoLuong" });
            dgvCTNhap.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đơn giá", DataPropertyName = "DonGia" });

            // Add controls vào panel chính
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
                Margin = new Padding(6)
            };
            btn.Click += click;
            return btn;
        }

        // === Load dữ liệu ban đầu ===
        private async Task LoadAllAsync()
        {
            var listPhieu = await _nhapKhoService.GetAllAsync();
            var listCT = await _ctNhapKhoService.GetAllAsync();

            // nếu model NhapKho không có TenKho, bạn có thể map manually trong service hoặc ở đây
            dgvNhapKho.DataSource = listPhieu.ToList();

            dgvCTNhap.DataSource = null; // chưa chọn phiếu
        }

        private void SearchNhapKho()
        {
            string kw = txtSearch.Text.Trim().ToLower();
            var filtered = _nhapKhoService.GetAll()
                .Where(n => (n.MaPhieuNhap ?? "").ToLower().Contains(kw)
                         || (n.MaKho ?? "").ToLower().Contains(kw)
                         || (n.GhiChu ?? "").ToLower().Contains(kw))
                .ToList();
            dgvNhapKho.DataSource = filtered;
        }

        // === Khi chọn phiếu, load chi tiết ===
        private void DgvNhapKho_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhapKho.SelectedRows.Count == 0)
            {
                dgvCTNhap.DataSource = null;
                return;
            }

            var phieu = (NhapKho)dgvNhapKho.SelectedRows[0].DataBoundItem;
            if (phieu == null) return;

            var ctList = _ctNhapKhoService.GetAll()
                .Where(c => c.MaPhieuNhap == phieu.MaPhieuNhap)
                .ToList();
            dgvCTNhap.DataSource = ctList;
        }

        // === CRUD phiếu ===
        private void Add_Click(object sender, EventArgs e) => ShowForm("Thêm phiếu nhập");
        private void Edit_Click(object sender, EventArgs e)
        {
            if (dgvNhapKho.SelectedRows.Count == 0) { ShowMessage("Vui lòng chọn phiếu để sửa"); return; }
            var phieu = (NhapKho)dgvNhapKho.SelectedRows[0].DataBoundItem;
            ShowForm("Sửa phiếu nhập", phieu);
        }

        private async void Delete_Click(object sender, EventArgs e)
        {
            if (dgvNhapKho.SelectedRows.Count == 0) { ShowMessage("Vui lòng chọn phiếu để xóa"); return; }
            var phieu = (NhapKho)dgvNhapKho.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Bạn có chắc muốn xóa phiếu \"{phieu.MaPhieuNhap}\"? (Toàn bộ chi tiết sẽ bị xóa)", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _ctNhapKhoService.DeleteByMaPhieuNhapAsync(phieu.MaPhieuNhap);
                await _nhapKhoService.DeleteAsync(phieu.MaPhieuNhap);
                await LoadAllAsync();
                ShowMessage("Đã xóa phiếu nhập.");
            }
        }

        // === Thêm chi tiết (thêm sách vào phiếu đang chọn hoặc mở form tạo phiếu mới) ===
        private void AddDetail_Click(object sender, EventArgs e)
        {
            if (dgvNhapKho.SelectedRows.Count == 0)
            {
                ShowMessage("Vui lòng chọn phiếu nhập trước khi thêm chi tiết (hoặc tạo phiếu mới).");
                return;
            }

            var phieu = (NhapKho)dgvNhapKho.SelectedRows[0].DataBoundItem;
            ShowDetailForm("Thêm chi tiết - " + phieu.MaPhieuNhap, phieu);
        }

        // === ShowForm cho Thêm / Sửa phiếu (header) ===
        private async void ShowForm(string title, NhapKho phieu = null)
        {
            if (pnlForm != null && guna2Panel1.Controls.Contains(pnlForm))
            {
                await AnimatePanel(pnlForm, false);
            }

            pnlForm = new Guna2Panel
            {
                Size = new Size(0, guna2Panel1.Height),
                BorderRadius = 12,
                BorderThickness = 1,
                BorderColor = Color.Gray,
                BackColor = Color.White,
                Dock = DockStyle.Right,
                Padding = new Padding(12),
                Visible = true,
                ShadowDecoration = { Enabled = true, Depth = 8, Color = Color.FromArgb(60, 0, 0, 0) }
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 36,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Controls nhập phiếu
            txtMaPhieu = new Guna2TextBox { PlaceholderText = "Mã phiếu", Text = phieu?.MaPhieuNhap ?? RandHelper.TaoMa("PN"), ReadOnly = true };
            dtpNgayNhap = new Guna2DateTimePicker { Format = DateTimePickerFormat.Short, Value = phieu?.NgayNhap ?? DateTime.Now };
            var tmp = new Guna2ComboBox();
            tmp.AutoCompleteSource = AutoCompleteSource.ListItems;
            tmp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboKho = tmp;
            txtGhiChu = new Guna2TextBox { PlaceholderText = "Ghi chú", Text = phieu?.GhiChu, Multiline = true, Height = 60 };

            // load danh sách kho
            var khoList = await _khoService.GetAllAsync();
            cboKho.DataSource = khoList.ToList();
            cboKho.DisplayMember = "TenKho";
            cboKho.ValueMember = "MaKho";
            if (phieu != null)
            {
                cboKho.SelectedValue = phieu.MaKho;
            }

            // nút lưu / hủy
            btnSave = CreateButton("Lưu", async (s, e) => await SavePhieu_Click(phieu));
            btnCancel = CreateButton("Hủy", async (s, e) => await AnimatePanel(pnlForm, false));

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(5)
            };
            flow.Controls.AddRange(new Control[] { lblTitle, txtMaPhieu, dtpNgayNhap, cboKho, txtGhiChu, btnSave, btnCancel });

            pnlForm.Controls.Add(flow);
            guna2Panel1.Controls.Add(pnlForm);
            pnlForm.BringToFront();

            await AnimatePanel(pnlForm, true);
        }

        // === ShowForm thêm chi tiết (sách vào phiếu) ===
        private async void ShowDetailForm(string title, NhapKho phieu)
        {
            if (phieu == null) return;

            if (pnlForm != null && guna2Panel1.Controls.Contains(pnlForm))
            {
                await AnimatePanel(pnlForm, false);
            }

            pnlForm = new Guna2Panel
            {
                Size = new Size(0, guna2Panel1.Height),
                BorderRadius = 12,
                BorderThickness = 1,
                BorderColor = Color.Gray,
                BackColor = Color.White,
                Dock = DockStyle.Right,
                Padding = new Padding(12),
                Visible = true,
                ShadowDecoration = { Enabled = true, Depth = 8, Color = Color.FromArgb(60, 0, 0, 0) }
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 36,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Controls nhập chi tiết
            cboSach = new Guna2ComboBox { Width = 320, DropDownStyle = ComboBoxStyle.DropDownList };
            numSoLuong = new Guna2NumericUpDown { Minimum = 1, Maximum = 1000000, Value = 1, Width = 120 };
            txtDonGia = new Guna2TextBox { PlaceholderText = "Đơn giá", Width = 160 };

            // Load & map sách
            var sachList = await _sachService.GetAllAsync();
            cboSach.DataSource = sachList.ToList();
            cboSach.DisplayMember = "TenSach";
            cboSach.ValueMember = "MaSach";

            btnSave = CreateButton("Thêm vào phiếu", async (s, e) => await SaveDetail_Click(phieu));
            btnCancel = CreateButton("Hủy", async (s, e) => await AnimatePanel(pnlForm, false));

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(5)
            };
            flow.Controls.AddRange(new Control[] {
                lblTitle,
                new Label{ Text = "Phiếu: " + phieu.MaPhieuNhap, AutoSize=true },
                new Label{ Text = "Chọn sách", AutoSize=true },
                cboSach,
                new Label{ Text = "Số lượng", AutoSize=true },
                numSoLuong,
                new Label{ Text = "Đơn giá (VNĐ)", AutoSize=true },
                txtDonGia,
                btnSave,
                btnCancel
            });

            pnlForm.Controls.Add(flow);
            guna2Panel1.Controls.Add(pnlForm);
            pnlForm.BringToFront();

            await AnimatePanel(pnlForm, true);
        }

        // === Lưu phiếu (header) ===
        private async Task SavePhieu_Click(NhapKho phieu)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieu.Text) || cboKho.SelectedValue == null)
            {
                ShowMessage("Vui lòng điền Mã phiếu và chọn kho.");
                return;
            }

            bool success;
            if (phieu == null)
            {
                var newPhieu = new NhapKho
                {
                    MaPhieuNhap = txtMaPhieu.Text.Trim(),
                    NgayNhap = dtpNgayNhap.Value,
                    MaKho = cboKho.SelectedValue.ToString(),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                success = await _nhapKhoService.AddAsync(newPhieu);
            }
            else
            {
                phieu.NgayNhap = dtpNgayNhap.Value;
                phieu.MaKho = cboKho.SelectedValue.ToString();
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

        // === Lưu chi tiết (thêm sách vào phiếu) ===
        private async Task SaveDetail_Click(NhapKho phieu)
        {
            if (cboSach.SelectedValue == null)
            {
                ShowMessage("Vui lòng chọn sách.");
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia) || donGia <= 0)
            {
                ShowMessage("Đơn giá không hợp lệ.");
                return;
            }

            var newCT = new CT_NhapKho
            {
                MaPhieuNhap = phieu.MaPhieuNhap,
                MaSach = cboSach.SelectedValue.ToString(),
                SoLuong = (int)numSoLuong.Value,
                DonGia = donGia
            };

            var success = await _ctNhapKhoService.AddAsync(newCT);

            if (success)
            {
                // có thể cập nhật kho/số lượng tồn ở tầng service nếu cần
                ShowMessage("Đã thêm sách vào phiếu!");
                await AnimatePanel(pnlForm, false);
                DgvNhapKho_SelectionChanged(null, null); // reload chi tiết
            }
            else
            {
                ShowMessage("Có lỗi khi thêm chi tiết!");
            }
        }

        // === Hiệu ứng slide panel giống mẫu ===
        private async Task AnimatePanel(Guna2Panel panel, bool show)
        {
            if (_isAnimating) return;
            _isAnimating = true;

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = btnAddDetail.Enabled = false;

            int targetWidth = 380;
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

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = btnAddDetail.Enabled = true;
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

        // === Hiển thị FormMessage nhỏ ===
        private void ShowMessage(string text)
        {
            var fm = new FormMessage(text);
            fm.StartPosition = FormStartPosition.CenterScreen;
            fm.Show();
        }
    }
}
