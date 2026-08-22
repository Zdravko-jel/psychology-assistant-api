using PsychologyAssistant.Enums;
using PsychologyAssistant.Models;
using System.ComponentModel.DataAnnotations;

namespace PsychologyAssistant.DTOs.Appointment
{
    public class CreateAppointmentDto
    {
        [Required]
        public int PatientId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public DateTime BeginDateTime { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }
        [Required]
        public string? Location { get; set; }
        public List<string>? Notes { get; set; }
    }
}
