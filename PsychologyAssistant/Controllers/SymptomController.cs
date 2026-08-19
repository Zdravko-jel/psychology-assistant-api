using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychologyAssistant.Data;
using PsychologyAssistant.DTOs.Symptom;
using PsychologyAssistant.Interfaces;
using PsychologyAssistant.Mappers;

namespace PsychologyAssistant.Controllers
{
    [Route("api/symptoms")]
    [ApiController]
    public class SymptomController : ControllerBase
    {
        private readonly ISymptomRepo _symptomRepo;
        public SymptomController(ApplicationDbContext context, ISymptomRepo symptomRepo)
        {
            _symptomRepo = symptomRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var symptoms = await this._symptomRepo.GetAllAsync();
            var symptomDtos = symptoms.Select(x => x.ToSymptomDto()).ToList();
            return Ok(symptomDtos);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetSymptom(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var symptom = await this._symptomRepo.GetOneAsync(id);
            if (symptom == null)
            {
                return NotFound();
            }
            return Ok(symptom.ToSymptomDto());
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> CreateSymptom([FromBody] CreateSymptomDto createSymptomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var symptom = createSymptomDto.ToSymptom();
            await this._symptomRepo.CreateAsync(symptom);
            return CreatedAtAction(nameof(GetSymptom), new { id = symptom.Id }, symptom.ToSymptomDto());
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateSymptom([FromRoute] int id, [FromBody] UpdateSymptomDto updateSymptomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var symptom = await this._symptomRepo.UpdateAsync(id, updateSymptomDto);
            if (symptom == null)
            {
                return NotFound();
            }
            return Ok(symptom.ToSymptomDto());
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteSymptom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await this._symptomRepo.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
