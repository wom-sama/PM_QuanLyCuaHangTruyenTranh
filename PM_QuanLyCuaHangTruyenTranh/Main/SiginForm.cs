using Guna.UI2.WinForms;
using PM_QuanLyCuaHangTruyenTranh.Helpers;
using PM_QuanLyCuaHangTruyenTranh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PM_QuanLyCuaHangTruyenTranh
{
    public partial class SignInForm : Form
    {
        private bool otpVerified = false;
        private DateTime codeSentTime;
        private string sentOTP = null;
        private string email = null;
        private int countdown = 60; // Thời gian đếm ngược ban đầu (giây)
        public SignInForm()
        {
            InitializeComponent();
        }

        // Hàm thêm hiệu ứng animation cho các ô nhập OTP
        public static void AddOTPAnimation(Guna.UI2.WinForms.Guna2TextBox box)  //su dung cho nhieu form sau nay
        {
            box.FocusedState.BorderColor = Color.MediumSlateBlue; // Viền khi focus
            box.FocusedState.FillColor = Color.FromArgb(240, 248, 255); // Nền nhạt
            box.HoverState.BorderColor = Color.DeepSkyBlue; // Viền khi hover
            box.Animated = true; // Bật animation mặc định của Guna2
        }
        // ham tat hieu ung
        public static void RemoveOTPAnimation(Guna.UI2.WinForms.Guna2TextBox box) //su dung cho nhieu form sau nay
        {
            box.FocusedState.BorderColor = Color.Gray; // Viền khi focus
            box.FocusedState.FillColor = Color.White; // Nền trắng
            box.HoverState.BorderColor = Color.Gray; // Viền khi hover
            box.Animated = false; // Tắt animation mặc định của Guna2
        }






        private void txtOTP1_TextChanged(object sender, EventArgs e)
        {
            AddOTPAnimation(txtOTP1);
            var current = sender as Guna.UI2.WinForms.Guna2TextBox;
            if (current.Text.Length == 1)
                this.SelectNextControl(current, true, true, true, true);

            string entered = txtOTP1.Text + txtOTP2.Text + txtOTP3.Text + txtOTP4.Text + txtOTP5.Text;

            // Khi đủ 5 số → đổi nút
            if (entered.Length == 5)
            {
                GNbtnSendCode.Text = "Verify";
                //GNbtnSendCode.FillColor = Color.MediumSeaGreen;
             
                GNbtnSendCode.Enabled = true;
            }
            // truong hop nguoi dung xoa bot nut
            else {
                guna2Transition1.HideSync(GNbtnSendCode);
                GNbtnSendCode.Text = "Send Code";
                //GNbtnSendCode.FillColor = Color.DodgerBlue;
               
                guna2Transition1.ShowSync(GNbtnSendCode);
            }
        }


       
      

        // luu thong tin tai khoan khach vao co so du lieu
        private void SaveKhachToDatabase()
        {
            string username = GNtxtUN.Text.Trim();
            string password = GNtxtPass.Text.Trim();
            string repass = GNtxtRePass.Text.Trim();
            string email = GNtxtMail.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                new FormMessage("Please fill in all fields.").ShowDialog();
                return;
            }

            if (password != repass)
            {
                new FormMessage("Passwords do not match.").ShowDialog();
                return;
            }

            if (!otpVerified)
            {
                new FormMessage("Please verify your email first.").ShowDialog();
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    // Kiểm tra username hoặc email đã tồn tại chưa
                    if (db.TaiKhoans.Any(t => t.TenDangNhap == username))
                    {
                        new FormMessage("Username already exists.").ShowDialog();
                        return;
                    }

                    if (db.KhachHangs.Any(k => k.Email == email))
                    {
                        new FormMessage("This email is already registered.").ShowDialog();
                        return;
                    }

                    // Tạo đối tượng tài khoản mới
                    var taiKhoan = new TaiKhoan
                    {
                        TenDangNhap = username,
                        MatKhau = PasswordHelper.HashPassword(password),
                        Quyen = "Khach",
                        TrangThai = true
                    };

                    // Tạo mã khách
                    string id = "KH" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();

                    // Tạo đối tượng khách hàng mới
                    var khach = new KhachHang
                    {
                        //MaKH = id,
                        HoTen = username, // có thể cập nhật lại bằng form nhập tên thật
                        Email = email,
                        NgayDangKy = DateTime.Now,
                        TenDangNhap = taiKhoan.TenDangNhap
                    };

                    db.TaiKhoans.Add(taiKhoan);
                    db.KhachHangs.Add(khach);
                    db.SaveChanges();
                }

                new FormMessage("Account created successfully!").ShowDialog();
            }
            catch (Exception ex)
            {
                new FormMessage("Database error: " + ex.Message).ShowDialog();
            }
        }




        private void txtOTP1_KeyDown(object sender, KeyEventArgs e)
        {
            var current = sender as Guna.UI2.WinForms.Guna2TextBox;
            if (e.KeyCode == Keys.Back && string.IsNullOrEmpty(current.Text))
                this.SelectNextControl(current, false, true, true, true);

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn tiếng "bíp" khi nhấn Enter

                var box = sender as Guna.UI2.WinForms.Guna2TextBox;
                this.SelectNextControl(box, true, true, true, true); // Chuyển focus sang ô kế tiếp
            }
        }


        public static void AddHoverEffect(Guna.UI2.WinForms.Guna2TextBox box)
        {
            // Màu viền mặc định
            Color normalBorder = Color.Silver;
            // Màu viền khi hover
            Color hoverBorder = Color.DeepSkyBlue;

            // Bật animation mượt
            box.Animated = true;

            // Gán sự kiện hover
            box.MouseEnter += (s, e) =>
            {
                box.BorderColor = hoverBorder;
                box.ShadowDecoration.Enabled = true;
                box.ShadowDecoration.Color = Color.FromArgb(100, 0, 150, 255);
                box.ShadowDecoration.Depth = 15;
            };

            // Khi chuột rời khỏi ô
            box.MouseLeave += (s, e) =>
            {
                box.BorderColor = normalBorder;
                box.ShadowDecoration.Enabled = false;
            };
        }


        private void SignInForm_Load(object sender, EventArgs e)
        {
            //an nut gui ma
            GNbtnSendCode.Enabled = false;
            GNbtnSendCode.Visible = false;
            // Thêm hiệu ứng hover cho các ô nhập OTP
            AddHoverEffect(txtOTP1);
            AddHoverEffect(txtOTP2);
            AddHoverEffect(txtOTP3);
            AddHoverEffect(txtOTP4);
            AddHoverEffect(txtOTP5);

            // Thêm hiệu ứng hover cho ô nhập email
            AddHoverEffect(GNtxtMail);
            // Thêm hiệu ứng hover cho ô nhập tên đăng nhập
            AddHoverEffect(GNtxtUN);
            // Thêm hiệu ứng hover cho ô nhập mật khẩu
            AddHoverEffect(GNtxtPass);
            // Thêm hiệu ứng hover cho ô nhập xác nhận mật khẩu
            AddHoverEffect(GNtxtRePass);
            lblDem.Visible = false;
            //khoa nut dang ky khi email chua duoc xac nhan
            GNbtnSignUp.Enabled = false;
        }


        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void GNtxtMail_TextChanged(object sender, EventArgs e)
        {

             string test = GNtxtMail.Text.Trim();

            // Kiểm tra email có đuôi @gmail.com không
            if (IsValidEmail(test))
            {
                GNbtnSendCode.Visible = true;
                GNbtnSendCode.Enabled = true;
            }
            else
            {
                GNbtnSendCode.Visible = false;
            }

        }

        private void DemTg_Tick(object sender, EventArgs e)
        {
            countdown--;
            lblDem.Text = $"Wait ({countdown}s)";
            if (countdown <= 0)
            {
                DemTg.Stop();
                GNbtnSendCode.Enabled = true;
                lblDem.Visible = false;
            }
        }

        private void txtOTP1_Enter(object sender, EventArgs e)
        {
            var box = sender as Guna.UI2.WinForms.Guna2TextBox;
            AddOTPAnimation(box);
        }

        private void txtOTP1_Leave(object sender, EventArgs e)
        {
            var box = sender as Guna.UI2.WinForms.Guna2TextBox;
            RemoveOTPAnimation(box);
        }

        private void GNtxtUN_KeyDown(object sender, KeyEventArgs e)
        {
            // nhan enter de chuyen sang txtPass
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn tiếng "bíp" khi nhấn Enter
                var box = sender as Guna.UI2.WinForms.Guna2TextBox;
                this.SelectNextControl(box, true, true, true, true); // Chuyển focus sang ô kế tiếp
            }
        }



        // gui OTP ve email
        private async void GNbtnSendCode_Click(object sender, EventArgs e)
        {
            // Neu chua gui ma thi gui ma
            if (GNbtnSendCode.Text == "Send Code")
            {
                GNtxtMail.Enabled = false;
                await HandleSendCode();
            }
            // Neu da gui ma thi kiem tra ma
            else if (GNbtnSendCode.Text == "Verify")
            {
                HandleVerify();
            }

        }


        // gui OTP
        private async Task HandleSendCode()
        {
            this.email = GNtxtMail.Text;

            if (string.IsNullOrEmpty(this.email))
            {
                new FormMessage("Please enter your email.").ShowDialog();
                return;
            }

            try
            {
                sentOTP = AESHelper.EncryptString(RandHelper.GenerateOTP(), email.Trim());
                codeSentTime = DateTime.Now;

                await EmailHelper.SendVerificationCodeAsync(email, AESHelper.DecryptString(sentOTP, this.email));

                new FormMessage("Verification code sent successfully!").ShowDialog();
                StartCountdown();
            }
            catch (Exception ex)
            {
                new FormMessage($"Failed to send email: {ex.Message}").ShowDialog();
            }
        }

        // giai ma va kiem tra OTP nguoi dung nhap
        private void HandleVerify()
        {
            string enteredOTP = txtOTP1.Text.Trim() + txtOTP2.Text.Trim() + txtOTP3.Text.Trim() + txtOTP4.Text.Trim() + txtOTP5.Text.Trim();

            if (enteredOTP != AESHelper.DecryptString(sentOTP, this.email.Trim()) || (DateTime.Now - codeSentTime).TotalSeconds > 60)
            {
                new FormMessage("Invalid or expired code.").ShowDialog();
                return;
            }

            otpVerified = true;
            GNbtnSendCode.Text = "Verified ✓";
            GNbtnSendCode.Enabled = false;
            new FormMessage("Code verified successfully!").ShowDialog();
            GNbtnSignUp.Enabled = true;
        }




        private void StartCountdown()
        {
            countdown = 60;
            lblDem.Visible = true;
            GNbtnSendCode.Enabled = false;
            lblDem.Text = $"Wait ({countdown}s)";
            DemTg.Interval = 1000;
            DemTg.Start();
        }
    
        
       
       
      
        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GNbtnSignUp_Click(object sender, EventArgs e)
        {
            if (!otpVerified)
            {
                new FormMessage("Please verify your code first.").ShowDialog();
                return;
            }

            SaveKhachToDatabase();
            // thong bao dang ky thanh cong va quay lai giao dien dang nhap
            new FormMessage("Account registration successful!").ShowDialog();
            this.Close();

        }

        private void lblDem_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void GNtxtRePass_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void lblPass_Click(object sender, EventArgs e)
        {

        }

        private void lblUN_Click(object sender, EventArgs e)
        {

        }

        private void GNtxtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void GNtxtUN_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
