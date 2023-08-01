using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class TermbaseDetails
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets creation date
        /// </summary>
        // GroupShare (MultiTerm) RestAPI returns termbase creation date format depending on server settings (LTGS-9908)
        [JsonConverter(typeof(TwelveHourDateTimeConverter))]
        public DateTime? CreationDate { get; set; }
        /// <summary>
        /// Gets or sets copyright
        /// </summary>
        public string Copyright { get; set; }
        /// <summary>
        /// Gets or sets number of concepts
        /// </summary>
        public int? NumberOfConcepts { get; set; }

        /// <summary>
        /// Gets or sets language index details
        /// </summary>
        public List<LanguageIndexDetails> LanguageIndexDetails { get; set; }
        /// <summary>
        /// Gets or sets a list of languages
        /// </summary>
        public List<Language> Languages { get; set; }
        /// <summary>
        /// Gets or sets a list of attributes
        /// </summary>
        public List<Atribute> Attributes { get; set; }

        /// <summary>
        /// Gets or sets a list of entry classes
        /// </summary>
        public List<EntryClass> EntryClasses { get; set; }
    }
}
