using System.Windows.Forms;

namespace PM.GUI.userConTrol.Employee
{
    partial class Kho
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private DataGridView dgvKho;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvKho = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Controls.Add(this.dgvKho);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1354, 833);
            this.guna2Panel1.TabIndex = 0;
            // 
            // dgvKho
            // 
            this.dgvKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKho.Name = "dgvKho";
            this.dgvKho.RowTemplate.Height = 28;
            this.dgvKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKho.MultiSelect = false;
            this.dgvKho.ReadOnly = true;
            // 
            // Kho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "Kho";
            this.Size = new System.Drawing.Size(1354, 833);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
