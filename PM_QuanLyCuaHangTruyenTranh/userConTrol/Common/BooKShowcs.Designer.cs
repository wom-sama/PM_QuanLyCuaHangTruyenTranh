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
            this.txtNameBook = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.picBia = new Guna.UI2.WinForms.Guna2PictureBox();
            this.checkMouseTimer = new System.Windows.Forms.Timer(this.components);
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBia)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNameBook
            // 
            this.txtNameBook.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtNameBook.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNameBook.DefaultText = "";
            this.txtNameBook.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNameBook.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNameBook.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameBook.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameBook.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameBook.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNameBook.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameBook.Location = new System.Drawing.Point(15, 224);
            this.txtNameBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNameBook.Name = "txtNameBook";
            this.txtNameBook.PlaceholderText = "";
            this.txtNameBook.SelectedText = "";
            this.txtNameBook.Size = new System.Drawing.Size(128, 45);
            this.txtNameBook.TabIndex = 1;
            this.txtNameBook.TextChanged += new System.EventHandler(this.txtNameBook_TextChanged);
            this.txtNameBook.MouseEnter += new System.EventHandler(this.txtNameBook_MouseEnter);
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.txtNameBook);
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
            // checkMouseTimer
            // 
            this.checkMouseTimer.Enabled = true;
            this.checkMouseTimer.Tick += new System.EventHandler(this.checkMouseTimer_Tick);
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
        private Guna.UI2.WinForms.Guna2TextBox txtNameBook;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.Timer checkMouseTimer;
    }
}
