using PsychologyAssistant.DTOs.Note;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Mappers
{
    public static class NoteMappers
    {
        public static NoteDto ToNoteDto(this Note note)
        {
            return new NoteDto
            {
                Id = note.Id,
                UserId = note.User.Id,
                PatientId = note.PatientId,
                TakenNote = note.TakenNote
            };
        }
    }
}
