namespace PM_QuanLyCuaHangTruyenTranh.userConTrol.Admin
{
    partial class Edit_BOOk
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
            this.txtFindTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelDanhSach = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTheLoai = new Guna.UI2.WinForms.Guna2Button();
            this.flpTheLoai = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFindTen
            // 
            this.txtFindTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFindTen.DefaultText = "";
            this.txtFindTen.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFindTen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFindTen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFindTen.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFindTen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFindTen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFindTen.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFindTen.Location = new System.Drawing.Point(110, 28);
            this.txtFindTen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFindTen.Name = "txtFindTen";
            this.txtFindTen.PlaceholderText = "";
            this.txtFindTen.SelectedText = "";
            this.txtFindTen.Size = new System.Drawing.Size(489, 33);
            this.txtFindTen.TabIndex = 0;
            // 
            // panelDanhSach
            // 
            this.panelDanhSach.AutoScroll = true;
            this.panelDanhSach.Location = new System.Drawing.Point(3, 106);
            this.panelDanhSach.Name = "panelDanhSach";
            this.panelDanhSach.Size = new System.Drawing.Size(730, 352);
            this.panelDanhSach.TabIndex = 2;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.flpTheLoai);
            this.guna2Panel1.Controls.Add(this.btnTheLoai);
            this.guna2Panel1.Controls.Add(this.txtFindTen);
            this.guna2Panel1.Controls.Add(this.panelDanhSach);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(736, 461);
            this.guna2Panel1.TabIndex = 3;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // btnTheLoai
            // 
            this.btnTheLoai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTheLoai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTheLoai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTheLoai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTheLoai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTheLoai.ForeColor = System.Drawing.Color.White;
            this.btnTheLoai.Location = new System.Drawing.Point(235, 69);
            this.btnTheLoai.Name = "btnTheLoai";
            this.btnTheLoai.Size = new System.Drawing.Size(180, 31);
            this.btnTheLoai.TabIndex = 3;
            this.btnTheLoai.Text = "guna2Button1";
            // 
            // flpTheLoai
            // 
            this.flpTheLoai.Location = new System.Drawing.Point(110, 104);
            this.flpTheLoai.Name = "flpTheLoai";
            this.flpTheLoai.Size = new System.Drawing.Size(489, 354);
            this.flpTheLoai.TabIndex = 4;
            // 
            // Edit_BOOk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "Edit_BOOk";
            this.Size = new System.Drawing.Size(736, 461);
            this.Load += new System.EventHandler(this.Edit_BOOk_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtFindTen;
        private System.Windows.Forms.FlowLayoutPanel panelDanhSach;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnTheLoai;
        private System.Windows.Forms.FlowLayoutPanel flpTheLoai;
    }
}
