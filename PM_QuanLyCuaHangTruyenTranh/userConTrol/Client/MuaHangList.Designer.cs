namespace PM.GUI.userConTrol.Client
{
    partial class MuaHangList
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel pannelTong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pannelTong = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
            // 
            // pannelTong
            // 
            this.pannelTong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pannelTong.AutoScroll = true;
            this.pannelTong.FillColor = System.Drawing.Color.White;
            this.pannelTong.BorderRadius = 10;
            this.pannelTong.ShadowDecoration.Enabled = true;
            this.pannelTong.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.pannelTong.ShadowDecoration.Depth = 5;
            this.pannelTong.Location = new System.Drawing.Point(0, 0);
            this.pannelTong.Name = "pannelTong";
            this.pannelTong.Size = new System.Drawing.Size(800, 600);
            this.pannelTong.TabIndex = 0;
            // 
            // MuaHangList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pannelTong);
            this.Name = "MuaHangList";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
        }
    }
}
