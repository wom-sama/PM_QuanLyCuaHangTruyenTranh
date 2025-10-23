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
            this.panelInvoice.Controls.Add(this.lblTongTien);
            this.panelInvoice.Controls.Add(this.dataGridViewCT);
            this.panelInvoice.Controls.Add(this.lblNhanVien);
            this.panelInvoice.Controls.Add(this.lblNgayLap);
            this.panelInvoice.Controls.Add(this.lblMaDon);
            this.panelInvoice.Controls.Add(this.lblTieuDe);
            this.panelInvoice.Controls.Add(this.lblTenCuaHang);
            this.panelInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInvoice.Location = new System.Drawing.Point(0, 0);
            this.panelInvoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelInvoice.Name = "panelInvoice";
            this.panelInvoice.Size = new System.Drawing.Size(1012, 962);
            this.panelInvoice.TabIndex = 0;
            // 
            // lblCamOn
            // 
            this.lblCamOn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblCamOn.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblCamOn.Location = new System.Drawing.Point(0, 800);
            this.lblCamOn.Name = "lblCamOn";
            this.lblCamOn.Size = new System.Drawing.Size(1012, 31);
            this.lblCamOn.TabIndex = 7;
            this.lblCamOn.Text = "❤ Cảm ơn quý khách đã mua hàng!";
            this.lblCamOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.Maroon;
            this.lblTongTien.Location = new System.Drawing.Point(562, 750);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(405, 38);
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
            this.dataGridViewCT.Location = new System.Drawing.Point(45, 225);
            this.dataGridViewCT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewCT.Name = "dataGridViewCT";
            this.dataGridViewCT.ReadOnly = true;
            this.dataGridViewCT.RowHeadersVisible = false;
            this.dataGridViewCT.RowHeadersWidth = 62;
            this.dataGridViewCT.RowTemplate.Height = 28;
            this.dataGridViewCT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCT.Size = new System.Drawing.Size(922, 500);
            this.dataGridViewCT.TabIndex = 5;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNhanVien.Location = new System.Drawing.Point(45, 175);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(338, 29);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Nhân viên: ";
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgayLap.Location = new System.Drawing.Point(45, 144);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(338, 29);
            this.lblNgayLap.TabIndex = 3;
            this.lblNgayLap.Text = "Ngày lập: ";
            // 
            // lblMaDon
            // 
            this.lblMaDon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaDon.Location = new System.Drawing.Point(45, 112);
            this.lblMaDon.Name = "lblMaDon";
            this.lblMaDon.Size = new System.Drawing.Size(338, 29);
            this.lblMaDon.TabIndex = 2;
            this.lblMaDon.Text = "Mã đơn: ";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Location = new System.Drawing.Point(0, 56);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(1012, 31);
            this.lblTieuDe.TabIndex = 1;
            this.lblTieuDe.Text = "HÓA ĐƠN BÁN TRUYỆN";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenCuaHang
            // 
            this.lblTenCuaHang.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTenCuaHang.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblTenCuaHang.Location = new System.Drawing.Point(0, 12);
            this.lblTenCuaHang.Name = "lblTenCuaHang";
            this.lblTenCuaHang.Size = new System.Drawing.Size(1012, 38);
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
            this.btnXuatPDF.Location = new System.Drawing.Point(832, 900);
            this.btnXuatPDF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXuatPDF.Name = "btnXuatPDF";
            this.btnXuatPDF.Size = new System.Drawing.Size(158, 50);
            this.btnXuatPDF.TabIndex = 1;
            this.btnXuatPDF.Text = "🖨 Xuất PDF";
            this.btnXuatPDF.UseVisualStyleBackColor = false;
            this.btnXuatPDF.Click += new System.EventHandler(this.btnXuatPDF_Click);
            // 
            // InHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnXuatPDF);
            this.Controls.Add(this.panelInvoice);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InHoaDon";
            this.Size = new System.Drawing.Size(1012, 962);
            this.panelInvoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCT)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
