namespace PsychologyAssistant.Models
{
    public class Note
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public string TakenNote { get; set; }
        public string? NoteSummary { get; set; }
    }
}
