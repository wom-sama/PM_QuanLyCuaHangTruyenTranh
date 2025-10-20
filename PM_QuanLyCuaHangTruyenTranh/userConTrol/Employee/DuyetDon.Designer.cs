using System.Windows.Forms;

namespace PM_QuanLyCuaHangTruyenTranh.userConTrol.Employee
{
    partial class DuyetDon
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDonHang;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChiTiet;
        private Guna.UI2.WinForms.Guna2Button btnDuyet;
        private Guna.UI2.WinForms.Guna2Button btnTaiLai;
        private Label lblDonHang;
        private Label lblChiTiet;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDonHang = new System.Windows.Forms.Label();
            this.lblChiTiet = new System.Windows.Forms.Label();
            this.dgvDonHang = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvChiTiet = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnDuyet = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaiLai = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.lblDonHang);
            this.panelMain.Controls.Add(this.lblChiTiet);
            this.panelMain.Controls.Add(this.dgvDonHang);
            this.panelMain.Controls.Add(this.dgvChiTiet);
            this.panelMain.Controls.Add(this.btnDuyet);
            this.panelMain.Controls.Add(this.btnTaiLai);
            this.panelMain.Size = new System.Drawing.Size(1367, 754);
            this.panelMain.TabIndex = 0;
            // 
            // lblDonHang
            // 
            this.lblDonHang.AutoSize = true;
            this.lblDonHang.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDonHang.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblDonHang.Location = new System.Drawing.Point(30, 20);
            this.lblDonHang.Text = "📦 Danh sách đơn hàng";
            // 
            // lblChiTiet
            // 
            this.lblChiTiet.AutoSize = true;
            this.lblChiTiet.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblChiTiet.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblChiTiet.Location = new System.Drawing.Point(720, 20);
            this.lblChiTiet.Text = "📚 Chi tiết đơn hàng";
            // 
            // dgvDonHang
            // 
            this.dgvDonHang.Location = new System.Drawing.Point(35, 60);
            this.dgvDonHang.Size = new System.Drawing.Size(600, 550);
            this.dgvDonHang.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDonHang.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.SteelBlue;
            this.dgvDonHang.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvDonHang.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDonHang.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvDonHang.RowTemplate.Height = 28;
            this.dgvDonHang.CellClick += new DataGridViewCellEventHandler(this.guna2DataGridView1_CellClick);
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Location = new System.Drawing.Point(725, 60);
            this.dgvChiTiet.Size = new System.Drawing.Size(600, 550);
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.SeaGreen;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvChiTiet.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvChiTiet.RowTemplate.Height = 28;
            this.dgvChiTiet.CellClick += new DataGridViewCellEventHandler(this.guna2DataGridView2_CellClick);
            // 
            // btnDuyet
            // 
            this.btnDuyet.Text = "✅ Duyệt đơn";
            this.btnDuyet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDuyet.FillColor = System.Drawing.Color.ForestGreen;
            this.btnDuyet.ForeColor = System.Drawing.Color.White;
            this.btnDuyet.Size = new System.Drawing.Size(200, 60);
            this.btnDuyet.Location = new System.Drawing.Point(250, 640);
            this.btnDuyet.Click += new System.EventHandler(this.BtnDuyetDon_Click);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Text = "🔄 Tải lại";
            this.btnTaiLai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTaiLai.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnTaiLai.ForeColor = System.Drawing.Color.White;
            this.btnTaiLai.Size = new System.Drawing.Size(200, 60);
            this.btnTaiLai.Location = new System.Drawing.Point(480, 640);
            this.btnTaiLai.Click += new System.EventHandler(this.BtnTaiLai_Click);
            // 
            // DuyetDon
            // 
            this.Controls.Add(this.panelMain);
            this.Name = "DuyetDon";
            this.Size = new System.Drawing.Size(1367, 754);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
