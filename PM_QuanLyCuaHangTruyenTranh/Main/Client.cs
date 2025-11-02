using System;
using System.Windows.Forms;
using PM.DAL.Models;
using PM.GUI.FormThongBao;
using PM.GUI.userConTrol;


namespace PM.GUI.Main
{
    public partial class Client : Form
    {
        KhachHang currentUser;
        public Client(KhachHang kh)
        {
            InitializeComponent();
            currentUser= kh;
        }

        private void Client_Load_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
            try
            {
                txtHoTen.Text = currentUser.HoTen;
                txtEmail.Text = currentUser.Email;
                txtHoTen.ReadOnly = true;
                txtEmail.ReadOnly = true;

                cboTrangThai.Items.Clear();
                cboTrangThai.Items.Add("-- Chọn trạng thái --");
                cboTrangThai.Items.Add("Đang chuẩn bị hàng");
                cboTrangThai.Items.Add("Đang vận chuyển");
                cboTrangThai.Items.Add("Đã nhận hàng");
                cboTrangThai.SelectedIndex = 0;

                cboTrangThai.SelectedIndexChanged += cboTrangThai_SelectedIndexChanged_1;

                panelMain.Controls.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi khi load form",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserControl(UserControl uc)
        {
            try
            {
                panelMain.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                panelMain.Controls.Add(uc);

                if (uc is userConTrol.Client.Profile_Edit profileEdit)
                {
                    profileEdit.ProfileUpdated += ProfileEdit_ProfileUpdated;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load UserControl: {ex.Message}", "Lỗi");
            }
        }

        private void ProfileEdit_ProfileUpdated(object sender, userConTrol.Client.UserProfileEventArgs e)
        {
            txtHoTen.Text = e.FullName;
            txtEmail.Text = e.Email;
            MessageBox.Show("Dữ liệu trên Client đã được cập nhật!", "Thông báo");
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            var profile = new userConTrol.Client.Profile_Edit();
            profile.ProfileUpdated += ProfileEdit_ProfileUpdated;
            LoadUserControl(profile);
        }

        private void btnSeeOrder_Click(object sender, EventArgs e)
        {
            
            LoadUserControl(new userConTrol.Client.DonHang(currentUser.TenDangNhap));
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            LoadUserControl(new userConTrol.Client.LichSuMuaHang());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Form form = new FormMessage("LOL");
            form.ShowDialog();
        }

        private void btnChangePFP_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh đại diện";
                ofd.Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picAvatar.ImageLocation = ofd.FileName;
                }
            }
        }

        private void cboTrangThai_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                string trangThai = cboTrangThai.SelectedItem?.ToString();

                // Nếu chọn placeholder, xóa panel
                if (string.IsNullOrEmpty(trangThai) || trangThai == "-- Chọn trạng thái --")
                {
                    panelMain.Controls.Clear();
                    return;
                }

                // Tạo và load DonHang với trạng thái được chọn
                var donHangUC = new PM.GUI.userConTrol.Client.DonHang(currentUser.TenDangNhap);

                var method = typeof(PM.GUI.userConTrol.Client.DonHang)
                    .GetMethod("TaiDonHang", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if (method != null)
                {
                    method.Invoke(donHangUC, new object[] { trangThai });
                }

                LoadUserControl(donHangUC);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc đơn hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}