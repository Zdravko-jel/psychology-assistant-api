using PsychologyAssistant.DTOs.Note;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.DTOs.Session
{
    public class SessionDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PatientId { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string? Summary { get; set; } = "empty";
        public List<NoteDto>? Notes { get; set; }
        public int? MoodLevel { get; set; } = -1;
        public int? AnxietyLevel { get; set; } = -1;
        public int? DepressionLevel { get; set; } = -1;
        public int? SleepQualityLevel { get; set; } = -1;
        public int? StressLevel { get; set; } = -1;
    }
}
