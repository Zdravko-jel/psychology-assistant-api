using PsychologyAssistant.DTOs.Document;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Mappers
{
    public static class DocumentMappers
    {
        public static DocumentDto ToDocumentDto(this Document document)
        {
            return new DocumentDto
            {
                Id = document.Id,
                FileName = document.FileName
            };
        }
    }
}
