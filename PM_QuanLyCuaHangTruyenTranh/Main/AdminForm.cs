using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PM.GUI.userConTrol.Common;
using PM.GUI.userConTrol.Admin; // nhớ import namespace chứa UC

namespace PM.GUI.Main
{
    public partial class AdminForm : Form
    {
        private bool panelVisible = false;
        private UserControl currentControl; // lưu control đang hiển thị

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            Edit_Lable.AdjustFontSize(titleCN);
            shadow_PannelCN.Visible = false;
            shadow_PannelCN.Left = -shadow_PannelCN.Width;

            // luôn full màn hình
           // this.FormBorderStyle = FormBorderStyle.None;
         //   this.WindowState = FormWindowState.Normal;
           // this.WindowState = FormWindowState.Maximized;
        //    this.Bounds = Screen.PrimaryScreen.Bounds;
            this.MaximizeBox = false;
         //   this.MinimizeBox = false;
        }

        // Hàm hiển thị UserControl động
        private void HienThiUserControl(UserControl newUC)
        {
            try
            {
                // Xóa control cũ nếu có
                if (currentControl != null)
                {
                    shadow_PannelCN.Controls.Remove(currentControl);
                    currentControl.Dispose();
                }

                // Gắn control mới
                newUC.Dock = DockStyle.Fill;
                shadow_PannelCN.Controls.Add(newUC);
                currentControl = newUC;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị control: " + ex.Message);
            }
        }

        // Animation panel (mở/đóng)
        private async Task TogglePanelAsync()
        {
            int panel2Start = -shadow_PannelCN.Width;
            int panel2Target = 41;
            int moveStep = 10;
            int delay = 5;

            shadow_PannelCN.Visible = true;

            if (!panelVisible)
            {
                while (shadow_PannelCN.Left < panel2Target)
                {
                    shadow_PannelCN.Left += moveStep;
                    pannel_CT_CN.Left += moveStep / 2;
                    await Task.Delay(delay);
                }

                shadow_PannelCN.Left = panel2Target;
                panelVisible = true;
            }
            else
            {
                while (shadow_PannelCN.Left > panel2Start)
                {
                    shadow_PannelCN.Left -= moveStep;
                    pannel_CT_CN.Left -= moveStep / 2;
                    await Task.Delay(delay);
                }

                shadow_PannelCN.Left = panel2Start;
                shadow_PannelCN.Visible = false;
                panelVisible = false;
            }
        }

        private async void btnCN_Click(object sender, EventArgs e)
        {
            await TogglePanelAsync();
        }

        // ==== CÁC BUTTON SỰ KIỆN CŨ - GIỮ NGUYÊN ====

        private void BtnThem_Click(object sender, EventArgs e)
        {
            var uc = new Add_Book(); // tạo mới control
            HienThiUserControl(uc);
            titleCN.Text = BtnThem.Text;
            Edit_Lable.AdjustFontSize(titleCN);
            _ = TogglePanelAsync(); // hiển thị panel
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            var uc = new Edit_BOOk(); // ví dụ UC hiển thị sách
            HienThiUserControl(uc);
            titleCN.Text = "Thông tin sách đang có trong cửa hàng";
            Edit_Lable.AdjustFontSize(titleCN);
            _ = TogglePanelAsync();
        }

        private void btn_DSTG_Click(object sender, EventArgs e)
        {
            var uc = new Edit_TacGia(); // ví dụ UC hiển thị tác giả
            HienThiUserControl(uc);
            titleCN.Text = btn_DSTG.Text;
            Edit_Lable.AdjustFontSize(titleCN);
            _ = TogglePanelAsync();
        }

        // ==== SỰ KIỆN KHÁC GIỮ NGUYÊN ====
        private void userControl11_Load(object sender, EventArgs e) { }
        private void userControl21_Load(object sender, EventArgs e) { }
        private void guna2Button1_Click(object sender, EventArgs e) { }
        private void guna2Button2_Click(object sender, EventArgs e) { }
        private void titleCN_Click(object sender, EventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e) { }
        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e) { }
        private void PanelCN_Paint(object sender, PaintEventArgs e) { }
        private void edit_BOOk1_Load_1(object sender, EventArgs e) { }
        private void guna2GradientTileButton4_Click(object sender, EventArgs e) { }
    }
}
