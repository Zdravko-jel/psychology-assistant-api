using PsychologyAssistant.DTOs.Report;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Interfaces
{
    public interface IReportRepo
    {
        Task<List<ReportDto>> GetAll();
        Task<List<ReportDto>> GetAllForUser(string userId);
        Task<MonthlyReport> GetById(int id);
        Task<ReportDto> Create(CreateReportDto reportDto);
    }
}
