using PsychologyAssistant.Enums;

namespace PsychologyAssistant.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public AppointmentStatus Status { get; set; }
        public string? Location { get; set; }
        public List<string>? Notes { get; set; }
    }
}
