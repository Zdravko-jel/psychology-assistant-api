using PsychologyAssistant.Models;

namespace PsychologyAssistant.Interfaces
{
    public interface IPdfCreator
    {
        Task<MonthlyReport> CreatePdf(User user, List<Patient> patients, List<PatientFile> diagnoses, List<Session> sessions, List<PatientFile> closedFiles);
    }
}
