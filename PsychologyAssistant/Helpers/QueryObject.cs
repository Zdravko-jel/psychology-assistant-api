namespace PsychologyAssistant.Helpers
{
    public class QueryObject
    {
        //Using nullable reference types to allow for optional parameters to query a database with .AsQuearyable()

        public int? SampleValue { get; set; } = null;
        public string? SampleText { get; set; } = null;
    }
}
