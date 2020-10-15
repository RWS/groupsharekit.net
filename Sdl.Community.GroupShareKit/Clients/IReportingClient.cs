using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IReportingClient
    {
		/// <summary>
		/// Returns the Predefined Projects report data
		/// </summary>
		/// <param name="options"></param>
		/// <remarks>
		///  This method requires authentication.
		///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
		///  </remarks>
		///  <exception cref="AuthorizationException">
		///  Thrown when the current user does not have permission to make the request.
		///  </exception>
		///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
		Task<List<ReportingServiceProjects>> PredefinedProjects(PredefinedReportsFilters filters);

		/// <summary>
		/// Returns the Predefined Tasks report data
		/// </summary>
		/// <param name="options"></param>
		/// <remarks>
		///  This method requires authentication.
		///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
		///  </remarks>
		///  <exception cref="AuthorizationException">
		///  Thrown when the current user does not have permission to make the request.
		///  </exception>
		///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
		Task<List<ReportingServiceTasks>> PredefinedTasks(PredefinedReportsFilters filters);

		/// <summary>
		/// Returns the Predefined TmLeverage report data
		/// </summary>
		/// <param name="options"></param>
		/// <remarks>
		///  This method requires authentication.
		///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
		///  </remarks>
		///  <exception cref="AuthorizationException">
		///  Thrown when the current user does not have permission to make the request.
		///  </exception>
		///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
		Task<List<ReportingServiceTmLeverage>> PredefinedTmLeverage(PredefinedReportsFilters filters);

	}
}
