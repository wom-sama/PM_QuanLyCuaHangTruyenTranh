using PM_QuanLyCuaHangTruyenTranh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM_QuanLyCuaHangTruyenTranh.userConTrol.Common
{
    public partial class BooKShowcs : UserControl
    {
        Sach sach = new Sach();
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
            if (sach == null) return;

            // Gán tên sách
            txtNameBook.Text = sach.TenSach;

            // Hiển thị ảnh bìa nếu có
            if (sach.BiaSach != null && sach.BiaSach.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(sach.BiaSach))
                {
                    picBia.Image = Image.FromStream(ms);
                }
            }
            else
            {
                picBia.Image = Properties.Resources.sparkle_hanabi; // ảnh mặc định nếu không có
            }

            // Giao diện đẹp hơn
            txtNameBook.ReadOnly = true;
            picBia.BorderRadius = 10;
            picBia.SizeMode = PictureBoxSizeMode.Zoom;
            picBia.FillColor = Color.FromArgb(240, 240, 240);
            guna2ShadowPanel1.Radius = 15;
            guna2ShadowPanel1.FillColor = Color.White;
        }

    

        private void txtNameBook_TextChanged(object sender, EventArgs e)
        {

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

        }

        private void txtNameBook_MouseEnter(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}
