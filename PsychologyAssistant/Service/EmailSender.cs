using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Service
{
    public class EmailSender : Interfaces.IEmailSender
    {
        public async Task SendEmailAsync(Patient patient, string subject, string body)
        {
            var message = new MimeMessage();
            var from = new MailboxAddress("Psychology Assistant", "no-reply@psychologyassistant.com");
            message.From.Add(from);
            var to = new MailboxAddress($"{patient.FirstName} {patient.LastName}", patient.EmailAddress);
            message.To.Add(to);
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Plain)
            {
                Text = body
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("localhost", 1025);
            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
        }
    }
}
