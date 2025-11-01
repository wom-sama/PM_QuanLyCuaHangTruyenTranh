using Guna.UI2.WinForms;
using PM.BUS.Services.DonHangsv;
using PM.BUS.Services.Sachsv;
using PM.DAL.Models;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Admin
{
    public partial class Edit_BOOK_CT : UserControl
    {
        private readonly SachService _sachService = new SachService();
        private Sach _sach;
        private readonly string _maSach;

        private Guna2TextBox txtTenSach, txtISBN, txtGiaNhap, txtGiaBan, txtMoTa;
        private Guna2PictureBox picBia;
        private Guna2Button btnLuu, btnXoa, btnChonAnh, btnThoat;
        private Guna2Panel mainPanel;
        private Guna2ComboBox cbNhaXB, cbTacGia;
        private Label lblLuotBan;

        private int fadeAlpha = 0;
        private Timer fadeTimer;

        public event EventHandler OnExitClicked;

        public Edit_BOOK_CT(string maSach)
        {
            InitializeComponent();
            _maSach = maSach;
            SetupUI();
            _ = LoadDataAsync();
            StartFadeIn();
        }

        #region UI Setup
        private void SetupUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.WhiteSmoke;

            mainPanel = new Guna2Panel
            {
                BorderRadius = 20,
                BorderThickness = 1,
                BorderColor = Color.LightGray,
                Padding = new Padding(20),
                Width = 820,
                Height = 600,
                ShadowDecoration = { Enabled = true }
            };
            this.Controls.Add(mainPanel);
            this.Resize += (s, e) => CenterPanel();

            Label lblTitle = new Label
            {
                Text = "CHỈNH SỬA THÔNG TIN SÁCH",
                Font = new Font("Segoe UI Black", 16, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.Black,
                Location = new Point(240, 15)
            };
            mainPanel.Controls.Add(lblTitle);

            // Thoát
            btnThoat = new Guna2Button
            {
                Text = "✕",
                Width = 35,
                Height = 35,
                BorderRadius = 8,
                FillColor = Color.Transparent,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Gray,
                Location = new Point(mainPanel.Width - 60, 10),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnThoat.Click += BtnThoat_Click;
            mainPanel.Controls.Add(btnThoat);

            int leftX = 40, topY = 70, spacingY = 55;

            txtTenSach = CreateTextBox("Tên sách...", leftX, topY);
            txtISBN = CreateTextBox("ISBN...", leftX, topY + spacingY);
            txtGiaNhap = CreateTextBox("Giá nhập...", leftX, topY + spacingY * 2);
            txtGiaBan = CreateTextBox("Giá bán...", leftX, topY + spacingY * 3);
            txtMoTa = CreateTextBox("Mô tả...", leftX, topY + spacingY * 4, 400, 60, true);



            // Combobox Nhà xuất bản
            cbNhaXB = new Guna2ComboBox
            {
                Width = 400,
                Height = 40,
                Location = new Point(leftX, topY + spacingY * 5+10),
               
            };

            // Combobox Tác giả
            cbTacGia = new Guna2ComboBox
            {
                Width = 400,
                Height = 40,
                Location = new Point(leftX, topY + spacingY * 6+10),
                
            };

            // Label lượt bán
            lblLuotBan = new Label
            {
                Text = "Lượt bán: 0",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                AutoSize = true,
                Location = new Point(500, 350)
            };

            mainPanel.Controls.AddRange(new Control[] { cbNhaXB, cbTacGia, lblLuotBan });







            picBia = new Guna2PictureBox
            {
                Size = new Size(180, 220),
                BorderRadius = 10,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(500, 80),
                SizeMode = PictureBoxSizeMode.Zoom,
                ShadowDecoration = { Enabled = true }
            };

            btnChonAnh = new Guna2Button
            {
                Text = "Chọn ảnh bìa",
                Width = 150,
                BorderRadius = 8,
                Location = new Point(500, 310),
                FillColor = Color.SteelBlue,
                ForeColor = Color.White
            };
            btnChonAnh.Click += BtnChonAnh_Click;

            btnLuu = new Guna2Button
            {
                Text = "Lưu thay đổi",
                FillColor = Color.SeaGreen,
                BorderRadius = 8,
                Width = 130,
                Height = 40,
                Location = new Point(230, 500)
            };
            btnLuu.Click += async (s, e) => await SaveChangesAsync();

            btnXoa = new Guna2Button
            {
                Text = "Xóa sách",
                FillColor = Color.IndianRed,
                BorderRadius = 8,
                Width = 130,
                Height = 40,
                Location = new Point(380, 500)
            };
            btnXoa.Click += async (s, e) => await DeleteBookAsync();

            mainPanel.Controls.AddRange(new Control[]
            {
                txtTenSach, txtISBN, txtGiaNhap, txtGiaBan, txtMoTa,
                picBia, btnChonAnh, btnLuu, btnXoa
            });

            CenterPanel();
        }

        private Guna2TextBox CreateTextBox(string placeholder, int x, int y, int width = 400, int height = 40, bool multiline = false)
        {
            return new Guna2TextBox
            {
                PlaceholderText = placeholder,
                Width = width,
                Height = height,
                Location = new Point(x, y),
                Multiline = multiline
            };
        }

        private void CenterPanel()
        {
            mainPanel.Location = new Point(
                (this.Width - mainPanel.Width) / 2,
                (this.Height - mainPanel.Height) / 2
            );
        }
        #endregion

        #region Fade Animations
        private void StartFadeIn()
        {
            fadeTimer = new Timer { Interval = 10 };
            fadeTimer.Tick += (s, e) =>
            {
                fadeAlpha += 20;
                if (fadeAlpha >= 255)
                {
                    fadeAlpha = 255;
                    fadeTimer.Stop();
                }
                this.BackColor = Color.FromArgb(fadeAlpha, Color.White);
            };
            fadeTimer.Start();
        }
        #endregion

        #region Data
        private async Task LoadDataAsync()
        {
            _sach = await _sachService.GetByIdAsync(_maSach);
            if (_sach == null)
            {
                MessageBox.Show("Không tìm thấy sách!");
                return;
            }

            txtTenSach.Text = _sach.TenSach;
            txtISBN.Text = _sach.ISBN;
            txtGiaNhap.Text = _sach.GiaNhap.ToString();
            txtGiaBan.Text = _sach.GiaBan.ToString();
            txtMoTa.Text = _sach.MoTa;

            // ✅ Fix lỗi GDI+ khi ảnh load từ CSDL
            if (_sach.BiaSach != null && _sach.BiaSach.Length > 0)
            {
                using (var ms = new MemoryStream(_sach.BiaSach))
                {
                    using (var temp = Image.FromStream(ms))
                    {
                        picBia.Image = new Bitmap(temp); // clone ảnh tránh lỗi
                    }
                }
            }
            else
            {
                picBia.Image = null;
            }
            // Load danh sách NXB
  
            var listNXB = new NhaXuatBanService().GetAll();
            cbNhaXB.DataSource = listNXB;
            cbNhaXB.DisplayMember = "TenNXB";
            cbNhaXB.ValueMember = "MaNXB";
            cbNhaXB.SelectedValue = _sach.MaNXB;

            // Load tác giả
            var listTG = new TacGiaService().GetAll();
            cbTacGia.DataSource = listTG;
            cbTacGia.DisplayMember = "TenTacGia";
            cbTacGia.ValueMember = "MaTacGia";
            cbTacGia.SelectedValue = _sach.MaTacGia;

            // Load lượt bán sách (sum số lượng bán trong CT_DonHang)
            var luotBan = await new CT_DonHangService().LaySoLuongBanDuocTheoSachAsync(_maSach);
            lblLuotBan.Text = $"Lượt bán: {luotBan}";

        }

        private void BtnChonAnh_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "Ảnh (*.jpg;*.png)|*.jpg;*.png" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (var fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    using (var ms = new MemoryStream())
                    {
                        fs.CopyTo(ms);
                        ms.Position = 0;
                        picBia.Image = Image.FromStream(ms); // load ảnh từ stream để không bị khóa file
                    }
                }
            }
        }

        private async Task SaveChangesAsync()
        {
            try
            {
                _sach.TenSach = txtTenSach.Text.Trim();
                _sach.ISBN = txtISBN.Text.Trim();
                _sach.GiaNhap = decimal.Parse(txtGiaNhap.Text);
                _sach.GiaBan = decimal.Parse(txtGiaBan.Text);
                _sach.MoTa = txtMoTa.Text.Trim();
                _sach.MaNXB = cbNhaXB.SelectedValue?.ToString();
                _sach.MaTacGia = cbTacGia.SelectedValue?.ToString();


                if (picBia.Image != null)
                {
                    using (var ms = new MemoryStream())
                    using (var bmp = new Bitmap(picBia.Image)) // clone ảnh để tránh GDI+
                    {
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        _sach.BiaSach = ms.ToArray();
                    }
                }

                await _sachService.UpdateAsync(_sach);
                MessageBox.Show("✅ Đã lưu thay đổi!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private async Task DeleteBookAsync()
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa sách này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _sachService.DeleteAsync(_maSach);
                MessageBox.Show("Đã xóa thành công!");
                OnExitClicked?.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion

        #region Exit
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            var timer = new Timer { Interval = 10 };
            int alpha = 255;
            timer.Tick += (s2, e2) =>
            {
                alpha -= 25;
                if (alpha <= 0)
                {
                    timer.Stop();
                    OnExitClicked?.Invoke(this, EventArgs.Empty);
                    this.Dispose();
                }
                else
                    this.BackColor = Color.FromArgb(alpha, Color.White);
            };
            timer.Start();
        }
        #endregion
    }
}
