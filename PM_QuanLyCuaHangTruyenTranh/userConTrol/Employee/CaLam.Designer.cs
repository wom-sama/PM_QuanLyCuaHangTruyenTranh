namespace PM.GUI.userConTrol.Employee
{
    partial class CaLam
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.DataGridView dgvCaLam;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.dgvCaLam = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaLam)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Text = "📅 Ca làm của tôi";

            // lblNhanVien
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblNhanVien.ForeColor = System.Drawing.Color.Gray;
            this.lblNhanVien.Location = new System.Drawing.Point(35, 60);
            this.lblNhanVien.Text = "Nhân viên: ";

            // dgvCaLam
            this.dgvCaLam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCaLam.BackgroundColor = System.Drawing.Color.White;
            this.dgvCaLam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCaLam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaLam.Location = new System.Drawing.Point(30, 100);
            this.dgvCaLam.ReadOnly = true;
            this.dgvCaLam.RowHeadersVisible = false;
            this.dgvCaLam.Size = new System.Drawing.Size(1120, 530);
            this.dgvCaLam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaLam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // CaLam
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNhanVien);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvCaLam);
            this.Name = "CaLam";
            this.Size = new System.Drawing.Size(1193, 662);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaLam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
