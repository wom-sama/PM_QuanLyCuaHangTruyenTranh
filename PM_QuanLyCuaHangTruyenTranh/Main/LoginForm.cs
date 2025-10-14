using Guna.UI2.WinForms;
using PM_QuanLyCuaHangTruyenTranh.Helpers;
using PM_QuanLyCuaHangTruyenTranh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM_QuanLyCuaHangTruyenTranh
{
    public partial class LoginForm : Form
    {
        private AppDbContext db = new AppDbContext();
        FormMessage f = new FormMessage("Vui lòng liên hệ Admin để được hỗ trợ!");

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

            lblInfo.Cursor = Cursors.Default;

            // them hieu ung vao combo box
            GNcmbVAI.Items.AddRange(new string[] { "", "Admin", "Nhân viên", "Khách" });
            GNcmbVAI.SelectedIndex = 0;
            


        }

        private void GNbtnLogin_Click(object sender, EventArgs e)
        {
            string username = GNtxtUN.Text.Trim();
            string password = GNtxtPass.Text.Trim();
            string role = GNcmbVAI.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                new FormMessage("Vui lòng nhập đầy đủ thông tin đăng nhập!").ShowDialog();
                return;
            }

            try
            {
                var tk = db.TaiKhoans.FirstOrDefault(t => t.TenDangNhap == username && t.Quyen == role);

                if (tk == null)
                {
                    new FormMessage("Tài khoản không tồn tại hoặc sai vai trò!").ShowDialog();
                    return;
                }

                bool isValid = PasswordHelper.VerifyPassword(password, tk.MatKhau);

                if (!isValid)
                {
                    new FormMessage("Mật khẩu không đúng!").ShowDialog();
                    return;
                }

                // Đăng nhập thành công → mở form tương ứng
                new FormMessage($"Đăng nhập thành công với vai trò {tk.Quyen}!").ShowDialog();
                this.Hide();

                switch (tk.Quyen)
                {
                    case "Admin":
                        new AdminForm(tk).ShowDialog();
                        break;
                    case "NhanVien":
                        new NhanVienForm(tk).ShowDialog();
                        break;
                    case "Khach":
                        new Client(tk).ShowDialog();
                        break;
                }

                this.Show();
            }
            catch (Exception ex)
            {
                new FormMessage("Lỗi khi đăng nhập: " + ex.Message).ShowDialog();
            }
        }


        private void lblClick_Click(object sender, EventArgs e)
        {
            // Ẩn form hiện tại
            this.Hide();
            // Ẩn form hiện tại
            this.Hide();

            // Tạo và hiển thị form đăng ký

            SignInForm f = new SignInForm();
            f.StartPosition = FormStartPosition.CenterScreen; // Hiển thị giữa màn hình
            f.ShowDialog();

            // Sau khi form đăng ký đóng, hiện lại form đăng nhập
            this.Show();
        }

        private void GNcmbVAI_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ảnh GIF mới theo vai trò
            Image newGif;
            switch (GNcmbVAI.SelectedItem.ToString())
            {
                case "Admin":
                    newGif = Properties.Resources.evernight_ezgif_com_apng_to_gif_converter;
                    break;
                case "Nhân viên":
                    newGif = Properties.Resources.sparkle_hanabi;
                    break;
                case "Khách":
                    newGif = Properties.Resources.text;
                    break;
                default:
                    newGif = Properties.Resources.cherry_blossoms_6383_128;
                    break;
            }

            // Tạo ảnh mới (Guna2PictureBox)
            Guna2PictureBox picNew = new Guna2PictureBox
            {
                Size = picRoleGif.Size,
                Location = picRoleGif.Location,
                SizeMode = picRoleGif.SizeMode,
                Image = newGif,
                BackColor = Color.Transparent,
                UseTransparentBackground = true,
                Parent = picRoleGif.Parent,
            };

            // tam chua hien anh moi
            picNew.Hide();




            // Ẩn ảnh cũ với hiệu ứng

            guna2Transition1.HideSync(picRoleGif);

            // Hiện ảnh mới 
            guna2Transition1.ShowSync(picNew);

            // Dọn dẹp ảnh cũ 
            picRoleGif.Dispose();

            // Cập nhật biến gốc để các chỗ khác trong form vẫn dùng được
            picRoleGif = picNew;
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblClick_MouseEnter(object sender, EventArgs e)
        {
            // Đổi màu va gach chan khi hover chuột vào(link)
            lblClick.ForeColor = Color.Blue;
            lblClick.Font = new Font("Palatino Linotype", 12F , FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

        }

        private void lblClick_MouseLeave(object sender, EventArgs e)
        {
            // Trả về màu và kiểu chữ ban đầu khi chuột rời khỏi(link)
            lblClick.ForeColor = Color.FromArgb(75, 63, 63);
            lblClick.Font = new Font("Palatino Linotype",12F, FontStyle.Bold | FontStyle.Italic);
        }

        private void lblHoi_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_MouseEnter(object sender, EventArgs e)
        {
            Point cursorPos = Cursor.Position;
            f.Location = new Point(cursorPos.X + 15, cursorPos.Y + 15);
            f.Show();
            checkMouseTimer.Start();
        }

        private void guna2HtmlLabel1_MouseLeave(object sender, EventArgs e)
        {
            checkMouseTimer.Start();

        }

        private void checkMouseTimer_Tick(object sender, EventArgs e)
        {
            bool isOnLabel = lblInfo.Bounds.Contains(PointToClient(Cursor.Position));
            if (!isOnLabel && !f.IsMouseInside)
            {
                f.Hide();
                checkMouseTimer.Stop();
            }
        }
    }
}
