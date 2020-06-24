using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{

    public class BasicCreateProjectRequest
    {
        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        /// <value>
        /// The name of the project.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the organization id.
        /// </summary>
        /// <value>
        /// The organization id.
        /// </value>
        public string OrganizationId { get; set; }

        /// <summary>
        /// Gets or sets the template id
        /// </summary>
        public string ProjectTemplateId { get; set; }

        /// <summary>
        /// Gets or sets the due date
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Gets or sets the lists of reference projects used for perfect match
        /// </summary>
        public ReferenceProject[] ReferenceProjects { get; set; }

        /// <summary>
        /// Gets or sets the flag to control where email notification is required
        /// </summary>
        public bool SuppressEmail { get; set; }

        /// <summary>
        /// Gets or sets the flag to restrict file downloading
        /// </summary>
        public bool IsSecure { get; set; }
    }
}
