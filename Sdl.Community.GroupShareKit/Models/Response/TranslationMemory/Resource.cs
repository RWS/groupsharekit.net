namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class Resource
    {
        /// <summary>
        /// Gets or sets language resource id
        /// </summary>
        public string LanguageResourceId { get; set; }
        /// <summary>
        /// Gets or sets language resource template id
        /// </summary>
        public string LanguageResourceTemplateId { get; set; }
        /// <summary>
        /// Gets or sets language resource culture name
        /// </summary>
        public string CultureName { get; set; }
        /// <summary>
        /// Gets or sets type 
        /// Type possible value: Variables, Abbreviations, OrdinalFollowers, SegmentationRules
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets data
        /// </summary>
        public string Data { get; set; }

    }
}
