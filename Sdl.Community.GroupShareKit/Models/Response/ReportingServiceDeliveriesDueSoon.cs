using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ReportingServiceDeliveriesDueSoon
    {
        public string ProjectName { get; set; }

        public string SourceLanguage { get; set; }

        public string TargetLanguages { get; set; }

        public DateTime? DueDate { get; set; }

        public Guid ProjectGuid { get; set; }

        public bool IsSecure { get; set; }
    }
}
