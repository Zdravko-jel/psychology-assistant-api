using Microsoft.AspNetCore.Mvc;
using PsychologyAssistant.DTOs.Diagnosis;
using PsychologyAssistant.Interfaces;
using PsychologyAssistant.Repositories;

namespace PsychologyAssistant.Controllers
{
    [Route("api/diagnoses")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly IDiagnosisRepo _diagnosisRepo;

        public DiagnosisController(IDiagnosisRepo diagnosisRepo)
        {
            _diagnosisRepo = diagnosisRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var diagnoses = await _diagnosisRepo.GetAllAsync();
            return Ok(diagnoses);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var diagnosis = await _diagnosisRepo.GetOneAsync(id);
            if (diagnosis == null)
                return NotFound();
            return Ok(diagnosis);
        }
        
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateDiagnosisDto diagnosis)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdDiagnosis = await _diagnosisRepo.CreateAsync(diagnosis);
            return CreatedAtAction(nameof(Details), new { id = createdDiagnosis.Id }, createdDiagnosis);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _diagnosisRepo.DeleteAsync(id);
            if (!result)
                return NotFound("Diagnosis not found.");
            return Ok("Diagnosis deleted successfully.");
        }

        [HttpPost]
        [Route("update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDiagnosisDto diagnosis)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _diagnosisRepo.UpdateAsync(id, diagnosis);
            if (!result)
                return NotFound("Diagnosis not found.");
            return Ok("Diagnosis updated successfully.");
        }

        [HttpPost]
        [Route("symptom/add")]
        public async Task<IActionResult> AddSymptom([FromBody] AddRemoveDto addSymptomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _diagnosisRepo.AddSymptomAsync(addSymptomDto.DiagnosisId, addSymptomDto.SymptomId);
            if (!result)
                return NotFound("Diagnosis or Symptom not found.");
            return Ok("Symptom added to Diagnosis successfully.");
        }

        [HttpPost]
        [Route("symptom/remove")]
        public async Task<IActionResult> RemoveSymptom([FromBody] AddRemoveDto removeSymptomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _diagnosisRepo.RemoveSymptomAsync(removeSymptomDto.DiagnosisId, removeSymptomDto.SymptomId);
            if (!result)
                return NotFound("Diagnosis or Symptom not found.");
            return Ok("Symptom removed from Diagnosis successfully.");
        }
    }
}
