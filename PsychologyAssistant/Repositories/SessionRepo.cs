using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PsychologyAssistant.Data;
using PsychologyAssistant.DTOs.Session;
using PsychologyAssistant.Interfaces;
using PsychologyAssistant.Mappers;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Repositories
{
    public class SessionRepo : ISessionRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _manager;

        public SessionRepo(ApplicationDbContext context, UserManager<User> manager)
        {
            _context = context;
            _manager = manager;
        }

        public async Task<bool> AddNote(int sessionId, int noteId)
        {
            var session = await _context.Sessions.Include(s => s.Notes).FirstOrDefaultAsync(s => s.Id == sessionId);
            if (session == null)
            {
                return false;
            }

            if (session.Notes == null)
            {
                session.Notes = new List<Note>();
            }

            var note = await _context.Notes.FirstOrDefaultAsync(x => x.Id == noteId);
            if (note == null)
            {
                return false;
            }

            session.Notes.Add(note);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<SessionDto> Create(CreateSessionDto sessionDto)
        {
            var user = await _manager.FindByIdAsync(sessionDto.UserId);
            var patient = await _context.Patients.FindAsync(sessionDto.PatientId);
            var session = new Session
            {
                User = user,
                Patient = patient,
                PatientId = sessionDto.PatientId,
                BeginDateTime = DateTime.Now,
                EndDateTime = DateTime.Now.AddHours(1),
                Summary = "empty",
                Notes = new List<Note>(),
                MoodLevel = -1,
                AnxietyLevel = -1,
                DepressionLevel = -1,
                SleepQualityLevel = -1,
                StressLevel = -1
            };

            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
            return session.ToDto();
        }

        public async Task<bool> Delete(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
            {
                return false;
            }

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<SessionDto>> GetAll()
        {
            return await _context.Sessions.Select(x => x.ToDto()).ToListAsync();
        }

        public async Task<List<SessionDto>> GetAllForPatient(int patientId)
        {
            return await _context.Sessions.Where(x => x.PatientId == patientId).Select(x => x.ToDto()).ToListAsync();
        }

        public async Task<List<SessionDto>> GetAllForUser(string userId)
        {
            return await _context.Sessions.Where(x => x.User.Id == userId).Select(x => x.ToDto()).ToListAsync();
        }

        public async Task<SessionDto> GetById(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
            {
                return null;
            }
            return session.ToDto();
        }

        public async Task<SessionDto> Update(int id, UpdateSessionDto sessionDto)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
            {
                return null;
            }

            session.Summary = sessionDto.Summary;
            session.MoodLevel = sessionDto.MoodLevel;
            session.AnxietyLevel = sessionDto.AnxietyLevel;
            session.DepressionLevel = sessionDto.DepressionLevel;
            session.SleepQualityLevel = sessionDto.SleepQualityLevel;
            session.StressLevel = sessionDto.StressLevel;

            _context.Sessions.Update(session);
            await _context.SaveChangesAsync();

            return session.ToDto();
        }
    }
}
