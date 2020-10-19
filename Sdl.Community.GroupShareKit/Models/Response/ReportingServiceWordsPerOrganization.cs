using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ReportingServiceWordsPerOrganization
    {
        public string Organization { get; set; }

        public int NumberOfWords { get; set; }

        public int OrganizationId { get; set; }
    }
}
