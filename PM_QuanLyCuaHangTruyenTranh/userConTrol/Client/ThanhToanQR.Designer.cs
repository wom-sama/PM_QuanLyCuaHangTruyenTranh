using System;
using System.Windows.Forms;
using System.Drawing;
namespace PM.GUI.userConTrol.Customer
{
    partial class ThanhToanQR
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox picQR;
        private Label lblThongTin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblThongTin = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.lblCountdown = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.picQR = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            // 
            // lblThongTin
            // 
            this.lblThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThongTin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThongTin.Location = new System.Drawing.Point(31, 482);
            this.lblThongTin.Name = "lblThongTin";
            this.lblThongTin.Size = new System.Drawing.Size(653, 136);
            this.lblThongTin.TabIndex = 1;
            this.lblThongTin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHuy.BackColor = System.Drawing.Color.LightCoral;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(438, 645);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(164, 63);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXacNhan.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(118, 645);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(153, 63);
            this.btnXacNhan.TabIndex = 2;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // lblCountdown
            // 
            this.lblCountdown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountdown.AutoSize = false;
            this.lblCountdown.BackColor = System.Drawing.Color.Transparent;
            this.lblCountdown.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountdown.ForeColor = System.Drawing.Color.Brown;
            this.lblCountdown.Location = new System.Drawing.Point(68, 755);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(583, 62);
            this.lblCountdown.TabIndex = 4;
            this.lblCountdown.Text = "⏳ Mã QR sẽ hết hạn sau: 03:00";
            this.lblCountdown.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCountdown.Click += new System.EventHandler(this.lblCountdown_Click);
            // 
            // picQR
            // 
            this.picQR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picQR.Location = new System.Drawing.Point(118, 22);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(484, 445);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQR.TabIndex = 0;
            this.picQR.TabStop = false;
            // 
            // ThanhToanQR
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lblCountdown);
            this.Controls.Add(this.picQR);
            this.Controls.Add(this.lblThongTin);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnHuy);
            this.Name = "ThanhToanQR";
            this.Size = new System.Drawing.Size(1043, 833);
            this.Load += new System.EventHandler(this.ThanhToanQR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);

        }
        private Button btnHuy;
        private Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCountdown;
    }
}
