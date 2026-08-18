using System.ComponentModel.DataAnnotations;

namespace PsychologyAssistant.DTOs.Symptom
{
    public class CreateSymptomDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        public string Name { get; set; }
    }
}
