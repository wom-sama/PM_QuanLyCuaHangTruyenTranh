using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Helpers
{
    public static class EmailHelper
    {

        private static readonly string senderEmail = "your_email@gmail.com";
        private static readonly string senderPassword = "your_app_password"; // 

        public static async Task SendVerificationCodeAsync(string recipientEmail, string code)
        {
            try
            {
                var message = new MailMessage();
                message.From = new MailAddress(senderEmail, "Cửa hàng Truyện Tranh");
                message.To.Add(recipientEmail);
                message.Subject = "Mã xác nhận đăng ký tài khoản";
                message.Body = $"Xin chào,\n\nMã xác nhận đăng ký của bạn là: {code}\n\nTrân trọng,\nCửa hàng Truyện Tranh";
                message.IsBodyHtml = false;

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi gửi email: " + ex.Message);
            }
        }


    }
}
