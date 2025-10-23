using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM.GUI.FormThongBao
{
    public partial class FormMessage : Form
    {

        // Import hàm AnimateWindow từ Windows API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);

        // Các cờ hiệu ứng
        const int AW_HIDE = 0x00010000;
        const int AW_BLEND = 0x00080000;
        const int AW_CENTER = 0x00000010;

        public bool IsMouseInside = false; // Cờ kiểm tra chuột

        public FormMessage(string mess)
        {
            InitializeComponent();
            guna2HtmlLabelMess.Text = mess;
            // nếu là báo sai tài khoản sẽ hiện label quên mật khẩu
            if (mess == "Sai mat khau hoac tai khoan")
            {
                guna2HtmlLabel1Froget.Visible = true;
            }
            else
            {
                guna2HtmlLabel1Froget.Visible = false;
            }
            

            // Bắt sự kiện di chuột
            this.MouseEnter += (s, e) => IsMouseInside = true;
            this.MouseLeave += (s, e) =>
            {
                IsMouseInside = false;
                Hide();
            };
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {

            // Gọi hiệu ứng ẩn mờ dần
            AnimateWindow(this.Handle, 300, AW_HIDE | AW_BLEND);

            // Chờ hiệu ứng hoàn tất rồi đóng
            await Task.Delay(300);
            
            this.Close();

           
        }

        private void FormMessage_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void FormMessage_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void guna2HtmlLabel1Froget_Click(object sender, EventArgs e)
        {

        }
    }
}
