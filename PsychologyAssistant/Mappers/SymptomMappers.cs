using PsychologyAssistant.DTOs.Symptom;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Mappers
{
    public static class SymptomMappers
    {
        public static SymptomDto ToSymptomDto(this Symptom symptom)
        {
            return new SymptomDto
            {
                Id = symptom.Id,
                Name = symptom.Name
            };
        }

        public static Symptom ToSymptom(this CreateSymptomDto createSymptomDto)
        {
            return new Symptom
            {
                Name = createSymptomDto.Name
            };
        }
    }   
}
