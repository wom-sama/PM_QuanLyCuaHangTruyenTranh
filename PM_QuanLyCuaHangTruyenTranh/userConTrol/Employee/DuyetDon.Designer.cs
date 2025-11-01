using System.Windows.Forms;

namespace PM.GUI.userConTrol.Employee
{
    partial class DuyetDon
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDonHang;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChiTiet;
        private Guna.UI2.WinForms.Guna2Button btnDuyetDon;
        private Guna.UI2.WinForms.Guna2Button btnTaiLai;
        private Guna.UI2.WinForms.Guna2Panel panelThongTin;

        private Label lblTenKhach;
        private Label lblSDT;
        private Label lblEmail;
        private Label lblDiaChi;
        private Label lblDonViVC;
        private Label lblTongTien;
        private Label lblNgayDat;
        private Label lblNgayGiao;
        private Label lblTitleDonHang;
        private Label lblTitleChiTiet;
        private Label lblHTTT;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvDonHang = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelThongTin = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTenKhach = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblDonViVC = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblNgayDat = new System.Windows.Forms.Label();
            this.lblNgayGiao = new System.Windows.Forms.Label();
            this.lblHTTT = new System.Windows.Forms.Label();
            this.dgvChiTiet = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnDuyetDon = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaiLai = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitleDonHang = new System.Windows.Forms.Label();
            this.lblTitleChiTiet = new System.Windows.Forms.Label();
            this.btnKhongDuyet = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
            this.panelThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.btnKhongDuyet);
            this.panelMain.Controls.Add(this.dgvDonHang);
            this.panelMain.Controls.Add(this.panelThongTin);
            this.panelMain.Controls.Add(this.dgvChiTiet);
            this.panelMain.Controls.Add(this.btnDuyetDon);
            this.panelMain.Controls.Add(this.btnTaiLai);
            this.panelMain.Controls.Add(this.lblTitleDonHang);
            this.panelMain.Controls.Add(this.lblTitleChiTiet);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.FillColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1386, 774);
            this.panelMain.TabIndex = 0;
            // 
            // dgvDonHang
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvDonHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            this.dgvDonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDonHang.ColumnHeadersHeight = 35;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDonHang.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDonHang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDonHang.Location = new System.Drawing.Point(23, 108);
            this.dgvDonHang.Name = "dgvDonHang";
            this.dgvDonHang.RowHeadersVisible = false;
            this.dgvDonHang.RowHeadersWidth = 62;
            this.dgvDonHang.RowTemplate.Height = 30;
            this.dgvDonHang.Size = new System.Drawing.Size(650, 500);
            this.dgvDonHang.TabIndex = 0;
            this.dgvDonHang.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDonHang.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDonHang.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDonHang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDonHang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDonHang.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDonHang.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDonHang.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDonHang.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDonHang.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDonHang.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDonHang.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDonHang.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvDonHang.ThemeStyle.ReadOnly = false;
            this.dgvDonHang.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDonHang.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDonHang.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDonHang.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDonHang.ThemeStyle.RowsStyle.Height = 30;
            this.dgvDonHang.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            this.dgvDonHang.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDonHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonHang_CellClick);
            this.dgvDonHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonHang_CellContentClick_1);
            // 
            // panelThongTin
            // 
            this.panelThongTin.BackColor = System.Drawing.Color.Transparent;
            this.panelThongTin.BorderRadius = 10;
            this.panelThongTin.Controls.Add(this.lblTenKhach);
            this.panelThongTin.Controls.Add(this.lblSDT);
            this.panelThongTin.Controls.Add(this.lblEmail);
            this.panelThongTin.Controls.Add(this.lblDiaChi);
            this.panelThongTin.Controls.Add(this.lblDonViVC);
            this.panelThongTin.Controls.Add(this.lblTongTien);
            this.panelThongTin.Controls.Add(this.lblNgayDat);
            this.panelThongTin.Controls.Add(this.lblNgayGiao);
            this.panelThongTin.Controls.Add(this.lblHTTT);
            this.panelThongTin.FillColor = System.Drawing.Color.White;
            this.panelThongTin.Location = new System.Drawing.Point(720, 108);
            this.panelThongTin.Name = "panelThongTin";
            this.panelThongTin.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.panelThongTin.ShadowDecoration.Depth = 10;
            this.panelThongTin.ShadowDecoration.Enabled = true;
            this.panelThongTin.Size = new System.Drawing.Size(600, 255);
            this.panelThongTin.TabIndex = 1;
            // 
            // lblTenKhach
            // 
            this.lblTenKhach.Location = new System.Drawing.Point(0, 0);
            this.lblTenKhach.Name = "lblTenKhach";
            this.lblTenKhach.Size = new System.Drawing.Size(100, 23);
            this.lblTenKhach.TabIndex = 0;
            // 
            // lblSDT
            // 
            this.lblSDT.Location = new System.Drawing.Point(0, 0);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(100, 23);
            this.lblSDT.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(0, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 2;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Location = new System.Drawing.Point(0, 0);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(100, 23);
            this.lblDiaChi.TabIndex = 3;
            // 
            // lblDonViVC
            // 
            this.lblDonViVC.Location = new System.Drawing.Point(0, 0);
            this.lblDonViVC.Name = "lblDonViVC";
            this.lblDonViVC.Size = new System.Drawing.Size(100, 23);
            this.lblDonViVC.TabIndex = 4;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Location = new System.Drawing.Point(0, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(100, 23);
            this.lblTongTien.TabIndex = 5;
            // 
            // lblNgayDat
            // 
            this.lblNgayDat.Location = new System.Drawing.Point(0, 0);
            this.lblNgayDat.Name = "lblNgayDat";
            this.lblNgayDat.Size = new System.Drawing.Size(100, 23);
            this.lblNgayDat.TabIndex = 6;
            // 
            // lblNgayGiao
            // 
            this.lblNgayGiao.Location = new System.Drawing.Point(0, 0);
            this.lblNgayGiao.Name = "lblNgayGiao";
            this.lblNgayGiao.Size = new System.Drawing.Size(100, 23);
            this.lblNgayGiao.TabIndex = 7;
            // 
            // dgvChiTiet
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvChiTiet.ColumnHeadersHeight = 35;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvChiTiet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.Location = new System.Drawing.Point(720, 453);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowHeadersWidth = 62;
            this.dgvChiTiet.RowTemplate.Height = 30;
            this.dgvChiTiet.Size = new System.Drawing.Size(600, 400);
            this.dgvChiTiet.TabIndex = 2;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvChiTiet.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChiTiet.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvChiTiet.ThemeStyle.ReadOnly = false;
            this.dgvChiTiet.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTiet.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChiTiet.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvChiTiet.ThemeStyle.RowsStyle.Height = 30;
            this.dgvChiTiet.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnDuyetDon
            // 
            this.btnDuyetDon.BorderRadius = 10;
            this.btnDuyetDon.FillColor = System.Drawing.Color.ForestGreen;
            this.btnDuyetDon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDuyetDon.ForeColor = System.Drawing.Color.White;
            this.btnDuyetDon.Location = new System.Drawing.Point(175, 628);
            this.btnDuyetDon.Name = "btnDuyetDon";
            this.btnDuyetDon.Size = new System.Drawing.Size(200, 55);
            this.btnDuyetDon.TabIndex = 3;
            this.btnDuyetDon.Text = "✅ Duyệt đơn";
            this.btnDuyetDon.Click += new System.EventHandler(this.BtnDuyetDon_Click);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.BorderRadius = 10;
            this.btnTaiLai.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnTaiLai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTaiLai.ForeColor = System.Drawing.Color.White;
            this.btnTaiLai.Location = new System.Drawing.Point(405, 628);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(200, 55);
            this.btnTaiLai.TabIndex = 4;
            this.btnTaiLai.Text = "🔄 Tải lại";
            this.btnTaiLai.Click += new System.EventHandler(this.BtnTaiLai_Click);
            // 
            // lblTitleDonHang
            // 
            this.lblTitleDonHang.AutoSize = true;
            this.lblTitleDonHang.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleDonHang.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitleDonHang.Location = new System.Drawing.Point(50, 30);
            this.lblTitleDonHang.Name = "lblTitleDonHang";
            this.lblTitleDonHang.Size = new System.Drawing.Size(482, 38);
            this.lblTitleDonHang.TabIndex = 5;
            this.lblTitleDonHang.Text = "📦 Danh sách đơn hàng đang xử lý";
            // 
            // lblTitleChiTiet
            // 
            this.lblTitleChiTiet.AutoSize = true;
            this.lblTitleChiTiet.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleChiTiet.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitleChiTiet.Location = new System.Drawing.Point(740, 30);
            this.lblTitleChiTiet.Name = "lblTitleChiTiet";
            this.lblTitleChiTiet.Size = new System.Drawing.Size(438, 38);
            this.lblTitleChiTiet.TabIndex = 6;
            this.lblTitleChiTiet.Text = "📚 Thông tin & Chi tiết đơn hàng";
            // 
            // btnKhongDuyet
            // 
            this.btnKhongDuyet.BorderRadius = 10;
            this.btnKhongDuyet.FillColor = System.Drawing.Color.Crimson;
            this.btnKhongDuyet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnKhongDuyet.ForeColor = System.Drawing.Color.White;
            this.btnKhongDuyet.Location = new System.Drawing.Point(175, 696);
            this.btnKhongDuyet.Name = "btnKhongDuyet";
            this.btnKhongDuyet.Size = new System.Drawing.Size(200, 55);
            this.btnKhongDuyet.TabIndex = 7;
            this.btnKhongDuyet.Text = "❌Không Duyệt";
            this.btnKhongDuyet.Click += new System.EventHandler(this.btnKhongDuyet_Click);
            // 
            // DuyetDon
            // 
            this.Controls.Add(this.panelMain);
            this.Name = "DuyetDon";
            this.Size = new System.Drawing.Size(1386, 774);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
            this.panelThongTin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Button btnKhongDuyet;
    }
}
