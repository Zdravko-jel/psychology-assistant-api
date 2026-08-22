using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PsychologyAssistant.Data;
using PsychologyAssistant.DTOs.Appointment;
using PsychologyAssistant.Enums;
using PsychologyAssistant.Interfaces;
using PsychologyAssistant.Mappers;
using PsychologyAssistant.Models;
using PsychologyAssistant.Service;

namespace PsychologyAssistant.Repositories
{
    // ako appintment se cancelira da se iztriva sam.
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<User> _manager;
        public AppointmentRepo(ApplicationDbContext context, IEmailSender emailSender, UserManager<User> manager)
        {
            _context = context;
            _manager = manager;
            _emailSender = emailSender;
        }

        public async Task<bool> AddNote(int appointmentId, AddNoteDto noteDto)
        {
            var app = await _context.Appointments.Include(x => x.Patient).FirstOrDefaultAsync(x => x.Id == appointmentId);
            if (app == null)
            {
                return false;
            }

            if (app.Notes == null)
            {
                app.Notes = new List<string>();
            }

            app.Notes.Add(noteDto.Note);
            await _context.SaveChangesAsync();
            await _emailSender.SendEmailAsync(app.Patient, "New Note added to your Appointment", $"Hello, you have a new note added to your appointment scheduled for {app.BeginDateTime}. The note says: {noteDto.Note}");
            return true;
        }

        public async Task<AppointmentDto> CreateAsync(CreateAppointmentDto appointment)
        {
            var newAppointment = appointment.ToEntity();
            newAppointment.Patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == appointment.PatientId);
            newAppointment.Status = AppointmentStatus.Scheduled;
            newAppointment.User = await _manager.Users.FirstOrDefaultAsync(x => x.UserName == appointment.UserName);

            await _context.Appointments.AddAsync(newAppointment);
            await _context.SaveChangesAsync();

            await _emailSender.SendEmailAsync(newAppointment.Patient, "New Appointment Scheduled", $"Hello, you have a new appointment scheduled for {newAppointment.BeginDateTime}");

            return newAppointment.ToDto();
        }

        public async Task<List<AppointmentDto>> GetAllAsync()
        {
            return await _context.Appointments.Select(x => x.ToDto()).ToListAsync();
        }

        public async Task<AppointmentDetailDto> GetOneAsync(int id)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(x => x.Id == id);
            if (appointment == null)
            {
                return null;
            }

            return appointment.ToDetailDto();
        }

        public async Task<AppointmentDto> UpdateAsync(int id, UpdateAppointmentDto appointmentDto)
        {
            var app = await _context.Appointments.FirstOrDefaultAsync(x => x.Id == id);
            if (app == null)
            {
                return null;
            }

            if (appointmentDto.Status != null)
            {
                app.Status = (AppointmentStatus)appointmentDto.Status;

                if (app.Status == AppointmentStatus.Rescheduled)
                {
                    app.BeginDateTime = (DateTime)appointmentDto.BeginDateTime;
                    app.EndDateTime = (DateTime)appointmentDto.EndDateTime;
                    await _emailSender.SendEmailAsync(app.Patient, "Appointment Rescheduled", $"Hello, your appointment has been rescheduled to {app.BeginDateTime}");
                }
                else
                {
                    await _emailSender.SendEmailAsync(app.Patient, "Appointment Status Updated", $"Hello, the status of your appointment scheduled for {app.BeginDateTime} has been updated to {app.Status}");
                }
            }

            await _context.SaveChangesAsync();

            return app.ToDto();
        }
    }
}
