using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class File
    {
            public Guid FileUniqueId { get; set; }
            public string FileName { get; set; }
            public int Status { get; set; }
            public string StatusName { get; set; }
            public int PercentComplete { get; set; }
            public string LanguageCode { get; set; }
            public int ProjectPhaseId { get; set; }
            public List<Guid> Assignees { get; set; } 

    }
}
