using PsychologyAssistant.DTOs.Report;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Mappers
{
    public static class ReportMappers
    {
        public static ReportDto ToReportDto(this MonthlyReport report)
        {
            return new ReportDto { 
                Id = report.Id,
                FileName = report.FileName,
                FilePath = report.storedFileName
            };
        }
    }
}
