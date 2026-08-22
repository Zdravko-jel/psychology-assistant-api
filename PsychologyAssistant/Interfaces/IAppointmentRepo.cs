using PsychologyAssistant.DTOs.Appointment;
using PsychologyAssistant.DTOs.Symptom;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Interfaces
{
    public interface IAppointmentRepo
    {
        Task<List<AppointmentDto>> GetAllAsync();
        Task<AppointmentDetailDto> GetOneAsync(int id);
        Task<AppointmentDto> CreateAsync(CreateAppointmentDto appointment);
        Task<AppointmentDto> UpdateAsync(int id, UpdateAppointmentDto appointmentDto);
        Task<bool> AddNote(int appointmentId, AddNoteDto noteDto);
    }
}
