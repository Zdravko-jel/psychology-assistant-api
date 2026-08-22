namespace PsychologyAssistant.DTOs.Note
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PatientId { get; set; }
        public string TakenNote { get; set; }
    }
}
