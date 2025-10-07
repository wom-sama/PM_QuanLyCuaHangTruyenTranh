namespace PM_QuanLyCuaHangTruyenTranh
{
    partial class FormMessage
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
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabelMess = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2AnimateWindow2 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2HtmlLabel1Froget = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 15;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI Symbol", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(94, 120);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(146, 36);
            this.guna2Button1.TabIndex = 0;
            this.guna2Button1.Text = "Ok";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2HtmlLabelMess
            // 
            this.guna2HtmlLabelMess.AutoSize = false;
            this.guna2HtmlLabelMess.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabelMess.Font = new System.Drawing.Font("Castellar", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabelMess.Location = new System.Drawing.Point(2, 14);
            this.guna2HtmlLabelMess.Name = "guna2HtmlLabelMess";
            this.guna2HtmlLabelMess.Size = new System.Drawing.Size(345, 100);
            this.guna2HtmlLabelMess.TabIndex = 1;
            this.guna2HtmlLabelMess.Text = "Messgase";
            this.guna2HtmlLabelMess.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.guna2HtmlLabelMess.Click += new System.EventHandler(this.guna2HtmlLabel1_Click);
            // 
            // guna2AnimateWindow1
            // 
            this.guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
            this.guna2AnimateWindow1.Interval = 300;
            this.guna2AnimateWindow1.TargetForm = this;
            // 
            // guna2AnimateWindow2
            // 
            this.guna2AnimateWindow2.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_HIDE;
            this.guna2AnimateWindow2.Interval = 300;
            this.guna2AnimateWindow2.TargetForm = this;
            // 
            // guna2HtmlLabel1Froget
            // 
            this.guna2HtmlLabel1Froget.AutoSize = false;
            this.guna2HtmlLabel1Froget.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1Froget.Location = new System.Drawing.Point(88, 163);
            this.guna2HtmlLabel1Froget.Name = "guna2HtmlLabel1Froget";
            this.guna2HtmlLabel1Froget.Size = new System.Drawing.Size(153, 29);
            this.guna2HtmlLabel1Froget.TabIndex = 2;
            this.guna2HtmlLabel1Froget.Text = "Forget passwod";
            this.guna2HtmlLabel1Froget.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.guna2HtmlLabel1Froget.Click += new System.EventHandler(this.guna2HtmlLabel1Froget_Click);
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(353, 199);
            this.Controls.Add(this.guna2HtmlLabel1Froget);
            this.Controls.Add(this.guna2HtmlLabelMess);
            this.Controls.Add(this.guna2Button1);
            this.Font = new System.Drawing.Font("Microsoft Yi Baiti", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Notification";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMessage_FormClosing);
            this.Load += new System.EventHandler(this.FormMessage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabelMess;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1Froget;
    }
}