namespace Sdl.Community.GroupShareKit.Clients
{
    public class FileDownloadRequest : RequestParameters
    {
        /// <summary>
        /// Gets or sets the project id
        /// </summary>
        public string ProjectId { get; set; }
        /// <summary>
        /// Gets or sets the language code
        /// </summary>
        public string LanguageCode { get; set; }
        /// <summary>
        /// Gets or sets the type
        /// </summary>
        /// Possile values: All, TargetFiles
        public Types? Type { get; set; }

        public enum Types { All, TargetFiles }


        public FileDownloadRequest(string projectId, string languageCode, Types? type)
        {
            ProjectId = projectId;
            LanguageCode = languageCode;
            if (type != null) Type = type.Value;
        }

    }
}
