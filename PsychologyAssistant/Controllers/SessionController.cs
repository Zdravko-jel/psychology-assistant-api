using Microsoft.AspNetCore.Mvc;
using PsychologyAssistant.DTOs.Session;
using PsychologyAssistant.Interfaces;

namespace PsychologyAssistant.Controllers
{
    [ApiController]
    [Route("api/sessions")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionRepo _sessionRepo;

        public SessionController(ISessionRepo sessionRepo)
        {
            _sessionRepo = sessionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _sessionRepo.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var session = await _sessionRepo.GetById(id);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetAllForPatient(int patientId)
        {
            return Ok(await _sessionRepo.GetAllForPatient(patientId));
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAllForUser(string userId)
        {
            return Ok(await _sessionRepo.GetAllForUser(userId));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateSessionDto session)
        {
            var createdSession = await _sessionRepo.Create(session);
            return CreatedAtAction(nameof(GetById), new { id = createdSession.Id }, createdSession);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateSessionDto session)
        {
            var updatedSession = await _sessionRepo.Update(id, session);
            if (updatedSession == null)
            {
                return NotFound();
            }
            return Ok(updatedSession);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _sessionRepo.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("addnote/{id}")]
        public async Task<IActionResult> AddNote(int id, SessionNoteDto note)
        {
            var updatedSession = await _sessionRepo.AddNote(id, note.NoteId);
            if (updatedSession == null)
            {
                return NotFound();
            }
            return Ok(updatedSession);
        }
    }
}
