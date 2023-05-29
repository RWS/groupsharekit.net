using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response.Logs;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients.Logging
{
    public class LogsClient: ApiClient, ILogsClient
    {
        public LogsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Gets all logs
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of all logs and their count.</returns>
        public Task<PagedLogEntriesWithTotalCount> GetAllLogs()
        {
            var logsUrl = ApiUrls.GetLogs();
            return ApiConnection.Get<PagedLogEntriesWithTotalCount>(logsUrl, null); 
        }

        /// <summary>
        /// Gets filtered logs
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of all logs filtered and their count.</returns>
        public Task<PagedLogEntriesWithTotalCount> GetFilteredLogs(LogsFilter filter)
        {
            var jsonOptions = filter.Stringify();
            return ApiConnection.Get<PagedLogEntriesWithTotalCount>(ApiUrls.GetLogsFiltered(jsonOptions), null);
        }

        /// <summary>
        /// Gets a list of logs and their count
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="PagedLogEntriesWithTotalCount"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public Task<PagedLogEntriesWithTotalCount> GetLogs(LogsRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");

            return ApiConnection.Get<PagedLogEntriesWithTotalCount>(ApiUrls.GetLogs(), request.ToParametersDictionary());
        }
    }
}
