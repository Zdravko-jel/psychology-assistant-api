using PsychologyAssistant.DTOs.Note;
using System.ComponentModel.DataAnnotations;

namespace PsychologyAssistant.DTOs.Session
{
    public class CreateSessionDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public int PatientId { get; set; }
    }
}
