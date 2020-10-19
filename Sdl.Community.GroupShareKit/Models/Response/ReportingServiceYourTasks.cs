using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ReportingServiceYourTasks
    {
        public string FileName { get; set; }

        public string ProjectName { get; set; }

        public string SourceLanguage { get; set; }

        public string TargetLanguage { get; set; }

        public DateTime? DueDate { get; set; }

        public Guid ProjectGuid { get; set; }

        public Guid LanguageFileGuid { get; set; }

        public string PhaseName { get; set; }
    }
}
