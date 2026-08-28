using Microsoft.AspNetCore.Mvc;
using PsychologyAssistant.DTOs.Report;
using PsychologyAssistant.Interfaces;

namespace PsychologyAssistant.Controllers
{
    [ApiController]
    [Route("api/report")]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepo _reportRepo;

        public ReportController(IReportRepo reportRepo, IPdfCreator pdfCreator)
        {
            _reportRepo = reportRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var reports = await _reportRepo.GetAll();
            if (reports == null)
                return BadRequest();
            return Ok(reports);
        }

        [HttpGet("byuser/{id}")]
        public async Task<IActionResult> GetByUser(string id)
        {
            var reports = await _reportRepo.GetAllForUser(id);
            if (reports == null)
                return BadRequest();
            return Ok(reports);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var report = await _reportRepo.GetById(id);
            if (report == null)
                return NotFound();

            var path = Path.Combine(Directory.GetCurrentDirectory(), report.storedFileName);

            if (!System.IO.File.Exists(path))
                return NotFound();

            var stream = System.IO.File.OpenRead(path);

            return File(stream, "application/pdf", report.FileName);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateReportDto createReportDto)
        {
            var report = await _reportRepo.Create(createReportDto);
            if (report == null)
                return NotFound();

            return Ok(report);
        }
    }
}
