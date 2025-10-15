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
            this.lenDon1.Location = new System.Drawing.Point(45, 21);
            this.lenDon1.Name = "lenDon1";
            this.lenDon1.Size = new System.Drawing.Size(1255, 619);
            this.lenDon1.TabIndex = 0;
            // 
            // NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 694);
            this.Controls.Add(this.lenDon1);
            this.Name = "NhanVien";
            this.Text = "NhanVien";
            this.ResumeLayout(false);

        }

        #endregion

        private userConTrol.Employee.LenDon lenDon1;
    }
}