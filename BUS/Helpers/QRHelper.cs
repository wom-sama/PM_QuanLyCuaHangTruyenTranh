using System;
using System.Net;

namespace PM.BUS.Helpers
{
    public static class QrHelper
    {
        /// <summary>
        /// Tạo URL QR thanh toán VietQR dùng cho WinForms (.NET Framework 4.8).
        /// </summary>
        /// <param name="bankCode">Mã ngân hàng (VD: BIDV, MBBank, Vietcombank...)</param>
        /// <param name="accountNo">Số tài khoản người nhận</param>
        /// <param name="accountName">Tên chủ tài khoản</param>
        /// <param name="amount">Số tiền cần thanh toán</param>
        /// <param name="orderId">Mã đơn hàng hoặc nội dung ghi chú</param>
        /// <returns>Chuỗi URL ảnh QR hợp lệ có thể gán cho PictureBox.Load()</returns>
        public static string TaoQRThanhToan(
            string bankCode, string accountNo, string accountName,
            decimal amount, string orderId)
        {
            if (string.IsNullOrWhiteSpace(bankCode))
                throw new ArgumentException("Thiếu mã ngân hàng.");
            if (string.IsNullOrWhiteSpace(accountNo))
                throw new ArgumentException("Thiếu số tài khoản.");
            if (amount <= 0)
                throw new ArgumentException("Số tiền không hợp lệ.");

            string baseUrl = $"https://img.vietqr.io/image/{bankCode}-{accountNo}-compact2.png";
            string ghiChu = $"Thanh toan don {orderId}";

            // 🔹 Dùng WebUtility.UrlEncode để tương thích .NET Framework
            string url = $"{baseUrl}?amount={amount}" +
                         $"&addInfo={WebUtility.UrlEncode(ghiChu)}" +
                         $"&accountName={WebUtility.UrlEncode(accountName)}";

            return url;
        }
    }
}
