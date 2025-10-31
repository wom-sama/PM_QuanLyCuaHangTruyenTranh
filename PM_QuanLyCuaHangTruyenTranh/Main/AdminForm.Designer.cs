
namespace PM.GUI.Main
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pannel_CT_CN = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.shadow_PannelCN = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.PanelCN = new Guna.UI2.WinForms.Guna2Panel();
            this.btn_BangLuong = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.btn_LoiLo = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btn_CuaHang = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.Btn_Khach = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.btn_TheLoai = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.btn_Sach = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.btn_QLTK = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.btn_NhanVien = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.btn_DSTG = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.btnKho = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.BtnThem = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.pannel_Admin = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCN = new Guna.UI2.WinForms.Guna2Button();
            this.titleCN = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btn_Chung = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.shadow_PannelCN.SuspendLayout();
            this.PanelCN.SuspendLayout();
            this.pannel_Admin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pannel_CT_CN
            // 
            this.pannel_CT_CN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pannel_CT_CN.BackColor = System.Drawing.Color.White;
            this.pannel_CT_CN.FillColor = System.Drawing.Color.RosyBrown;
            this.pannel_CT_CN.Location = new System.Drawing.Point(296, 193);
            this.pannel_CT_CN.Name = "pannel_CT_CN";
            this.pannel_CT_CN.ShadowColor = System.Drawing.Color.Black;
            this.pannel_CT_CN.Size = new System.Drawing.Size(854, 477);
            this.pannel_CT_CN.TabIndex = 0;
            this.pannel_CT_CN.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2ShadowPanel1_Paint);
            // 
            // shadow_PannelCN
            // 
            this.shadow_PannelCN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.shadow_PannelCN.BackColor = System.Drawing.Color.Transparent;
            this.shadow_PannelCN.Controls.Add(this.PanelCN);
            this.shadow_PannelCN.FillColor = System.Drawing.Color.White;
            this.shadow_PannelCN.Location = new System.Drawing.Point(41, 193);
            this.shadow_PannelCN.Name = "shadow_PannelCN";
            this.shadow_PannelCN.ShadowColor = System.Drawing.Color.Black;
            this.shadow_PannelCN.Size = new System.Drawing.Size(249, 477);
            this.shadow_PannelCN.TabIndex = 1;
            this.shadow_PannelCN.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2ShadowPanel2_Paint);
            // 
            // PanelCN
            // 
            this.PanelCN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PanelCN.AutoScroll = true;
            this.PanelCN.Controls.Add(this.btn_Chung);
            this.PanelCN.Controls.Add(this.btn_BangLuong);
            this.PanelCN.Controls.Add(this.btn_LoiLo);
            this.PanelCN.Controls.Add(this.guna2Button1);
            this.PanelCN.Controls.Add(this.btn_CuaHang);
            this.PanelCN.Controls.Add(this.Btn_Khach);
            this.PanelCN.Controls.Add(this.btn_TheLoai);
            this.PanelCN.Controls.Add(this.btn_Sach);
            this.PanelCN.Controls.Add(this.btn_QLTK);
            this.PanelCN.Controls.Add(this.btn_NhanVien);
            this.PanelCN.Controls.Add(this.btn_DSTG);
            this.PanelCN.Controls.Add(this.btnKho);
            this.PanelCN.Controls.Add(this.BtnThem);
            this.PanelCN.Location = new System.Drawing.Point(3, 3);
            this.PanelCN.Name = "PanelCN";
            this.PanelCN.Size = new System.Drawing.Size(249, 474);
            this.PanelCN.TabIndex = 0;
            this.PanelCN.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCN_Paint);
            // 
            // btn_BangLuong
            // 
            this.btn_BangLuong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_BangLuong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_BangLuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_BangLuong.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_BangLuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_BangLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_BangLuong.ForeColor = System.Drawing.Color.White;
            this.btn_BangLuong.Location = new System.Drawing.Point(0, 460);
            this.btn_BangLuong.Name = "btn_BangLuong";
            this.btn_BangLuong.Size = new System.Drawing.Size(153, 40);
            this.btn_BangLuong.TabIndex = 11;
            this.btn_BangLuong.Text = "xem luong cho nhan vien";
            // 
            // btn_LoiLo
            // 
            this.btn_LoiLo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_LoiLo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_LoiLo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_LoiLo.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_LoiLo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_LoiLo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_LoiLo.ForeColor = System.Drawing.Color.White;
            this.btn_LoiLo.Location = new System.Drawing.Point(0, 414);
            this.btn_LoiLo.Name = "btn_LoiLo";
            this.btn_LoiLo.Size = new System.Drawing.Size(153, 40);
            this.btn_LoiLo.TabIndex = 10;
            this.btn_LoiLo.Text = "Loi Lo";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 15;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(212, 414);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(13, 259);
            this.guna2Button1.TabIndex = 9;
            this.guna2Button1.Text = "Menu";
            // 
            // btn_CuaHang
            // 
            this.btn_CuaHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_CuaHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_CuaHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_CuaHang.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_CuaHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_CuaHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_CuaHang.ForeColor = System.Drawing.Color.White;
            this.btn_CuaHang.Location = new System.Drawing.Point(0, 371);
            this.btn_CuaHang.Name = "btn_CuaHang";
            this.btn_CuaHang.Size = new System.Drawing.Size(202, 40);
            this.btn_CuaHang.TabIndex = 8;
            this.btn_CuaHang.Text = "Thong ke";
            // 
            // Btn_Khach
            // 
            this.Btn_Khach.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Btn_Khach.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Btn_Khach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Btn_Khach.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Btn_Khach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Btn_Khach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Btn_Khach.ForeColor = System.Drawing.Color.White;
            this.Btn_Khach.Location = new System.Drawing.Point(0, 325);
            this.Btn_Khach.Name = "Btn_Khach";
            this.Btn_Khach.Size = new System.Drawing.Size(153, 40);
            this.Btn_Khach.TabIndex = 7;
            this.Btn_Khach.Text = "Khach";
            // 
            // btn_TheLoai
            // 
            this.btn_TheLoai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_TheLoai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_TheLoai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_TheLoai.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_TheLoai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_TheLoai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_TheLoai.ForeColor = System.Drawing.Color.White;
            this.btn_TheLoai.Location = new System.Drawing.Point(-3, 187);
            this.btn_TheLoai.Name = "btn_TheLoai";
            this.btn_TheLoai.Size = new System.Drawing.Size(156, 40);
            this.btn_TheLoai.TabIndex = 6;
            this.btn_TheLoai.Text = "Thể Loại";
            // 
            // btn_Sach
            // 
            this.btn_Sach.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Sach.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Sach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Sach.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Sach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Sach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Sach.ForeColor = System.Drawing.Color.White;
            this.btn_Sach.Location = new System.Drawing.Point(0, 3);
            this.btn_Sach.Name = "btn_Sach";
            this.btn_Sach.Size = new System.Drawing.Size(202, 40);
            this.btn_Sach.TabIndex = 5;
            this.btn_Sach.Text = "Sách";
            // 
            // btn_QLTK
            // 
            this.btn_QLTK.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_QLTK.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_QLTK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_QLTK.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_QLTK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_QLTK.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_QLTK.ForeColor = System.Drawing.Color.White;
            this.btn_QLTK.Location = new System.Drawing.Point(0, 233);
            this.btn_QLTK.Name = "btn_QLTK";
            this.btn_QLTK.Size = new System.Drawing.Size(202, 40);
            this.btn_QLTK.TabIndex = 4;
            this.btn_QLTK.Text = "Quản Lý Tai Khoan";
            this.btn_QLTK.Click += new System.EventHandler(this.guna2GradientTileButton4_Click);
            // 
            // btn_NhanVien
            // 
            this.btn_NhanVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_NhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_NhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_NhanVien.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_NhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_NhanVien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_NhanVien.ForeColor = System.Drawing.Color.White;
            this.btn_NhanVien.Location = new System.Drawing.Point(0, 279);
            this.btn_NhanVien.Name = "btn_NhanVien";
            this.btn_NhanVien.Size = new System.Drawing.Size(153, 40);
            this.btn_NhanVien.TabIndex = 3;
            this.btn_NhanVien.Text = "Nhan Vien";
            // 
            // btn_DSTG
            // 
            this.btn_DSTG.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_DSTG.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_DSTG.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_DSTG.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_DSTG.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_DSTG.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_DSTG.ForeColor = System.Drawing.Color.White;
            this.btn_DSTG.Location = new System.Drawing.Point(-3, 141);
            this.btn_DSTG.Name = "btn_DSTG";
            this.btn_DSTG.Size = new System.Drawing.Size(156, 40);
            this.btn_DSTG.TabIndex = 2;
            this.btn_DSTG.Text = "Danh sách tác Giả";
            this.btn_DSTG.Click += new System.EventHandler(this.btn_DSTG_Click);
            // 
            // btnKho
            // 
            this.btnKho.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKho.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKho.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKho.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKho.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKho.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnKho.ForeColor = System.Drawing.Color.White;
            this.btnKho.Location = new System.Drawing.Point(0, 95);
            this.btnKho.Name = "btnKho";
            this.btnKho.Size = new System.Drawing.Size(153, 40);
            this.btnKho.TabIndex = 1;
            this.btnKho.Text = "Kho Sách";
            this.btnKho.Click += new System.EventHandler(this.guna2GradientTileButton1_Click);
            // 
            // BtnThem
            // 
            this.BtnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnThem.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnThem.ForeColor = System.Drawing.Color.White;
            this.BtnThem.Location = new System.Drawing.Point(-3, 49);
            this.BtnThem.Name = "BtnThem";
            this.BtnThem.Size = new System.Drawing.Size(156, 40);
            this.BtnThem.TabIndex = 0;
            this.BtnThem.Text = "Thêm Sách";
            this.BtnThem.Click += new System.EventHandler(this.BtnThem_Click);
            // 
            // pannel_Admin
            // 
            this.pannel_Admin.AutoScroll = true;
            this.pannel_Admin.Controls.Add(this.btnCN);
            this.pannel_Admin.Controls.Add(this.titleCN);
            this.pannel_Admin.Controls.Add(this.shadow_PannelCN);
            this.pannel_Admin.Controls.Add(this.pannel_CT_CN);
            this.pannel_Admin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pannel_Admin.Location = new System.Drawing.Point(0, 0);
            this.pannel_Admin.Name = "pannel_Admin";
            this.pannel_Admin.Size = new System.Drawing.Size(1188, 702);
            this.pannel_Admin.TabIndex = 30;
            this.pannel_Admin.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // btnCN
            // 
            this.btnCN.BorderRadius = 15;
            this.btnCN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCN.ForeColor = System.Drawing.Color.White;
            this.btnCN.Location = new System.Drawing.Point(31, 57);
            this.btnCN.Name = "btnCN";
            this.btnCN.Size = new System.Drawing.Size(90, 45);
            this.btnCN.TabIndex = 3;
            this.btnCN.Text = "Menu";
            this.btnCN.Click += new System.EventHandler(this.btnCN_Click);
            // 
            // titleCN
            // 
            this.titleCN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.titleCN.AutoSize = false;
            this.titleCN.BackColor = System.Drawing.Color.Transparent;
            this.titleCN.Enabled = false;
            this.titleCN.Font = new System.Drawing.Font("Monotype Corsiva", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleCN.Location = new System.Drawing.Point(141, 13);
            this.titleCN.Name = "titleCN";
            this.titleCN.Size = new System.Drawing.Size(1009, 151);
            this.titleCN.TabIndex = 2;
            this.titleCN.Text = "Chuc Nang";
            this.titleCN.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.titleCN.Click += new System.EventHandler(this.titleCN_Click);
            // 
            // btn_Chung
            // 
            this.btn_Chung.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Chung.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Chung.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Chung.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Chung.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Chung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Chung.ForeColor = System.Drawing.Color.White;
            this.btn_Chung.Location = new System.Drawing.Point(0, 506);
            this.btn_Chung.Name = "btn_Chung";
            this.btn_Chung.Size = new System.Drawing.Size(202, 40);
            this.btn_Chung.TabIndex = 12;
            this.btn_Chung.Text = "Cai dat chung";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(1188, 702);
            this.Controls.Add(this.pannel_Admin);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AdminForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.shadow_PannelCN.ResumeLayout(false);
            this.PanelCN.ResumeLayout(false);
            this.pannel_Admin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel pannel_CT_CN;
        private Guna.UI2.WinForms.Guna2ShadowPanel shadow_PannelCN;
        private Guna.UI2.WinForms.Guna2Panel PanelCN;
        private Guna.UI2.WinForms.Guna2Panel pannel_Admin;
        private Guna.UI2.WinForms.Guna2HtmlLabel titleCN;
        private Guna.UI2.WinForms.Guna2GradientTileButton BtnThem;
        private Guna.UI2.WinForms.Guna2GradientTileButton btnKho;
        private Guna.UI2.WinForms.Guna2Button btnCN;
        private Guna.UI2.WinForms.Guna2GradientTileButton btn_QLTK;
        private Guna.UI2.WinForms.Guna2GradientTileButton btn_DSTG;
        private Guna.UI2.WinForms.Guna2GradientTileButton btn_NhanVien;
        private Guna.UI2.WinForms.Guna2GradientTileButton btn_Sach;
        private Guna.UI2.WinForms.Guna2GradientTileButton btn_TheLoai;
        private Guna.UI2.WinForms.Guna2GradientTileButton btn_CuaHang;
        private Guna.UI2.WinForms.Guna2GradientTileButton Btn_Khach;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2GradientTileButton btn_BangLuong;
        private Guna.UI2.WinForms.Guna2GradientTileButton btn_LoiLo;
        private Guna.UI2.WinForms.Guna2GradientTileButton btn_Chung;
    }
}