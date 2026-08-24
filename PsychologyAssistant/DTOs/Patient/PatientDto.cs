using PsychologyAssistant.Models;

namespace PsychologyAssistant.DTOs.Patient
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string IdNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmergencyContact { get; set; }
        public string EmContactPhone { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatorId { get; set; }
    }
}
