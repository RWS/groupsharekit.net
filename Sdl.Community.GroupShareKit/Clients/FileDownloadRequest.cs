using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class FileDownloadRequest : RequestParameters
    {

        public string ProjectId { get; set; }
        public string LanguageCode { get; set; }
        public Types? Type { get; set; }

        public enum Types { All, Targetfiles }


        public FileDownloadRequest(string projectId,string languageCode,Types? type)
        {
            ProjectId = projectId;
            LanguageCode = languageCode;
            if (type != null) Type = type.Value;
        }

    }
}
