using PsychologyAssistant.DTOs.Session;

namespace PsychologyAssistant.Interfaces
{
    public interface ISessionRepo
    {
        Task<List<SessionDto>> GetAll();
        Task<List<SessionDto>> GetAllForUser(string userId);
        Task<List<SessionDto>> GetAllForPatient(int patientId);
        Task<SessionDto> GetById(int id);
        Task<SessionDto> Create(CreateSessionDto sessionDto);
        Task<bool> AddNote(int sessionId, int noteId);
        Task<SessionDto> Update(int id, UpdateSessionDto sessionDto);
        Task<bool> Delete(int id);
    }
}
