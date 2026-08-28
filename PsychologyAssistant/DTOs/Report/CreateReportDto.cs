using System.ComponentModel.DataAnnotations;

namespace PsychologyAssistant.DTOs.Report
{
    public class CreateReportDto
    {
        [Required]
        public string UserId { get; set; }
    }
}
