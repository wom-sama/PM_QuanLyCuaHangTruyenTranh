namespace PM.GUI.userConTrol.Customer
{
    partial class Shop_BookView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.txtFindTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnFind = new Guna.UI2.WinForms.Guna2Button();
            this.btnCart = new Guna.UI2.WinForms.Guna2Button();
            this.panelDanhSach = new System.Windows.Forms.FlowLayoutPanel();
            this.pannelTong = new Guna.UI2.WinForms.Guna2Panel();
            this.pannelTong.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFindTen
            // 
            this.txtFindTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFindTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFindTen.DefaultText = "";
            this.txtFindTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFindTen.Location = new System.Drawing.Point(80, 25);
            this.txtFindTen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFindTen.Name = "txtFindTen";
            this.txtFindTen.PlaceholderText = "Tìm kiếm sách...";
            this.txtFindTen.SelectedText = "";
            this.txtFindTen.Size = new System.Drawing.Size(500, 41);
            this.txtFindTen.TabIndex = 0;
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.BorderRadius = 10;
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Location = new System.Drawing.Point(590, 25);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(80, 41);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "Tìm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnCart
            // 
            this.btnCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCart.BorderRadius = 10;
            this.btnCart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCart.ForeColor = System.Drawing.Color.White;
            this.btnCart.Location = new System.Drawing.Point(680, 25);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(120, 41);
            this.btnCart.TabIndex = 0;
            this.btnCart.Text = "🛒 Giỏ hàng";
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // panelDanhSach
            // 
            this.panelDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDanhSach.AutoScroll = true;
            this.panelDanhSach.Location = new System.Drawing.Point(3, 80);
            this.panelDanhSach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelDanhSach.Name = "panelDanhSach";
            this.panelDanhSach.Size = new System.Drawing.Size(830, 490);
            this.panelDanhSach.TabIndex = 2;
            // 
            // pannelTong
            // 
            this.pannelTong.Controls.Add(this.btnCart);
            this.pannelTong.Controls.Add(this.btnFind);
            this.pannelTong.Controls.Add(this.txtFindTen);
            this.pannelTong.Controls.Add(this.panelDanhSach);
            this.pannelTong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pannelTong.Location = new System.Drawing.Point(0, 0);
            this.pannelTong.Name = "pannelTong";
            this.pannelTong.Size = new System.Drawing.Size(836, 573);
            this.pannelTong.TabIndex = 3;
            this.pannelTong.Paint += new System.Windows.Forms.PaintEventHandler(this.pannelTong_Paint);
            // 
            // Shop_BookView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pannelTong);
            this.Name = "Shop_BookView";
            this.Size = new System.Drawing.Size(836, 573);
            this.Load += new System.EventHandler(this.Shop_BookView_Load);
            this.pannelTong.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtFindTen;
        private Guna.UI2.WinForms.Guna2Button btnFind;
        private Guna.UI2.WinForms.Guna2Button btnCart;
        private System.Windows.Forms.FlowLayoutPanel panelDanhSach;
        private Guna.UI2.WinForms.Guna2Panel pannelTong;
    }
}
