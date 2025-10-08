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
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PM_QuanLyCuaHangTruyenTranh
{
    public partial class SignInForm : Form
    {
        private bool otpVerified = false;
        private DateTime codeSentTime;
        private string sentOTP = null;
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
                GNbtnSendCode.Click -= GNbtnSendCode_Click;
                GNbtnSendCode.Click += GNbtnVerify_Click;
                GNbtnSendCode.Enabled = true;
            }
            // truong hop nguoi dung xoa bot nut
            else {
                guna2Transition1.HideSync(GNbtnSendCode);
                GNbtnSendCode.Text = "Send Code";
                //GNbtnSendCode.FillColor = Color.DodgerBlue;
                GNbtnSendCode.Click -= GNbtnVerify_Click;
                GNbtnSendCode.Click += GNbtnSendCode_Click;
                guna2Transition1.ShowSync(GNbtnSendCode);
            }
        }

        private void GNbtnVerify_Click(object sender, EventArgs e)
        {
            string enteredOTP = txtOTP1.Text + txtOTP2.Text + txtOTP3.Text + txtOTP4.Text + txtOTP5.Text;

            string decryptedOTP = AESHelper.DecryptString(sentOTP); // Giải mã để so sánh khi người dùng nhập OTP

            if (enteredOTP != decryptedOTP || (DateTime.Now - codeSentTime).TotalSeconds > 60)
            {
                new FormMessage("Invalid or expired code.").ShowDialog();
                return;
            }

            otpVerified = true;
            GNbtnSendCode.Text = "Verified ✓";
            GNbtnSendCode.Enabled = false;
            new FormMessage("Code verified successfully!").ShowDialog();

            //  Bật nút Sign Up
            GNbtnSignUp.Enabled = true;
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
                new FormMessage("Please verify your code first.").ShowDialog();
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    if (db.Khaches.Any(k => k.Email == email))
                    {
                        new FormMessage("This email is already registered.").ShowDialog();
                        return;
                    }

                    string id = "KH" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();

                    var kh = new Khach
                    {
                        MaKhach = id,
                        TenDangNhap = username,
                        MatKhau = PasswordHelper.HashPassword(password),
                        Email = email
                    };

                    db.Khaches.Add(kh);
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

        private void GNtxtMail_TextChanged(object sender, EventArgs e)
        {

            string email = GNtxtMail.Text.Trim();

            // Kiểm tra email có đuôi @gmail.com không
            if (email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
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

        private async void GNbtnSendCode_Click(object sender, EventArgs e)
        {

            string email = GNtxtMail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                new FormMessage("Please enter your email.").ShowDialog();
                return;
            }

            try
            {
                // Sinh mã OTP

                sentOTP = AESHelper.EncryptString(OTPHelper.GenerateOTP()); //Mã hóa chuỗi OTP bằng AES (để không lưu plain text trong RAM)
                codeSentTime = DateTime.Now;

                // Gửi mail
                await EmailHelper.SendVerificationCodeAsync(email, AESHelper.DecryptString(sentOTP));

                new FormMessage("Verification code sent successfully!").ShowDialog();
                StartCountdown();
            }
            catch (Exception ex)
            {
                new FormMessage($"Failed to send email: {ex.Message}").ShowDialog();
            }



        }

        private void StartCountdown()
        {
            int countdown = 60;
            lblDem.Visible = true;
            GNbtnSendCode.Enabled = false;
            lblDem.Text = $"Wait ({countdown}s)";
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
    }
}
