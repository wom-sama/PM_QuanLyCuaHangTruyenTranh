namespace PM.GUI.userConTrol.Common
{
    partial class BooKShowcs
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
            this.components = new System.ComponentModel.Container();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.picBia = new Guna.UI2.WinForms.Guna2PictureBox();
            this.hoveDelayTimer = new System.Windows.Forms.Timer(this.components);
            this.checkMouseTimer = new System.Windows.Forms.Timer(this.components);
            this.tenSachlbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBia)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.tenSachlbl);
            this.guna2ShadowPanel1.Controls.Add(this.picBia);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(154, 285);
            this.guna2ShadowPanel1.TabIndex = 2;
            this.guna2ShadowPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2ShadowPanel1_Paint);
            // 
            // picBia
            // 
            this.picBia.BackColor = System.Drawing.Color.Transparent;
            this.picBia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picBia.Cursor = System.Windows.Forms.Cursors.No;
            this.picBia.Image = global::PM.GUI.Properties.Resources.rick_roll;
            this.picBia.ImageRotate = 0F;
            this.picBia.Location = new System.Drawing.Point(15, 16);
            this.picBia.Name = "picBia";
            this.picBia.Size = new System.Drawing.Size(128, 201);
            this.picBia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBia.TabIndex = 0;
            this.picBia.TabStop = false;
            this.picBia.WaitOnLoad = true;
            this.picBia.MouseEnter += new System.EventHandler(this.picBia_MouseEnter);
            this.picBia.MouseLeave += new System.EventHandler(this.picBia_MouseLeave);
            // 
            // hoveDelayTimer
            // 
            this.hoveDelayTimer.Enabled = true;
            this.hoveDelayTimer.Interval = 250;
            // 
            // checkMouseTimer
            // 
            this.checkMouseTimer.Enabled = true;
            // 
            // tenSachlbl
            // 
            this.tenSachlbl.AutoSize = false;
            this.tenSachlbl.BackColor = System.Drawing.Color.Transparent;
            this.tenSachlbl.Location = new System.Drawing.Point(15, 235);
            this.tenSachlbl.Name = "tenSachlbl";
            this.tenSachlbl.Size = new System.Drawing.Size(128, 35);
            this.tenSachlbl.TabIndex = 1;
            this.tenSachlbl.Text = "guna2HtmlLabel1";
            this.tenSachlbl.Click += new System.EventHandler(this.guna2HtmlLabel1_Click);
            // 
            // BooKShowcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "BooKShowcs";
            this.Size = new System.Drawing.Size(154, 285);
            this.Load += new System.EventHandler(this.BooKShowcs_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox picBia;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.Timer hoveDelayTimer;
        private System.Windows.Forms.Timer checkMouseTimer;
        private Guna.UI2.WinForms.Guna2HtmlLabel tenSachlbl;
    }
}
