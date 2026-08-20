using Microsoft.AspNetCore.Mvc;
using PsychologyAssistant.DTOs.Document;
using PsychologyAssistant.Interfaces;

namespace PsychologyAssistant.Controllers
{
    [Route("api/documents")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepo _documentRepo;

        public DocumentController(IDocumentRepo documentRepo)
        {
            _documentRepo = documentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var documents = await _documentRepo.GetAllAsync();
            return Ok(documents);
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
                return BadRequest("No file uploaded.");

            var allowedExtensions = new[] { ".pdf", ".docx", ".doc", ".ppt", ".pptx", ".txt" };
            var extenstion = Path.GetExtension(formFile.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extenstion))
                return BadRequest("Unsupported file type.");

            var documentId = Guid.NewGuid(); // Generate a unique identifier for the document

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads", "documents");
            Directory.CreateDirectory(uploadsFolder);

            var storedFileName = $"{Guid.NewGuid()}{extenstion}";

            var filePath = Path.Combine(uploadsFolder, storedFileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await formFile.CopyToAsync(stream);

            await _documentRepo.CreateAsync(formFile, documentId, storedFileName, filePath);

            return Ok(new { DocumentId = documentId, FileName = storedFileName, OriginalFileName = formFile.FileName });
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _documentRepo.DeleteAsync(id);
            if (!result)
                return NotFound("Document not found.");
            return Ok("Document deleted successfully.");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDocument([FromRoute] Guid id)
        {
            var document = await _documentRepo.GetOneAsync(id);
            if (document == null)
                return NotFound("Document not found.");
            return Ok(document);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchDocuments([FromQuery] DocumentSearchDto documentSearchDto)
        {
            var documents = await _documentRepo.SearchDocument(documentSearchDto);
            if (documents == null || !documents.Any())
                return NotFound("No documents found matching the search criteria.");
            return Ok(documents);
        }
    }
}
