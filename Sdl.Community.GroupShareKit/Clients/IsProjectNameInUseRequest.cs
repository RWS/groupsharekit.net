using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class IsProjectNameInUseRequest : RequestParameters
    {
        public IsProjectNameInUseRequest(Guid organizationId, string projectName)
        {
            OrganizationId = organizationId;
            ProjectName = projectName;
        }

        public Guid OrganizationId { get; set; }
        public string ProjectName { get; set; }
    }
}
