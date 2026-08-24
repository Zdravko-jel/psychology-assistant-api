using PsychologyAssistant.DTOs.Session;
using PsychologyAssistant.DTOs.Symptom;

namespace PsychologyAssistant.DTOs.PatientFile
{
    public class CreatePatientFileDto
    {
        public int PatientId { get; set; }
        public string UserId { get; set; }
    }
}
