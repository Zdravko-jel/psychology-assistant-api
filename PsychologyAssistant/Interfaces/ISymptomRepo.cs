using PsychologyAssistant.DTOs.Symptom;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Interfaces
{
    public interface ISymptomRepo
    {
        Task<List<Symptom>> GetAllAsync();
        Task<Symptom> GetOneAsync(int id);
        Task<Symptom> CreateAsync(Symptom symptom);
        Task<Symptom> UpdateAsync(int id, UpdateSymptomDto symptomDto);
        Task<bool> DeleteAsync(int id);
    }
}
