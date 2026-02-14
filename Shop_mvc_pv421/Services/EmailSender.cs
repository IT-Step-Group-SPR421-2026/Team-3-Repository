using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using MimeKit.Text;
using System.Configuration;

namespace Shop_mvc_pv421.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //MailData data = configuration.GetSection(nameof(MailData)).Get<MailData>()!;

            // create message
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse("vlad.tmsh@gmail.com"));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html) { Text = htmlMessage };

            // send email
            using var smtp = new SmtpClient();

            await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("vlad.tmsh@gmail.com", "bpmgvqrdbzbmffsh");
            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
        }
    }
}
