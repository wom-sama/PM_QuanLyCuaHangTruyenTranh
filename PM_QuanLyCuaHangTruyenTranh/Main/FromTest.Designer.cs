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
            this.PanelTest = new Guna.UI2.WinForms.Guna2Panel();
           // this.shop_BookView1 = new PM.GUI.userConTrol.Customer.Shop_BookView();
            this.PanelTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTest
            // 
            this.PanelTest.AutoScroll = true;
//            this.PanelTest.Controls.Add(this.shop_BookView1);
            this.PanelTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTest.Location = new System.Drawing.Point(0, 0);
            this.PanelTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PanelTest.Name = "PanelTest";
            this.PanelTest.Size = new System.Drawing.Size(900, 562);
            this.PanelTest.TabIndex = 0;
            // 
            // shop_BookView1
            // 
//            this.shop_BookView1.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.shop_BookView1.Location = new System.Drawing.Point(0, 0);
  //          this.shop_BookView1.Name = "shop_BookView1";
         //   this.shop_BookView1.Size = new System.Drawing.Size(900, 562);
         //   this.shop_BookView1.TabIndex = 0;
            // 
            // FromTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.PanelTest);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FromTest";
            this.Text = "FromTest";
            this.PanelTest.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel PanelTest;
        private userConTrol.Customer.Shop_BookView shop_BookView1;
    }
}