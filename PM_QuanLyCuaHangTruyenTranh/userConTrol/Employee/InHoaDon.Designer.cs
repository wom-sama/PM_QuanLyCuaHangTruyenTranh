using System.Windows.Forms;
using System.Drawing;

namespace PM.GUI.userConTrol.Employee
{
    partial class InHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelInvoice;
        private Label lblTenCuaHang;
        private Label lblTieuDe;
        private Label lblMaDon;
        private Label lblNgayLap;
        private Label lblNhanVien;
        private DataGridView dataGridViewCT;
        private Label lblTongTien;
        private Label lblCamOn;
        private Label lblTienKhachDua; // mới
        private Label lblTienThua;     // mới
        private Button btnXuatPDF;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelInvoice = new System.Windows.Forms.Panel();
            this.lblCamOn = new System.Windows.Forms.Label();
            this.lblTienThua = new System.Windows.Forms.Label();
            this.lblTienKhachDua = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.dataGridViewCT = new System.Windows.Forms.DataGridView();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.lblMaDon = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblTenCuaHang = new System.Windows.Forms.Label();
            this.btnXuatPDF = new System.Windows.Forms.Button();
            this.panelInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCT)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInvoice
            // 
            this.panelInvoice.BackColor = System.Drawing.Color.White;
            this.panelInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInvoice.Controls.Add(this.lblCamOn);
            this.panelInvoice.Controls.Add(this.lblTienThua);
            this.panelInvoice.Controls.Add(this.lblTienKhachDua);
            this.panelInvoice.Controls.Add(this.lblTongTien);
            this.panelInvoice.Controls.Add(this.dataGridViewCT);
            this.panelInvoice.Controls.Add(this.lblNhanVien);
            this.panelInvoice.Controls.Add(this.lblNgayLap);
            this.panelInvoice.Controls.Add(this.lblMaDon);
            this.panelInvoice.Controls.Add(this.lblTieuDe);
            this.panelInvoice.Controls.Add(this.lblTenCuaHang);
            this.panelInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInvoice.Location = new System.Drawing.Point(0, 0);
            this.panelInvoice.Name = "panelInvoice";
            this.panelInvoice.Size = new System.Drawing.Size(900, 770);
            this.panelInvoice.TabIndex = 0;
            // 
            // lblCamOn
            // 
            this.lblCamOn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblCamOn.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblCamOn.Location = new System.Drawing.Point(0, 672);
            this.lblCamOn.Name = "lblCamOn";
            this.lblCamOn.Size = new System.Drawing.Size(900, 25);
            this.lblCamOn.TabIndex = 8;
            this.lblCamOn.Text = "❤ Cảm ơn quý khách đã mua hàng!";
            this.lblCamOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTienThua
            // 
            this.lblTienThua.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTienThua.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTienThua.Location = new System.Drawing.Point(40, 632);
            this.lblTienThua.Name = "lblTienThua";
            this.lblTienThua.Size = new System.Drawing.Size(356, 23);
            this.lblTienThua.TabIndex = 10;
            this.lblTienThua.Text = "Tiền thừa: ";
            // 
            // lblTienKhachDua
            // 
            this.lblTienKhachDua.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTienKhachDua.ForeColor = System.Drawing.Color.Green;
            this.lblTienKhachDua.Location = new System.Drawing.Point(40, 608);
            this.lblTienKhachDua.Name = "lblTienKhachDua";
            this.lblTienKhachDua.Size = new System.Drawing.Size(356, 23);
            this.lblTienKhachDua.TabIndex = 9;
            this.lblTienKhachDua.Text = "Tiền khách đưa: ";
            // 
            // lblTongTien
            // 
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.Maroon;
            this.lblTongTien.Location = new System.Drawing.Point(500, 600);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(360, 30);
            this.lblTongTien.TabIndex = 6;
            this.lblTongTien.Text = "Tổng cộng: ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridViewCT
            // 
            this.dataGridViewCT.AllowUserToAddRows = false;
            this.dataGridViewCT.AllowUserToDeleteRows = false;
            this.dataGridViewCT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCT.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCT.Location = new System.Drawing.Point(40, 180);
            this.dataGridViewCT.Name = "dataGridViewCT";
            this.dataGridViewCT.ReadOnly = true;
            this.dataGridViewCT.RowHeadersVisible = false;
            this.dataGridViewCT.RowHeadersWidth = 62;
            this.dataGridViewCT.RowTemplate.Height = 28;
            this.dataGridViewCT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCT.Size = new System.Drawing.Size(820, 400);
            this.dataGridViewCT.TabIndex = 5;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNhanVien.Location = new System.Drawing.Point(40, 140);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(300, 23);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Nhân viên: ";
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgayLap.Location = new System.Drawing.Point(40, 115);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(300, 23);
            this.lblNgayLap.TabIndex = 3;
            this.lblNgayLap.Text = "Ngày lập: ";
            // 
            // lblMaDon
            // 
            this.lblMaDon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaDon.Location = new System.Drawing.Point(40, 90);
            this.lblMaDon.Name = "lblMaDon";
            this.lblMaDon.Size = new System.Drawing.Size(300, 23);
            this.lblMaDon.TabIndex = 2;
            this.lblMaDon.Text = "Mã đơn: ";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Location = new System.Drawing.Point(-6, 56);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(900, 34);
            this.lblTieuDe.TabIndex = 1;
            this.lblTieuDe.Text = "HÓA ĐƠN BÁN TRUYỆN";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenCuaHang
            // 
            this.lblTenCuaHang.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTenCuaHang.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblTenCuaHang.Location = new System.Drawing.Point(0, 10);
            this.lblTenCuaHang.Name = "lblTenCuaHang";
            this.lblTenCuaHang.Size = new System.Drawing.Size(900, 46);
            this.lblTenCuaHang.TabIndex = 0;
            this.lblTenCuaHang.Text = "🏪 CỬA HÀNG TRUYỆN TRANH MANGA ";
            this.lblTenCuaHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnXuatPDF
            // 
            this.btnXuatPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatPDF.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnXuatPDF.FlatAppearance.BorderSize = 0;
            this.btnXuatPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatPDF.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXuatPDF.ForeColor = System.Drawing.Color.White;
            this.btnXuatPDF.Location = new System.Drawing.Point(740, 720);
            this.btnXuatPDF.Name = "btnXuatPDF";
            this.btnXuatPDF.Size = new System.Drawing.Size(140, 40);
            this.btnXuatPDF.TabIndex = 1;
            this.btnXuatPDF.Text = "🖨 Xuất PDF";
            this.btnXuatPDF.UseVisualStyleBackColor = false;
            this.btnXuatPDF.Click += new System.EventHandler(this.btnXuatPDF_Click);
            // 
            // InHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnXuatPDF);
            this.Controls.Add(this.panelInvoice);
            this.Name = "InHoaDon";
            this.Size = new System.Drawing.Size(900, 770);
            this.panelInvoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCT)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
