namespace PM.GUI.userConTrol.Client
{
    partial class GioHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pannelTong = new Guna.UI2.WinForms.Guna2Panel();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pannelTong.SuspendLayout();
            this.SuspendLayout();
            // 
            // pannelTong
            // 
            this.pannelTong.AutoScroll = true;
            this.pannelTong.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pannelTong.Controls.Add(this.btnBack);
            this.pannelTong.Location = new System.Drawing.Point(10, 50);
            this.pannelTong.Name = "pannelTong";
            this.pannelTong.Size = new System.Drawing.Size(1440, 1000);
            this.pannelTong.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.FillColor = System.Drawing.Color.LightGray;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(18, 898);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(175, 64);
            this.btnBack.TabIndex = 44;
            this.btnBack.Text = "← Quay lại";
            //this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(335, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "GIỎ HÀNG CỦA BẠN";
            // 
            // GioHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pannelTong);
            this.Name = "GioHang";
            this.Size = new System.Drawing.Size(1460, 1100);
            this.pannelTong.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pannelTong;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnBack;
    }
}
