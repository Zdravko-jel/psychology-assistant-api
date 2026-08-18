using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychologyAssistant.Data;
using PsychologyAssistant.DTOs.Symptom;
using PsychologyAssistant.Mappers;

namespace PsychologyAssistant.Controllers
{
    [Route("api/symptoms")]
    [ApiController]
    public class SymptomController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SymptomController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var symptoms = await this._context.Symptoms.ToListAsync();
            var symptomDtos = symptoms.Select(x => x.ToSymptomDto()).ToList();
            return Ok(symptomDtos);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetSymptom(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var symptom = await this._context.Symptoms.FindAsync(id);
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
            await this._context.Symptoms.AddAsync(symptom);
            await this._context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSymptom), new { id = symptom.Id }, symptom.ToSymptomDto());
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateSymptom([FromRoute] int id, [FromBody] UpdateSymptomDto updateSymptomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var symptom = await this._context.Symptoms.FindAsync(id);
            if (symptom == null)
            {
                return NotFound();
            }
            symptom.Name = updateSymptomDto.Name;
            await this._context.SaveChangesAsync();
            return Ok(symptom.ToSymptomDto());
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteSymptom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var symptom = await this._context.Symptoms.FindAsync(id);
            if (symptom == null)
            {
                return NotFound();
            }
            this._context.Symptoms.Remove(symptom);
            await this._context.SaveChangesAsync();
            return NoContent();
        }
    }
}
