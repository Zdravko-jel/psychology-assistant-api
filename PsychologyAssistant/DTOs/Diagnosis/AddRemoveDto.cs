using System.ComponentModel.DataAnnotations;

namespace PsychologyAssistant.DTOs.Diagnosis
{
    public class AddRemoveDto
    {
        [Required]
        public int DiagnosisId { get; set; }
        [Required]
        public int SymptomId { get; set; }
    }
}
