using Guna.UI2.WinForms;
using PM.DAL.Models;
using PM.GUI.userConTrol.Admin;
using PM.GUI.userConTrol.Common;
using System;
using PM.BUS.Services;
using System.Drawing;
using System.Windows.Forms;
using PM.BUS.Services.TaiKhoansv;

namespace PM.GUI.Main
{
    public partial class AdminForm : Form
    {
        // ====== CẤU HÌNH ANIMATION ======
        private const int ANIM_STEP = 15;   // tốc độ di chuyển (px mỗi tick)
        private const int ANIM_INTERVAL = 10; // tốc độ khung hình (ms)
        private bool menuMo = true;          // trạng thái menu
        private Timer animTimer;             // bộ hẹn giờ animation
        private int menuWidth;               // chiều rộng panel ban đầu


        // ===== ANIMATION PANEL CON =====
        private const int ANIM_CT_STEP = 25;    // tốc độ di chuyển
        private const int ANIM_CT_INTERVAL = 10; // tốc độ khung hình
        private Timer animCTTimer;               // bộ hẹn giờ animation panel con
        private bool ctDangHien = false;         // trạng thái panel con
        private string nutDangMo = "";           // tên nút đang mở
        private int viTriYBanDau;                // vị trí Y ban đầu (ẩn dưới)
        private int viTriYDich;                  // vị trí Y khi hiển thị
        private bool dangDongCT = false; // ngăn việc nhấn khi đang đóng

        // thuộc tính và phương thức khác của AdminForm...
        // biến nhân    viên hiện tại
        NhanVien currentNV= new NhanVienService().GetById("NV01");
        //



        public AdminForm()
        {
            InitializeComponent();
            CaiDatAnimation();
            CaiDatAnimationCT();
        }
        public AdminForm(NhanVien main9)
        {
            currentNV = main9;
            InitializeComponent();
            CaiDatAnimation();
            CaiDatAnimationCT();
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

        // chuyển động của panel chức năng con
        private void CaiDatAnimationCT()
        {
            animCTTimer = new Timer();
            animCTTimer.Interval = ANIM_CT_INTERVAL;
            animCTTimer.Tick += AnimCTTimer_Tick;

            viTriYBanDau = this.Height;                 // vị trí ban đầu (ẩn)
            viTriYDich = this.Height - pannel_CT_CN.Height - 50; // vị trí khi hiện

            pannel_CT_CN.Top = viTriYBanDau; // ẩn panel con dưới màn hình
            pannel_CT_CN.Visible = false;
        }


        private string pendingNut = null; // nút yêu cầu mở sau khi đóng xong

        private void AnimCTTimer_Tick(object sender, EventArgs e)
        {
            if (dangDongCT)
            {
                // trượt sang phải (ẩn)
                if (pannel_CT_CN.Left < this.Width)
                {
                    pannel_CT_CN.Left += ANIM_CT_STEP;
                    return;
                }

                // ======= ĐÃ ẨN HOÀN TOÀN =======
                animCTTimer.Stop();
                pannel_CT_CN.Visible = false;
                ctDangHien = false;
                dangDongCT = false;

                // ⚡️ Nếu có yêu cầu mở panel khác đang chờ
                if (!string.IsNullOrEmpty(pendingNut))
                {
                    string nutCanMo = pendingNut;
                    pendingNut = null;
                    nutDangMo = nutCanMo;

                    // 🔸 Load control mới
                    pannel_CT_CN.Controls.Clear();
                    var newUC = TaiControlChoNut(nutCanMo);
                    if (newUC != null)
                        pannel_CT_CN.Controls.Add(newUC);

                    // Chuẩn bị vị trí hiển thị
                    pannel_CT_CN.Left = (this.Width - pannel_CT_CN.Width) / 2;
                    pannel_CT_CN.Top = viTriYBanDau;
                    pannel_CT_CN.Visible = true;

                    // Khởi động animation mở lại
                    animCTTimer.Start();
                }

                return;
            }

            // ======= MỞ PANEL =======
            if (pannel_CT_CN.Top > viTriYDich)
            {
                pannel_CT_CN.Top -= ANIM_CT_STEP;
                return;
            }

            // Mở xong
            animCTTimer.Stop();
            ctDangHien = true;
        }


        // ===== thay thế MoPanelConTheoNut để dùng pendingNut, tránh timer thứ cấp =====
        private void MoPanelConTheoNut(string tenNut)
        {
            // Nếu timer đang chạy => queue xử lý sau
            if (animCTTimer.Enabled)
            {
                if (ctDangHien && nutDangMo == tenNut)
                {
                    pendingNut = "";
                    return;
                }

                pendingNut = tenNut;
                return;
            }

            // Nếu panel đang mở và bấm cùng nút => đóng
            if (ctDangHien && nutDangMo == tenNut)
            {
                nutDangMo = "";
                dangDongCT = true;
                animCTTimer.Start();
                return;
            }

            // Nếu panel đang mở nhưng bấm nút khác => đặt pendingNut rồi đóng
            if (ctDangHien && nutDangMo != tenNut)
            {
                pendingNut = tenNut;
                dangDongCT = true;
                animCTTimer.Start();
                return;
            }

            // Nếu panel đang ẩn => mở trực tiếp (fix lỗi lần đầu không load)
            if (!ctDangHien)
            {
                nutDangMo = tenNut;

                // 🔸 Load control mới
                pannel_CT_CN.Controls.Clear();
                var newUC = TaiControlChoNut(tenNut);
                if (newUC != null)
                    pannel_CT_CN.Controls.Add(newUC);

                // Chuẩn bị vị trí hiển thị
                pannel_CT_CN.Left = (this.Width - pannel_CT_CN.Width) / 2;
                pannel_CT_CN.Top = viTriYBanDau;
                pannel_CT_CN.Visible = true;

                // Bắt đầu animation mở
                animCTTimer.Start();
                return;
            }
        }




        // Cac su kien
        private void AdminForm_Load(object sender, EventArgs e)
        {
        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            Edit_Lable.AdjustFontSize(lbl_titleCN);
            MoPanelConTheoNut("NhanVien");
            

        }
        private UserControl TaiControlChoNut(string nut)
        {
            switch (nut)
            {
                case "BtnThem":
                    return new Add_Book(currentNV) { Dock = DockStyle.Fill };
                case "btnKho":
                    return new Edit_BOOk(currentNV) { Dock = DockStyle.Fill };
               case "btn_DSTG":
                   return new Edit_TacGia { Dock = DockStyle.Fill };
               case "btn_LoiLo":
                   return new ucThongKeLoiNhuan { Dock = DockStyle.Fill };



                default:
                    return null;
            }
        }








        private void BtnThem_Click(object sender, EventArgs e)
        {
         
            
            MoPanelConTheoNut("BtnThem");
            btnCN_Click_1(sender, e);
        }

        private void btnKho_Click(object sender, EventArgs e)
        {

            
            MoPanelConTheoNut("btnKho");
            btnCN_Click_1(sender, e);

        }

        private void btn_DSTG_Click(object sender, EventArgs e)
        {
            MoPanelConTheoNut("btn_DSTG");
            btnCN_Click_1(sender, e);
        }

        private void btn_LoiLo_Click(object sender, EventArgs e)
        {
            MoPanelConTheoNut("btn_LoiLo");
            btnCN_Click_1(sender, e);

        }
    }
    }

