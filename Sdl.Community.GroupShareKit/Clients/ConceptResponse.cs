namespace Sdl.Community.GroupShareKit.Clients
{
    /// <remarks>
    /// This class appears to be misnamed. It actaully represents a request (parameter), not a response.
    /// </remarks>
    public class ConceptResponse : RequestParameters
    {
        public string TermbaseId { get; set; }
        public string ConceptId { get; set; }

        public ConceptResponse(string termbaseId, string conceptId)
        {
            TermbaseId = termbaseId;
            ConceptId = conceptId;
        }
    }
}
