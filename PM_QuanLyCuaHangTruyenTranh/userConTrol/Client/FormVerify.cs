using System;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Client
{
    public partial class FormVerify : Form
    {
        private string _type;  // email / SDT / ...
        private string _otp;   // mã xác thực được truyền vào

        public FormVerify(string type, string otp)
        {
            InitializeComponent();
            _type = type;
            _otp = otp;
            lblTitle.Text = $"Xác minh {_type}";
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtOTP.Text.Trim() == _otp)
            {
                MessageBox.Show($"{_type} đã được xác thực thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã OTP không chính xác, vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
