using FontAwesome.Sharp;
using PM.BUS.Services.Facade;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Employee
{
    public partial class GiaoDienNV : UserControl
    {
        private readonly QuanLyDonHangBUS _bus = new QuanLyDonHangBUS();
        private IconPictureBox iconBell; // Chuông thông báo
        private Label lblThongBao;       // Hiển thị "!"
        private Timer timerCapNhat;      // Cập nhật định kỳ

        public GiaoDienNV()
        {
            InitializeComponent();
        }

        private void GiaoDienNV_Load(object sender, EventArgs e)
        {
            // 🟡 Tạo icon chuông FontAwesome
            iconBell = new IconPictureBox
            {
                IconChar = IconChar.Bell,
                IconColor = Color.Gold,
                IconSize = 40,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.CenterImage,
                Location = new Point((btnChuong.Width - 40) / 2, (btnChuong.Height - 40) / 2)
            };
            btnChuong.Controls.Add(iconBell);

            // 🔴 Khởi tạo label "!" (điểm thông báo) với kích thước mặc định bạn có thể chỉnh
            lblThongBao = new Label
            {
                Text = "!",
                Font = new Font("Segoe UI", 14, FontStyle.Bold), // chỉnh cỡ chữ ở đây
                ForeColor = Color.White,
                BackColor = Color.Red,
                Size = new Size(24, 24),                          // chỉnh khung ở đây
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false,
                Cursor = Cursors.Hand
            };

            // 👉 đặt lblThongBao làm con của btnChuong để nó luôn dính góc nút
            btnChuong.Controls.Add(lblThongBao);
            lblThongBao.Location = new Point(btnChuong.Width - lblThongBao.Width - 2, 2);
            lblThongBao.BringToFront();

            // 🔁 Kiểm tra thông báo lần đầu
            CapNhatThongBao();

            // ⏰ Tự động cập nhật mỗi 10s
            timerCapNhat = new Timer { Interval = 10000 };
            timerCapNhat.Tick += (s, ev) => CapNhatThongBao();
            timerCapNhat.Start();

            // đảm bảo nút có event (nếu Designer chưa gán)
            btnChuong.Click -= btnChuong_Click; // tránh gán nhiều lần
            btnChuong.Click += btnChuong_Click;
        }

        private void CapNhatThongBao()
        {
            try
            {
                // Lấy danh sách đơn cần chú ý (bạn đổi trạng thái tùy ý)
                var donCho = _bus.LayDanhSachDonHangTheoTrangThai("Đã thanh toán");
                // hiện "!" nếu có ít nhất 1 đơn
                lblThongBao.Visible = donCho != null && donCho.Any();
            }
            catch (Exception ex)
            {
                // ghi log thay vì ném lỗi lên UI
                Console.WriteLine("Lỗi khi cập nhật thông báo: " + ex.Message);
            }
        }

        private void btnChuong_Click(object sender, EventArgs e)
        {
            try
            {
                // Khi nhấn chuông -> mở giao diện duyệt đơn
                DuyetDon duyetDonUC = new DuyetDon();
                Form form = new Form
                {
                    Text = "Duyệt đơn hàng",
                    Width = 1000,
                    Height = 600,
                    StartPosition = FormStartPosition.CenterScreen
                };
                duyetDonUC.Dock = DockStyle.Fill;
                form.Controls.Add(duyetDonUC);
                form.ShowDialog();

                // Sau khi đóng form duyệt, cập nhật lại trạng thái chuông
                CapNhatThongBao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở DuyệtDon: " + ex.Message);
            }
        }

        //click vào chính dấu "!" cũng mở được
        private void lblBadge_Click(object sender, EventArgs e)
        {
            btnChuong_Click(sender, e);
        }
    }
}
