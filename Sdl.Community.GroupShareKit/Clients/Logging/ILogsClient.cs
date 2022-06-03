using Sdl.Community.GroupShareKit.Models.Response.Logs;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients.Logging
{
    public interface ILogsClient
    {
        /// <summary>
        /// Returns all GroupShare log entries
        /// </summary>
        /// <remarks>
        ///  This method requires authentication.
        ///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        ///  </remarks>
        ///  <exception cref="AuthorizationException">
        ///  Thrown when the current user does not have permission to make the request.
        ///  </exception>
        ///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<PagedLogEntriesWithTotalCount> GetAllLogs();

        /// <summary>
        /// Returns a list of filtered logs and their count
        /// </summary>
        /// <param name="filter"></param>
        /// <remarks>
        ///  This method requires authentication.
        ///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        ///  </remarks>
        ///  <exception cref="AuthorizationException">
        ///  Thrown when the current user does not have permission to make the request.
        ///  </exception>
        ///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<PagedLogEntriesWithTotalCount> GetFilteredLogs(LogsFilter filter);

        /// <summary>
        /// Gets a list of logs paged/filtered/sorted
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="ProjectsRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<PagedLogEntriesWithTotalCount> GetLogs(LogsRequest request);
    }
}
