using PsychologyAssistant.DTOs.Symptom;

namespace PsychologyAssistant.DTOs.Diagnosis
{
    public class DiagnosisDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SymptomDto> Symptoms { get; set; }
    }
}
