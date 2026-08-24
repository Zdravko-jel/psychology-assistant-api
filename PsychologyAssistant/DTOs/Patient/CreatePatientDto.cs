using PsychologyAssistant.Models;
using System.ComponentModel.DataAnnotations;

namespace PsychologyAssistant.DTOs.Patient
{
    public class CreatePatientDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public string IdNumber { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string? Gender { get; set; } = "None";
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string EmergencyContact { get; set; }
        [Required]
        public string EmContactPhone { get; set; }
        [Required]
        public string CreatorId { get; set; }
    }
}
