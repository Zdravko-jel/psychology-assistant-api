using Microsoft.AspNetCore.Identity;

namespace PsychologyAssistant.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Specialization {  get; set; }
        public string? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string? LicenceNumber { get; set; }
        public string? OfficeAddress { get; set; }
        public TimeSpan? WorkingHours { get; set; }
    }
}
