using System;
using System.Drawing;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Customer
{
    partial class BookDetailControl
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox picBiaSach;
        private Label lblTenSach;
        private Label lblGiaBan;
        private Label lblLuotBan;
        private Label lblSoTrang;
        private Label lblNamXB;
        private Label lblTacGia;
        private Label lblTheLoai;
        private Label lblNXB;
        private TextBox txtMoTa;
        private System.Windows.Forms.Label lblSoLuong;

        private Guna.UI2.WinForms.Guna2Button btnMuaNgay;
        private Guna.UI2.WinForms.Guna2Button btnGioHang;
        private Guna.UI2.WinForms.Guna2Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picBiaSach = new System.Windows.Forms.PictureBox();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.lblLuotBan = new System.Windows.Forms.Label();
            this.lblSoTrang = new System.Windows.Forms.Label();
            this.lblNamXB = new System.Windows.Forms.Label();
            this.lblTacGia = new System.Windows.Forms.Label();
            this.lblTheLoai = new System.Windows.Forms.Label();
            this.lblNXB = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnMuaNgay = new Guna.UI2.WinForms.Guna2Button();
            this.btnGioHang = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.lblSoLuong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBiaSach)).BeginInit();
            this.SuspendLayout();
            // 
            // picBiaSach
            // 
            this.picBiaSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBiaSach.Location = new System.Drawing.Point(40, 40);
            this.picBiaSach.Name = "picBiaSach";
            this.picBiaSach.Size = new System.Drawing.Size(220, 300);
            this.picBiaSach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBiaSach.TabIndex = 8;
            this.picBiaSach.TabStop = false;
            // 
            // lblTenSach
            // 
            this.lblTenSach.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTenSach.Location = new System.Drawing.Point(280, 30);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(500, 40);
            this.lblTenSach.TabIndex = 9;
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblGiaBan.ForeColor = System.Drawing.Color.Red;
            this.lblGiaBan.Location = new System.Drawing.Point(280, 75);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(300, 35);
            this.lblGiaBan.TabIndex = 10;
            // 
            // lblLuotBan
            // 
            this.lblLuotBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLuotBan.ForeColor = System.Drawing.Color.Gray;
            this.lblLuotBan.Location = new System.Drawing.Point(280, 115);
            this.lblLuotBan.Name = "lblLuotBan";
            this.lblLuotBan.Size = new System.Drawing.Size(300, 25);
            this.lblLuotBan.TabIndex = 11;
            // 
            // lblSoTrang
            // 
            this.lblSoTrang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSoTrang.ForeColor = System.Drawing.Color.Black;
            this.lblSoTrang.Location = new System.Drawing.Point(280, 145);
            this.lblSoTrang.Name = "lblSoTrang";
            this.lblSoTrang.Size = new System.Drawing.Size(200, 25);
            this.lblSoTrang.TabIndex = 12;
            // 
            // lblNamXB
            // 
            this.lblNamXB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNamXB.ForeColor = System.Drawing.Color.Black;
            this.lblNamXB.Location = new System.Drawing.Point(500, 145);
            this.lblNamXB.Name = "lblNamXB";
            this.lblNamXB.Size = new System.Drawing.Size(150, 25);
            this.lblNamXB.TabIndex = 13;
            // 
            // lblTacGia
            // 
            this.lblTacGia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTacGia.ForeColor = System.Drawing.Color.Black;
            this.lblTacGia.Location = new System.Drawing.Point(280, 175);
            this.lblTacGia.Name = "lblTacGia";
            this.lblTacGia.Size = new System.Drawing.Size(300, 25);
            this.lblTacGia.TabIndex = 14;
            // 
            // lblTheLoai
            // 
            this.lblTheLoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTheLoai.ForeColor = System.Drawing.Color.Black;
            this.lblTheLoai.Location = new System.Drawing.Point(280, 205);
            this.lblTheLoai.Name = "lblTheLoai";
            this.lblTheLoai.Size = new System.Drawing.Size(300, 25);
            this.lblTheLoai.TabIndex = 15;
            // 
            // lblNXB
            // 
            this.lblNXB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNXB.ForeColor = System.Drawing.Color.Black;
            this.lblNXB.Location = new System.Drawing.Point(280, 235);
            this.lblNXB.Name = "lblNXB";
            this.lblNXB.Size = new System.Drawing.Size(300, 25);
            this.lblNXB.TabIndex = 16;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMoTa.Location = new System.Drawing.Point(280, 301);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ReadOnly = true;
            this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoTa.Size = new System.Drawing.Size(500, 150);
            this.txtMoTa.TabIndex = 17;
            // 
            // btnMuaNgay
            // 
            this.btnMuaNgay.BorderRadius = 10;
            this.btnMuaNgay.FillColor = System.Drawing.Color.OrangeRed;
            this.btnMuaNgay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMuaNgay.ForeColor = System.Drawing.Color.White;
            this.btnMuaNgay.Location = new System.Drawing.Point(271, 474);
            this.btnMuaNgay.Name = "btnMuaNgay";
            this.btnMuaNgay.Size = new System.Drawing.Size(150, 40);
            this.btnMuaNgay.TabIndex = 18;
            this.btnMuaNgay.Text = "Mua ngay";
            this.btnMuaNgay.Click += new System.EventHandler(this.btnMuaNgay_Click);
            // 
            // btnGioHang
            // 
            this.btnGioHang.BorderRadius = 10;
            this.btnGioHang.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGioHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGioHang.ForeColor = System.Drawing.Color.White;
            this.btnGioHang.Location = new System.Drawing.Point(444, 474);
            this.btnGioHang.Name = "btnGioHang";
            this.btnGioHang.Size = new System.Drawing.Size(180, 40);
            this.btnGioHang.TabIndex = 19;
            this.btnGioHang.Text = "Thêm vào giỏ hàng";
            this.btnGioHang.Click += new System.EventHandler(this.btnGioHang_Click);
            // 
            // btnBack
            // 
            this.btnBack.BorderRadius = 6;
            this.btnBack.FillColor = System.Drawing.Color.Gray;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(40, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "← Quay lại";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSoLuong.Location = new System.Drawing.Point(283, 270);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(149, 28);
            this.lblSoLuong.TabIndex = 7;
            this.lblSoLuong.Text = "Số lượng còn: 0";
            // 
            // BookDetailControl
            // 
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.picBiaSach);
            this.Controls.Add(this.lblTenSach);
            this.Controls.Add(this.lblGiaBan);
            this.Controls.Add(this.lblLuotBan);
            this.Controls.Add(this.lblSoTrang);
            this.Controls.Add(this.lblNamXB);
            this.Controls.Add(this.lblTacGia);
            this.Controls.Add(this.lblTheLoai);
            this.Controls.Add(this.lblNXB);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.btnMuaNgay);
            this.Controls.Add(this.btnGioHang);
            this.Controls.Add(this.btnBack);
            this.Name = "BookDetailControl";
            this.Size = new System.Drawing.Size(936, 594);
            this.Load += new System.EventHandler(this.BookDetailControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBiaSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
