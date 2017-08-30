using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class ConcordanceSearchSettings
    {
        public bool IsTargetConcodanceSearch { get; set; }
        public int MinScore { get; set; }
        public int MaxResults { get; set; }
        //We need to add filter property
    }
}
