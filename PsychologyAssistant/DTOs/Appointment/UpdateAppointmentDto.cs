using PsychologyAssistant.Enums;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.DTOs.Appointment
{
    public class UpdateAppointmentDto
    {
        public DateTime? BeginDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public AppointmentStatus? Status { get; set; }
    }
}
