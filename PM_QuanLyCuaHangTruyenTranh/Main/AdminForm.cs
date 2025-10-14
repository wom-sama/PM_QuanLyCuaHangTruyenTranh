using Guna.UI2.WinForms;
using PM_QuanLyCuaHangTruyenTranh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM_QuanLyCuaHangTruyenTranh
{
    public partial class AdminForm : Form
    {
        // danh sach cac UserControl
        private List<UserControl> AdminControl = new List<UserControl>();

        public AdminForm(TaiKhoan Admin)
        {
            InitializeComponent();
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void userControl21_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            AdjustFontSize(titleCN);
            // them cac UC vao list
            AdminControl = this.guna2ShadowPanel1.Controls.OfType<UserControl>().ToList();
            foreach (var item in AdminControl)
            {
                item.Visible = false; // ẩn tất cả
                item.Enabled = false; // khoa tat ca
            }

        }
        //hien thi control su dung
        private void HienThiUserControl(UserControl uc)
        {
            foreach (var item in AdminControl)
            {
                item.Visible = false; // ẩn tất cả
                item.Enabled = false; // khoa tat ca
            }

            uc.Visible = true; // chỉ hiện UC được chọn
            uc.Enabled = true; // mo khoa UC duoc chon
        }
        
        // khong hien thi ngay
        private void add_Book1_Load(object sender, EventArgs e)
        {
            // an cac control
            add_Book1.Visible = false;
            add_Book1.Enabled = false;
        }

        private void titleCN_Click(object sender, EventArgs e)
        {

        }
        private void AdjustFontSize(Guna2HtmlLabel lbl)
        {
            if (string.IsNullOrEmpty(lbl.Text))
                return;

            Graphics g = lbl.CreateGraphics();
            float fontSize = lbl.Font.Size;

            SizeF textSize = g.MeasureString(lbl.Text, lbl.Font);
            float ratio = Math.Min(lbl.Width / textSize.Width, lbl.Height / textSize.Height);

            // Giới hạn cỡ chữ tối đa và tối thiểu
            float newSize = Math.Max(8, lbl.Font.Size * ratio);

            lbl.Font = new Font(lbl.Font.FontFamily, newSize, lbl.Font.Style);
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            //hien Add_Book
            HienThiUserControl(add_Book1);
            titleCN.Text=BtnThem.Text;
            AdjustFontSize(titleCN);
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            HienThiUserControl(edit_BOOk1);
            titleCN.Text = "Thông tin sách đang có trong cửa hàng";
            AdjustFontSize(titleCN);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
