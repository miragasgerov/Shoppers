using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Services
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html);
    }

    public class EmailService : IEmailService
    {


        public void Send(string to, string subject, string html)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("adm1nshoppers@yandex.com"));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.yandex.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("adm1nshoppers@yandex.com", "Admin.2022");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
