using PsychologyAssistant.DTOs.Session;
using PsychologyAssistant.DTOs.Symptom;

namespace PsychologyAssistant.DTOs.PatientFile
{
    public class UpdatePatientFileDto
    {
        public string? Summary { get; set; } = "empty";
        public int? DiagnosisId { get; set; } = -1;
        public int? SymptomId { get; set; } = -1;
        public int? SessionId { get; set; } = -1;
    }
}
