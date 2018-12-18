namespace Sdl.Community.GroupShareKit.Clients
{
    public class TranslationAndAnalysisJobRequest
    {
        /// <summary>
        /// Gets the fuzzyBands
        /// </summary>
        public string FuzzyBand { get; }

        public TranslationAndAnalysisJobRequest(string fuzzyBand)
        {
            FuzzyBand = fuzzyBand;
        }
    }
}
