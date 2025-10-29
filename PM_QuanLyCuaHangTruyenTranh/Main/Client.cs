using System;
using System.Windows.Forms;
using PM.GUI.FormThongBao;

namespace PM.GUI.Main
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            // Dữ liệu ban đầu
            txtHoTen.Text = "Nguyễn Văn A";
            txtEmail.Text = "vana@example.com";

            txtHoTen.ReadOnly = true;
            txtEmail.ReadOnly = true;

          // var profile = new userConTrol.Client.Profile_Edit();
           // profile.ProfileUpdated += ProfileEdit_ProfileUpdated; // Đăng ký sự kiện
           // LoadUserControl(profile);
        }

        private void LoadUserControl(UserControl uc)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);

            // Nếu là form chỉnh sửa hồ sơ thì gắn event luôn
         //   if (uc is userConTrol.Client.Profile_Edit profileEdit)
           // {
             //  profileEdit.ProfileUpdated += ProfileEdit_ProfileUpdated;
           // }
        }

        // ✅ Nhận dữ liệu cập nhật từ Profile_Edit
     /*   private void ProfileEdit_ProfileUpdated(object sender, userConTrol.Client.UserProfileEventArgs e)
        {
            txtHoTen.Text = e.FullName;
            txtEmail.Text = e.Email;

            MessageBox.Show("Dữ liệu trên Client đã được cập nhật!", "Thông báo");
        }*/

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
           // var profile = new userConTrol.Client.Profile_Edit();
           // profile.ProfileUpdated += ProfileEdit_ProfileUpdated; // Gắn lại event
         //  LoadUserControl(profile);
        }

      /* private void btnSeeOrder_Click(object sender, EventArgs e)
        {
            LoadUserControl(new userConTrol.Client.DonHang());
        }*/

        private void btnHistory_Click(object sender, EventArgs e)
        {
           // LoadUserControl(new userConTrol.Client.LichSuMuaHang());
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
    }
}
