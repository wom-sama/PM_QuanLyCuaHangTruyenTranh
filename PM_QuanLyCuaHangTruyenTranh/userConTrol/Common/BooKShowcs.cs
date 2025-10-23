using PM.BUS.Services.Sachsv;
using PM.DAL.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Common
{
    public partial class BooKShowcs : UserControl
    {
        private SachService sachService = new SachService();
        private Sach sach = new Sach();

        public BooKShowcs()
        {
            InitializeComponent();
        }

        public BooKShowcs(Sach book)
        {
            InitializeComponent();
            sach = book;
        }

        private void BooKShowcs_Load(object sender, EventArgs e)
        {
            try
            {
                txtNameBook.ReadOnly = true;
                picBia.BorderRadius = 10;
                picBia.FillColor = Color.FromArgb(245, 245, 245);
                picBia.SizeMode = PictureBoxSizeMode.Zoom;
                picBia.Cursor = Cursors.Hand;

                guna2ShadowPanel1.Radius = 15;
                guna2ShadowPanel1.ShadowDepth = 40;
                guna2ShadowPanel1.ShadowShift = 5;
                guna2ShadowPanel1.ShadowColor = Color.FromArgb(120, 0, 0, 0);
                guna2ShadowPanel1.FillColor = Color.White;

                if (sach == null || string.IsNullOrEmpty(sach.MaSach))
                {
                    txtNameBook.Text = "Không xác định";
                    picBia.Image = Properties.Resources.sparkle_hanabi;
                    return;
                }

                // ✅ Lấy thông tin sách mới nhất từ service
                var sachMoi = sachService.GetById(sach.MaSach);
                if (sachMoi != null)
                    sach = sachMoi;

                // Gán tên sách
                txtNameBook.Text = sach.TenSach ?? "Không có tên";

                // Hiển thị ảnh bìa
                if (sach.BiaSach != null && sach.BiaSach.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(sach.BiaSach))
                    {
                        picBia.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picBia.Image = Properties.Resources.sparkle_hanabi;
                }

                // Giao diện mượt hơn
                txtNameBook.ReadOnly = true;
                picBia.BorderRadius = 10;
                picBia.SizeMode = PictureBoxSizeMode.Zoom;
                picBia.FillColor = Color.FromArgb(240, 240, 240);
                guna2ShadowPanel1.Radius = 15;
                guna2ShadowPanel1.FillColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin sách: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNameBook_TextChanged(object sender, EventArgs e)
        {
            // Giữ nguyên
        }

        private void picBia_MouseEnter(object sender, EventArgs e)
        {
            guna2ShadowPanel1.ShadowColor = Color.FromArgb(180, 60, 60, 60);
            guna2ShadowPanel1.ShadowDepth = 60;
            guna2ShadowPanel1.FillColor = Color.FromArgb(250, 250, 250);
        }

        private void picBia_MouseLeave(object sender, EventArgs e)
        {
            guna2ShadowPanel1.ShadowColor = Color.FromArgb(120, 0, 0, 0);
            guna2ShadowPanel1.ShadowDepth = 40;
            guna2ShadowPanel1.FillColor = Color.White;
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Giữ nguyên
        }

        private void txtNameBook_MouseEnter(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}
