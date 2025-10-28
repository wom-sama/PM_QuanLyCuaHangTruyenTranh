namespace PM.GUI.Main
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
            this.giaoDienNV1 = new PM.GUI.userConTrol.Employee.GiaoDienNV();
            this.SuspendLayout();
            // 
            // giaoDienNV1
            // 
            this.giaoDienNV1.AutoScroll = true;
            this.giaoDienNV1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.giaoDienNV1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.giaoDienNV1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.giaoDienNV1.Location = new System.Drawing.Point(0, 0);
            this.giaoDienNV1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.giaoDienNV1.Name = "giaoDienNV1";
            this.giaoDienNV1.Size = new System.Drawing.Size(1190, 796);
            this.giaoDienNV1.TabIndex = 0;
            // 
            // NhanVienForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 796);
            this.Controls.Add(this.giaoDienNV1);
            this.Name = "NhanVienForm";
            this.Text = "NhanVienForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private userConTrol.Employee.GiaoDienNV giaoDienNV1;
    }
}