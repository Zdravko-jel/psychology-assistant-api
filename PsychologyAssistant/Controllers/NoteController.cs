using Microsoft.AspNetCore.Mvc;
using PsychologyAssistant.DTOs.Note;
using PsychologyAssistant.Interfaces;

namespace PsychologyAssistant.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepo _noteRepo;
        public NoteController(INoteRepo noteRepo)
        {
            _noteRepo = noteRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notes = await _noteRepo.GetAll();
            return Ok(notes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var note = await _noteRepo.GetById(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }
        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetAllForPatient(int patientId)
        {
            var notes = await _noteRepo.GetAllForPatient(patientId);
            return Ok(notes);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateNoteDto note)
        {
            var createdNote = await _noteRepo.Create(note);
            return CreatedAtAction(nameof(GetById), new { id = createdNote.Id }, createdNote);
        }
    }
}
