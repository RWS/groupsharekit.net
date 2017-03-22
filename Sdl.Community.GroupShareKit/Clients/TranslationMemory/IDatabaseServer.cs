using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;

namespace Sdl.Community.GroupShareKit.Clients.TranslationMemory
{
    public interface IDatabaseServer
    {
        /// <summary>
        ///Returns a list of all available database servers
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns><see cref="DatabaseServerResponse"/></returns>
        Task<DatabaseServerResponse> GetDbServers();

        /// <summary>
        ///Returns specified  database server
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// <param name="serverId">Server id</param>
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns><see cref="DatabaseServer"/></returns>
        Task<DatabaseServer> GetDbServerById(string serverId);

        /// <summary>
        ///Creates a new database server
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="DatabaseServerRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns>The id of db server</returns>
        Task<string> CreateDbServer(DatabaseServerRequest request);

        /// <summary>
        ///Deletes specified  database server
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// <param name="serverId">Server id</param>
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteDbServer(string serverId);

        /// <summary>
        ///Updates specified  database server
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// <param name="serverId">Server id</param>
        /// <param name="request"><see cref="RequestDbServer"/></param>
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task UpdateDbServer(string serverId, RequestDbServer request);
    }
}
