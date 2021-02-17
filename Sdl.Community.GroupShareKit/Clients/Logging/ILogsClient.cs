using Sdl.Community.GroupShareKit.Models.Response.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients.Logging
{
    public interface ILogsClient
    {
		/// <summary>
		/// Returns all GroupShare log entries
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


		Task<PagedLogEntriesWithTotalCount> GetAllLogs();
		
		
		Task<PagedLogEntriesWithTotalCount> GetFilteredLogs(LogsFilter filter);
	}
}
