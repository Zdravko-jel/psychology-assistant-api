using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PsychologyAssistant.Data;
using PsychologyAssistant.DTOs.Document;
using PsychologyAssistant.Interfaces;
using PsychologyAssistant.Mappers;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Repositories
{
    public class DocumentRepo : IDocumentRepo
    {
        private readonly ApplicationDbContext _context;

        public DocumentRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DocumentDto> CreateAsync(IFormFile formFile, Guid documentId, string storedFileName, string filePath)
        {
            var document = new Document
            {
                Id = documentId,
                FileName = formFile.FileName,
                StoredFileName = storedFileName,
                FilePath = filePath,
                ContentType = formFile.ContentType,
                FileSize = formFile.Length,
                UploadDate = DateTime.Now
            };

            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();
            return document.ToDocumentDto();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var document = await _context.Documents.FirstOrDefaultAsync(d => d.Id == id);
            if (document == null)
            {
                return false;
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), document.FilePath);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<DocumentDto>> GetAllAsync()
        {
            return await _context.Documents.Select(d => d.ToDocumentDto()).ToListAsync();
        }

        public async Task<DocumentDto> GetOneAsync(Guid id)
        {
            var document = await _context.Documents.FirstOrDefaultAsync(d => d.Id == id);
            if (document == null)
            {
                return null;
            }

            return document.ToDocumentDto();
        }

        public async Task<List<DocumentDto>> SearchDocument(DocumentSearchDto documentSearchDto)
        {
            if (documentSearchDto.Words.IsNullOrEmpty())
                return null;

            var query = _context.Documents.AsQueryable();
            if (documentSearchDto.Words.Count == 1)
            {
                var word = documentSearchDto.Words[0];
                query = query.Where(x => x.FileName.Contains(word));
                return await query.Select(x => x.ToDocumentDto()).ToListAsync();
            }
            else
            {
                query = query.Where(x => documentSearchDto.Words.Any(word => x.FileName.Contains(word)));
                return await query.Select(x => x.ToDocumentDto()).ToListAsync();
            }
        }
    }
}
