using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
   public  interface IFileVersion
   {
       /// <summary>
       /// Gets file versions informations<see cref="FileVersion"/>.
       /// </summary>
       ///  <param name="languageFileId">Language file id></param>
       /// <remarks>
       /// This method requires authentication.
       /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
       /// </remarks>
       /// <exception cref="AuthorizationException">
       /// Thrown when the current user does not have permission to make the request.
       /// </exception>
       /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
       /// <returns> List <see cref="FileVersion"/>s.</returns>
       Task<IReadOnlyList<FileVersion>> GetFileVersions(string languageFileId);

        /// <summary>
        /// Downloads the file/>.
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="languageFileId"> Language file id</param>
        /// <param name="version"> File version</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> Donwloaded file in bytes[].</returns>
        Task<byte[]> DownloadFileVersion(string projectId, string languageFileId, int version);
   }
}
