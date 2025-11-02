using Guna.UI2.WinForms;
using PM.BUS.Helpers;
using PM.BUS.Services.Sachsv;
using PM.DAL.Models;
using PM.GUI.FormThongBao;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Admin
{
    public partial class Edit_TheLoai : UserControl
    {
        private TheLoaiService _theLoaiService;
        private Guna2DataGridView dgvTheLoai;
        private Guna2TextBox txtSearch;
        private Guna2Button btnAdd, btnEdit, btnDelete, btnRefresh;
        private Guna2Panel pnlForm;
        private Guna2TextBox txtMa, txtTen, txtGhiChu;
        private Guna2Button btnSave, btnCancel;
        private FlowLayoutPanel pnlTop;
        private bool _isAnimating = false;

        public Edit_TheLoai()
        {
            if (!DesignMode)
            {
                InitializeComponent();

                _theLoaiService = new TheLoaiService();

                BuildUI();
                _ = LoadTheLoaiAsync();
                _ = AnimateTopPanelAsync();
            }
        }

        // === Dựng UI chính (giống Edit_TacGia) ===
        private void BuildUI()
        {
            // Xóa control hiện có trong panel chính (designer) rồi dựng lại
            guna2Panel1.Controls.Clear();

            txtSearch = new Guna2TextBox
            {
                PlaceholderText = "Tìm kiếm theo tên...",
                BorderRadius = 8,
                Width = 250,
                Margin = new Padding(10)
            };
            txtSearch.TextChanged += (s, e) => SearchTheLoai();

            btnAdd = CreateButton("Thêm", Add_Click);
            btnEdit = CreateButton("Sửa", Edit_Click);
            btnDelete = CreateButton("Xóa", Delete_Click);
            btnRefresh = CreateButton("Làm mới", async (s, e) => await LoadTheLoaiAsync());

            pnlTop = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10, 8, 10, 8)
            };
            pnlTop.Controls.AddRange(new Control[] { txtSearch, btnAdd, btnEdit, btnDelete, btnRefresh });

            dgvTheLoai = new Guna2DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Margin = new Padding(0, 5, 0, 0)
            };

            dgvTheLoai.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã TL", DataPropertyName = "MaTheLoai" });
            dgvTheLoai.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên thể loại", DataPropertyName = "TenTheLoai", Width = 200 });
            dgvTheLoai.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ghi chú", DataPropertyName = "GhiChu", Width = 200 });
           
            guna2Panel1.Controls.Add(dgvTheLoai);
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

        // === Load dữ liệu bất đồng bộ và cập nhật cột số lượng sách ===
        private async Task LoadTheLoaiAsync()
        {
            var list = await _theLoaiService.GetAllAsync();
            dgvTheLoai.DataSource = list.ToList();

           
            
        }


        private void SearchTheLoai()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            var filtered = _theLoaiService.GetAll()
                .Where(t => (t.TenTheLoai ?? "").ToLower().Contains(keyword))
                .ToList();
            dgvTheLoai.DataSource = filtered;
        }

        // === CRUD handlers ===
        private void Add_Click(object sender, EventArgs e)
        {
            ShowForm("Thêm thể loại");
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (dgvTheLoai.SelectedRows.Count == 0)
            {
                ShowMessage("Vui lòng chọn thể loại để sửa");
                return;
            }

            var tl = (TheLoai)dgvTheLoai.SelectedRows[0].DataBoundItem;
            ShowForm("Sửa thể loại", tl);
        }

        private async void Delete_Click(object sender, EventArgs e)
        {
            if (dgvTheLoai.SelectedRows.Count == 0)
            {
                ShowMessage("Vui lòng chọn thể loại để xóa");
                return;
            }

            var tl = (TheLoai)dgvTheLoai.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Bạn có chắc muốn xóa thể loại \"{tl.TenTheLoai}\"?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool ok = await _theLoaiService.DeleteAsync(tl.MaTheLoai);
                if (ok)
                {
                    await LoadTheLoaiAsync();
                    ShowMessage("Đã xóa thể loại thành công!");
                }
                else
                {
                    ShowMessage("Xóa thất bại. Kiểm tra ràng buộc dữ liệu hoặc lỗi hệ thống.");
                }
            }
        }

        // === Hiển thị form thêm/sửa (panel bên phải) ===
        private async void ShowForm(string title, TheLoai tl = null)
        {
            // Nếu panel hiện có đang mở thì đóng trước
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

            txtMa = new Guna2TextBox { PlaceholderText = "Mã thể loại", Text = tl?.MaTheLoai??RandHelper.TaoMa("TL") }; txtMa.ReadOnly = true;
            txtTen = new Guna2TextBox { PlaceholderText = "Tên thể loại", Text = tl?.TenTheLoai };
            txtGhiChu = new Guna2TextBox { PlaceholderText = "Ghi chú", Text = tl?.GhiChu, Multiline = true, Height = 60 };

            btnSave = CreateButton("Lưu", async (s, e) => await Save_Click(tl));
            btnCancel = CreateButton("Hủy", async (s, e) => await AnimatePanel(pnlForm, false));

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(5),
                AutoScroll = true
            };
            flow.Controls.AddRange(new Control[] { lblTitle, txtMa, txtTen, txtGhiChu, btnSave, btnCancel });

            pnlForm.Controls.Add(flow);
            guna2Panel1.Controls.Add(pnlForm);
            pnlForm.BringToFront();

            await AnimatePanel(pnlForm, true);
        }

        // === Hiệu ứng slide + fade cho panel ===
        private async Task AnimatePanel(Guna2Panel panel, bool show)
        {
            if (_isAnimating) return;
            _isAnimating = true;

            // Tạm khóa các nút thao tác
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;

            int targetWidth = 320;
            int frameRate = 120;
            int totalDuration = show ? 220 : 160;
            int frameDelay = 1000 / frameRate;
            int steps = Math.Max(1, totalDuration / frameDelay);

            // Bật DoubleBuffered nếu có thể để mượt
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
                    double eased = 1 - Math.Pow(1 - t, 3); // cubic-out
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
                    double eased = t * t * t; // cubic-in
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

            // Mở lại nút CRUD
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = true;

            _isAnimating = false;
        }

        // === Hiệu ứng top panel khi load ===
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

        // === Lưu thể loại (thêm hoặc cập nhật) ===
        private async Task Save_Click(TheLoai tl)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text) || string.IsNullOrWhiteSpace(txtTen.Text))
            {
                ShowMessage("Vui lòng nhập đầy đủ Mã và Tên thể loại!");
                return;
            }

            bool success;

            if (tl == null)
            {
                var newTL = new TheLoai
                {
                    MaTheLoai = txtMa.Text.Trim(),
                    TenTheLoai = txtTen.Text.Trim(),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                success = await _theLoaiService.AddAsync(newTL);
            }
            else
            {
                tl.TenTheLoai = txtTen.Text.Trim();
                tl.GhiChu = txtGhiChu.Text.Trim();
                success = await _theLoaiService.UpdateAsync(tl);
            }

            if (success)
            {
                ShowMessage("Lưu thành công!");
                await AnimatePanel(pnlForm, false);
                await LoadTheLoaiAsync();
            }
            else
            {
                ShowMessage("Có lỗi khi lưu!");
            }
        }

        // === Hiển thị FormMessage (popup đơn giản) ===
        private void ShowMessage(string text)
        {
            var fm = new FormMessage(text);
            fm.StartPosition = FormStartPosition.CenterScreen;
            fm.Show();
        }
    }
}
