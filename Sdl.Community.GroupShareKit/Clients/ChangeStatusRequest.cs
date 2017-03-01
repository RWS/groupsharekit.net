using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class ChangeStatusRequest: RequestParameters
    {
        public string ProjectId { get; set; }

        public ProjectStatus Status { get; set; }

        public enum ProjectStatus
        {
            Started,
            Archived,
            Completed

        }

        public ChangeStatusRequest(string projectId, ProjectStatus projectStatus)
        {
            ProjectId = projectId;
            Status = projectStatus;
        }
    }

}
