using PM.DAL;
using PM.DAL.Models;
using PM.GUI.FormThongBao;
using System;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Client
{
    public partial class Profile_Edit : UserControl
    {
        private KhachHang currentKhachHang;
        private readonly AppDbContext _db;

        public event EventHandler<UserProfileEventArgs> ProfileUpdated;

        public Profile_Edit(KhachHang khachHang)
        {
            InitializeComponent();
            currentKhachHang = khachHang;
            _db = new AppDbContext();
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            if (currentKhachHang == null)
            {
                new FormMessage("Không tìm thấy thông tin khách hàng!").ShowDialog();
                return;
            }

            txtUsername.Text = currentKhachHang.HoTen ?? "";
            txtEmail.Text = currentKhachHang.Email ?? "";
            txtSDT.Text = currentKhachHang.SoDienThoai ?? "";
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (currentKhachHang == null)
                {
                    new FormMessage("Không thể lưu vì thông tin khách hàng rỗng!").ShowDialog();
                    return;
                }

                // Cập nhật thông tin vào đối tượng hiện tại
                currentKhachHang.HoTen = txtUsername.Text.Trim();
                currentKhachHang.Email = txtEmail.Text.Trim();
                currentKhachHang.SoDienThoai = txtSDT.Text.Trim();

                // Lưu xuống database
                var khach = _db.KhachHangs.Find(currentKhachHang.TenKhach);
                if (khach != null)
                {
                    khach.HoTen = currentKhachHang.HoTen;
                    khach.Email = currentKhachHang.Email;
                    khach.SoDienThoai = currentKhachHang.SoDienThoai;
                    _db.SaveChanges();
                }

                // Gửi event cập nhật
                ProfileUpdated?.Invoke(this, new UserProfileEventArgs
                {
                    FullName = currentKhachHang.HoTen,
                    Email = currentKhachHang.Email,
                    Phone = currentKhachHang.SoDienThoai
                });

                new FormMessage("Thông tin hồ sơ đã được cập nhật thành công!").ShowDialog();
            }
            catch (Exception ex)
            {
                new FormMessage($"Lỗi khi lưu thông tin: {ex.Message}").ShowDialog();
            }
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
