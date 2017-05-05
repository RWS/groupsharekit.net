using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IProjectsTemplateClient
    {
        /// <summary>
        ///Gets all templates
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A List of <see cref="ProjectTemplates"/></returns>
        Task<IReadOnlyList<ProjectTemplates>> GetAllTemplates();

        /// <summary>
        ///Creates a template
        /// </summary>
        /// <param name="projectRequest"><see cref="ProjectTemplates"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Id of created template/></returns>
        Task<string> CreateTemplate(ProjectTemplates projectRequest, byte[] rawData);

        /// <summary>
        ///Get a template by id
        /// </summary>
        /// <param name="templateId">string</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Te contend of template in a string/></returns>
        Task<string> GetTemplateById(string templateId);

        /// <summary>
        ///Deletes a template 
        /// </summary>
        /// <param name="id">string</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task Delete(string id);

        /// <summary>
        ///Uploades a template to a newly created project 
        /// This method shoulg be called after you create a project in order to add the template
        /// </summary>
        /// <param name="templateId">string</param>
        /// <param name="projectTemplate">byte[]</param>
        /// <param name="templateName">string</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<string> UploadProjectTemplate(string templateId,byte[] projectTemplate,string templateName);
    }
}
