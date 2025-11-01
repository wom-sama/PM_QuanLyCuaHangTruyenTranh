using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace PM.GUI.Main
{
    public partial class AdminForm : Form
    {
        // ====== CẤU HÌNH ANIMATION ======
        private const int ANIM_STEP = 150;   // tốc độ di chuyển (px mỗi tick)
        private const int ANIM_INTERVAL = 6; // tốc độ khung hình (ms)
        private bool menuMo = true;          // trạng thái menu
        private Timer animTimer;             // bộ hẹn giờ animation
        private int menuWidth;               // chiều rộng panel ban đầu


        // thuộc tính và phương thức khác của AdminForm...

        public AdminForm()
        {
            InitializeComponent();
            CaiDatAnimation();
        }

        private void CaiDatAnimation()
        {
            animTimer = new Timer();
            animTimer.Interval = ANIM_INTERVAL;
            animTimer.Tick += AnimTimer_Tick;
            menuWidth = shadow_PannelCN.Width;

            // Ẩn panel nếu cần
            menuMo = true;
        }

        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            if (menuMo)
            {
                // hiệu ứng đóng
                if (shadow_PannelCN.Width > 0)
                {
                    shadow_PannelCN.Width -= ANIM_STEP;
                    if (shadow_PannelCN.Width <= 0)
                    {
                        shadow_PannelCN.Width = 0;
                        animTimer.Stop();
                        menuMo = false;
                    }
                }
            }
            else
            {
                // hiệu ứng mở
                if (shadow_PannelCN.Width < menuWidth)
                {
                    shadow_PannelCN.Width += ANIM_STEP;
                    if (shadow_PannelCN.Width >= menuWidth)
                    {
                        shadow_PannelCN.Width = menuWidth;
                        animTimer.Stop();
                        menuMo = true;
                    }
                }
            }
        }

        // Nút mở/đóng menu
        private void btnCN_Click_1(object sender, EventArgs e)
        {
            animTimer.Start();
        }

        // Giữ nguyên load form, không thêm xử lý khác
        private void AdminForm_Load(object sender, EventArgs e)
        {
        }
    }
}
