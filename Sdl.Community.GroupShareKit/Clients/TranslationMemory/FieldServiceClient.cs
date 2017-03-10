using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;

namespace Sdl.Community.GroupShareKit.Clients.TranslationMemory
{
    public class FieldServiceClient : ApiClient, IFieldService
    {
        public FieldServiceClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

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
        public async Task<string> CreateTemplate(FieldTemplate template)
        {
            Ensure.ArgumentNotNull(template, "FieldTemplate");
            var templateLocation =
                await ApiConnection.Post<string>(ApiUrls.FieldTemplate(), template, "application/json");
            var templateId = templateLocation.Split('/').Last();
            return templateId;
        }


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
        public async  Task<FieldTemplates> GetFieldTemplates()
        {
            return await ApiConnection.Get<FieldTemplates>(ApiUrls.FieldTemplate(), null);
        }

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
        public async Task<FieldTemplate> GetFieldTemplateById(string id)
        {
            return await ApiConnection.Get<FieldTemplate>(ApiUrls.GetFieldTemplateById(id), null);
        }

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
        public async Task UpdateFieldTemplate(string templateId, FieldTemplateRequest templateRequest)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNull(templateRequest, "templateRequest");

            await ApiConnection.Put<string>(ApiUrls.GetFieldTemplateById(templateId), templateRequest);

        }

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
        public async Task DeleteFieldTemplate(string templateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId,"templateId");
             await ApiConnection.Delete(ApiUrls.GetFieldTemplateById(templateId));
        }

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
        public async Task AddOperationsForFieldTemplate(string templateId, FieldTemplatePatchRequest request)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNull(request,"request");

             await ApiConnection.Patch(ApiUrls.GetFieldTemplateById(templateId), request, "application/json");
        }
    }
}
