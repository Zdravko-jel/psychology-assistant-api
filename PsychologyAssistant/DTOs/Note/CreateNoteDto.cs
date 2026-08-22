using System.ComponentModel.DataAnnotations;

namespace PsychologyAssistant.DTOs.Note
{
    public class CreateNoteDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]  
        public int PatientId { get; set; }
        [Required]
        public string? TakenNote { get; set; }

    }
}
