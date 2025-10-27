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
        private bool isMenuVisible = false; // Trạng thái panel menu
        private Timer menuTimer;            // Timer để tạo hiệu ứng
        private int targetWidth = 217;      // Độ rộng tối đa của panelMenu
        private int slideSpeed = 15;        // Tốc độ trượt

        private readonly QuanLyDonHangBUS _bus = new QuanLyDonHangBUS();
        private IconPictureBox iconBell;   // Chuông thông báo
        private Label lblThongBao;         // Hiển thị số lượng đơn chờ
        private Timer timerCapNhat;        // Cập nhật định kỳ
        private ToolTip _toolTipThongBao;  // Tooltip hiển thị khi hover

        public GiaoDienNV()
        {
            InitializeComponent();
        }

        private void GiaoDienNV_Load(object sender, EventArgs e)
        {
            // tránh load khi design
            if(!DesignMode) {return;}
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

            // 🔴 Label thông báo (badge)
            lblThongBao = new Label
            {
                Text = "",
                AutoSize = false,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Red,
                Size = new Size(24, 24),
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false,
                Cursor = Cursors.Hand
            };
            
            btnChuong.Controls.Add(lblThongBao);

            // 🧭 Vị trí badge góc trên phải (dịch để không bị che)
            lblThongBao.Location = new Point(btnChuong.Width - lblThongBao.Width - 8, -3);
            lblThongBao.BringToFront();

            // 🎨 Bo tròn badge
            lblThongBao.Paint += (s, ev) =>
            {
                System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
                gp.AddEllipse(0, 0, lblThongBao.Width - 1, lblThongBao.Height - 1);
                lblThongBao.Region = new Region(gp);
            };
            panelMenu.Width = 0;

            // 🔁 Gán sự kiện click
            lblThongBao.Click += lblBadge_Click;

            // 🟢 Tạo tooltip
            _toolTipThongBao = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 200,
                ReshowDelay = 200,
                ShowAlways = true
            };
            _toolTipThongBao.SetToolTip(btnChuong, "Đang kiểm tra đơn hàng...");

            // 🔄 Kiểm tra thông báo lần đầu
            CapNhatThongBao();

            // ⏱️ Tự động cập nhật mỗi 10 giây
            timerCapNhat = new Timer { Interval = 10000 };
            timerCapNhat.Tick += (s, ev) => CapNhatThongBao();
            timerCapNhat.Start();
            // Khởi tạo Timer cho hiệu ứng trượt
            menuTimer = new Timer();
            menuTimer.Interval = 10; // 10ms mỗi tick => hiệu ứng mượt
            menuTimer.Tick += MenuTimer_Tick;
        }

        private void CapNhatThongBao()
        {
            try
            {
                // 🧾 Lấy danh sách đơn cần duyệt
                var donCho = _bus.LayDanhSachDonHangTheoTrangThai("Đã bán");
                int soLuong = donCho?.Count() ?? 0;

                if (soLuong > 0)
                {
                    lblThongBao.Visible = true;
                    lblThongBao.Text = soLuong > 99 ? "99+" : soLuong.ToString();

                    // 🧩 Tự co giãn theo nội dung
                    int width = (lblThongBao.Text.Length == 1) ? 24 :
                                (lblThongBao.Text.Length == 2) ? 28 : 36;
                    lblThongBao.Size = new Size(width, 24);

                    // 🧭 Cập nhật lại vị trí (vì size thay đổi)
                    lblThongBao.Location = new Point(btnChuong.Width - lblThongBao.Width - 8, -3);

                    // 🎨 Bo tròn lại
                    System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
                    gp.AddEllipse(0, 0, lblThongBao.Width - 1, lblThongBao.Height - 1);
                    lblThongBao.Region = new Region(gp);
                    lblThongBao.Invalidate();

                    // 💬 Cập nhật tooltip
                    _toolTipThongBao.SetToolTip(btnChuong, $"Có {soLuong} đơn hàng đang chờ duyệt");
                }
                else
                {
                    lblThongBao.Visible = false;
                    _toolTipThongBao.SetToolTip(btnChuong, "Không có đơn hàng nào đang chờ duyệt");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật thông báo: " + ex.Message);
            }
        }

        private void btnChuong_Click(object sender, EventArgs e)
        {
            try
            {
                // 🟩 Khi nhấn chuông -> mở giao diện duyệt đơn
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

                // Sau khi đóng form duyệt, cập nhật lại chuông
                CapNhatThongBao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở DuyetDon: " + ex.Message);
            }
        }

        // 🖱️ Click vào dấu "!" cũng mở duyệt đơn
        private void lblBadge_Click(object sender, EventArgs e)
        {
            btnChuong_Click(sender, e);
        }

        private void btnLenDon_Click(object sender, EventArgs e)
        {
            var uc = new LenDon();
            HienThiUserControl(uc);
        }

        private void btnDuyetDon_Click(object sender, EventArgs e)
        {
            var uc = new DuyetDon();
            HienThiUserControl(uc);
        }

        private void btnXemDon_Click(object sender, EventArgs e)
        {
            var uc = new XemDon();
            HienThiUserControl(uc);
        }

        private void btnCaLam_Click(object sender, EventArgs e)
        {
            var uc = new CaLam();
            HienThiUserControl(uc);
        }

      

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            isMenuVisible = !isMenuVisible; // Đảo trạng thái
            menuTimer.Start();              // Kích hoạt hiệu ứng
        }
        private void MenuTimer_Tick(object sender, EventArgs e)
        {
            if (isMenuVisible)
            {
                // Mở rộng panel
                if (panelMenu.Width < targetWidth)
                {
                    panelMenu.Width += slideSpeed;
                    if (panelMenu.Width >= targetWidth)
                    {
                        panelMenu.Width = targetWidth;
                        menuTimer.Stop();
                    }
                }
            }
            else
            {
                // Thu gọn panel
                if (panelMenu.Width > 0)
                {
                    panelMenu.Width -= slideSpeed;
                    if (panelMenu.Width <= 0)
                    {
                        panelMenu.Width = 0;
                        menuTimer.Stop();
                    }
                }
            }
        }

        private void panelhienthi_Paint(object sender, PaintEventArgs e)
        {

        }
        // 🧩 Hàm hiển thị UserControl trong panelhienthi
        private void HienThiUserControl(UserControl uc)
        {
            // Xóa các control cũ
            panelhienthi.Controls.Clear();

            // Cấu hình UC
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();

            // Thêm vào panel hiển thị
            panelhienthi.Controls.Add(uc);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
