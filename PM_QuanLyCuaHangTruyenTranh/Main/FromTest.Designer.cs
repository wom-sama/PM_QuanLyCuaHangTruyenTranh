namespace PM.GUI.Main
{
    partial class FromTest
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
            this.add_Book1 = new PM.GUI.userConTrol.Admin.Add_Book();
            this.SuspendLayout();
            // 
            // add_Book1
            // 
            this.add_Book1.BackColor = System.Drawing.Color.White;
            this.add_Book1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.add_Book1.Location = new System.Drawing.Point(0, 0);
            this.add_Book1.Name = "add_Book1";
            this.add_Book1.Size = new System.Drawing.Size(800, 450);
            this.add_Book1.TabIndex = 0;
            // 
            // FromTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.add_Book1);
            this.Name = "FromTest";
            this.Text = "FromTest";
            this.ResumeLayout(false);

        }

        #endregion

        private userConTrol.Admin.Add_Book add_Book1;
    }
}