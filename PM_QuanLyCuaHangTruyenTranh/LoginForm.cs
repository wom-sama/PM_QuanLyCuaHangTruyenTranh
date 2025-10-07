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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void lblDN_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 192, 203); // cùng màu pastel hồng như panel
            //this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void GNbtnLogin_Click(object sender, EventArgs e)
        {
            if (GNtxtUN.Text == "admin" && GNtxtPass.Text == "123")
            {
                Khachcs khachForm = new Khachcs();
                khachForm.FormClosed += (s, args) => this.Show();
                this.Hide();
                khachForm.Show();
            }
            else
            {
                FormMessage tb = new FormMessage("Sai mat khau hoac tai khoan");

                tb.ShowDialog();
            }

        }

        private void lblClick_Click(object sender, EventArgs e)
        {
            // Ẩn form hiện tại
            this.Hide();

            // Tạo và hiển thị form đăng ký
            SignInForm f = new SignInForm();
            f.StartPosition = FormStartPosition.CenterScreen; // Hiển thị giữa màn hình
            f.ShowDialog();

            // Sau khi form đăng ký đóng, hiện lại form đăng nhập
            this.Show();
        }
    }
}
