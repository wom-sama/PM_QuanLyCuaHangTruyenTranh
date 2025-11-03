namespace PM.GUI.userConTrol.Admin
{
    partial class TaiKhoanNhanVien
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaiKhoanNhanVien));
            this.panel_tong = new Guna.UI2.WinForms.Guna2Panel();
            this.Panel_Them = new Guna.UI2.WinForms.Guna2Panel();
            this.txt_MatKhau = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_Tao = new Guna.UI2.WinForms.Guna2Button();
            this.cbo_ChiNhanhThem = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbo_ChucVuThem = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btn_Bo = new Guna.UI2.WinForms.Guna2Button();
            this.txtTaiKhoan = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel_Sua = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTenNhanVienSua = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbo_CvSua = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbo_ChiNhanhSua = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btn_Luu = new Guna.UI2.WinForms.Guna2Button();
            this.btn_huy = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Tim = new Guna.UI2.WinForms.Guna2Button();
            this.txtTim = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_Xoa = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Sua = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Them = new Guna.UI2.WinForms.Guna2Button();
            this.lbl_Title = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.DGV_TaiKhoanNhanVien = new Guna.UI2.WinForms.Guna2DataGridView();
            this.TransT = new Guna.UI2.WinForms.Guna2Transition();
            this.guna2ColorTransition1 = new Guna.UI2.WinForms.Guna2ColorTransition(this.components);
            this.panel_tong.SuspendLayout();
            this.Panel_Them.SuspendLayout();
            this.panel_Sua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_TaiKhoanNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_tong
            // 
            this.panel_tong.BackgroundImage = global::PM.GUI.Properties.Resources.cherry_blossoms_6383_128;
            this.panel_tong.Controls.Add(this.Panel_Them);
            this.panel_tong.Controls.Add(this.panel_Sua);
            this.panel_tong.Controls.Add(this.btn_Tim);
            this.panel_tong.Controls.Add(this.txtTim);
            this.panel_tong.Controls.Add(this.btn_Xoa);
            this.panel_tong.Controls.Add(this.btn_Sua);
            this.panel_tong.Controls.Add(this.btn_Them);
            this.panel_tong.Controls.Add(this.lbl_Title);
            this.panel_tong.Controls.Add(this.DGV_TaiKhoanNhanVien);
            this.TransT.SetDecoration(this.panel_tong, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panel_tong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_tong.Location = new System.Drawing.Point(0, 0);
            this.panel_tong.Name = "panel_tong";
            this.panel_tong.Size = new System.Drawing.Size(1242, 630);
            this.panel_tong.TabIndex = 0;
            this.panel_tong.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_tong_Paint);
            // 
            // Panel_Them
            // 
            this.Panel_Them.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Them.BackColor = System.Drawing.Color.Pink;
            this.Panel_Them.Controls.Add(this.txt_MatKhau);
            this.Panel_Them.Controls.Add(this.btn_Tao);
            this.Panel_Them.Controls.Add(this.cbo_ChiNhanhThem);
            this.Panel_Them.Controls.Add(this.cbo_ChucVuThem);
            this.Panel_Them.Controls.Add(this.btn_Bo);
            this.Panel_Them.Controls.Add(this.txtTaiKhoan);
            this.TransT.SetDecoration(this.Panel_Them, Guna.UI2.AnimatorNS.DecorationType.None);
            this.Panel_Them.Location = new System.Drawing.Point(902, 114);
            this.Panel_Them.Name = "Panel_Them";
            this.Panel_Them.Size = new System.Drawing.Size(340, 521);
            this.Panel_Them.TabIndex = 7;
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TransT.SetDecoration(this.txt_MatKhau, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txt_MatKhau.DefaultText = "";
            this.txt_MatKhau.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_MatKhau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_MatKhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MatKhau.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MatKhau.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MatKhau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_MatKhau.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MatKhau.Location = new System.Drawing.Point(59, 127);
            this.txt_MatKhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.PasswordChar = '*';
            this.txt_MatKhau.PlaceholderText = "Mật Khẩu..";
            this.txt_MatKhau.SelectedText = "";
            this.txt_MatKhau.Size = new System.Drawing.Size(267, 48);
            this.txt_MatKhau.TabIndex = 11;
            // 
            // btn_Tao
            // 
            this.btn_Tao.BorderRadius = 20;
            this.btn_Tao.BorderThickness = 1;
            this.TransT.SetDecoration(this.btn_Tao, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btn_Tao.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Tao.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Tao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Tao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Tao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Tao.ForeColor = System.Drawing.Color.White;
            this.btn_Tao.Location = new System.Drawing.Point(20, 428);
            this.btn_Tao.Name = "btn_Tao";
            this.btn_Tao.Size = new System.Drawing.Size(180, 45);
            this.btn_Tao.TabIndex = 9;
            this.btn_Tao.Text = "Tạo";
            this.btn_Tao.Click += new System.EventHandler(this.btn_Tao_Click);
            // 
            // cbo_ChiNhanhThem
            // 
            this.cbo_ChiNhanhThem.BackColor = System.Drawing.Color.Transparent;
            this.TransT.SetDecoration(this.cbo_ChiNhanhThem, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cbo_ChiNhanhThem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_ChiNhanhThem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_ChiNhanhThem.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_ChiNhanhThem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_ChiNhanhThem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_ChiNhanhThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbo_ChiNhanhThem.ItemHeight = 30;
            this.cbo_ChiNhanhThem.Location = new System.Drawing.Point(59, 257);
            this.cbo_ChiNhanhThem.Name = "cbo_ChiNhanhThem";
            this.cbo_ChiNhanhThem.Size = new System.Drawing.Size(267, 36);
            this.cbo_ChiNhanhThem.TabIndex = 1;
            // 
            // cbo_ChucVuThem
            // 
            this.cbo_ChucVuThem.BackColor = System.Drawing.Color.Transparent;
            this.TransT.SetDecoration(this.cbo_ChucVuThem, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cbo_ChucVuThem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_ChucVuThem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_ChucVuThem.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_ChucVuThem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_ChucVuThem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_ChucVuThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbo_ChucVuThem.ItemHeight = 30;
            this.cbo_ChucVuThem.Location = new System.Drawing.Point(59, 200);
            this.cbo_ChucVuThem.Name = "cbo_ChucVuThem";
            this.cbo_ChucVuThem.Size = new System.Drawing.Size(267, 36);
            this.cbo_ChucVuThem.TabIndex = 2;
            this.cbo_ChucVuThem.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox2_SelectedIndexChanged);
            // 
            // btn_Bo
            // 
            this.btn_Bo.BorderRadius = 20;
            this.btn_Bo.BorderThickness = 1;
            this.TransT.SetDecoration(this.btn_Bo, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btn_Bo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Bo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Bo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Bo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Bo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Bo.ForeColor = System.Drawing.Color.White;
            this.btn_Bo.Location = new System.Drawing.Point(218, 428);
            this.btn_Bo.Name = "btn_Bo";
            this.btn_Bo.Size = new System.Drawing.Size(108, 45);
            this.btn_Bo.TabIndex = 10;
            this.btn_Bo.Text = "Hủy";
            this.btn_Bo.Click += new System.EventHandler(this.btn_Bo_Click);
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TransT.SetDecoration(this.txtTaiKhoan, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtTaiKhoan.DefaultText = "";
            this.txtTaiKhoan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTaiKhoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTaiKhoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTaiKhoan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTaiKhoan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTaiKhoan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTaiKhoan.Location = new System.Drawing.Point(59, 46);
            this.txtTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.PlaceholderText = "Tài Khoản..";
            this.txtTaiKhoan.SelectedText = "";
            this.txtTaiKhoan.Size = new System.Drawing.Size(267, 48);
            this.txtTaiKhoan.TabIndex = 0;
            // 
            // panel_Sua
            // 
            this.panel_Sua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_Sua.BackColor = System.Drawing.Color.Pink;
            this.panel_Sua.Controls.Add(this.txtTenNhanVienSua);
            this.panel_Sua.Controls.Add(this.cbo_CvSua);
            this.panel_Sua.Controls.Add(this.cbo_ChiNhanhSua);
            this.panel_Sua.Controls.Add(this.btn_Luu);
            this.panel_Sua.Controls.Add(this.btn_huy);
            this.TransT.SetDecoration(this.panel_Sua, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panel_Sua.Location = new System.Drawing.Point(3, 114);
            this.panel_Sua.Name = "panel_Sua";
            this.panel_Sua.Size = new System.Drawing.Size(355, 513);
            this.panel_Sua.TabIndex = 8;
            // 
            // txtTenNhanVienSua
            // 
            this.txtTenNhanVienSua.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TransT.SetDecoration(this.txtTenNhanVienSua, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtTenNhanVienSua.DefaultText = "";
            this.txtTenNhanVienSua.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenNhanVienSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenNhanVienSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenNhanVienSua.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenNhanVienSua.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenNhanVienSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenNhanVienSua.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenNhanVienSua.Location = new System.Drawing.Point(37, 41);
            this.txtTenNhanVienSua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenNhanVienSua.Name = "txtTenNhanVienSua";
            this.txtTenNhanVienSua.PlaceholderText = "";
            this.txtTenNhanVienSua.ReadOnly = true;
            this.txtTenNhanVienSua.SelectedText = "";
            this.txtTenNhanVienSua.Size = new System.Drawing.Size(267, 48);
            this.txtTenNhanVienSua.TabIndex = 12;
            // 
            // cbo_CvSua
            // 
            this.cbo_CvSua.BackColor = System.Drawing.Color.Transparent;
            this.TransT.SetDecoration(this.cbo_CvSua, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cbo_CvSua.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_CvSua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_CvSua.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_CvSua.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_CvSua.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_CvSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbo_CvSua.ItemHeight = 30;
            this.cbo_CvSua.Location = new System.Drawing.Point(37, 131);
            this.cbo_CvSua.Name = "cbo_CvSua";
            this.cbo_CvSua.Size = new System.Drawing.Size(267, 36);
            this.cbo_CvSua.TabIndex = 12;
            // 
            // cbo_ChiNhanhSua
            // 
            this.cbo_ChiNhanhSua.BackColor = System.Drawing.Color.Transparent;
            this.TransT.SetDecoration(this.cbo_ChiNhanhSua, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cbo_ChiNhanhSua.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_ChiNhanhSua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_ChiNhanhSua.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_ChiNhanhSua.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_ChiNhanhSua.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_ChiNhanhSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbo_ChiNhanhSua.ItemHeight = 30;
            this.cbo_ChiNhanhSua.Location = new System.Drawing.Point(37, 192);
            this.cbo_ChiNhanhSua.Name = "cbo_ChiNhanhSua";
            this.cbo_ChiNhanhSua.Size = new System.Drawing.Size(267, 36);
            this.cbo_ChiNhanhSua.TabIndex = 13;
            // 
            // btn_Luu
            // 
            this.btn_Luu.BorderRadius = 20;
            this.btn_Luu.BorderThickness = 1;
            this.TransT.SetDecoration(this.btn_Luu, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btn_Luu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Luu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Luu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Luu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Luu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Luu.ForeColor = System.Drawing.Color.White;
            this.btn_Luu.Location = new System.Drawing.Point(15, 420);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(180, 45);
            this.btn_Luu.TabIndex = 12;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.BorderRadius = 20;
            this.btn_huy.BorderThickness = 1;
            this.TransT.SetDecoration(this.btn_huy, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btn_huy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_huy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_huy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_huy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_huy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_huy.ForeColor = System.Drawing.Color.White;
            this.btn_huy.Location = new System.Drawing.Point(201, 420);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(108, 45);
            this.btn_huy.TabIndex = 13;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_Tim
            // 
            this.btn_Tim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Tim.BackColor = System.Drawing.Color.Transparent;
            this.btn_Tim.BorderRadius = 20;
            this.btn_Tim.BorderThickness = 1;
            this.TransT.SetDecoration(this.btn_Tim, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btn_Tim.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Tim.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Tim.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Tim.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Tim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Tim.ForeColor = System.Drawing.Color.White;
            this.btn_Tim.Location = new System.Drawing.Point(421, 162);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(180, 45);
            this.btn_Tim.TabIndex = 6;
            this.btn_Tim.Text = "Tim";
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // txtTim
            // 
            this.txtTim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTim.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TransT.SetDecoration(this.txtTim, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtTim.DefaultText = "";
            this.txtTim.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTim.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTim.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTim.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTim.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTim.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTim.Location = new System.Drawing.Point(1, 162);
            this.txtTim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTim.Name = "txtTim";
            this.txtTim.PlaceholderText = "";
            this.txtTim.SelectedText = "";
            this.txtTim.Size = new System.Drawing.Size(357, 48);
            this.txtTim.TabIndex = 5;
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Xoa.BackColor = System.Drawing.Color.Transparent;
            this.btn_Xoa.BorderRadius = 20;
            this.btn_Xoa.BorderThickness = 1;
            this.TransT.SetDecoration(this.btn_Xoa, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btn_Xoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Xoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Xoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Xoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Xoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Xoa.ForeColor = System.Drawing.Color.White;
            this.btn_Xoa.Location = new System.Drawing.Point(1048, 162);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(180, 45);
            this.btn_Xoa.TabIndex = 4;
            this.btn_Xoa.Text = "Xoa";
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Sua.BackColor = System.Drawing.Color.Transparent;
            this.btn_Sua.BorderRadius = 20;
            this.btn_Sua.BorderThickness = 1;
            this.TransT.SetDecoration(this.btn_Sua, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btn_Sua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Sua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Sua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Sua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Sua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Sua.ForeColor = System.Drawing.Color.White;
            this.btn_Sua.Location = new System.Drawing.Point(834, 162);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(180, 45);
            this.btn_Sua.TabIndex = 3;
            this.btn_Sua.Text = "Sua";
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Them.BackColor = System.Drawing.Color.Transparent;
            this.btn_Them.BorderRadius = 20;
            this.btn_Them.BorderThickness = 1;
            this.TransT.SetDecoration(this.btn_Them, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btn_Them.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Them.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Them.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Them.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Them.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Them.ForeColor = System.Drawing.Color.White;
            this.btn_Them.Location = new System.Drawing.Point(632, 162);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(180, 45);
            this.btn_Them.TabIndex = 2;
            this.btn_Them.Text = "Them";
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = false;
            this.lbl_Title.BackColor = System.Drawing.Color.Pink;
            this.TransT.SetDecoration(this.lbl_Title, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lbl_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Title.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(0, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(1242, 115);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "Thông Tin  Nhân Viên";
            // 
            // DGV_TaiKhoanNhanVien
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGV_TaiKhoanNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_TaiKhoanNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_TaiKhoanNhanVien.ColumnHeadersHeight = 4;
            this.DGV_TaiKhoanNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.TransT.SetDecoration(this.DGV_TaiKhoanNhanVien, Guna.UI2.AnimatorNS.DecorationType.None);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_TaiKhoanNhanVien.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_TaiKhoanNhanVien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGV_TaiKhoanNhanVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGV_TaiKhoanNhanVien.Location = new System.Drawing.Point(0, 240);
            this.DGV_TaiKhoanNhanVien.Name = "DGV_TaiKhoanNhanVien";
            this.DGV_TaiKhoanNhanVien.RowHeadersVisible = false;
            this.DGV_TaiKhoanNhanVien.RowHeadersWidth = 51;
            this.DGV_TaiKhoanNhanVien.RowTemplate.Height = 24;
            this.DGV_TaiKhoanNhanVien.Size = new System.Drawing.Size(1242, 390);
            this.DGV_TaiKhoanNhanVien.TabIndex = 0;
            this.DGV_TaiKhoanNhanVien.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGV_TaiKhoanNhanVien.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGV_TaiKhoanNhanVien.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGV_TaiKhoanNhanVien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGV_TaiKhoanNhanVien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGV_TaiKhoanNhanVien.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGV_TaiKhoanNhanVien.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGV_TaiKhoanNhanVien.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DGV_TaiKhoanNhanVien.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGV_TaiKhoanNhanVien.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_TaiKhoanNhanVien.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGV_TaiKhoanNhanVien.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGV_TaiKhoanNhanVien.ThemeStyle.HeaderStyle.Height = 4;
            this.DGV_TaiKhoanNhanVien.ThemeStyle.ReadOnly = false;
            this.DGV_TaiKhoanNhanVien.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGV_TaiKhoanNhanVien.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGV_TaiKhoanNhanVien.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_TaiKhoanNhanVien.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGV_TaiKhoanNhanVien.ThemeStyle.RowsStyle.Height = 24;
            this.DGV_TaiKhoanNhanVien.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGV_TaiKhoanNhanVien.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGV_TaiKhoanNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_TaiKhoanNhanVien_CellClick);
            // 
            // TransT
            // 
            this.TransT.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Scale;
            this.TransT.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.TransT.DefaultAnimation = animation1;
            // 
            // guna2ColorTransition1
            // 
            this.guna2ColorTransition1.ColorArray = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue,
        System.Drawing.Color.Orange};
            // 
            // TaiKhoanNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_tong);
            this.TransT.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.Name = "TaiKhoanNhanVien";
            this.Size = new System.Drawing.Size(1242, 630);
            this.Load += new System.EventHandler(this.TaiKhoanNhanVien_Load);
            this.panel_tong.ResumeLayout(false);
            this.Panel_Them.ResumeLayout(false);
            this.panel_Sua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_TaiKhoanNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panel_tong;
        private Guna.UI2.WinForms.Guna2Button btn_Them;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_Title;
        private Guna.UI2.WinForms.Guna2DataGridView DGV_TaiKhoanNhanVien;
        private Guna.UI2.WinForms.Guna2Button btn_Sua;
        private Guna.UI2.WinForms.Guna2Button btn_Xoa;
        private Guna.UI2.WinForms.Guna2Button btn_Tim;
        private Guna.UI2.WinForms.Guna2TextBox txtTim;
        private Guna.UI2.WinForms.Guna2Panel panel_Sua;
        private Guna.UI2.WinForms.Guna2Panel Panel_Them;
        private Guna.UI2.WinForms.Guna2TextBox txt_MatKhau;
        private Guna.UI2.WinForms.Guna2Button btn_Tao;
        private Guna.UI2.WinForms.Guna2Button btn_Bo;
        private Guna.UI2.WinForms.Guna2ComboBox cbo_ChucVuThem;
        private Guna.UI2.WinForms.Guna2ComboBox cbo_ChiNhanhThem;
        private Guna.UI2.WinForms.Guna2TextBox txtTaiKhoan;
        private Guna.UI2.WinForms.Guna2Button btn_Luu;
        private Guna.UI2.WinForms.Guna2Button btn_huy;
        private Guna.UI2.WinForms.Guna2ComboBox cbo_CvSua;
        private Guna.UI2.WinForms.Guna2ComboBox cbo_ChiNhanhSua;
        private Guna.UI2.WinForms.Guna2TextBox txtTenNhanVienSua;
        private Guna.UI2.WinForms.Guna2Transition TransT;
        private Guna.UI2.WinForms.Guna2ColorTransition guna2ColorTransition1;
    }
}
