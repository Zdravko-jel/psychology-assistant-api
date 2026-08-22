using PsychologyAssistant.DTOs.Note;

namespace PsychologyAssistant.Interfaces
{
    public interface INoteRepo
    {
        Task<List<NoteDto>> GetAll();
        Task<List<NoteDto>> GetAllForPatient(int patientId);
        Task<NoteDto> GetById(int id);
        Task<NoteDto> Create(CreateNoteDto note);
    }
}
