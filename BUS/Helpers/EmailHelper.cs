using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PM.BUS.Helpers
{
    public static class EmailHelper
    {
        // Lấy encrypted strings từ App.config
        private static readonly string encEmail = ConfigurationManager.AppSettings["EncryptedSenderEmail"];
        private static readonly string encPass = ConfigurationManager.AppSettings["EncryptedSenderPass"];

        public static async Task SendVerificationCodeAsync(string recipientEmail, string code)
        {
            try
            {
                if (string.IsNullOrEmpty(encEmail) || string.IsNullOrEmpty(encPass))
                    throw new Exception("Encrypted email/password not found in appSettings.");

                // Giải mã
                string senderEmail = AESHelper.DecryptString(encEmail);
                string senderPassword = AESHelper.DecryptString(encPass);

                var message = new MailMessage();
                message.From = new MailAddress(senderEmail, "Cửa Hàng Manga Truyện Tranh");
                message.To.Add(recipientEmail);
                message.Subject = "Your verification code";
                message.Body = $"Hello,\n\nYour verification code is: {code}\n\nThanks!";
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
                // Bạn có thể log ex.Message ở nơi khác
                throw new Exception("Failed to send email: " + ex.Message);
            }
        }
    }
}
