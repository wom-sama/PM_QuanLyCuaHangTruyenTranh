using Guna.UI2.WinForms;
using PM.BUS.Services.TaiKhoansv;
using PM.DAL.Models;
using PM.GUI.FormThongBao;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM.GUI.Main
{
    public partial class LoginForm : Form
    {
        private readonly AuthService authService = new AuthService(); // dùng BUS thay vì DbContext
        FormMessage f = new FormMessage("Vui lòng liên hệ Admin để được hỗ trợ!");

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 192, 203);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            lblInfo.Cursor = Cursors.Default;

            GNcmbVAI.Items.AddRange(new string[] { "", "Admin", "Nhân viên", "Khách" });
            GNcmbVAI.SelectedIndex = 0;
        }

        private async void GNbtnLogin_Click(object sender, EventArgs e)
        {
            string username = GNtxtUN.Text.Trim();
            string password = GNtxtPass.Text.Trim();
            string role = GNcmbVAI.Text.Trim();

            // Chuẩn hóa vai trò bằng cách loại bỏ dấu tiếng Việt
            string normalized = role.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in normalized)
            {
                var category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            // Loại bỏ khoảng trắng và dấu câu
            string cleanRole = Regex.Replace(sb.ToString(), @"[\p{P}\s]+", "");
            role = cleanRole;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                new FormMessage("Vui lòng nhập đầy đủ thông tin đăng nhập!").ShowDialog();
                return;
            }

            try
            {
                // Dùng BUS async
                var tk = await authService.LoginAsync(username, password, role);

                if (tk == null)
                {
                    new FormMessage("Sai thông tin đăng nhập hoặc vai trò không hợp lệ!").ShowDialog();
                    return;
                }

                new FormMessage($"Chào {tk.HoTen ?? tk.TenDangNhap}, bạn đã đăng nhập với vai trò {tk.Quyen}!").ShowDialog();
                this.Hide();

                switch (tk.Quyen)
                {
                    case "Admin":
                        AdminForm adminForm = new AdminForm();
                        adminForm.StartPosition = FormStartPosition.CenterScreen;
                        adminForm.ShowDialog();

                        break;
                    case "NhanVien":
                         NhanVienForm nvForm = new NhanVienForm();
                        nvForm.StartPosition = FormStartPosition.CenterScreen;
                        nvForm.ShowDialog();
                        break;
                    case "Khach":
                        // Lấy thông tin KhachHang từ database theo TenDangNhap của TaiKhoan
                        using (var uow = new PM.DAL.UnitOfWork()) // hoặc context EF của bạn
                        {
                            var kh = uow.KhachHangs.Get(tk.TenDangNhap); // Lấy KhachHang theo TenDangNhap
                            if (kh == null)
                            {
                                new FormMessage("Khách hàng chưa có thông tin!").ShowDialog();
                                return;
                            }

                            // Truyền KhachHang vào FromTest
                            FromTest clientForm = new FromTest(kh);
                            clientForm.StartPosition = FormStartPosition.CenterScreen;
                            clientForm.ShowDialog();
                        }
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
            this.Hide();
            SignInForm f = new SignInForm();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
            this.Show();
        }

        private void GNcmbVAI_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image newGif;
            switch (GNcmbVAI.SelectedItem.ToString())
            {
                case "Admin":
                    newGif = Properties.Resources.evernight_ezgif_com_apng_to_gif_converter;
                    break;
                case "Nhân Viên":
                    newGif = Properties.Resources.sparkle_hanabi;
                    break;
                case "Khách":
                    newGif = Properties.Resources.text;
                    break;
                default:
                    newGif = Properties.Resources.cherry_blossoms_6383_128;
                    break;
            }

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

            picNew.Hide();
            guna2Transition1.HideSync(picRoleGif);
            guna2Transition1.ShowSync(picNew);
            picRoleGif.Dispose();
            picRoleGif = picNew;
        }

        private void lblClick_MouseEnter(object sender, EventArgs e)
        {
            lblClick.ForeColor = Color.Blue;
            lblClick.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
        }

        private void lblClick_MouseLeave(object sender, EventArgs e)
        {
            lblClick.ForeColor = Color.FromArgb(75, 63, 63);
            lblClick.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold | FontStyle.Italic);
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
