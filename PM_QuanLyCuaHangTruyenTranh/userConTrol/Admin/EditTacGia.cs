using Guna.UI2.WinForms;
using PM.BUS.Services.Sachsv;
using PM.DAL;
using PM.DAL.Models;
using PM.GUI.FormThongBao;
using System;
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

        public Edit_TacGia()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                var unitOfWork = new UnitOfWork();
                _tacGiaService = new TacGiaService(unitOfWork);

                BuildUI();
                _ = LoadTacGiaAsync();
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

            var pnlTop = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                FlowDirection = FlowDirection.LeftToRight
            };
            pnlTop.Controls.AddRange(new Control[] { txtSearch, btnAdd, btnEdit, btnDelete, btnRefresh });
            guna2Panel1.Controls.Add(pnlTop);

            dgvTacGia = new Guna2DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            dgvTacGia.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã TG", DataPropertyName = "MaTacGia" });
            dgvTacGia.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên tác giả", DataPropertyName = "TenTacGia", Width = 200 });
            dgvTacGia.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Quốc tịch", DataPropertyName = "QuocTich", Width = 120 });
            dgvTacGia.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ghi chú", DataPropertyName = "GhiChu", Width = 200 });

            guna2Panel1.Controls.Add(dgvTacGia);
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

            // Có thể thay bằng form xác nhận riêng nếu bạn muốn
            if (MessageBox.Show($"Bạn có chắc muốn xóa tác giả \"{tg.TenTacGia}\"?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _tacGiaService.DeleteAsync(tg.MaTacGia);
                await LoadTacGiaAsync();
                ShowMessage("Đã xóa tác giả thành công!");
            }
        }

        // === Hiển thị form thêm/sửa với hiệu ứng slide ===
        private void ShowForm(string title, TacGia tg = null)
        {
            pnlForm = new Guna2Panel
            {
                Size = new System.Drawing.Size(300, 300),
                BorderRadius = 12,
                BorderThickness = 1,
                BorderColor = System.Drawing.Color.Gray,
                BackColor = System.Drawing.Color.White,
                Dock = DockStyle.Right,
                Padding = new Padding(10),
                Visible = false
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 35,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            txtMa = new Guna2TextBox { PlaceholderText = "Mã tác giả", Text = tg?.MaTacGia };
            txtTen = new Guna2TextBox { PlaceholderText = "Tên tác giả", Text = tg?.TenTacGia };
            txtQuocTich = new Guna2TextBox { PlaceholderText = "Quốc tịch", Text = tg?.QuocTich };
            txtGhiChu = new Guna2TextBox { PlaceholderText = "Ghi chú", Text = tg?.GhiChu, Multiline = true, Height = 60 };

            btnSave = CreateButton("Lưu", async (s, e) => await Save_Click(tg));
            btnCancel = CreateButton("Hủy", (s, e) => AnimatePanel(pnlForm, false));

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

            AnimatePanel(pnlForm, true);
        }

        // === Hiệu ứng slide panel ===
        private async void AnimatePanel(Guna2Panel panel, bool show)
        {
            int step = 20;
            int targetWidth = 300;

            if (show)
            {
                panel.Width = 0;
                panel.Visible = true;
                while (panel.Width < targetWidth)
                {
                    panel.Width += step;
                    await Task.Delay(5);
                }
                panel.Width = targetWidth;
            }
            else
            {
                while (panel.Width > 0)
                {
                    panel.Width -= step;
                    await Task.Delay(5);
                }
                guna2Panel1.Controls.Remove(panel);
            }
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
                AnimatePanel(pnlForm, false);
                await LoadTacGiaAsync();
            }
            else
            {
                ShowMessage("Có lỗi khi lưu!");
            }
        }

        // === Hàm hiển thị FormMessage ===
        private void ShowMessage(string text)
        {
            var fm = new FormMessage(text);
            fm.StartPosition = FormStartPosition.CenterScreen;
            fm.Show();
        }
    }
}
