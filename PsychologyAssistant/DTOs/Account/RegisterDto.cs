using System.ComponentModel.DataAnnotations;

namespace PsychologyAssistant.DTOs.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public string? Specialization { get; set; }
        public string? Gender { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? LicenceNumber { get; set; }
        public string? OfficeAddress { get; set; }
        public TimeOnly? WorkingHoursStart { get; set; }
        public TimeOnly? WorkingHoursEnd { get; set; }
    }
}
