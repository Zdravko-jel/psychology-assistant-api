using System.ComponentModel.DataAnnotations;

namespace PsychologyAssistant.DTOs.Diagnosis
{
    public class CreateDiagnosisDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Minimum length must be at least 2 characters.")]
        public string? Name { get; set; }
    }
}
