using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
   public  class UserAssignments
    {
        public string ProjectId { get; set; }
        public string Project { get; set; }
        public string LanguageFileId { get; set; }
        public string LanguageFile { get; set; }
        public DateTime? DueDate { get; set; }
        public int PhaseId { get; set; }
        public string Phase { get; set; }

       public string SourceLanguage { get; set; }
       public string TargetLanguage { get; set; }
    }
}
