using PsychologyAssistant.DTOs.Session;
using PsychologyAssistant.DTOs.Symptom;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.DTOs.PatientFile
{
    public class PatientFileDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Summary { get; set; } = "empty";
        public int? DiagnosisId { get; set; } = -1;
        public List<SymptomDto> Symptoms { get; set; }
        public List<SessionDto> Sessions { get; set; }
        public List<int> MoodLevels { get; set; }
        public List<int> AnxietyLevels { get; set; }
        public List<int> DepressionLevels { get; set; }
        public List<int> SleepQualityLevels { get; set; }
        public List<int> StressLevels { get; set; }
    }
}
