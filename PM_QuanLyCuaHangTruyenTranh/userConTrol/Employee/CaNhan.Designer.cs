namespace PM.GUI.userConTrol.Employee
{
    partial class CaNhan
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
            this.pannelCaNhan = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
            // 
            // pannelCaNhan
            // 
            this.pannelCaNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pannelCaNhan.Location = new System.Drawing.Point(0, 0);
            this.pannelCaNhan.Name = "pannelCaNhan";
            this.pannelCaNhan.Size = new System.Drawing.Size(1507, 1048);
            this.pannelCaNhan.TabIndex = 0;
            // 
            // CaNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pannelCaNhan);
            this.Name = "CaNhan";
            this.Size = new System.Drawing.Size(1507, 1048);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pannelCaNhan;
    }
}
