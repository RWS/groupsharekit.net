namespace Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Concepts
{
    public class ConceptXmlBatchResponse
    {
        public ConceptXmlItem[] Concepts { get; set; }
        public int[] NotFound { get; set; }
    }
}
