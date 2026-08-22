using PsychologyAssistant.DTOs.Appointment;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Mappers
{
    public static class AppointmentMappers
    {
        public static AppointmentDto ToDto(this Models.Appointment appointment)
        {
            return new AppointmentDto
            {
                Id = appointment.Id,
                PatientName = appointment.Patient.FirstName,
                BeginDateTime = appointment.BeginDateTime,
                EndDateTime = appointment.EndDateTime,
                Status = appointment.Status,
                Location = appointment.Location
            };
        }

        public static AppointmentDetailDto ToDetailDto(this Models.Appointment appointment)
        {
            return new AppointmentDetailDto
            {
                Id = appointment.Id,
                PatientName = appointment.Patient.FirstName,
                BeginDateTime = appointment.BeginDateTime,
                EndDateTime = appointment.EndDateTime,
                Status = appointment.Status,
                Location = appointment.Location,
                Notes = appointment.Notes.ToList()
            };
        }

        public static Appointment ToEntity(this CreateAppointmentDto appointmentDto)
        {
            return new Appointment
            {
                PatientId = appointmentDto.PatientId,
                BeginDateTime = appointmentDto.BeginDateTime,
                EndDateTime = appointmentDto.EndDateTime,
                Location = appointmentDto.Location,
                Notes = new List<string>()
            };
        }
    }
}
