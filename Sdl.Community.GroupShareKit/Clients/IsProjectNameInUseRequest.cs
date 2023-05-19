using System;

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
