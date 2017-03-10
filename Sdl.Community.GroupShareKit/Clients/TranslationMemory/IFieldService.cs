using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;

namespace Sdl.Community.GroupShareKit.Clients.TranslationMemory
{
    public interface IFieldService
    {
        /// <summary>
        /// Creates <see cref="FieldTemplate"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns>Created field template id</returns>
        Task<string> CreateTemplate(FieldTemplate template);

        /// <summary>
        /// Gets <see cref="FieldTemplates"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns>Returns <see cref="FieldTemplates"/> which contains a list of <see cref="FieldTemplate"/></returns>
        Task<FieldTemplates> GetFieldTemplates();

        /// <summary>
        /// Gets <see cref="FieldTemplate"/> by id.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns><see cref="FieldTemplate"/></returns>
        Task<FieldTemplate> GetFieldTemplateById(string id);

        /// <summary>
        /// Updates <see cref="FieldTemplate"/> 
        /// </summary>
        /// <remarks>
        /// <param name="templateRequest"><see cref="FieldTemplateRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns><see cref="FieldTemplate"/> id</returns>
        Task UpdateFieldTemplate(string templateId, FieldTemplateRequest templateRequest);


        /// <summary>
        /// Deletes <see cref="FieldTemplate"/> by id.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteFieldTemplate(string templateId);


        /// <summary>
        /// Updates <see cref="FieldTemplate"/> 
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="FieldTemplatePatchRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task AddOperationsForFieldTemplate(string templateId, FieldTemplatePatchRequest request);
    }
}
