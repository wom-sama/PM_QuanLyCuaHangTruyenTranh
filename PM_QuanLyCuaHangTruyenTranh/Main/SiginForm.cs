using Guna.UI2.WinForms;
using PM.BUS.Helpers;
using PM.BUS.Services;
using PM.BUS.Services.TaiKhoansv;
using System;
using System.Drawing;
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
        private int countdown = 60; // Thời gian đếm ngược OTP (giây)

        private KhachHangService _khachHangService;

        public SignInForm()
        {
            InitializeComponent();

            // tránh lỗi design-time
            if (!DesignMode)
                _khachHangService = new KhachHangService();
        }

        #region Animation & Hover
        public static void AddOTPAnimation(Guna2TextBox box)
        {
            box.FocusedState.BorderColor = Color.MediumSlateBlue;
            box.FocusedState.FillColor = Color.FromArgb(240, 248, 255);
            box.HoverState.BorderColor = Color.DeepSkyBlue;
            box.Animated = true;
        }

        public static void RemoveOTPAnimation(Guna2TextBox box)
        {
            box.FocusedState.BorderColor = Color.Gray;
            box.FocusedState.FillColor = Color.White;
            box.HoverState.BorderColor = Color.Gray;
            box.Animated = false;
        }

        public static void AddHoverEffect(Guna2TextBox box)
        {
            Color normalBorder = Color.Silver;
            Color hoverBorder = Color.DeepSkyBlue;

            box.Animated = true;

            box.MouseEnter += (s, e) =>
            {
                box.BorderColor = hoverBorder;
                box.ShadowDecoration.Enabled = true;
                box.ShadowDecoration.Color = Color.FromArgb(100, 0, 150, 255);
                box.ShadowDecoration.Depth = 15;
            };

            box.MouseLeave += (s, e) =>
            {
                box.BorderColor = normalBorder;
                box.ShadowDecoration.Enabled = false;
            };
        }
        #endregion

        #region Form Load
        private void SignInForm_Load(object sender, EventArgs e)
        {
            GNbtnSendCode.Enabled = false;
            GNbtnSendCode.Visible = false;

            // Thêm hiệu ứng hover
            foreach (var txt in new[] { txtOTP1, txtOTP2, txtOTP3, txtOTP4, txtOTP5, GNtxtMail, GNtxtUN, GNtxtPass, GNtxtRePass })
                if (txt != null)
                    AddHoverEffect(txt);

            lblDem.Visible = false;
            GNbtnSignUp.Enabled = false;
        }
        #endregion

        #region OTP nhập liệu (áp dụng chung cho 5 textbox)
        private void txtOTP1_TextChanged(object sender, EventArgs e)
        {
            AddOTPAnimation((Guna2TextBox)sender);

            var entered = txtOTP1.Text + txtOTP2.Text + txtOTP3.Text + txtOTP4.Text + txtOTP5.Text;

            if (entered.Length == 5)
            {
                GNbtnSendCode.Text = "Verify";
                GNbtnSendCode.Enabled = true;
            }
            else
            {
                GNbtnSendCode.Text = "Send Code";
                GNbtnSendCode.Enabled = false;
            }
        }

        private void txtOTP1_KeyDown(object sender, KeyEventArgs e)
        {
            var box = (Guna2TextBox)sender;

            if (e.KeyCode == Keys.Back && string.IsNullOrEmpty(box.Text))
                this.SelectNextControl(box, false, true, true, true);

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl(box, true, true, true, true);
            }
        }

        private void txtOTP1_Enter(object sender, EventArgs e)
        {
            AddOTPAnimation((Guna2TextBox)sender);
        }

        private void txtOTP1_Leave(object sender, EventArgs e)
        {
            RemoveOTPAnimation((Guna2TextBox)sender);
        }
        #endregion

        #region Email Validation & Countdown
        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void GNtxtMail_TextChanged(object sender, EventArgs e)
        {
            string test = GNtxtMail.Text.Trim();
            GNbtnSendCode.Visible = IsValidEmail(test);
            GNbtnSendCode.Enabled = GNbtnSendCode.Visible;
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
        #endregion

        #region Gửi & Xác thực OTP
        private async void GNbtnSendCode_Click(object sender, EventArgs e)
        {
            if (GNbtnSendCode.Text == "Send Code")
            {
                GNtxtMail.Enabled = false;
                await HandleSendCode();
            }
            else if (GNbtnSendCode.Text == "Verify")
            {
                HandleVerify();
            }
        }

        private async Task HandleSendCode()
        {
            this.email = GNtxtMail.Text.Trim();

            if (string.IsNullOrEmpty(this.email))
            {
                new FormMessage("Please enter your email.").ShowDialog();
                return;
            }

            try
            {
                sentOTP = AESHelper.EncryptString(RandHelper.GenerateOTP(), email);
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

        private void HandleVerify()
        {
            string enteredOTP = txtOTP1.Text + txtOTP2.Text + txtOTP3.Text + txtOTP4.Text + txtOTP5.Text;

            if (enteredOTP != AESHelper.DecryptString(sentOTP, this.email) ||
                (DateTime.Now - codeSentTime).TotalSeconds > 60)
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
        #endregion

        #region Đăng ký tài khoản
        private async void GNbtnSignUp_Click(object sender, EventArgs e)
        {
            AuthService _authService = new AuthService();
            if (!otpVerified)
            {
                new FormMessage("Vui lòng xác minh mã OTP trước khi đăng ký.").ShowDialog();
                return;
            }

            string username = GNtxtUN.Text.Trim();
            string password = GNtxtPass.Text.Trim();
            string repass = GNtxtRePass.Text.Trim();
            string email = GNtxtMail.Text.Trim();

            string result = await _authService.DangKyKhachAsync(username, password, repass, email);

            new FormMessage(result).ShowDialog();

            if (result.Contains("thành công"))
                this.Close();
        }
        #endregion
    }
}
