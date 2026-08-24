using PsychologyAssistant.DTOs.Session;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Mappers
{
    public static class SessionMappers
    {
        public static SessionDto ToDto(this Session session)
        {
            return new SessionDto
            {
                Id = session.Id,
                UserId = session.User.Id,
                PatientId = session.PatientId,
                BeginDateTime = session.BeginDateTime,
                EndDateTime = session.EndDateTime,
                Summary = session.Summary,
                Notes = session.Notes.Select(x => x.ToNoteDto()).ToList(),
                MoodLevel = session.MoodLevel,
                AnxietyLevel = session.AnxietyLevel,
                DepressionLevel = session.DepressionLevel,
                SleepQualityLevel = session.SleepQualityLevel,
                StressLevel = session.StressLevel
            };
        }
    }
}
