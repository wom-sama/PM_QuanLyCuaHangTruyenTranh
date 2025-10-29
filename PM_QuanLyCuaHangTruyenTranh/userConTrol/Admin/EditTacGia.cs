using Guna.UI2.WinForms;
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
    public partial class Edit_TacGia : UserControl
    {
        private TacGiaService _tacGiaService;
        private Guna2DataGridView dgvTacGia;
        private Guna2TextBox txtSearch;
        private Guna2Button btnAdd, btnEdit, btnDelete, btnRefresh;
        private Guna2Panel pnlForm;
        private Guna2TextBox txtMa, txtTen, txtQuocTich, txtGhiChu;
        private Guna2Button btnSave, btnCancel;
        private FlowLayoutPanel pnlTop;
        private bool _isAnimating = false;


        public Edit_TacGia()
        {
            

            if (!DesignMode)
            {
                InitializeComponent();

                _tacGiaService = new TacGiaService();

                BuildUI();
                _ = LoadTacGiaAsync();
                _ = AnimateTopPanelAsync(); // hiệu ứng load
            }
        }

        // === Dựng giao diện chính ===
        private void BuildUI()
        {
            guna2Panel1.Controls.Clear();

            txtSearch = new Guna2TextBox
            {
                PlaceholderText = "Tìm kiếm theo tên...",
                BorderRadius = 8,
                Width = 250,
                Margin = new Padding(10)
            };
            txtSearch.TextChanged += (s, e) => SearchTacGia();

            btnAdd = CreateButton("Thêm", Add_Click);
            btnEdit = CreateButton("Sửa", Edit_Click);
            btnDelete = CreateButton("Xóa", Delete_Click);
            btnRefresh = CreateButton("Làm mới", async (s, e) => await LoadTacGiaAsync());

            pnlTop = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10, 8, 10, 8)
            };
            pnlTop.Controls.AddRange(new Control[] { txtSearch, btnAdd, btnEdit, btnDelete, btnRefresh });

            dgvTacGia = new Guna2DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Margin = new Padding(0, 5, 0, 0)
            };

            dgvTacGia.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã TG", DataPropertyName = "MaTacGia" });
            dgvTacGia.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên tác giả", DataPropertyName = "TenTacGia", Width = 200 });
            dgvTacGia.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Quốc tịch", DataPropertyName = "QuocTich", Width = 120 });
            dgvTacGia.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ghi chú", DataPropertyName = "GhiChu", Width = 200 });

            guna2Panel1.Controls.Add(dgvTacGia);
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

        private async Task LoadTacGiaAsync()
        {
            var list = await _tacGiaService.GetAllAsync();
            dgvTacGia.DataSource = list.ToList();
        }

        private void SearchTacGia()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            var filtered = _tacGiaService.GetAll()
                .Where(t => t.TenTacGia.ToLower().Contains(keyword))
                .ToList();
            dgvTacGia.DataSource = filtered;
        }

        // === CRUD ===
        private void Add_Click(object sender, EventArgs e)
        {
            ShowForm("Thêm tác giả");
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (dgvTacGia.SelectedRows.Count == 0)
            {
                ShowMessage("Vui lòng chọn tác giả để sửa");
                return;
            }

            var tg = (TacGia)dgvTacGia.SelectedRows[0].DataBoundItem;
            ShowForm("Sửa tác giả", tg);
        }

        private async void Delete_Click(object sender, EventArgs e)
        {
            if (dgvTacGia.SelectedRows.Count == 0)
            {
                ShowMessage("Vui lòng chọn tác giả để xóa");
                return;
            }

            var tg = (TacGia)dgvTacGia.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Bạn có chắc muốn xóa tác giả \"{tg.TenTacGia}\"?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _tacGiaService.DeleteAsync(tg.MaTacGia);
                await LoadTacGiaAsync();
                ShowMessage("Đã xóa tác giả thành công!");
            }
        }

        // === Hiển thị form thêm/sửa với hiệu ứng ===
        private async void ShowForm(string title, TacGia tg = null)
        {
            // Nếu panel đang mở => đóng trước, sau đó mở lại
            if (pnlForm != null && guna2Panel1.Controls.Contains(pnlForm))
            {
                await AnimatePanel(pnlForm, false); // chờ đóng xong
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

            txtMa = new Guna2TextBox { PlaceholderText = "Mã tác giả", Text = tg?.MaTacGia };
            txtTen = new Guna2TextBox { PlaceholderText = "Tên tác giả", Text = tg?.TenTacGia };
            txtQuocTich = new Guna2TextBox { PlaceholderText = "Quốc tịch", Text = tg?.QuocTich };
            txtGhiChu = new Guna2TextBox { PlaceholderText = "Ghi chú", Text = tg?.GhiChu, Multiline = true, Height = 60 };

            btnSave = CreateButton("Lưu", async (s, e) => await Save_Click(tg));
            btnCancel = CreateButton("Hủy", async (s, e) => await AnimatePanel(pnlForm, false));

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(5)
            };
            flow.Controls.AddRange(new Control[] { lblTitle, txtMa, txtTen, txtQuocTich, txtGhiChu, btnSave, btnCancel });

            pnlForm.Controls.Add(flow);
            guna2Panel1.Controls.Add(pnlForm);
            pnlForm.BringToFront();

            await AnimatePanel(pnlForm, true);
        }



        // === Hiệu ứng slide + fade ===
        private async Task AnimatePanel(Guna2Panel panel, bool show)
        {
            if (_isAnimating) return; // chặn spam khi đang chạy animation
            _isAnimating = true;

            // 🔒 Tạm vô hiệu hóa các nút thao tác CRUD
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = false;

            int targetWidth = 320;
            int frameRate = 120;
            int totalDuration = show ? 220 : 160; // đóng nhanh hơn
            int frameDelay = 1000 / frameRate;
            int steps = totalDuration / frameDelay;

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
                    double eased = 1 - Math.Pow(1 - t, 3); // easing cubic-out
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
                    double eased = t * t * t; // easing cubic-in
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

            // 🔓 Mở lại các nút CRUD sau khi animation hoàn tất
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = true;

            _isAnimating = false;
        }


        // === Hiệu ứng top panel khi load ===
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

        // === Lưu tác giả ===
        private async Task Save_Click(TacGia tg)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text) || string.IsNullOrWhiteSpace(txtTen.Text))
            {
                ShowMessage("Vui lòng nhập đầy đủ Mã và Tên tác giả!");
                return;
            }

            bool success;

            if (tg == null)
            {
                var newTG = new TacGia
                {
                    MaTacGia = txtMa.Text.Trim(),
                    TenTacGia = txtTen.Text.Trim(),
                    QuocTich = txtQuocTich.Text.Trim(),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                success = await _tacGiaService.AddAsync(newTG);
            }
            else
            {
                tg.TenTacGia = txtTen.Text.Trim();
                tg.QuocTich = txtQuocTich.Text.Trim();
                tg.GhiChu = txtGhiChu.Text.Trim();
                success = await _tacGiaService.UpdateAsync(tg);
            }

            if (success)
            {
                ShowMessage("Lưu thành công!");
               await AnimatePanel(pnlForm, false);
                await LoadTacGiaAsync();
            }
            else
            {
                ShowMessage("Có lỗi khi lưu!");
            }
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
