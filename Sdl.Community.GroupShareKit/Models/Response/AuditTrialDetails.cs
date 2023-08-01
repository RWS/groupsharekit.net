using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    [Obsolete("AuditTrialDetails is deprecated, please use AuditTrailDetails instead.")]
    public class AuditTrialDetails
    {
        public LanguageFileDetails LanguageFile { get; set; }
        public List<Trial> Trials { get; set; }
    }
}
