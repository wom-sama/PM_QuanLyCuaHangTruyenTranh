using FontAwesome.Sharp;
using PM.BUS.Services.Facade;
using PM.GUI.userConTrol.Employee;
using PM.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PM.GUI.userConTrol.Common;

namespace PM.GUI.Main
{
    public partial class NhanVienForm : Form
    {
        private bool isMenuVisible = false; // Trạng thái panel menu
        private Timer menuTimer;            // Timer để tạo hiệu ứng
        private int targetWidth = 160;      // Độ rộng tối đa của panelMenu  
        private int slideSpeed = 200;        // Tốc độ trượt

        private readonly QuanLyDonHangBUS _bus = new QuanLyDonHangBUS();
        private IconPictureBox iconBell;   // Chuông thông báo
        private Label lblThongBao;         // Hiển thị số lượng đơn chờ
        private Timer timerCapNhat;        // Cập nhật định kỳ
        private ToolTip _toolTipThongBao;  // Tooltip hiển thị khi hover
        private Timer timerPanelHienThi;
        private int targetHeightPanelHienThi = 1200; // chiều cao bạn muốn
        private int slideSpeedPanel = 15;

        // Biến Chứa nhân viên hiện tại
        private NhanVien currentNV;
        public NhanVienForm()
        {
            InitializeComponent();
        }

        public NhanVienForm(NhanVien nv)
        {
            currentNV = nv;
            InitializeComponent();
            panelMenu.BackColor = Color.Transparent;
            panelMenu.Parent = pannelGD_tong; // nếu pannelGD_tong là nền chính
            guna2Button1.Visible = false;

            panelMenu.BringToFront();

        }
        private void CapNhatThongBao()
        {
            try
            {
                // ✅ Đếm đơn hàng chờ duyệt theo chi nhánh của nhân viên hiện tại
                int soLuong = _bus.DemDonHangChoXuLyTheoChiNhanh(currentNV.MaChiNhanh);

                if (soLuong > 0)
                {
                    lblThongBao.Visible = true;
                    lblThongBao.Text = soLuong > 99 ? "99+" : soLuong.ToString();
                    int width = (lblThongBao.Text.Length == 1) ? 24 :
                                (lblThongBao.Text.Length == 2) ? 28 : 36;
                    lblThongBao.Size = new Size(width, 24);
                    lblThongBao.Location = new Point(btnChuong.Width - lblThongBao.Width - 8, -3);
                    System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
                    gp.AddEllipse(0, 0, lblThongBao.Width - 1, lblThongBao.Height - 1);
                    lblThongBao.Region = new Region(gp);
                    lblThongBao.Invalidate();

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


        private void NhanVienForm_Load(object sender, EventArgs e)
        {
            // tránh load khi design
            if (DesignMode) { return; }
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
           // this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            //  Label thông báo (badge)
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
            panelhienthi.Height = 0; // bắt đầu từ 0
            timerPanelHienThi = new Timer();
            timerPanelHienThi.Interval = 10;
            timerPanelHienThi.Tick += TimerPanelHienThi_Tick;
            timerPanelHienThi.Start();           

            // Đăng ký sự kiện BUS -> cập nhật chuông khi có đơn mới duyệt
            _bus.OnDonHangDuyet += () => CapNhatThongBao();
            _bus.OnDonHangHoanTat += () => CapNhatThongBao();

        }

        private void btnChuong_Click(object sender, EventArgs e)
        {
            try
            {
                // 🟩 Khi nhấn chuông -> mở giao diện duyệt đơn
                DuyetDon duyetDonUC = new DuyetDon(_bus, currentNV);  // ✅ truyền nhân viên hiện tại

                duyetDonUC.OnDonHangDuyet += () => CapNhatThongBao();
                // 🔔 Khi duyệt thành công trong UC => cập nhật lại chuông ngay
                Form form = new Form
                {
                    Text = "Duyệt đơn hàng",
                    Width = 1000,
                    Height = 600,
                    StartPosition = FormStartPosition.CenterScreen
                };

                duyetDonUC.Dock = DockStyle.Fill;
                form.Controls.Add(duyetDonUC);

                // 🔁 Khi form con đóng => cập nhật lại chuông lần nữa (đảm bảo sync DB)
                form.FormClosed += (s, ev) => CapNhatThongBao();

                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở DuyetDon: " + ex.Message);
            }
        }


        //  Click vào dấu "!" cũng mở duyệt đơn
        private void lblBadge_Click(object sender, EventArgs e)
        {
            btnChuong_Click(sender, e);
        }

        private void btnLenDon_Click(object sender, EventArgs e)
        {
            var uc = new LenDon(currentNV);
            HienThiUserControl(uc);
        }

        private void btnDuyetDon_Click(object sender, EventArgs e)
        {
            var uc = new DuyetDon(_bus, currentNV);  // ✅ truyền nhân viên hiện tại
            uc.OnDonHangDuyet += () => CapNhatThongBao(); // 🔔 đồng bộ chuông
            HienThiUserControl(uc);
        }

        private void btnXemDon_Click(object sender, EventArgs e)
        {
            var uc = new XemDon(currentNV);
            HienThiUserControl(uc);
        }

        private void btnCaLam_Click(object sender, EventArgs e)
        {
            var uc = new CaLam(currentNV.MaNV); // ✅ chỉ xem được ca của mình
            HienThiUserControl(uc);
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

        //  Hàm hiển thị UserControl trong panelhienthi
        private void HienThiUserControl(UserControl uc)
        {
            // Xóa các control cũ
            panelhienthi.Controls.Clear();

            // Thêm UC mới nhưng để panel bắt đầu từ chiều cao 0
            panelhienthi.Height = 0;
            panelhienthi.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();

            // Bật timer trượt lên
            timerPanelHienThi.Start();
        }
        private void TimerPanelHienThi_Tick(object sender, EventArgs e)
        {
            if (panelhienthi.Height < targetHeightPanelHienThi)
            {
                panelhienthi.Height += slideSpeedPanel;
                if (panelhienthi.Height >= targetHeightPanelHienThi)
                {
                    panelhienthi.Height = targetHeightPanelHienThi;
                    timerPanelHienThi.Stop();
                }
            }
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            guna2Button1.Visible = false;
            var uc = new userConTrol.Employee.Kho(HienThiUserControl); //  truyền delegate
            HienThiUserControl(uc);
        }

        private void btnGiaoHang_Click(object sender, EventArgs e)
        {
            guna2Button1.Visible = false;
            var uc = new GiaoHang(currentNV);
            HienThiUserControl(uc);
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            isMenuVisible = !isMenuVisible; // Đảo trạng thái
            menuTimer.Start();              // Kích hoạt hiệu ứng
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            guna2Button1.Visible = false;
            var ucThongBao = new PM.GUI.userConTrol.Employee.ThongBao(currentNV);
            HienThiUserControl(ucThongBao);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button1.Visible = false;
            var uc = new XemLuong(currentNV.MaNV);
            HienThiUserControl(uc);
        }

        private void btnThongTin_Click_1(object sender, EventArgs e)
        {
            var uc = new CaNhan(currentNV.MaNV);
            // 👉 Hiện nút guna2Button1 khi bấm vào Thông tin
            guna2Button1.Visible = true;
            HienThiUserControl(uc);
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            var uc =  new ShowTTCN(currentNV.MaNV);
            HienThiUserControl(uc);
        }
        
    }
}
