using PsychologyAssistant.Models;

namespace PsychologyAssistant.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Patient patient, string subject, string body);
    }
}
