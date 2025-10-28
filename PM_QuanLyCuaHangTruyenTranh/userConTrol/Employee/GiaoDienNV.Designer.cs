using FontAwesome.Sharp;

namespace PM.GUI.userConTrol.Employee
{
    partial class GiaoDienNV
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Button btnChuong;
        private System.Windows.Forms.Label lblBadge;
        private Guna.UI2.WinForms.Guna2Button btnLenDon;
        private Guna.UI2.WinForms.Guna2Button btnDuyetDon;
        private Guna.UI2.WinForms.Guna2Button btnXemDon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.btnChuong = new Guna.UI2.WinForms.Guna2Button();
            this.lblBadge = new System.Windows.Forms.Label();
            this.btnLenDon = new Guna.UI2.WinForms.Guna2Button();
            this.btnDuyetDon = new Guna.UI2.WinForms.Guna2Button();
            this.btnXemDon = new Guna.UI2.WinForms.Guna2Button();
            this.btnCaLam = new Guna.UI2.WinForms.Guna2Button();
            this.pannelGD_tong = new Guna.UI2.WinForms.Guna2Panel();
            this.panelhienthi = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMenu = new Guna.UI2.WinForms.Guna2Button();
            this.panelMenu = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.pannelGD_tong.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChuong
            // 
            this.btnChuong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChuong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChuong.FillColor = System.Drawing.Color.Transparent;
            this.btnChuong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChuong.ForeColor = System.Drawing.Color.Gold;
            this.btnChuong.ImageSize = new System.Drawing.Size(40, 40);
            this.btnChuong.Location = new System.Drawing.Point(1061, 26);
            this.btnChuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChuong.Name = "btnChuong";
            this.btnChuong.Size = new System.Drawing.Size(74, 82);
            this.btnChuong.TabIndex = 0;
            this.btnChuong.Click += new System.EventHandler(this.btnChuong_Click);
            // 
            // lblBadge
            // 
            this.lblBadge.BackColor = System.Drawing.Color.Red;
            this.lblBadge.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblBadge.ForeColor = System.Drawing.Color.White;
            this.lblBadge.Location = new System.Drawing.Point(1116, 15);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Size = new System.Drawing.Size(40, 42);
            this.lblBadge.TabIndex = 1;
            this.lblBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBadge.Visible = false;
            this.lblBadge.Click += new System.EventHandler(this.lblBadge_Click);
            // 
            // btnLenDon
            // 
            this.btnLenDon.BorderRadius = 10;
            this.btnLenDon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLenDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLenDon.ForeColor = System.Drawing.Color.White;
            this.btnLenDon.Location = new System.Drawing.Point(18, 48);
            this.btnLenDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLenDon.Name = "btnLenDon";
            this.btnLenDon.Size = new System.Drawing.Size(160, 40);
            this.btnLenDon.TabIndex = 2;
            this.btnLenDon.Text = "Lên đơn";
            this.btnLenDon.Click += new System.EventHandler(this.btnLenDon_Click);
            // 
            // btnDuyetDon
            // 
            this.btnDuyetDon.BorderRadius = 10;
            this.btnDuyetDon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnDuyetDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDuyetDon.ForeColor = System.Drawing.Color.White;
            this.btnDuyetDon.Location = new System.Drawing.Point(18, 104);
            this.btnDuyetDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDuyetDon.Name = "btnDuyetDon";
            this.btnDuyetDon.Size = new System.Drawing.Size(160, 40);
            this.btnDuyetDon.TabIndex = 3;
            this.btnDuyetDon.Text = "Duyệt đơn";
            this.btnDuyetDon.Click += new System.EventHandler(this.btnDuyetDon_Click);
            // 
            // btnXemDon
            // 
            this.btnXemDon.BorderRadius = 10;
            this.btnXemDon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnXemDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXemDon.ForeColor = System.Drawing.Color.White;
            this.btnXemDon.Location = new System.Drawing.Point(18, 166);
            this.btnXemDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXemDon.Name = "btnXemDon";
            this.btnXemDon.Size = new System.Drawing.Size(160, 40);
            this.btnXemDon.TabIndex = 4;
            this.btnXemDon.Text = "Xem đơn";
            this.btnXemDon.Click += new System.EventHandler(this.btnXemDon_Click);
            // 
            // btnCaLam
            // 
            this.btnCaLam.BorderRadius = 10;
            this.btnCaLam.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCaLam.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCaLam.ForeColor = System.Drawing.Color.White;
            this.btnCaLam.Location = new System.Drawing.Point(18, 231);
            this.btnCaLam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCaLam.Name = "btnCaLam";
            this.btnCaLam.Size = new System.Drawing.Size(160, 40);
            this.btnCaLam.TabIndex = 5;
            this.btnCaLam.Text = "Xem đơn";
            this.btnCaLam.Click += new System.EventHandler(this.btnCaLam_Click);
            // 
            // pannelGD_tong
            // 
            this.pannelGD_tong.AutoScroll = true;
            this.pannelGD_tong.Controls.Add(this.panelhienthi);
            this.pannelGD_tong.Controls.Add(this.btnMenu);
            this.pannelGD_tong.Controls.Add(this.panelMenu);
            this.pannelGD_tong.Controls.Add(this.btnChuong);
            this.pannelGD_tong.Controls.Add(this.lblBadge);
            this.pannelGD_tong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pannelGD_tong.Location = new System.Drawing.Point(0, 0);
            this.pannelGD_tong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pannelGD_tong.Name = "pannelGD_tong";
            this.pannelGD_tong.Size = new System.Drawing.Size(1208, 843);
            this.pannelGD_tong.TabIndex = 6;
            this.pannelGD_tong.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // panelhienthi
            // 
            this.panelhienthi.AutoSize = true;
            this.panelhienthi.Location = new System.Drawing.Point(263, 154);
            this.panelhienthi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelhienthi.Name = "panelhienthi";
            this.panelhienthi.Size = new System.Drawing.Size(1819, 1154);
            this.panelhienthi.TabIndex = 7;
            this.panelhienthi.Paint += new System.Windows.Forms.PaintEventHandler(this.panelhienthi_Paint);
            // 
            // btnMenu
            // 
            this.btnMenu.BorderRadius = 10;
            this.btnMenu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(45, 67);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(160, 40);
            this.btnMenu.TabIndex = 6;
            this.btnMenu.Text = "Menu";
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnLenDon);
            this.panelMenu.Controls.Add(this.btnDuyetDon);
            this.panelMenu.Controls.Add(this.btnXemDon);
            this.panelMenu.Controls.Add(this.btnCaLam);
            this.panelMenu.Location = new System.Drawing.Point(45, 154);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(193, 318);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2CustomGradientPanel1_Paint);
            // 
            // GiaoDienNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.pannelGD_tong);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GiaoDienNV";
            this.Size = new System.Drawing.Size(1208, 843);
            this.Load += new System.EventHandler(this.GiaoDienNV_Load);
            this.pannelGD_tong.ResumeLayout(false);
            this.pannelGD_tong.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnCaLam;
        private Guna.UI2.WinForms.Guna2Panel pannelGD_tong;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel panelMenu;
        private Guna.UI2.WinForms.Guna2Button btnMenu;
        private Guna.UI2.WinForms.Guna2Panel panelhienthi;
    }
}
