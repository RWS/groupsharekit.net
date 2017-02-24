using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
   public  interface IFileVersion
   {
       Task<IReadOnlyList<FileVersion>> GetFileVersion(string languageFileId);
       Task<string> DownloadFileVersion(string projectId, string languageFileId, int version);
   }
}
