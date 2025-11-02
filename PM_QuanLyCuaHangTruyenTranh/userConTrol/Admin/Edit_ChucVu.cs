using Guna.UI2.WinForms;
using PM.BUS.Helpers;
using PM.BUS.Services.TaiKhoansv;
using PM.DAL.Models;
using PM.GUI.FormThongBao;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Admin
{
    public partial class Edit_ChucVu : UserControl
    {
        private readonly ChucVuService _chucVuService;
        private Guna2DataGridView dgvChucVu;
        private Guna2TextBox txtSearch;
        private Guna2Button btnAdd, btnEdit, btnDelete, btnRefresh;
        private Guna2Panel pnlForm;
        private Guna2TextBox txtMa, txtTen, txtMoTa;
        private Guna2Button btnSave, btnCancel;
        private FlowLayoutPanel pnlTop;
        private bool _isAnimating = false;

        public Edit_ChucVu()
        {
            if (!DesignMode)
            {
                InitializeComponent();

                _chucVuService = new ChucVuService(new PM.DAL.UnitOfWork());
                BuildUI();
                _ = LoadChucVuAsync();
                _ = AnimateTopPanelAsync(); // hiệu ứng load
            }
        }

        // ===== Dựng giao diện chính =====
        private void BuildUI()
        {
            guna2Panel1.Controls.Clear();

            txtSearch = new Guna2TextBox
            {
                PlaceholderText = "Tìm kiếm theo tên chức vụ...",
                BorderRadius = 8,
                Width = 250,
                Margin = new Padding(10)
            };
            txtSearch.TextChanged += (s, e) => SearchChucVu();

            btnAdd = CreateButton("Thêm", Add_Click);
            btnEdit = CreateButton("Sửa", Edit_Click);
            btnDelete = CreateButton("Xóa", Delete_Click);
            btnRefresh = CreateButton("Làm mới", async (s, e) => await LoadChucVuAsync());

            pnlTop = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10, 8, 10, 8)
            };
            pnlTop.Controls.AddRange(new Control[] { txtSearch, btnAdd, btnEdit, btnDelete, btnRefresh });

            dgvChucVu = new Guna2DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Margin = new Padding(0, 5, 0, 0)
            };

            dgvChucVu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã CV", DataPropertyName = "MaChucVu", Width = 100 });
            dgvChucVu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên chức vụ", DataPropertyName = "TenChucVu", Width = 200 });
            dgvChucVu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mô tả", DataPropertyName = "MoTa", Width = 250 });

            guna2Panel1.Controls.Add(dgvChucVu);
            guna2Panel1.Controls.Add(pnlTop);
        }

        private Guna2Button CreateButton(string text, EventHandler click)
        {
            var btn = new Guna2Button
            {
                Text = text,
                BorderRadius = 8,
                Height = 35,
                Margin = new Padding(5)
            };
            btn.Click += click;
            return btn;
        }

        // ===== Load dữ liệu =====
        private async Task LoadChucVuAsync()
        {
            var list = await _chucVuService.GetAllAsync();
            dgvChucVu.DataSource = list.ToList();
        }

        private void SearchChucVu()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            var filtered = _chucVuService.GetAll()
                .Where(c => c.TenChucVu.ToLower().Contains(keyword))
                .ToList();
            dgvChucVu.DataSource = filtered;
        }

        // ===== CRUD =====
        private void Add_Click(object sender, EventArgs e)
        {
            ShowForm("Thêm chức vụ");
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (dgvChucVu.SelectedRows.Count == 0)
            {
                ShowMessage("Vui lòng chọn chức vụ để sửa");
                return;
            }

            var cv = (ChucVu)dgvChucVu.SelectedRows[0].DataBoundItem;
            ShowForm("Sửa chức vụ", cv);
        }

        private async void Delete_Click(object sender, EventArgs e)
        {
            if (dgvChucVu.SelectedRows.Count == 0)
            {
                ShowMessage("Vui lòng chọn chức vụ để xóa");
                return;
            }

            var cv = (ChucVu)dgvChucVu.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Bạn có chắc muốn xóa chức vụ \"{cv.TenChucVu}\"?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _chucVuService.DeleteAsync(cv.MaChucVu);
                await LoadChucVuAsync();
                ShowMessage("Đã xóa chức vụ thành công!");
            }
        }

        // ===== Hiển thị form thêm/sửa =====
        private async void ShowForm(string title, ChucVu cv = null)
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
                Padding = new Padding(10),
                Visible = true,
                ShadowDecoration = { Enabled = true, Depth = 10, Color = Color.FromArgb(60, 0, 0, 0) }
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 35,
                TextAlign = ContentAlignment.MiddleCenter
            };

            txtMa = new Guna2TextBox { PlaceholderText = "Mã chức vụ", Text = cv?.MaChucVu ?? RandHelper.TaoMa("CV") };
            txtMa.ReadOnly = true;
            txtTen = new Guna2TextBox { PlaceholderText = "Tên chức vụ", Text = cv?.TenChucVu };
            txtMoTa = new Guna2TextBox { PlaceholderText = "Mô tả", Text = cv?.MoTa, Multiline = true, Height = 60 };

            btnSave = CreateButton("Lưu", async (s, e) => await Save_Click(cv));
            btnCancel = CreateButton("Hủy", async (s, e) => await AnimatePanel(pnlForm, false));

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(5)
            };
            flow.Controls.AddRange(new Control[] { lblTitle, txtMa, txtTen, txtMoTa, btnSave, btnCancel });

            pnlForm.Controls.Add(flow);
            guna2Panel1.Controls.Add(pnlForm);
            pnlForm.BringToFront();

            await AnimatePanel(pnlForm, true);
        }

        // ===== Hiệu ứng panel =====
        private async Task AnimatePanel(Guna2Panel panel, bool show)
        {
            if (_isAnimating) return;
            _isAnimating = true;

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = false;

            int targetWidth = 320;
            int frameRate = 120;
            int totalDuration = show ? 220 : 160;
            int frameDelay = 1000 / frameRate;
            int steps = totalDuration / frameDelay;

            panel.SuspendLayout();

            if (show)
            {
                panel.Visible = true;
                panel.Width = 0;

                for (int i = 0; i <= steps; i++)
                {
                    double t = (double)i / steps;
                    double eased = 1 - Math.Pow(1 - t, 3);
                    panel.Width = (int)(targetWidth * eased);
                    await Task.Delay(frameDelay);
                }
                panel.Width = targetWidth;
            }
            else
            {
                for (int i = steps; i >= 0; i--)
                {
                    double t = (double)i / steps;
                    double eased = t * t * t;
                    panel.Width = (int)(targetWidth * eased);
                    await Task.Delay(frameDelay);
                }

                panel.Width = 0;
                panel.Visible = false;

                if (panel.Parent != null)
                    panel.Parent.Controls.Remove(panel);

                pnlForm = null;
            }

            panel.ResumeLayout();
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = true;
            _isAnimating = false;
        }

        private async Task AnimateTopPanelAsync()
        {
            pnlTop.Top = -pnlTop.Height;
            await Task.Delay(100);
            for (int i = -pnlTop.Height; i < 0; i += 5)
            {
                pnlTop.Top = i;
                await Task.Delay(5);
            }
            pnlTop.Top = 0;
        }

        // ===== Lưu chức vụ =====
        private async Task Save_Click(ChucVu cv)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text) || string.IsNullOrWhiteSpace(txtTen.Text))
            {
                ShowMessage("Vui lòng nhập đầy đủ Mã và Tên chức vụ!");
                return;
            }

            bool success;

            if (cv == null)
            {
                var newCV = new ChucVu
                {
                    MaChucVu = txtMa.Text.Trim(),
                    TenChucVu = txtTen.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim()
                };
                success = await _chucVuService.AddAsync(newCV);
            }
            else
            {
                cv.TenChucVu = txtTen.Text.Trim();
                cv.MoTa = txtMoTa.Text.Trim();
                success = await _chucVuService.UpdateAsync(cv);
            }

            if (success)
            {
                ShowMessage("Lưu thành công!");
                await AnimatePanel(pnlForm, false);
                await LoadChucVuAsync();
            }
            else
            {
                ShowMessage("Có lỗi khi lưu!");
            }
        }

        // ===== Hiển thị thông báo =====
        private void ShowMessage(string text)
        {
            var fm = new FormMessage(text);
            fm.StartPosition = FormStartPosition.CenterScreen;
            fm.Show();
        }
    }
}
