using PsychologyAssistant.DTOs.Patient;

namespace PsychologyAssistant.Interfaces
{
    public interface IPatientRepo
    {
        Task<List<PatientDto>> GetAll();
        Task<List<PatientDto>> GetAllForUser(string userId);
        Task<PatientDto> GetById(int id);
        Task<PatientDto> Create(CreatePatientDto patientDto);
        Task<PatientDto> Update(int id, UpdatePatientDto patientDto);
    }
}
