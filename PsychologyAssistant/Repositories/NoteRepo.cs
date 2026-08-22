using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PsychologyAssistant.Data;
using PsychologyAssistant.DTOs.Note;
using PsychologyAssistant.Interfaces;
using PsychologyAssistant.Mappers;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Repositories
{
    public class NoteRepo : INoteRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _manager;

        public NoteRepo(ApplicationDbContext context, UserManager<User> manager)
        {
            _context = context;
            _manager = manager;
        }

        public async Task<NoteDto> Create(CreateNoteDto note)
        {
            var user = await _manager.FindByIdAsync(note.UserId);
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == note.PatientId);

            var newNote = new Note
            {
                User = user,
                PatientId = note.PatientId,
                Patient = patient,
                TakenNote = note.TakenNote,
            };

            await _context.Notes.AddAsync(newNote);
            await _context.SaveChangesAsync();
            return newNote.ToNoteDto();
        }

        public async Task<List<NoteDto>> GetAll()
        {
            return await _context.Notes.Select(x => x.ToNoteDto()).ToListAsync();
        }

        public async Task<List<NoteDto>> GetAllForPatient(int patientId)
        {
            return await _context.Notes.Where(x => x.PatientId == patientId)
                .Select(x => x.ToNoteDto())
                .ToListAsync();
        }

        public async Task<NoteDto> GetById(int id)
        {
            return await _context.Notes.Where(x => x.Id == id).Select(x => x.ToNoteDto()).FirstOrDefaultAsync(); 
        }
    }
}
