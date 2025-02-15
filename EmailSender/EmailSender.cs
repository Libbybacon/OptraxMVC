using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender
{

    public class EmailMessage
    {
        public required List<string> To { get; set; }           // Primary recipient
        public required string Subject { get; set; }      // Subject
        public string? Body { get; set; }         // HTML body
        public List<string> Cc { get; set; }     // CC recipients
        public List<string> Bcc { get; set; }    // BCC recipients
        public List<Attachment> Attachments { get; set; }  // Attachments

        public EmailMessage()
        {
            Cc = [];
            Bcc = [];
            Attachments = [];
        }
    }

    public class EmailSender(string smtpServer, int smtpPort, string smtpUser, string smtpPassword)
    {
        private readonly string Server = smtpServer;
        private readonly int Port = smtpPort;
        private readonly string User = smtpUser;
        private readonly string Password = smtpPassword;

        public async Task SendEmailAsync(EmailMessage message)
        {
            if (message.To.Count == 0)
            {
                throw new ArgumentException("No primary recipient specified.");
            }

            if (string.IsNullOrEmpty(message.Subject))
            {
                throw new ArgumentException("No subject specified.");
            }

            var mailMessage = new MailMessage
            {
                From = new MailAddress(User),
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true
            };

            foreach (var toEmail in message.Cc)
            {
                mailMessage.To.Add(toEmail);
            }

            foreach (var ccEmail in message.Cc)
            {
                mailMessage.CC.Add(ccEmail);
            }

            foreach (var bccEmail in message.Bcc)
            {
                mailMessage.Bcc.Add(bccEmail);
            }

            foreach (var attachment in message.Attachments)
            {
                mailMessage.Attachments.Add(attachment);
            }

            using var smtpClient = new SmtpClient(Server, Port);
            smtpClient.Credentials = new NetworkCredential(User, Password);
            smtpClient.EnableSsl = true;
     
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
