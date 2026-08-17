namespace PsychologyAssistant.Models
{
    public class Session
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string? Summary { get; set; }
        public List<Note>? Notes { get; set; }
        public int? MoodLevel { get; set; }
        public int? AnxietyLevel { get; set; }
        public int? DepressionLevel { get; set; }
        public int? SleepQualityLevel { get; set; }
        public int? StressLevel { get; set; }
    }
}
