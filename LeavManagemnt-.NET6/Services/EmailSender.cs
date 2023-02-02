using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Net.Mail;

namespace LeavManagemnt_.NET6.Services
{
    public class EmailSender : IEmailSender
    {
        private string _smtpServer;
        private int _smtpPort;
        private string _fromEmailAddress;
        public EmailSender(string smtpServer, int smtpPort, string frromEmailAddress)
        {
            _smtpPort = smtpPort;
            _fromEmailAddress = frromEmailAddress;  
            _smtpServer = smtpServer;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MailMessage
            {
                From = new MailAddress(_fromEmailAddress),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            message.To.Add(new MailAddress(email));

            // Using Blocks, Are used to replace Idisposible Interfaces.that they used for releasing managed or unmanaged resources.
            using (var client = new SmtpClient(_smtpServer, _smtpPort))
            {
                client.Send(message);
            }


            //var client = new SmtpClient(_smtpServer,_smtpPort);
            //client.Send(message);
            //client.Dispose();
            

            return Task.CompletedTask;
        }
    }
}
