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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMenu = new Guna.UI2.WinForms.Guna2Button();
            this.panelMenu = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.panelhienthi = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
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
            this.btnChuong.Location = new System.Drawing.Point(1194, 32);
            this.btnChuong.Name = "btnChuong";
            this.btnChuong.Size = new System.Drawing.Size(83, 102);
            this.btnChuong.TabIndex = 0;
            this.btnChuong.Click += new System.EventHandler(this.btnChuong_Click);
            // 
            // lblBadge
            // 
            this.lblBadge.BackColor = System.Drawing.Color.Red;
            this.lblBadge.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblBadge.ForeColor = System.Drawing.Color.White;
            this.lblBadge.Location = new System.Drawing.Point(1255, 19);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Size = new System.Drawing.Size(45, 53);
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
            this.btnLenDon.Location = new System.Drawing.Point(20, 60);
            this.btnLenDon.Name = "btnLenDon";
            this.btnLenDon.Size = new System.Drawing.Size(180, 50);
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
            this.btnDuyetDon.Location = new System.Drawing.Point(20, 130);
            this.btnDuyetDon.Name = "btnDuyetDon";
            this.btnDuyetDon.Size = new System.Drawing.Size(180, 50);
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
            this.btnXemDon.Location = new System.Drawing.Point(20, 208);
            this.btnXemDon.Name = "btnXemDon";
            this.btnXemDon.Size = new System.Drawing.Size(180, 50);
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
            this.btnCaLam.Location = new System.Drawing.Point(20, 289);
            this.btnCaLam.Name = "btnCaLam";
            this.btnCaLam.Size = new System.Drawing.Size(180, 50);
            this.btnCaLam.TabIndex = 5;
            this.btnCaLam.Text = "Xem đơn";
            this.btnCaLam.Click += new System.EventHandler(this.btnCaLam_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.Controls.Add(this.panelhienthi);
            this.guna2Panel1.Controls.Add(this.btnMenu);
            this.guna2Panel1.Controls.Add(this.panelMenu);
            this.guna2Panel1.Controls.Add(this.btnChuong);
            this.guna2Panel1.Controls.Add(this.lblBadge);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1356, 983);
            this.guna2Panel1.TabIndex = 6;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // btnMenu
            // 
            this.btnMenu.BorderRadius = 10;
            this.btnMenu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(51, 84);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(180, 50);
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
            this.panelMenu.Location = new System.Drawing.Point(51, 192);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(217, 397);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2CustomGradientPanel1_Paint);
            // 
            // panelhienthi
            // 
            this.panelhienthi.AutoSize = true;
            this.panelhienthi.Location = new System.Drawing.Point(296, 192);
            this.panelhienthi.Name = "panelhienthi";
            this.panelhienthi.Size = new System.Drawing.Size(2046, 1443);
            this.panelhienthi.TabIndex = 7;
            this.panelhienthi.Paint += new System.Windows.Forms.PaintEventHandler(this.panelhienthi_Paint);
            // 
            // GiaoDienNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.guna2Panel1);
            this.Name = "GiaoDienNV";
            this.Size = new System.Drawing.Size(1359, 1054);
            this.Load += new System.EventHandler(this.GiaoDienNV_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnCaLam;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel panelMenu;
        private Guna.UI2.WinForms.Guna2Button btnMenu;
        private Guna.UI2.WinForms.Guna2Panel panelhienthi;
    }
}
