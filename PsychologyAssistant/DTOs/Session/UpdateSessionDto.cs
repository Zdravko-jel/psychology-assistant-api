using PsychologyAssistant.DTOs.Note;
using System.ComponentModel.DataAnnotations;

namespace PsychologyAssistant.DTOs.Session
{
    public class UpdateSessionDto
    {
        [Required]
        public int Id { get; set; }
        public string? Summary { get; set; } = "empty";
        public int? MoodLevel { get; set; } = -1;
        public int? AnxietyLevel { get; set; } = -1;
        public int? DepressionLevel { get; set; } = -1;
        public int? SleepQualityLevel { get; set; } = -1;
        public int? StressLevel { get; set; } = -1;
    }
}
