using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Customer
{
    partial class MuaHang
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.picBiaSach = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.lblGiaSach = new System.Windows.Forms.Label();
            this.btnGiam = new Guna.UI2.WinForms.Guna2Button();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.btnTang = new Guna.UI2.WinForms.Guna2Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            this.txtTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSDT = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDiaChi = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbVanChuyen = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbThanhToan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpNgayDat = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnDatHang = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBiaSach)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.picBiaSach);
            this.guna2Panel1.Controls.Add(this.lblTenSach);
            this.guna2Panel1.Controls.Add(this.lblGiaSach);
            this.guna2Panel1.Controls.Add(this.btnGiam);
            this.guna2Panel1.Controls.Add(this.lblSoLuong);
            this.guna2Panel1.Controls.Add(this.btnTang);
            this.guna2Panel1.Controls.Add(this.lblTongTien);
            this.guna2Panel1.Controls.Add(this.lbl1);
            this.guna2Panel1.Controls.Add(this.lbl2);
            this.guna2Panel1.Controls.Add(this.lbl3);
            this.guna2Panel1.Controls.Add(this.lbl4);
            this.guna2Panel1.Controls.Add(this.lbl5);
            this.guna2Panel1.Controls.Add(this.lbl6);
            this.guna2Panel1.Controls.Add(this.lbl7);
            this.guna2Panel1.Controls.Add(this.txtTen);
            this.guna2Panel1.Controls.Add(this.txtSDT);
            this.guna2Panel1.Controls.Add(this.txtDiaChi);
            this.guna2Panel1.Controls.Add(this.cbVanChuyen);
            this.guna2Panel1.Controls.Add(this.cbThanhToan);
            this.guna2Panel1.Controls.Add(this.dtpNgayDat);
            this.guna2Panel1.Controls.Add(this.btnDatHang);
            this.guna2Panel1.Controls.Add(this.btnBack);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(700, 600);
            this.guna2Panel1.TabIndex = 0;
            // 
            // picBiaSach
            // 
            this.picBiaSach.ImageRotate = 0F;
            this.picBiaSach.Location = new System.Drawing.Point(45, 30);
            this.picBiaSach.Name = "picBiaSach";
            this.picBiaSach.Size = new System.Drawing.Size(150, 200);
            this.picBiaSach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBiaSach.TabIndex = 22;
            this.picBiaSach.TabStop = false;
            // 
            // lblTenSach
            // 
            this.lblTenSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenSach.Location = new System.Drawing.Point(215, 30);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(400, 30);
            this.lblTenSach.TabIndex = 23;
            // 
            // lblGiaSach
            // 
            this.lblGiaSach.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGiaSach.ForeColor = System.Drawing.Color.Red;
            this.lblGiaSach.Location = new System.Drawing.Point(215, 70);
            this.lblGiaSach.Name = "lblGiaSach";
            this.lblGiaSach.Size = new System.Drawing.Size(200, 25);
            this.lblGiaSach.TabIndex = 24;
            // 
            // btnGiam
            // 
            this.btnGiam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGiam.ForeColor = System.Drawing.Color.White;
            this.btnGiam.Location = new System.Drawing.Point(215, 110);
            this.btnGiam.Name = "btnGiam";
            this.btnGiam.Size = new System.Drawing.Size(40, 30);
            this.btnGiam.TabIndex = 25;
            this.btnGiam.Text = "-";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoLuong.Location = new System.Drawing.Point(260, 115);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(30, 25);
            this.lblSoLuong.TabIndex = 26;
            this.lblSoLuong.Text = "1";
            this.lblSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTang
            // 
            this.btnTang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTang.ForeColor = System.Drawing.Color.White;
            this.btnTang.Location = new System.Drawing.Point(295, 110);
            this.btnTang.Name = "btnTang";
            this.btnTang.Size = new System.Drawing.Size(40, 30);
            this.btnTang.TabIndex = 27;
            this.btnTang.Text = "+";
            // 
            // lblTongTien
            // 
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTongTien.Location = new System.Drawing.Point(215, 150);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(200, 25);
            this.lblTongTien.TabIndex = 28;
            // 
            // lbl1
            // 
            this.lbl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl1.Location = new System.Drawing.Point(45, 250);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(200, 25);
            this.lbl1.TabIndex = 29;
            this.lbl1.Text = "Tên người nhận:";
            // 
            // lbl2
            // 
            this.lbl2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl2.Location = new System.Drawing.Point(45, 290);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(200, 25);
            this.lbl2.TabIndex = 30;
            this.lbl2.Text = "Số điện thoại:";
            // 
            // lbl3
            // 
            this.lbl3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl3.Location = new System.Drawing.Point(45, 330);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(200, 25);
            this.lbl3.TabIndex = 31;
            this.lbl3.Text = "Địa chỉ nhận hàng:";
            // 
            // lbl4
            // 
            this.lbl4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl4.Location = new System.Drawing.Point(45, 370);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(200, 25);
            this.lbl4.TabIndex = 32;
            this.lbl4.Text = "Đơn vị vận chuyển:";
            // 
            // lbl5
            // 
            this.lbl5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl5.Location = new System.Drawing.Point(45, 410);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(200, 25);
            this.lbl5.TabIndex = 33;
            this.lbl5.Text = "Ngày đặt hàng:";
            // 
            // lbl6
            // 
            this.lbl6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl6.Location = new System.Drawing.Point(45, 450);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(200, 25);
            this.lbl6.TabIndex = 34;
            this.lbl6.Text = "Phương thức thanh toán:";
            // 
            // lbl7
            // 
            this.lbl7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl7.Location = new System.Drawing.Point(45, 490);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(200, 25);
            this.lbl7.TabIndex = 35;
            this.lbl7.Text = "Tổng tiền:";
            // 
            // txtTen
            // 
            this.txtTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTen.DefaultText = "";
            this.txtTen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTen.Location = new System.Drawing.Point(255, 250);
            this.txtTen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTen.Name = "txtTen";
            this.txtTen.PlaceholderText = "";
            this.txtTen.SelectedText = "";
            this.txtTen.Size = new System.Drawing.Size(250, 30);
            this.txtTen.TabIndex = 36;
            // 
            // txtSDT
            // 
            this.txtSDT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSDT.DefaultText = "";
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSDT.Location = new System.Drawing.Point(255, 290);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.PlaceholderText = "";
            this.txtSDT.SelectedText = "";
            this.txtSDT.Size = new System.Drawing.Size(250, 30);
            this.txtSDT.TabIndex = 37;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiaChi.DefaultText = "";
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiaChi.Location = new System.Drawing.Point(255, 330);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.PlaceholderText = "";
            this.txtDiaChi.SelectedText = "";
            this.txtDiaChi.Size = new System.Drawing.Size(400, 30);
            this.txtDiaChi.TabIndex = 38;
            // 
            // cbVanChuyen
            // 
            this.cbVanChuyen.BackColor = System.Drawing.Color.Transparent;
            this.cbVanChuyen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVanChuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVanChuyen.FocusedColor = System.Drawing.Color.Empty;
            this.cbVanChuyen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbVanChuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbVanChuyen.ItemHeight = 30;
            this.cbVanChuyen.Location = new System.Drawing.Point(255, 370);
            this.cbVanChuyen.Name = "cbVanChuyen";
            this.cbVanChuyen.Size = new System.Drawing.Size(250, 36);
            this.cbVanChuyen.TabIndex = 39;
            // 
            // cbThanhToan
            // 
            this.cbThanhToan.BackColor = System.Drawing.Color.Transparent;
            this.cbThanhToan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbThanhToan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThanhToan.FocusedColor = System.Drawing.Color.Empty;
            this.cbThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbThanhToan.ItemHeight = 30;
            this.cbThanhToan.Location = new System.Drawing.Point(255, 450);
            this.cbThanhToan.Name = "cbThanhToan";
            this.cbThanhToan.Size = new System.Drawing.Size(250, 36);
            this.cbThanhToan.TabIndex = 40;
            // 
            // dtpNgayDat
            // 
            this.dtpNgayDat.Checked = true;
            this.dtpNgayDat.Enabled = false;
            this.dtpNgayDat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayDat.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgayDat.Location = new System.Drawing.Point(255, 410);
            this.dtpNgayDat.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayDat.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayDat.Name = "dtpNgayDat";
            this.dtpNgayDat.Size = new System.Drawing.Size(250, 30);
            this.dtpNgayDat.TabIndex = 41;
            this.dtpNgayDat.Value = new System.DateTime(2025, 10, 31, 8, 6, 53, 75);
            // 
            // btnDatHang
            // 
            this.btnDatHang.Enabled = false;
            this.btnDatHang.FillColor = System.Drawing.Color.Gray;
            this.btnDatHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDatHang.ForeColor = System.Drawing.Color.White;
            this.btnDatHang.Location = new System.Drawing.Point(255, 530);
            this.btnDatHang.Name = "btnDatHang";
            this.btnDatHang.Size = new System.Drawing.Size(200, 40);
            this.btnDatHang.TabIndex = 42;
            this.btnDatHang.Text = "Đặt hàng";
            this.btnDatHang.Click += new System.EventHandler(this.btnDatHang_Click);
            // 
            // btnBack
            // 
            this.btnBack.FillColor = System.Drawing.Color.LightGray;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(45, 530);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 35);
            this.btnBack.TabIndex = 43;
            this.btnBack.Text = "← Quay lại";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // MuaHang
            // 
            this.Controls.Add(this.guna2Panel1);
            this.Name = "MuaHang";
            this.Size = new System.Drawing.Size(700, 600);
            this.Load += new System.EventHandler(this.MuaHang_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBiaSach)).EndInit();
            this.ResumeLayout(false);

        }

        private Guna2Panel guna2Panel1;
        private Guna2PictureBox picBiaSach;
        private Label lblTenSach;
        private Label lblGiaSach;
        private Guna2Button btnGiam;
        private Label lblSoLuong;
        private Guna2Button btnTang;
        private Label lblTongTien;
        private Label lbl1;
        private Label lbl2;
        private Label lbl3;
        private Label lbl4;
        private Label lbl5;
        private Label lbl6;
        private Label lbl7;
        private Guna2TextBox txtTen;
        private Guna2TextBox txtSDT;
        private Guna2TextBox txtDiaChi;
        private Guna2ComboBox cbVanChuyen;
        private Guna2ComboBox cbThanhToan;
        private Guna2DateTimePicker dtpNgayDat;
        private Guna2Button btnDatHang;
        private Guna2Button btnBack;
    }
}
