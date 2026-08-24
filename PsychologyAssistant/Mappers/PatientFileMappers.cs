using PsychologyAssistant.DTOs.PatientFile;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Mappers
{
    public static class PatientFileMappers
    {
        public static PatientFileDto toFileDto(this PatientFile patientFile)
        {
            return new PatientFileDto
            {
                Id = patientFile.Id,
                PatientId = patientFile.PatientId,
                UserId = patientFile.User.Id,
                CreatedAt = patientFile.CreatedAt,
                Summary = patientFile.Summary,
                DiagnosisId = patientFile.DiagnosisId,
                Symptoms = patientFile.Symptoms.Select(x => x.ToSymptomDto()).ToList(),
                Sessions = patientFile.Sessions.Select(x => x.ToDto()).ToList(),
                MoodLevels = patientFile.MoodLevels,
                AnxietyLevels = patientFile.AnxietyLevels,
                DepressionLevels = patientFile.DepressionLevels,
                SleepQualityLevels = patientFile.SleepQualityLevels,
                StressLevels = patientFile.StressLevels
            };
        }
    }
}
