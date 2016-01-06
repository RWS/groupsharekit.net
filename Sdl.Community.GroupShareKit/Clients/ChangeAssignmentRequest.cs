using System;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class ChangeAssignmentRequest
    {

        public string Comment { get; set; }
        public File[] Files { get; set; }
        public ChangeAssignmentRequest(string comment, File[] files)
        {
            Comment = comment;
            Files = files;
        }
        public class File
        {
            public string LanguageFileId { get; set; }
            public DateTimeOffset DueDate { get; set; }
            public int PhaseId { get; set; }
            public string[] AssignedUsers { get; set; }
           
        }
    }
}
