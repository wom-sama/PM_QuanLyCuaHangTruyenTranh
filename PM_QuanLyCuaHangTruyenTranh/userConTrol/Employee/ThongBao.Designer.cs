namespace PM.GUI.userConTrol.Employee
{
    partial class ThongBao
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
            this.panelDanhSach = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
            // 
            // panelDanhSach
            // 
            this.panelDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDanhSach.Location = new System.Drawing.Point(0, 0);
            this.panelDanhSach.Name = "panelDanhSach";
            this.panelDanhSach.Size = new System.Drawing.Size(1469, 785);
            this.panelDanhSach.TabIndex = 0;
            // 
            // ThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDanhSach);
            this.Name = "ThongBao";
            this.Size = new System.Drawing.Size(1469, 785);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelDanhSach;
    }
}
