namespace PM.GUI.userConTrol.Client
{
    partial class MuaHangItem
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTong;
        private System.Windows.Forms.PictureBox picBiaSach;
        private System.Windows.Forms.Label lblTenSach;
        private System.Windows.Forms.Label lblGiaSach;
        private System.Windows.Forms.Label lblSoLuong;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panelTong = new System.Windows.Forms.Panel();
            this.picBiaSach = new System.Windows.Forms.PictureBox();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.lblGiaSach = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.panelTong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBiaSach)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTong
            // 
            this.panelTong.BackColor = System.Drawing.Color.White;
            this.panelTong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTong.Controls.Add(this.picBiaSach);
            this.panelTong.Controls.Add(this.lblTenSach);
            this.panelTong.Controls.Add(this.lblGiaSach);
            this.panelTong.Controls.Add(this.lblSoLuong);
            this.panelTong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTong.Location = new System.Drawing.Point(0, 0);
            this.panelTong.Name = "panelTong";
            this.panelTong.Padding = new System.Windows.Forms.Padding(5);
            this.panelTong.Size = new System.Drawing.Size(500, 90);
            this.panelTong.TabIndex = 0;
            // 
            // picBiaSach
            // 
            this.picBiaSach.Location = new System.Drawing.Point(5, 5);
            this.picBiaSach.Name = "picBiaSach";
            this.picBiaSach.Size = new System.Drawing.Size(60, 80);
            this.picBiaSach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBiaSach.TabIndex = 0;
            this.picBiaSach.TabStop = false;
            // 
            // lblTenSach
            // 
            this.lblTenSach.AutoSize = true;
            this.lblTenSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTenSach.Location = new System.Drawing.Point(75, 5);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(76, 19);
            this.lblTenSach.TabIndex = 1;
            this.lblTenSach.Text = "Tên sách";
            // 
            // lblGiaSach
            // 
            this.lblGiaSach.AutoSize = true;
            this.lblGiaSach.ForeColor = System.Drawing.Color.Red;
            this.lblGiaSach.Location = new System.Drawing.Point(75, 35);
            this.lblGiaSach.Name = "lblGiaSach";
            this.lblGiaSach.Size = new System.Drawing.Size(50, 15);
            this.lblGiaSach.TabIndex = 2;
            this.lblGiaSach.Text = "0 ₫";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(75, 60);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(17, 15);
            this.lblSoLuong.TabIndex = 3;
            this.lblSoLuong.Text = "0";
            // 
            // MuaHangItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelTong);
            this.Name = "MuaHangItem";
            this.Size = new System.Drawing.Size(500, 90);
            this.panelTong.ResumeLayout(false);
            this.panelTong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBiaSach)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
