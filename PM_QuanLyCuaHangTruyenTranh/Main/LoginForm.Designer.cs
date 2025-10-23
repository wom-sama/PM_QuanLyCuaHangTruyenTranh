namespace PM.GUI.Main
{
    partial class LoginForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.PicWaitGif = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GNcmbVAI = new Guna.UI2.WinForms.Guna2ComboBox();
            this.picRoleGif = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblInfo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblClick = new System.Windows.Forms.Label();
            this.lblHoi = new System.Windows.Forms.Label();
            this.GNbtnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUN = new System.Windows.Forms.Label();
            this.GNtxtPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.GNtxtUN = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
            this.checkMouseTimer = new System.Windows.Forms.Timer(this.components);
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicWaitGif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRoleGif)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.PicWaitGif);
            this.guna2ShadowPanel1.Controls.Add(this.label1);
            this.guna2ShadowPanel1.Controls.Add(this.GNcmbVAI);
            this.guna2ShadowPanel1.Controls.Add(this.picRoleGif);
            this.guna2ShadowPanel1.Controls.Add(this.lblInfo);
            this.guna2ShadowPanel1.Controls.Add(this.lblClick);
            this.guna2ShadowPanel1.Controls.Add(this.lblHoi);
            this.guna2ShadowPanel1.Controls.Add(this.GNbtnLogin);
            this.guna2ShadowPanel1.Controls.Add(this.lblPass);
            this.guna2ShadowPanel1.Controls.Add(this.lblUN);
            this.guna2ShadowPanel1.Controls.Add(this.GNtxtPass);
            this.guna2ShadowPanel1.Controls.Add(this.GNtxtUN);
            this.guna2Transition1.SetDecoration(this.guna2ShadowPanel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.Pink;
            this.guna2ShadowPanel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.LightGray;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(800, 450);
            this.guna2ShadowPanel1.TabIndex = 0;
//           this.guna2ShadowPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2ShadowPanel1_Paint);
            // 
            // PicWaitGif
            // 
            this.PicWaitGif.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2Transition1.SetDecoration(this.PicWaitGif, Guna.UI2.AnimatorNS.DecorationType.None);
            this.PicWaitGif.Image = global::PM_QuanLyCuaHangTruyenTranh.Properties.Resources.cherry_blossoms_6383_128;
            this.PicWaitGif.ImageRotate = 0F;
            this.PicWaitGif.Location = new System.Drawing.Point(431, 235);
            this.PicWaitGif.Name = "PicWaitGif";
            this.PicWaitGif.Size = new System.Drawing.Size(39, 36);
            this.PicWaitGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicWaitGif.TabIndex = 21;
            this.PicWaitGif.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.label1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.label1.Location = new System.Drawing.Point(195, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 20;
            this.label1.Text = "You are";
            // 
            // GNcmbVAI
            // 
            this.GNcmbVAI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GNcmbVAI.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.GNcmbVAI, Guna.UI2.AnimatorNS.DecorationType.None);
            this.GNcmbVAI.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.GNcmbVAI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GNcmbVAI.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNcmbVAI.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNcmbVAI.Font = new System.Drawing.Font("Imprint MT Shadow", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GNcmbVAI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(42)))), ((int)(((byte)(71)))));
            this.GNcmbVAI.ItemHeight = 30;
            this.GNcmbVAI.Location = new System.Drawing.Point(285, 235);
            this.GNcmbVAI.Name = "GNcmbVAI";
            this.GNcmbVAI.Size = new System.Drawing.Size(140, 36);
            this.GNcmbVAI.TabIndex = 19;
            this.GNcmbVAI.SelectedIndexChanged += new System.EventHandler(this.GNcmbVAI_SelectedIndexChanged);
            // 
            // picRoleGif
            // 
            this.picRoleGif.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picRoleGif.BorderRadius = 10;
            this.guna2Transition1.SetDecoration(this.picRoleGif, Guna.UI2.AnimatorNS.DecorationType.None);
            this.picRoleGif.Image = global::PM_QuanLyCuaHangTruyenTranh.Properties.Resources.cherry_blossoms_6383_128;
            this.picRoleGif.ImageRotate = 0F;
            this.picRoleGif.Location = new System.Drawing.Point(576, 161);
            this.picRoleGif.Name = "picRoleGif";
            this.picRoleGif.Size = new System.Drawing.Size(191, 160);
            this.picRoleGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRoleGif.TabIndex = 18;
            this.picRoleGif.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblInfo, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblInfo.Font = new System.Drawing.Font("Lucida Calligraphy", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblInfo.Location = new System.Drawing.Point(292, 40);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(186, 80);
            this.lblInfo.TabIndex = 17;
            this.lblInfo.Text = "Login";
            this.lblInfo.MouseEnter += new System.EventHandler(this.guna2HtmlLabel1_MouseEnter);
           this.lblInfo.MouseLeave += new System.EventHandler(this.guna2HtmlLabel1_MouseLeave);
            // 
            // lblClick
            // 
            this.lblClick.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblClick.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.lblClick, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblClick.Font = new System.Drawing.Font("Palatino Linotype", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.lblClick.Location = new System.Drawing.Point(378, 359);
            this.lblClick.Name = "lblClick";
            this.lblClick.Size = new System.Drawing.Size(102, 27);
            this.lblClick.TabIndex = 16;
            this.lblClick.Text = "click here!";
            this.lblClick.Click += new System.EventHandler(this.lblClick_Click);
           this.lblClick.MouseEnter += new System.EventHandler(this.lblClick_MouseEnter);
            this.lblClick.MouseLeave += new System.EventHandler(this.lblClick_MouseLeave);
            // 
            // lblHoi
            // 
            this.lblHoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHoi.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.lblHoi, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblHoi.Font = new System.Drawing.Font("Palatino Linotype", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.lblHoi.Location = new System.Drawing.Point(208, 359);
            this.lblHoi.Name = "lblHoi";
            this.lblHoi.Size = new System.Drawing.Size(123, 27);
            this.lblHoi.TabIndex = 15;
            this.lblHoi.Text = "not have acc";
          //  this.lblHoi.Click += new System.EventHandler(this.lblHoi_Click);
            // 
            // GNbtnLogin
            // 
            this.GNbtnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GNbtnLogin.BorderRadius = 20;
            this.guna2Transition1.SetDecoration(this.GNbtnLogin, Guna.UI2.AnimatorNS.DecorationType.None);
            this.GNbtnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNbtnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNbtnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNbtnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNbtnLogin.FillColor = System.Drawing.Color.RoyalBlue;
            this.GNbtnLogin.Font = new System.Drawing.Font("Tempus Sans ITC", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GNbtnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.GNbtnLogin.Location = new System.Drawing.Point(292, 294);
            this.GNbtnLogin.Name = "GNbtnLogin";
            this.GNbtnLogin.Size = new System.Drawing.Size(180, 45);
            this.GNbtnLogin.TabIndex = 14;
            this.GNbtnLogin.Text = "Login";
            this.GNbtnLogin.Click += new System.EventHandler(this.GNbtnLogin_Click);
            // 
            // lblPass
            // 
            this.lblPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPass.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.lblPass, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblPass.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.lblPass.Location = new System.Drawing.Point(189, 192);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(73, 23);
            this.lblPass.TabIndex = 13;
            this.lblPass.Text = "Password";
            // 
            // lblUN
            // 
            this.lblUN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUN.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.lblUN, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblUN.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.lblUN.Location = new System.Drawing.Point(189, 161);
            this.lblUN.Name = "lblUN";
            this.lblUN.Size = new System.Drawing.Size(79, 23);
            this.lblUN.TabIndex = 12;
            this.lblUN.Text = "UserName";
            // 
            // GNtxtPass
            // 
            this.GNtxtPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GNtxtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.GNtxtPass, Guna.UI2.AnimatorNS.DecorationType.None);
            this.GNtxtPass.DefaultText = "";
            this.GNtxtPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GNtxtPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GNtxtPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNtxtPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNtxtPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNtxtPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNtxtPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNtxtPass.Location = new System.Drawing.Point(285, 192);
            this.GNtxtPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GNtxtPass.Name = "GNtxtPass";
            this.GNtxtPass.PasswordChar = '*';
            this.GNtxtPass.PlaceholderText = "";
            this.GNtxtPass.SelectedText = "";
            this.GNtxtPass.Size = new System.Drawing.Size(227, 23);
            this.GNtxtPass.TabIndex = 11;
            // 
            // GNtxtUN
            // 
            this.GNtxtUN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GNtxtUN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.GNtxtUN, Guna.UI2.AnimatorNS.DecorationType.None);
            this.GNtxtUN.DefaultText = "";
            this.GNtxtUN.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GNtxtUN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GNtxtUN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNtxtUN.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNtxtUN.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNtxtUN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNtxtUN.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNtxtUN.Location = new System.Drawing.Point(285, 161);
            this.GNtxtUN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GNtxtUN.Name = "GNtxtUN";
            this.GNtxtUN.PlaceholderText = "";
            this.GNtxtUN.SelectedText = "";
            this.GNtxtUN.Size = new System.Drawing.Size(227, 23);
            this.GNtxtUN.TabIndex = 10;
            // 
            // guna2Transition1
            // 
            this.guna2Transition1.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Leaf;
            this.guna2Transition1.Cursor = System.Windows.Forms.Cursors.No;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 1F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.guna2Transition1.DefaultAnimation = animation1;
            // 
            // checkMouseTimer
            // 
            this.checkMouseTimer.Enabled = true;
            this.checkMouseTimer.Tick += new System.EventHandler(this.checkMouseTimer_Tick);
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicWaitGif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRoleGif)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.Label lblClick;
        private System.Windows.Forms.Label lblHoi;
        private Guna.UI2.WinForms.Guna2Button GNbtnLogin;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblUN;
        private Guna.UI2.WinForms.Guna2TextBox GNtxtPass;
        private Guna.UI2.WinForms.Guna2TextBox GNtxtUN;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblInfo;
        private Guna.UI2.WinForms.Guna2PictureBox picRoleGif;
        private Guna.UI2.WinForms.Guna2ComboBox GNcmbVAI;
        private Guna.UI2.WinForms.Guna2Transition guna2Transition1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox PicWaitGif;
        private System.Windows.Forms.Timer checkMouseTimer;
    }
}

