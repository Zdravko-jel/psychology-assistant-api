using System.ComponentModel.DataAnnotations;

namespace PsychologyAssistant.DTOs.Document
{
    public class DocumentSearchDto
    {
        [Required]
        public List<string>? Words { get; set; }
    }
}
