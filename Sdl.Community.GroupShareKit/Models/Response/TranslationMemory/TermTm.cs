using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class TermTm
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the text
        /// </summary>
        public string Text { get; set; }

        /// <summary> 
        /// Gets or sets score
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets a list of term translation
        /// </summary>
        public List<TermTranslation> TermTranslations { get; set; }

    }
}
