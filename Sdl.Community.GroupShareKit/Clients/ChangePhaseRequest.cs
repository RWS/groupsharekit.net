using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class ChangePhaseRequest
    {
        public string Comment { get; set; }
        public File[] Files { get; set; }
        public ChangePhaseRequest(string comment, File[] files)
        {
            Comment = comment;
            Files = files;
        }
        public class File
        {
            public string LanguageFileId { get; set; }
            public int PhaseId { get; set; }
        }
    }
}
