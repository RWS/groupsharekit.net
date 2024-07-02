using System;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class ChangeStatusRequest : RequestParameters

    {
        /// <summary>
        /// Gets or sets the project id
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the status
        /// </summary>
        /// Possible values : Started, Archived, Completed
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

        public ChangeStatusRequest(Guid projectId, ProjectStatus projectStatus)
        {
            ProjectId = projectId.ToString();
            Status = projectStatus;
        }
    }

}
