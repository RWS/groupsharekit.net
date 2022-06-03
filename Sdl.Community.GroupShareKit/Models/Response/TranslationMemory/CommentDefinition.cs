using System;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class CommentDefinition
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
        /// Gets or sets author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the date
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Gets or sets comment severity
        /// </summary>
        public string CommentSeverity { get; set; }

        /// <summary>
        /// Gets or sets metadata
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}
