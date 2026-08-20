using Microsoft.AspNetCore.Mvc;
using PsychologyAssistant.DTOs.Document;
using PsychologyAssistant.DTOs.Symptom;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Interfaces
{
    public interface IDocumentRepo
    {
        Task<List<DocumentDto>> GetAllAsync();
        Task<DocumentDto> GetOneAsync(Guid id);
        Task<DocumentDto> CreateAsync(IFormFile formFile, Guid documentId, string storedFileName, string filePath);
        Task<bool> DeleteAsync(Guid id);
        Task<List<DocumentDto>> SearchDocument(DocumentSearchDto documentSearchDto);
    }
}
