namespace Sdl.Community.GroupShareKit.Clients
{
    public class ChangePhaseRequest
    {
        /// <summary>
        /// Gets or sets the comment
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Gets or sets the files
        /// </summary>
        public File[] Files { get; set; }

        public ChangePhaseRequest(string comment, File[] files)
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
            /// Gets or sets phase id
            /// </summary>
            public int PhaseId { get; set; }
        }
    }
}
