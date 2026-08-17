namespace PsychologyAssistant.Models
{
    public class Diagnosis
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Symptom>? Symptoms { get; set; }
    }
}
