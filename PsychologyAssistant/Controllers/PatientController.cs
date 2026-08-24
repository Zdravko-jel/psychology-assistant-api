using Microsoft.AspNetCore.Mvc;
using PsychologyAssistant.DTOs.Patient;
using PsychologyAssistant.Interfaces;

namespace PsychologyAssistant.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepo _patientRepo;

        public PatientController(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var patients = await _patientRepo.GetAll();
            return Ok(patients);
        }

        [HttpGet("byuser/{userId}")]
        public async Task<IActionResult> GetPatientsByUserId([FromRoute]string userId)
        {
            var patients = await _patientRepo.GetAllForUser(userId);
            return Ok(patients);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPatientById([FromRoute]int id)
        {
            var patient = await _patientRepo.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientDto patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }
            var createdPatient = await _patientRepo.Create(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = createdPatient.Id }, createdPatient);
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdatePatient([FromRoute]int id, [FromBody] UpdatePatientDto patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }
            var updatedPatient = await _patientRepo.Update(id, patient);
            if (updatedPatient == null)
            {
                return NotFound();
            }
            return Ok(updatedPatient);
        }
    }
}
