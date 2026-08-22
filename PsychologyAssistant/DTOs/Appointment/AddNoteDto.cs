using System.ComponentModel.DataAnnotations;

namespace PsychologyAssistant.DTOs.Appointment
{
    public class AddNoteDto
    {
        [Required]
        public string? Note { get; set; }
    }
}
