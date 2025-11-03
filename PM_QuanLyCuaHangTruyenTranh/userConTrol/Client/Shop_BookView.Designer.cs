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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shop_BookView));
            this.txtFindTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnFind = new Guna.UI2.WinForms.Guna2Button();
            this.btnCart = new Guna.UI2.WinForms.Guna2Button();
            this.panelDanhSach = new System.Windows.Forms.FlowLayoutPanel();
            this.pannelTong = new Guna.UI2.WinForms.Guna2Panel();
            this.cbChiNhanh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2ColorTransition1 = new Guna.UI2.WinForms.Guna2ColorTransition(this.components);
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pannelTong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFindTen
            // 
            this.txtFindTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFindTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFindTen.DefaultText = "";
            this.txtFindTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFindTen.Location = new System.Drawing.Point(117, 20);
            this.txtFindTen.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtFindTen.Name = "txtFindTen";
            this.txtFindTen.PlaceholderText = "Tìm kiếm sách...";
            this.txtFindTen.SelectedText = "";
            this.txtFindTen.Size = new System.Drawing.Size(234, 33);
            this.txtFindTen.TabIndex = 0;
            this.txtFindTen.TextChanged += new System.EventHandler(this.txtFindTen_TextChanged);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.BorderRadius = 10;
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Location = new System.Drawing.Point(357, 20);
            this.btnFind.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(122, 33);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnCart
            // 
            this.btnCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCart.BorderRadius = 10;
            this.btnCart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCart.ForeColor = System.Drawing.Color.White;
            this.btnCart.Location = new System.Drawing.Point(497, 20);
            this.btnCart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(148, 33);
            this.btnCart.TabIndex = 0;
            this.btnCart.Text = "🛒 Giỏ hàng";
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // panelDanhSach
            // 
            this.panelDanhSach.AutoScroll = true;
            this.panelDanhSach.Location = new System.Drawing.Point(3, 64);
            this.panelDanhSach.Name = "panelDanhSach";
            this.panelDanhSach.Size = new System.Drawing.Size(740, 392);
            this.panelDanhSach.TabIndex = 2;
            // 
            // pannelTong
            // 
            this.pannelTong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pannelTong.BackgroundImage")));
            this.pannelTong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pannelTong.Controls.Add(this.cbChiNhanh);
            this.pannelTong.Controls.Add(this.btnCart);
            this.pannelTong.Controls.Add(this.btnFind);
            this.pannelTong.Controls.Add(this.txtFindTen);
            this.pannelTong.Controls.Add(this.panelDanhSach);
            this.pannelTong.Location = new System.Drawing.Point(0, 0);
            this.pannelTong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pannelTong.Name = "pannelTong";
            this.pannelTong.Size = new System.Drawing.Size(677, 458);
            this.pannelTong.TabIndex = 3;
            this.pannelTong.Paint += new System.Windows.Forms.PaintEventHandler(this.pannelTong_Paint);
            // 
            // cbChiNhanh
            // 
            this.cbChiNhanh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbChiNhanh.BackColor = System.Drawing.Color.Transparent;
            this.cbChiNhanh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChiNhanh.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbChiNhanh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbChiNhanh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbChiNhanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbChiNhanh.ItemHeight = 30;
            this.cbChiNhanh.Location = new System.Drawing.Point(14, 20);
            this.cbChiNhanh.Name = "cbChiNhanh";
            this.cbChiNhanh.Size = new System.Drawing.Size(97, 36);
            this.cbChiNhanh.TabIndex = 3;
            this.cbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // guna2ColorTransition1
            // 
            this.guna2ColorTransition1.ColorArray = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue,
        System.Drawing.Color.Orange};
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CirclePictureBox1.Image = global::PM.GUI.Properties.Resources.Untitled123;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(651, 8);
            this.guna2CirclePictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(57, 51);
            this.guna2CirclePictureBox1.TabIndex = 0;
            this.guna2CirclePictureBox1.TabStop = false;
            this.guna2CirclePictureBox1.Click += new System.EventHandler(this.guna2CirclePictureBox1_Click);
            // 
            // Shop_BookView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2CirclePictureBox1);
            this.Controls.Add(this.pannelTong);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Shop_BookView";
            this.Size = new System.Drawing.Size(743, 458);
            this.Load += new System.EventHandler(this.Shop_BookView_Load);
            this.pannelTong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtFindTen;
        private Guna.UI2.WinForms.Guna2Button btnFind;
        private Guna.UI2.WinForms.Guna2Button btnCart;
        private System.Windows.Forms.FlowLayoutPanel panelDanhSach;
        private Guna.UI2.WinForms.Guna2Panel pannelTong;
        private Guna.UI2.WinForms.Guna2ComboBox cbChiNhanh;
        private Guna.UI2.WinForms.Guna2ColorTransition guna2ColorTransition1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
    }
}
