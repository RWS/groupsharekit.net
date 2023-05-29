namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class FilterResponse
    {
        /// <summary>
        /// Gets or sets  source text
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// Gets or sets  target text
        /// </summary>
        public string Target { get; set; }
        public string MatchScore { get; set; }
    }
}
