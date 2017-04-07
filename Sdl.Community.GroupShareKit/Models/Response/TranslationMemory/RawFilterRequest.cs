using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class RawFilterRequest
    {
        /// <summary>
        /// Gets or sets translation memory id
        /// </summary>
        public Guid TmId { get; set; }
        /// <summary>
        /// Gets or sets 
        /// </summary>
        public string SourceLanguageCode { get; set; }
        /// <summary>
        /// Gets or sets 
        /// </summary>
        public string TargetLanguageCode { get; set; }
        /// <summary>
        /// Gets or sets 
        /// </summary>
        public int StartTuId { get; set; }
        /// <summary>
        /// Gets or sets 
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Gets or sets 
        /// </summary>
        public FieldFilterRequest Filter { get; set; }

        public RawFilterRequest(Guid tmId,string sourceCode,string targetCode,int startTuId,int count, FieldFilterRequest filter )
        {
            TmId = tmId;
            SourceLanguageCode = sourceCode;
            TargetLanguageCode = targetCode;
            StartTuId = startTuId;
            Count = count;
            Filter = filter;
        }
    }
}
