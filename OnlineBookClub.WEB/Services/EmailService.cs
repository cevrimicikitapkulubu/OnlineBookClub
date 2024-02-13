using AspNetCoreIdentityApp.OptionsModels;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace AspNetCoreIdentityApp.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public async Task SendResetPasswordEmail(string resetPasswordEmailLink, string toEmail)
        {
            var smptClient = new SmtpClient();

            smptClient.Host = _emailSettings.Host;
            smptClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smptClient.UseDefaultCredentials = false;
            smptClient.Port = 587;
            smptClient.Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password);
            smptClient.EnableSsl = true;

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailSettings.Email);
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = "AspNetcoreIdentityApp | Şifre Sıfırlama İsteği";
            mailMessage.Body = @$"
                                <h4>Şifrenizi yenilemek için alttaki linke tııklayınız.</h4>
                                <br>
                                <a href='{resetPasswordEmailLink}' style='border-radius: 1rem; background-color: cadetblue; text-decoration: none; color: white; padding: 1.2rem 1rem;'>Reset Your Password</a>";
			mailMessage.IsBodyHtml = true;
            await smptClient.SendMailAsync(mailMessage);
        }
    }
}
