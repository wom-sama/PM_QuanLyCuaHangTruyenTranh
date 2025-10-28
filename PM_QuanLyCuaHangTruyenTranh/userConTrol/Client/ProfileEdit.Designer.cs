namespace PM.GUI.userConTrol.Client
{
    partial class Profile_Edit
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.linkChangeEmail = new System.Windows.Forms.LinkLabel();
            this.linkChangeSDT = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(235, 266);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(167, 53);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu thông tin";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(29, 80);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(98, 16);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Tên đăng nhập";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(86, 127);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(41, 16);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(42, 175);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(85, 16);
            this.lblSDT.TabIndex = 4;
            this.lblSDT.Text = "Số điện thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ngày sinh";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(156, 127);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(191, 22);
            this.txtEmail.TabIndex = 6;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(156, 175);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(191, 22);
            this.txtSDT.TabIndex = 7;
            // 
            // txtUsername
            // 
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Location = new System.Drawing.Point(142, 71);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderText = "";
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(229, 34);
            this.txtUsername.TabIndex = 9;
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.Checked = true;
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(156, 224);
            this.guna2DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(246, 36);
            this.guna2DateTimePicker1.TabIndex = 10;
            this.guna2DateTimePicker1.Value = new System.DateTime(2025, 10, 28, 14, 45, 13, 328);
            // 
            // linkChangeEmail
            // 
            this.linkChangeEmail.AutoSize = true;
            this.linkChangeEmail.Location = new System.Drawing.Point(363, 130);
            this.linkChangeEmail.Name = "linkChangeEmail";
            this.linkChangeEmail.Size = new System.Drawing.Size(60, 16);
            this.linkChangeEmail.TabIndex = 11;
            this.linkChangeEmail.TabStop = true;
            this.linkChangeEmail.Text = "Thay đổi";
            this.linkChangeEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkChangeEmail_LinkClicked);
            // 
            // linkChangeSDT
            // 
            this.linkChangeSDT.AutoSize = true;
            this.linkChangeSDT.Location = new System.Drawing.Point(363, 181);
            this.linkChangeSDT.Name = "linkChangeSDT";
            this.linkChangeSDT.Size = new System.Drawing.Size(60, 16);
            this.linkChangeSDT.TabIndex = 12;
            this.linkChangeSDT.TabStop = true;
            this.linkChangeSDT.Text = "Thay đổi";
            this.linkChangeSDT.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkChangeSDT_LinkClicked_1);
            // 
            // Profile_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkChangeSDT);
            this.Controls.Add(this.linkChangeEmail);
            this.Controls.Add(this.guna2DateTimePicker1);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnSave);
            this.Name = "Profile_Edit";
            this.Size = new System.Drawing.Size(671, 438);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private System.Windows.Forms.LinkLabel linkChangeEmail;
        private System.Windows.Forms.LinkLabel linkChangeSDT;
    }
}
