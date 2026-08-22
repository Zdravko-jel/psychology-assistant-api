using PsychologyAssistant.Enums;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.DTOs.Appointment
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string? PatientName { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public AppointmentStatus Status { get; set; }
        public string? Location { get; set; }
    }
}
