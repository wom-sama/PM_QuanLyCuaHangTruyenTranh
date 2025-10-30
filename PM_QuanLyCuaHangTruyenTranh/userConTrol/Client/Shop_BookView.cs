using PM.BUS.Services.Sachsv;
using PM.DAL.Models;
using PM.GUI.userConTrol.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Customer
{
    public partial class Shop_BookView : UserControl
    {
        private SachService sachService = new SachService();

        public Shop_BookView()
        {
            if (!DesignMode)
                InitializeComponent();
        }

        private void Shop_BookView_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            LoadAllBooks();
        }

        // ================== HIỂN THỊ SÁCH ==================
        private void LoadAllBooks(IEnumerable<Sach> list = null)
        {
            panelDanhSach.Controls.Clear();
            var books = list ?? sachService.GetAll();

            foreach (var sach in books)
            {
                Panel card = CreateBookCard(sach);
                panelDanhSach.Controls.Add(card);
            }
        }

        // ================== TẠO MỘT CARD HIỂN THỊ SÁCH ==================
        private Panel CreateBookCard(Sach sach)
        {
            Panel card = new Panel
            {
                Width = 180,
                Height = 250,
                Margin = new Padding(10),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                Tag = sach
            };

            // ----- ẢNH BÌA -----
            PictureBox pic = new PictureBox
            {
                Dock = DockStyle.Top,
                Height = 150,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.WhiteSmoke
            };

            // ✅ Nếu BiaSach là byte[] → chuyển thành ảnh
            if (sach.BiaSach != null && sach.BiaSach.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(sach.BiaSach))
                    {
                        pic.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    pic.Image = Properties.Resources.sparkle_hanabi; // ảnh mặc định
                }
            }
            else
            {
                pic.Image = Properties.Resources.sparkle_hanabi; // ảnh mặc định nếu chưa có
            }

            // ----- TÊN SÁCH -----
            Label lblTen = new Label
            {
                Text = sach.TenSach,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // ----- GIÁ -----
            Label lblGia = new Label
            {
                Text = $"{sach.GiaBan:N0} ₫",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Red,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // ----- NÚT MUA NGAY -----
            Guna.UI2.WinForms.Guna2Button btnMua = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Mua ngay",
                Dock = DockStyle.Bottom,
                BorderRadius = 8,
                Height = 35,
                FillColor = Color.OrangeRed,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Tag = sach
            };
            btnMua.Click += BtnMua_Click;

            // ----- GẮN CONTROL -----
            card.Controls.Add(btnMua);
            card.Controls.Add(lblGia);
            card.Controls.Add(lblTen);
            card.Controls.Add(pic);

            // ----- CLICK VÀO SÁCH -----
            card.Click += (s, e) => OpenBookDetail((Sach)card.Tag);
            pic.Click += (s, e) => OpenBookDetail((Sach)card.Tag);

            return card;
        }

        // ================== NÚT MUA NGAY ==================
        private void BtnMua_Click(object sender, EventArgs e)
        {
            var sach = (sender as Guna.UI2.WinForms.Guna2Button)?.Tag as Sach;
            if (sach != null)
            {
                MessageBox.Show($"🛒 Mua ngay: {sach.TenSach}\nGiá: {sach.GiaBan:N0} ₫",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ================== CLICK VÀO SÁCH ==================
        private void OpenBookDetail(Sach sach)
        {
            // Ẩn danh sách
            panelDanhSach.Visible = false;

            // Khai báo biến trước
            BookDetailControl detailControl = null;

            // Gán control chi tiết (truyền hành động quay lại)
            detailControl = new BookDetailControl(sach, () =>
            {
                // Khi nhấn "Quay lại"
                pannelTong.Controls.Remove(detailControl);
                panelDanhSach.Visible = true;
            });

            // Cấu hình hiển thị toàn màn hình
            detailControl.Dock = DockStyle.Fill;
            detailControl.AutoScroll = true;

            // Thêm control chi tiết vào panel
            pannelTong.Controls.Add(detailControl);
            detailControl.BringToFront();
        }



        // ================== TÌM KIẾM ==================
        private void btnFind_Click(object sender, EventArgs e)
        {
            string keyword = txtFindTen.Text.Trim().ToLower();
            var filtered = sachService.Find(s => s.TenSach.ToLower().Contains(keyword));
            LoadAllBooks(filtered);
        }

        // ================== NÚT GIỎ HÀNG ==================
        private void btnCart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("🛒 Mở giỏ hàng (chức năng đang phát triển).",
                "Giỏ hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pannelTong_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}