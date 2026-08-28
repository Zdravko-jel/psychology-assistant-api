using PsychologyAssistant.Enums;

namespace PsychologyAssistant.Models
{
    public class PatientFile
    {
        public int Id {  get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt {  get; set; }
        public string? Summary { get; set; }
        public PatientFileStatus Status { get; set; }
        public DateTime? ClosedOn { get; set; }
        public int DiagnosisId {  get; set; }
        public Diagnosis? Diagnosis { get; set; }
        public DateTime? DiagnosisAdded { get; set; }
        public List<Symptom> Symptoms { get; set; }
        public List<Session> Sessions { get; set; }
        public List<int>? MoodLevels { get; set; }
        public List<int>? AnxietyLevels { get; set; }
        public List<int>? DepressionLevels { get; set; }
        public List<int>? SleepQualityLevels { get; set; }
        public List<int>? StressLevels { get; set; }
    }
}
