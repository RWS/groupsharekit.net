using System;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public  class FuzzyIndexResponse
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
       public string Id { get; set; }
        /// <summary>
        /// Gets or sets translation memory id
        /// </summary>
        public string TranslationMemoryId { get; set; }
        /// <summary>
        /// Gets or sets status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets details
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// Gets or sets statistics
         /// </summary>
        public StatisticsDetails Statistics { get; set; }
        /// <summary>
        /// Gets or sets created on date
        /// </summary>
        public DateTime? CreatedOn { get; set; }
    }
}
