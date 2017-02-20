using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Statistics
    {
        public int TyPercentCompletepe { get; set; }
        public int TotalWords { get; set; }
        public int UnspecifiedWords { get; set; }
        public int DraftWords { get; set; }
        public int TranslatedWords { get; set; }
        public int RejectedTranslationWords { get; set; }
        public int ApprovedTranslationWords { get; set; }
        public int RejectedSignOffWords { get; set; }
        public int ApprovedSignOffWords { get; set; }
    }
}
