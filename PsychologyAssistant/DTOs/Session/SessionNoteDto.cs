using System.ComponentModel.DataAnnotations;

namespace PsychologyAssistant.DTOs.Session
{
    public class SessionNoteDto
    {
        [Required]
        public int NoteId { get; set; }
    }
}
