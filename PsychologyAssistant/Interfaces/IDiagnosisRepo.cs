using PsychologyAssistant.DTOs.Diagnosis;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Interfaces
{
    public interface IDiagnosisRepo
    {
        Task<List<DiagnosisDto>> GetAllAsync();
        Task<DiagnosisDto> GetOneAsync(int id);
        Task<DiagnosisDto> CreateAsync(CreateDiagnosisDto diagnosis);
        Task<bool> UpdateAsync(int id, UpdateDiagnosisDto diagnosis); 
        Task<bool> DeleteAsync(int id);
        Task<bool> AddSymptomAsync(int diagnosisId, int symptomId);
        Task<bool> RemoveSymptomAsync(int diagnosisId, int symptomId);
    }
}
