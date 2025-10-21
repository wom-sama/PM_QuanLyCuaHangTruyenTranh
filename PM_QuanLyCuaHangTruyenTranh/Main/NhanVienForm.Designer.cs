namespace PM_QuanLyCuaHangTruyenTranh.Main
{
    partial class NhanVienForm
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
            this.lenDon1 = new PM_QuanLyCuaHangTruyenTranh.userConTrol.Employee.LenDon();
            this.SuspendLayout();
            // 
            // lenDon1
            // 
            this.lenDon1.Location = new System.Drawing.Point(12, 11);
            this.lenDon1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lenDon1.Name = "lenDon1";
            this.lenDon1.Size = new System.Drawing.Size(1191, 567);
            this.lenDon1.TabIndex = 0;
            this.lenDon1.Load += new System.EventHandler(this.lenDon1_Load_1);
            // 
            // NhanVienForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 555);
            this.Controls.Add(this.lenDon1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "NhanVienForm";
            this.Text = "NhanVien";
            this.ResumeLayout(false);

        }

        #endregion

        private userConTrol.Employee.LenDon lenDon1;
    }
}