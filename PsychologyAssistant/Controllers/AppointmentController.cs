using Microsoft.AspNetCore.Mvc;
using PsychologyAssistant.DTOs.Appointment;
using PsychologyAssistant.Interfaces;
using PsychologyAssistant.Repositories;

namespace PsychologyAssistant.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepo _appointmentRepo;

        public AppointmentController(IAppointmentRepo appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var appointments = await _appointmentRepo.GetAllAsync();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var appointment = await _appointmentRepo.GetOneAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentDto appointment)
        {
            var createdAppointment = await _appointmentRepo.CreateAsync(appointment);
            return CreatedAtAction(nameof(GetOne), new { id = createdAppointment.Id }, createdAppointment);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAppointmentDto appointmentDto)
        {
            var updatedAppointment = await _appointmentRepo.UpdateAsync(id, appointmentDto);
            if (updatedAppointment == null)
            {
                return NotFound();
            }
            return Ok(updatedAppointment);
        }

        [HttpPut("addnote/{id}")]
        public async Task<IActionResult> AddNote(int id, [FromBody] AddNoteDto noteDto)
        {
            var result = await _appointmentRepo.AddNote(id, noteDto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
