using System;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class ChangeAssignmentRequest
    {
        /// <summary>
        /// Gets or sets the comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the files
        /// </summary>
        public File[] Files { get; set; }
        public ChangeAssignmentRequest(string comment, File[] files)
        {
            Comment = comment;
            Files = files;
        }
        public class File
        {
            /// <summary>
            /// Gets or sets language file id
            /// </summary>
            public string LanguageFileId { get; set; }

            /// <summary>
            /// Gets or sets due date
            /// </summary>
            public DateTimeOffset DueDate { get; set; }

            /// <summary>
            /// Gets or sets phase id
            /// </summary>
            public int PhaseId { get; set; }

            /// <summary>
            /// Gets or sets assigned users
            /// </summary>
            public string[] AssignedUsers { get; set; }
           
        }
    }
}
