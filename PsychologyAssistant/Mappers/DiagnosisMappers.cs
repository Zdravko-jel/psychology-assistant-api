using PsychologyAssistant.DTOs.Diagnosis;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Mappers
{
    public static class DiagnosisMappers
    {
        public static DiagnosisDto ToDTO(this Diagnosis diagnosis)
        {
            return new DiagnosisDto
            {
                Id = diagnosis.Id,
                Name = diagnosis.Name,
                Symptoms = diagnosis.Symptoms?.Select(s => s.ToSymptomDto()).ToList()
            };
        }
    }
}
