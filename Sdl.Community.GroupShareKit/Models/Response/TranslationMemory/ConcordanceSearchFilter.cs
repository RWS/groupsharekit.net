namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class ConcordanceSearchFilter
    {
        public string Name { get; set; }
        public FieldFilterRequest Expression { get; set; }
        public int Penalty { get; set; }
    }
}
