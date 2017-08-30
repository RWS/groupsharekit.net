using Sdl.TmService.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class ConcordanceSearchRequest
    {
        public string SourceLanguageCode { get; set; }
        public string TargetLanguageCode { get; set; }
        public Guid TmId { get; set; }
        public string SearchText { get; set; }
        public ConcordanceSearchSettings Settings { get; set; }
        public ConcordanceSearchRequest(Guid tmId, string searchText, string sourceCode, string targetCode)
        {
            SourceLanguageCode = sourceCode;
            TargetLanguageCode = targetCode;
            TmId = tmId;
            SearchText = searchText;

        }

        public ConcordanceSearchRequest(Guid tmId, string searchText, string sourceCode, string targetCode, ConcordanceSearchSettings searchSettings)
            :this(tmId,searchText,sourceCode,targetCode)
        {
            Settings = searchSettings;
        }
    }
}
