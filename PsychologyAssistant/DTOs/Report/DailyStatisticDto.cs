using Microsoft.OpenApi.Models;

namespace PsychologyAssistant.DTOs.Report
{
    public class DailyStatisticDto
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}
