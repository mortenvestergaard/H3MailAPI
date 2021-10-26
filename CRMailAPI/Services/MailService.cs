using MimeKit;
using System.IO;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMailAPI.Models;
using CRMailAPI.Settings;

namespace CRMailAPI.Services
{
    // This class represents MailService with inheritance from IMailService!
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        // The body of the interface method is provided here!
        public async Task SendEmailAsync(MailRequest mailRequest)
        {

            // Create a new object of MimeMessage and adds in the Sender, To, ReplyTo and Subject to this object! 
            var email = new MimeMessage();

            // Getting MailSettings data from the JSON File!
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(_mailSettings.ToEmail));

            // Filling the message related data (ReplyFrom, Subject, Body) from the mailRequest! 
            email.ReplyTo.Add(MailboxAddress.Parse(mailRequest.ReplyFrom));
            email.Subject = mailRequest.Subject;

            // Creates a new object of BodyBuilder!
            var builder = new BodyBuilder();

            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            // Create a new object of SmtpClient!
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);

            // Send the Message using the smpt’s SendMailAsync Method!
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
