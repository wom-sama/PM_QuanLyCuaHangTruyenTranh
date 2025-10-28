using PM.BUS.Services.Sachsv;
using PM.DAL.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PM.GUI.FormThongBao;

namespace PM.GUI.userConTrol.Common
{
    public partial class BooKShowcs : UserControl
    {
        private readonly SachService sachService = new SachService();
        private Sach sach = new Sach();
        private FormMessage f;

        private Timer hoverDelayTimer;
        private Timer fadeTimer;
        private bool isHovering = false;
        private double opacity = 0;
        private bool fadingOut = false;

        // ============================
        // 🔹 Khai báo sự kiện click
        // ============================
        public event EventHandler<Sach> OnBookClick;

        // Biến lưu trạng thái chọn
        private static BooKShowcs currentlySelected = null;
        private bool isSelected = false;

        public BooKShowcs()
        {
            InitializeComponent();
            InitTimers();
        }

        public BooKShowcs(Sach book)
        {
            InitializeComponent();
            sach = book;
            InitTimers();
        }

        private void BooKShowcs_Load(object sender, EventArgs e)
        {
            try
            {
                //tenSachlbl.ReadOnly = true;
                picBia.BorderRadius = 10;
                picBia.FillColor = Color.FromArgb(245, 245, 245);
                picBia.SizeMode = PictureBoxSizeMode.Zoom;
                picBia.Cursor = Cursors.Hand;

                guna2ShadowPanel1.Radius = 15;
                guna2ShadowPanel1.ShadowDepth = 40;
                guna2ShadowPanel1.ShadowShift = 5;
                guna2ShadowPanel1.ShadowColor = Color.FromArgb(120, 0, 0, 0);
                guna2ShadowPanel1.FillColor = Color.White;

                // 📘 Gán sự kiện click cho toàn control
                this.Click += BooKShowcs_Click;
                picBia.Click += BooKShowcs_Click;
                tenSachlbl.Click += BooKShowcs_Click;
                guna2ShadowPanel1.Click += BooKShowcs_Click;

                if (sach == null || string.IsNullOrEmpty(sach.MaSach))
                {
                    tenSachlbl.Text = "Không xác định";
                    picBia.Image = Properties.Resources.sparkle_hanabi;
                    return;
                }

                var sachMoi = sachService.GetById(sach.MaSach);
                if (sachMoi != null)
                    sach = sachMoi;

                tenSachlbl.Text = sach.TenSach ?? "Không có tên";

                if (sach.BiaSach != null && sach.BiaSach.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(sach.BiaSach))
                        picBia.Image = Image.FromStream(ms);
                }
                else
                {
                    picBia.Image = Properties.Resources.sparkle_hanabi;
                }
                Edit_Lable.AdjustFontSize(this.tenSachlbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin sách: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================
        // 🕒 Khởi tạo Timer
        // ===============================
        private void InitTimers()
        {
            hoverDelayTimer = new Timer { Interval = 1000 };
            hoverDelayTimer.Tick += HoverDelayTimer_Tick;

            fadeTimer = new Timer { Interval = 20 };
            fadeTimer.Tick += FadeTimer_Tick;

            picBia.MouseMove += PicBia_MouseMove; // Di chuyển form theo chuột
        }

        // ===============================
        // 🖱️ Sự kiện chuột (hover)
        // ===============================
        private void picBia_MouseEnter(object sender, EventArgs e)
        {
            isHovering = true;
            hoverDelayTimer.Stop();
            hoverDelayTimer.Start();
        }

        private void picBia_MouseLeave(object sender, EventArgs e)
        {
            isHovering = false;
            hoverDelayTimer.Stop();

            if (!isSelected)
            {
                guna2ShadowPanel1.ShadowColor = Color.FromArgb(120, 0, 0, 0);
                guna2ShadowPanel1.ShadowDepth = 40;
                guna2ShadowPanel1.FillColor = Color.White;
            }

            StartFadeOut();
        }

        private void PicBia_MouseMove(object sender, MouseEventArgs e)
        {
            if (f != null && f.Visible && !fadingOut)
            {
                Point cursorPos = Cursor.Position;
                f.Location = new Point(cursorPos.X + 15, cursorPos.Y + 15);
            }
        }

        // ===============================
        // ⏳ Delay trước khi show tooltip
        // ===============================
        private void HoverDelayTimer_Tick(object sender, EventArgs e)
        {
            hoverDelayTimer.Stop();
            if (!isHovering) return;

            guna2ShadowPanel1.ShadowColor = Color.FromArgb(180, 60, 60, 60);
            guna2ShadowPanel1.ShadowDepth = 60;
            guna2ShadowPanel1.FillColor = Color.FromArgb(250, 250, 250);

            ShowFormMessage();
        }

        // ===============================
        // 🌫️ Hiển thị form + fade-in
        // ===============================
        private void ShowFormMessage()
        {
            try
            {
                if (f == null || f.IsDisposed)
                    f = new FormMessage(sach?.TenSach ?? "Thông tin sách");

                if (!f.IsHandleCreated)
                    f.CreateControl();

                Point cursorPos = Cursor.Position;
                f.StartPosition = FormStartPosition.Manual;
                f.Location = new Point(cursorPos.X + 15, cursorPos.Y + 15);
                f.TopMost = true;

                if (!f.Visible)
                    f.Show();

                f.Opacity = 0; // ⚙️ Không lỗi vì đã có handle
                opacity = 0;
                fadingOut = false;
                fadeTimer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("⚠️ Lỗi ShowFormMessage: " + ex.Message);
            }
        }

        // ===============================
        // 🌫️ Fade hiệu ứng (in & out)
        // ===============================
        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            if (f == null || f.IsDisposed) { fadeTimer.Stop(); return; }

            try
            {
                if (!fadingOut)
                {
                    opacity += 0.1;
                    if (opacity >= 1)
                    {
                        opacity = 1;
                        fadeTimer.Stop();
                    }
                }
                else
                {
                    opacity -= 0.1;
                    if (opacity <= 0)
                    {
                        opacity = 0;
                        fadeTimer.Stop();
                        f.Hide();
                    }
                }

                if (f.IsHandleCreated)
                    f.Opacity = opacity;
            }
            catch
            {
                fadeTimer.Stop();
            }
        }

        private void StartFadeOut()
        {
            if (f == null || f.IsDisposed || !f.Visible) return;

            fadingOut = true;
            fadeTimer.Start();
        }

        // ===============================
        // 📘 Sự kiện click chọn sách
        // ===============================
        private void BooKShowcs_Click(object sender, EventArgs e)
        {
            // Nếu đã có item khác được chọn → bỏ chọn nó
            if (currentlySelected != null && currentlySelected != this)
                currentlySelected.Unselect();

            SelectThis(); // chọn item hiện tại
            currentlySelected = this;

            // Gọi sự kiện ra ngoài
            OnBookClick?.Invoke(this, sach);
        }

        private void SelectThis()
        {
            isSelected = true;
            guna2ShadowPanel1.FillColor = Color.FromArgb(230, 245, 255);
            guna2ShadowPanel1.ShadowColor = Color.FromArgb(80, 120, 200);
            guna2ShadowPanel1.ShadowDepth = 70;
        }

        public void Unselect()
        {
            isSelected = false;
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.ShadowColor = Color.FromArgb(120, 0, 0, 0);
            guna2ShadowPanel1.ShadowDepth = 40;
        }

        // ===============================
        // 🔧 Khác
        // ===============================
        private void txtNameBook_TextChanged(object sender, EventArgs e) { }
        private void txtNameBook_MouseEnter(object sender, EventArgs e) { this.ActiveControl = null; }
        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e) { }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
