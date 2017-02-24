using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class FileVersionClient: ApiClient,IFileVersion
    {
        public FileVersionClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public async Task<IReadOnlyList<FileVersion>> GetFileVersion(string languageFileId)
        {
            Ensure.ArgumentNotNullOrEmptyString(languageFileId,"languageFileId");
            return await ApiConnection.GetAll<FileVersion>(ApiUrls.GetFileVersion(languageFileId), null);
        }

        public async Task<string> DownloadFileVersion(string projectId, string languageFileId, int version)
        {
            Ensure.ArgumentNotNullOrEmptyString(languageFileId, "languageFileId");
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotNull(version, "version");

            return
                await
                    ApiConnection.Get<string>(ApiUrls.DownloadFileForVersion(projectId, languageFileId, version), null);
        }
    }
}
