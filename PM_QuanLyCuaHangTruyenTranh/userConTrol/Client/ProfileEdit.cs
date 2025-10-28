using PM.GUI.FormThongBao;
using System;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Client
{
    public partial class Profile_Edit : UserControl
    {
        public event EventHandler<UserProfileEventArgs> ProfileUpdated;

        public Profile_Edit()
        {
            InitializeComponent();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            var updatedProfile = new UserProfileEventArgs
            {
                FullName = txtUsername.Text,
                Email = txtEmail.Text,
                Phone = txtSDT.Text
            };

            ProfileUpdated?.Invoke(this, updatedProfile);

            MessageBox.Show("Thông tin hồ sơ đã được cập nhật!", "Thông báo");
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void linkChangeEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenVerificationForm("Email");
        }

        private void linkChangeSDT_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenVerificationForm("Số điện thoại");
        }

        private void OpenVerificationForm(string fieldType)
        {
            string otp = new Random().Next(100000, 999999).ToString();
            MessageBox.Show($"[DEBUG] Mã OTP {fieldType}: {otp}");

            using (FormVerify frm = new FormVerify(fieldType, otp))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show($"{fieldType} đã được thay đổi thành công!", "Thông báo");
                }
            }
        }
    }
    public class UserProfileEventArgs : EventArgs
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
