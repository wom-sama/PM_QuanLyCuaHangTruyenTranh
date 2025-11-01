using System;
using System.Windows.Forms;
using PM.BUS.Helpers;
using System.Drawing;

namespace PM.GUI.userConTrol.Customer
{
    public partial class ThanhToanQR : UserControl
    {
        private readonly string _maDon;
        private readonly decimal _tongTien;
        private readonly Action _onPaymentConfirmed;

        private int _thoiGianConLai = 10; // 🕒 180 giây = 3 phút
        private Timer _timer;

        public ThanhToanQR(string maDon, decimal tongTien, Action onPaymentConfirmed)
        {
            InitializeComponent();
            _maDon = maDon;
            _tongTien = tongTien;
            _onPaymentConfirmed = onPaymentConfirmed;
        }

        private void ThanhToanQR_Load(object sender, EventArgs e)
        {
            try
            {
                string bankCode = "BIDV";
                string accountNo = "6910973464";
                string accountName = "TRAN DUY TAN";

                string qrUrl = QrHelper.TaoQRThanhToan(bankCode, accountNo, accountName, _tongTien, _maDon);
                picQR.Load(qrUrl);

                lblThongTin.Text =
                    $"💳 Vui lòng quét mã để thanh toán\n" +
                    $"Số tiền: {_tongTien:N0} ₫\n" +
                    $"Nội dung: Thanh toan don {_maDon}";

                // 🟩 Khởi động bộ đếm thời gian
                _timer = new Timer();
                _timer.Interval = 1000; // 1 giây
                _timer.Tick += Timer_Tick;
                _timer.Start();

                UpdateCountdownLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải mã QR: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _thoiGianConLai--;
            UpdateCountdownLabel();

            if (_thoiGianConLai <= 0)
            {
                _timer.Stop();
                HetHanQR();
            }
        }

        private void UpdateCountdownLabel()
        {
            int phut = _thoiGianConLai / 60;
            int giay = _thoiGianConLai % 60;
            lblCountdown.Text = $"⏳ Mã QR sẽ hết hạn sau: {phut:D2}:{giay:D2}";
        }

        private void HetHanQR()
        {
            picQR.Image = null;
            lblThongTin.Text = "⚠️ Mã QR đã hết hạn.\nVui lòng tạo lại mã mới để thanh toán.";
            lblCountdown.Text = "🕒 Hết hạn";
            btnXacNhan.Enabled = false;
            btnXacNhan.BackColor = Color.Gray;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (_thoiGianConLai <= 0)
            {
                MessageBox.Show("❌ Mã QR đã hết hạn. Vui lòng tạo lại mã khác.", "Hết hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _timer?.Stop();

            // 🟢 Gọi callback để thêm đơn hàng + vận chuyển + quay lại Shop_BookView
            _onPaymentConfirmed?.Invoke();

            MessageBox.Show("✅ Thanh toán thành công!", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 🟢 Xóa control QR và hiển thị lại giao diện trước đó
            var parent = this.Parent;
            if (parent != null)
            {
                parent.Controls.Remove(this);
                this.Dispose();

                // Tìm control MuaHang và hiển thị lại nếu có
                foreach (Control ctrl in parent.Controls)
                {
                    if (ctrl is MuaHang)
                    {
                        ctrl.Show();
                        ctrl.BringToFront();
                        break;
                    }
                }
            }
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            _timer?.Stop();

            // 🟢 Lưu parent lại trước khi Dispose
            var parent = this.Parent;

            if (parent != null)
            {
                parent.Controls.Remove(this);
                this.Dispose();

                // Hiện lại control mua hàng
                foreach (Control ctrl in parent.Controls)
                {
                    if (ctrl is MuaHang)
                    {
                        ctrl.Show();
                        ctrl.BringToFront(); // ✅ đảm bảo hiện lên trên cùng
                        break;
                    }
                }
            }
        }

        private void lblCountdown_Click(object sender, EventArgs e)
        {

        }
    }
}
