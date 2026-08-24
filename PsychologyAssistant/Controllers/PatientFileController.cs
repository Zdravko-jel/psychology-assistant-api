using Microsoft.AspNetCore.Mvc;
using PsychologyAssistant.DTOs.PatientFile;
using PsychologyAssistant.Interfaces;

namespace PsychologyAssistant.Controllers
{
    [ApiController]
    [Route("api/patientfile")]
    public class PatientFileController : ControllerBase
    {
        private readonly IPatientFileRepo _patientFileRepo;

        public PatientFileController(IPatientFileRepo patientFileRepo)
        {
            _patientFileRepo = patientFileRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var files = await _patientFileRepo.GetAll();
            if (files == null)
                return BadRequest();
            return Ok(files);
        }

        [HttpGet("bypatient/{id:int}")]
        public async Task<IActionResult> GetByPatient(int id)
        {
            var files = await _patientFileRepo.GetAllByPatient(id);
            if (files == null)
                return BadRequest();
            return Ok(files);
        }

        [HttpGet("byuser/{id}")]
        public async Task<IActionResult> GetByPatient(string id)
        {
            var files = await _patientFileRepo.GetAllByUser(id);
            if (files == null)
                return BadRequest();
            return Ok(files);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var files = await _patientFileRepo.GetById(id);
            if (files == null)
                return BadRequest();
            return Ok(files);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePatientFileDto createPatientFile)
        {
            var file = await _patientFileRepo.Create(createPatientFile);
            if (file == null)
                return BadRequest();
            return Ok(file);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _patientFileRepo.Delete(id);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpPut("add/symptom/{id:int}")]
        public async Task<IActionResult> AddSymptomToFile(int id, UpdatePatientFileDto patientFileDto)
        {
            var result = await _patientFileRepo.AddSymptomToFile(id, patientFileDto);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpPut("remove/symptom/{id:int}")]
        public async Task<IActionResult> RemoveSymptomFromFile(int id, UpdatePatientFileDto patientFileDto)
        {
            var result = await _patientFileRepo.RemoveSymptomToFile(id, patientFileDto);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpPut("add/diagnosis/{id:int}")]
        public async Task<IActionResult> AddDiagnosisToFile(int id, UpdatePatientFileDto patientFileDto)
        {
            var result = await _patientFileRepo.AddDiagnosisToFile(id, patientFileDto);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpPut("change/diagnosis/{id:int}")]
        public async Task<IActionResult> ChangeDiagnosis(int id, UpdatePatientFileDto patientFileDto)
        {
            var result = await _patientFileRepo.ChangeDiagnosisToFile(id, patientFileDto);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpPut("add/session/{id:int}")]
        public async Task<IActionResult> AddSessionToFile(int id, UpdatePatientFileDto patientFileDto)
        {
            var result = await _patientFileRepo.AddSessionToFile(id, patientFileDto);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpPut("summary/{id:int}")]
        public async Task<IActionResult> FileSummary(int id, UpdatePatientFileDto patientFileDto)
        {
            var result = await _patientFileRepo.CloseFileAndSummary(id, patientFileDto);
            if (!result)
                return BadRequest();
            return Ok();
        }
    }
}
