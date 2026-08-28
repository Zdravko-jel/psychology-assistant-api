using PsychologyAssistant.DTOs.Report;

namespace PsychologyAssistant.Interfaces
{
    public interface IChartService
    {
        byte[] CreatePatientsPerDayChart(List<DailyStatisticDto> data);
        byte[] CreateDiagnosesPerDayChart(List<DailyStatisticDto> data);
        byte[] CreateSessionsPerDayChart(List<DailyStatisticDto> data);
        byte[] CreateClosedFilesPerDayChart(List<DailyStatisticDto> data);
    }
}
