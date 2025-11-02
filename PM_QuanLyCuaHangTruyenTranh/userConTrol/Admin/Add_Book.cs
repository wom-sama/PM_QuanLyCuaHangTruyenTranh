using Guna.UI2.WinForms;
using PM.BUS.Services.Sachsv;
using PM.BUS.Services;
using PM.BUS.Helpers;
using PM.DAL.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Admin
{
    public partial class Add_Book : UserControl
    {
        private TacGiaService _tacGiaService;
        private TheLoaiService _theLoaiService;
        private NhaXuatBanService _nxbService;
        private SachService _sachService;
        private NhanVien _currentNV;

        private byte[] _biaSachData;

        private Guna2TextBox txtMaSach, txtTenSach, txtISBN, txtGiaNhap, txtGiaBan, txtSoTrang, txtNamXB, txtMoTa;
        private Guna2ComboBox cbTacGia, cbTheLoai, cbNhaXuatBan;
        private Guna2PictureBox picBiaSach;
        private Guna2Button btnUpload, btnLuu, btnHuy;
        private Label lblTitle;
        private Guna2Panel Pannel_AddBook_main;


        public Add_Book(NhanVien a)
        {
           
            if (!DesignMode) // 🔹 chỉ chạy khi đang chạy thật, không phải khi mở trong Designer
            {
                InitializeComponent();
                _tacGiaService = new TacGiaService();
                _theLoaiService = new TheLoaiService();
                _nxbService = new NhaXuatBanService();
                _sachService = new SachService();
                _currentNV = a;

                BuildUI();
                Load += Add_Book_Load;
            }
            
        }

        private void Add_Book_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
            txtMaSach.Text = RandHelper.TaoMa("S");
        }

        private void BuildUI()
        {
            // ===== MAIN PANEL =====
            Pannel_AddBook_main = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true,
                Padding = new Padding(20)
            };
            Controls.Add(Pannel_AddBook_main);

            // ===== TITLE =====
            lblTitle = new Label
            {
                Text = "THÊM SÁCH MỚI",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 45),
                Dock = DockStyle.Top,
                Height = 60,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Pannel_AddBook_main.Controls.Add(lblTitle);

            // ===== CONTAINER PANEL (CENTERED) =====
            var panelContainer = new Guna2Panel
            {
                Size = new Size(900, 700),
                Anchor = AnchorStyles.None,
                Location = new Point((Pannel_AddBook_main.Width - 900) / 2, 80),
                BackColor = Color.Transparent
            };
            panelContainer.Anchor = AnchorStyles.Top;
            panelContainer.AutoScroll = false;
            Pannel_AddBook_main.Controls.Add(panelContainer);

            // ===== LEFT COLUMN =====
            int xLeft = 40, y = 20;
            int width = 350, spacingY = 60;

            txtMaSach = CreateTextBox("Mã sách (tự sinh)...", xLeft, y, width);
            txtMaSach.Enabled = false;
            txtTenSach = CreateTextBox("Tên sách...", xLeft, y += spacingY, width);
            txtISBN = CreateTextBox("ISBN...", xLeft, y += spacingY, width);
            cbTacGia = CreateComboBox(xLeft, y += spacingY+15, width);
            cbTheLoai = CreateComboBox(xLeft, y += spacingY, width);
            cbNhaXuatBan = CreateComboBox(xLeft, y += spacingY, width);
            txtGiaNhap = CreateTextBox("Giá nhập...", xLeft, y += spacingY, width);
            txtGiaBan = CreateTextBox("Giá bán...", xLeft, y += spacingY, width);
            txtSoTrang = CreateTextBox("Số trang...", xLeft, y += spacingY, width);
            txtNamXB = CreateTextBox("Năm xuất bản...", xLeft, y += spacingY, width);

            panelContainer.Controls.AddRange(new Control[] {
                txtMaSach, txtTenSach, txtISBN,
                cbTacGia, cbTheLoai, cbNhaXuatBan,
                txtGiaNhap, txtGiaBan, txtSoTrang, txtNamXB
            });

            // ===== RIGHT COLUMN =====
            int xRight = xLeft + 450;

            btnUpload = new Guna2Button
            {
                Text = "Chọn ảnh bìa",
                BorderRadius = 8,
                Size = new Size(160, 40),
                Location = new Point(xRight, 20),
                FillColor = Color.FromArgb(78, 159, 245),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnUpload.Click += BtnUpload_Click;
            panelContainer.Controls.Add(btnUpload);

            picBiaSach = new Guna2PictureBox
            {
                BorderRadius = 10,
                Size = new Size(230, 300),
                Location = new Point(xRight, 70),
                SizeMode = PictureBoxSizeMode.Zoom,
                FillColor = Color.FromArgb(245, 245, 245),
                ShadowDecoration = { Depth = 8, Enabled = true }
            };
            panelContainer.Controls.Add(picBiaSach);

            txtMoTa = CreateTextBox("Mô tả...", xRight, 390, 230);
            txtMoTa.Multiline = true;
            txtMoTa.Height = 100;
            panelContainer.Controls.Add(txtMoTa);

            // ===== BUTTONS =====
            int btnY = 600;
            btnLuu = new Guna2Button
            {
                Text = "Lưu",
                BorderRadius = 10,
                Size = new Size(100, 40),
                Location = new Point(xRight, btnY),
                FillColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White
            };
            btnLuu.Click += BtnLuu_Click;
            panelContainer.Controls.Add(btnLuu);

            btnHuy = new Guna2Button
            {
                Text = "Hủy",
                BorderRadius = 10,
                Size = new Size(100, 40),
                Location = new Point(xRight + 130, btnY),
                FillColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White
            };
            btnHuy.Click += BtnHuy_Click;
            panelContainer.Controls.Add(btnHuy);
        }

        // ===== Helper Methods =====
        private Guna2TextBox CreateTextBox(string placeholder, int x, int y, int width)
        {
            return new Guna2TextBox
            {
                PlaceholderText = placeholder,
                BorderRadius = 8,
                Size = new Size(width, 40),
                Location = new Point(x, y),
                Font = new Font("Segoe UI", 10),
                FillColor = Color.FromArgb(250, 250, 250),
                BorderColor = Color.Silver,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
        }

        private Guna2ComboBox CreateComboBox(int x, int y, int width)
        {
            return new Guna2ComboBox
            {
                BorderRadius = 8,
                Size = new Size(width, 40),
                Location = new Point(x, y),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
        }

        private void LoadDropdowns()
        {
            var tacGias = _tacGiaService.GetAll().ToList();
            tacGias.Insert(0, new TacGia { MaTacGia = "", TenTacGia = "-- Chọn tác giả --" });
            cbTacGia.DataSource = tacGias;
            cbTacGia.DisplayMember = "TenTacGia";
            cbTacGia.ValueMember = "MaTacGia";

            var theLoais = _theLoaiService.GetAll().ToList();
            theLoais.Insert(0, new DAL.Models.TheLoai { MaTheLoai = "", TenTheLoai = "-- Chọn thể loại --" });
            cbTheLoai.DataSource = theLoais;
            cbTheLoai.DisplayMember = "TenTheLoai";
            cbTheLoai.ValueMember = "MaTheLoai";

            var nxbs = _nxbService.GetAll().ToList();
            nxbs.Insert(0, new NhaXuatBan { MaNXB = "", TenNXB = "-- Chọn NXB --" });
            cbNhaXuatBan.DataSource = nxbs;
            cbNhaXuatBan.DisplayMember = "TenNXB";
            cbNhaXuatBan.ValueMember = "MaNXB";
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picBiaSach.Image = Image.FromFile(ofd.FileName);
                    _biaSachData = File.ReadAllBytes(ofd.FileName);
                }
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenSach.Text) ||
                    cbTacGia.SelectedIndex <= 0 || cbTheLoai.SelectedIndex <= 0 || cbNhaXuatBan.SelectedIndex <= 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sach = new Sach
                {
                    MaSach = txtMaSach.Text,
                    TenSach = txtTenSach.Text.Trim(),
                    ISBN = txtISBN.Text.Trim(),
                    MaTacGia = cbTacGia.SelectedValue?.ToString(),
                    MaTheLoai = cbTheLoai.SelectedValue?.ToString(),
                    MaNXB = cbNhaXuatBan.SelectedValue?.ToString(),
                    GiaNhap = decimal.TryParse(txtGiaNhap.Text, out var giaNhap) ? giaNhap : 0,
                    GiaBan = decimal.TryParse(txtGiaBan.Text, out var giaBan) ? giaBan : 0,
                    SoTrang = int.TryParse(txtSoTrang.Text, out var soTrang) ? soTrang : 0,
                    NamXuatBan = int.TryParse(txtNamXB.Text, out var nam) ? nam : 0,
                    MoTa = txtMoTa.Text.Trim(),
                    TrangThai = true,
                    BiaSach = _biaSachData
                };

                if (_sachService.Add(sach))
                {
                    MessageBox.Show("Thêm sách thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Không thể thêm sách. Kiểm tra lại dữ liệu!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sách: " + ex.Message);
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            foreach (var c in Pannel_AddBook_main.Controls.OfType<Guna2Panel>().SelectMany(p => p.Controls.OfType<Guna2TextBox>()))
                c.Text = string.Empty;

            cbTacGia.SelectedIndex = 0;
            cbTheLoai.SelectedIndex = 0;
            cbNhaXuatBan.SelectedIndex = 0;
            picBiaSach.Image = null;
            _biaSachData = null;
            txtMaSach.Text = RandHelper.TaoMa("S");
        }
    }
}
