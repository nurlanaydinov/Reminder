using Sender.Application.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Sender.Application.Email
{
    public class EmailSender : IEmailSender
    {
        public void Send(string to, string subject, string body)
        {
            SendEmail(to, subject, body);
        }

        public void SendEmail(string to, string subject, string body)
        {
            var mail = "test@gmail.com";
            var password = "12345";
            var client = new SmtpClient("smtp-mail@gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, password)
            };
                client.SendMailAsync(
                new MailMessage (from: mail,
                                 to: to,
                                 subject, 
                                 body));

        }
    }
}
