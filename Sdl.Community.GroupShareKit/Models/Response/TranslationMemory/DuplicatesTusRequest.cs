namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class DuplicatesTusRequest
    {
        /// <summary>
        /// Gets or sets starting position
        /// </summary>
        public Position PositionFrom { get; set; }
        /// <summary>
        /// Gets or sets end position
        /// </summary>
        public Position PositionTo { get; set; }
        /// <summary>
        /// Gets or sets max count number
        /// </summary>
        public int MaxCount { get; set; }
        /// <summary>
        /// Gets or sets max scan number
        /// </summary>
        public int MaxScan { get; set; }
        /// <summary>
        /// Gets or sets if is forward
        /// </summary>
        public bool Forward { get; set; }
        /// <summary>
        /// Gets or sets number of processed translation units
        /// </summary>
        public int ProcessedTranslationUnits { get; set; }
        /// <summary>
        /// Gets or sets number of scanned translation units
        /// </summary>
        public int ScannedTranslationUnits { get; set; }
        /// <summary>
        /// Gets or sets the filter
        /// </summary>
        public FilterDuplicates Filter { get; set; }
    }
}
