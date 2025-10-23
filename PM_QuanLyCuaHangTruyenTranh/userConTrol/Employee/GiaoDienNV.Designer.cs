namespace PM.GUI.userConTrol.Employee
{
    partial class GiaoDienNV
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Button btnChuong;
        private System.Windows.Forms.Label lblBadge;

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
            this.btnChuong.Location = new System.Drawing.Point(1227, 20);
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
            this.lblBadge.Location = new System.Drawing.Point(1280, 15);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Size = new System.Drawing.Size(45, 53);
            this.lblBadge.TabIndex = 1;
            this.lblBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBadge.Visible = false;
            this.lblBadge.Click += new System.EventHandler(this.lblBadge_Click);
            // 
            // GiaoDienNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.lblBadge);
            this.Controls.Add(this.btnChuong);
            this.Name = "GiaoDienNV";
            this.Size = new System.Drawing.Size(1359, 1054);
            this.Load += new System.EventHandler(this.GiaoDienNV_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
