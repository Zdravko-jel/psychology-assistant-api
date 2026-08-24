using PsychologyAssistant.DTOs.Patient;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Mappers
{
    public static class PatientMappers
    {
        public static PatientDto toDto(this Patient patient)
        {
            return new PatientDto
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                BirthDate = patient.BirthDate,
                IdNumber = patient.IdNumber,
                EmailAddress = patient.EmailAddress,
                Gender = patient.Gender,
                PhoneNumber = patient.PhoneNumber,
                Address = patient.Address,
                EmergencyContact = patient.EmergencyContact,
                EmContactPhone = patient.EmContactPhone,
                CreatedAt = patient.CreatedAt,
                CreatorId = patient.Creator.Id
            };
        }
    }
}
