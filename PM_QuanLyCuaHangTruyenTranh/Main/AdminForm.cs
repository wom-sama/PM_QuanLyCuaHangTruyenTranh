using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PM.GUI;
using PM.GUI.Main;

namespace PM.GUI.Main
{
    public partial class AdminForm : Form
    {
        // danh sach cac UserControl
        private List<UserControl> AdminControl = new List<UserControl>();
        

        private bool panelVisible = false; // theo dõi trạng thái của pannel hiển thị các danh sách control 
        public AdminForm()
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
            AdminControl = this.pannel_CT_CN.Controls.OfType<UserControl>().ToList();
            foreach (var item in AdminControl)
            {
                item.Visible = false; // ẩn tất cả
                item.Enabled = false; // khoa tat ca
            }
            shadow_PannelCN.Visible = false;
            shadow_PannelCN.Left = -shadow_PannelCN.Width;
           

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
            btnCN_Click(sender, e);
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            HienThiUserControl(edit_BOOk1);
            titleCN.Text = "Thông tin sách đang có trong cửa hàng";
            AdjustFontSize(titleCN);
            btnCN_Click(sender, e);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelCN_Paint(object sender, PaintEventArgs e)
        {

        }




     

     

     


        private async void btnCN_Click(object sender, EventArgs e)
        {
            int panel2Start = -shadow_PannelCN.Width; // vị trí ẩn ban đầu
            int panel2Target = 41;                      // vị trí hiện ra
            int moveStep = 10;                          // tốc độ di chuyển
            int delay = 5;                              // delay mỗi bước (ms)

            shadow_PannelCN.Visible = true; // đảm bảo thấy panel trước khi trượt

            if (!panelVisible)
            {
                // 👉 Khi mở menu
                while (shadow_PannelCN.Left < panel2Target)
                {
                    shadow_PannelCN.Left += moveStep;

                    // Di chuyển panel1 song song theo hướng phải
                    pannel_CT_CN.Left += moveStep / 2; // tốc độ chậm hơn để tạo cảm giác mượt
                    await Task.Delay(delay);
                }

                // Đảm bảo đúng vị trí cuối cùng
                shadow_PannelCN.Left = panel2Target;
                panelVisible = true;
            }
            else
            {
                // 👉 Khi đóng menu
                while (shadow_PannelCN.Left > panel2Start)
                {
                    shadow_PannelCN.Left -= moveStep;

                    // Panel1 trượt ngược lại vị trí ban đầu
                    pannel_CT_CN.Left -= moveStep / 2;
                    await Task.Delay(delay);
                }

                shadow_PannelCN.Left = panel2Start;
                shadow_PannelCN.Visible = false;
                panelVisible = false;
            }
        }

        private void edit_BOOk1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
