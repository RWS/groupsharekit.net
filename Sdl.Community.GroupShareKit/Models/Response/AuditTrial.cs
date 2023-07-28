using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    [Obsolete("AuditTrial is deprecated, please use AuditTrail instead.")]
    public class AuditTrial
    {
        public LanguageFileDetails LanguageFile { get; set; }
        public List<Trial> Trials { get; set; }
    }
}
