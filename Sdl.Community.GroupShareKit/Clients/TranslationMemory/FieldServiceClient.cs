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
        public async Task<string> CreateFieldTemplate(FieldTemplate template)
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

        /// <summary>
        /// Gets a list of Fields for a specific field Template ID
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Field"/>'s</returns>
        public async Task<IReadOnlyList<Field>> GetFieldsForTemplate(string fieldTemplateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(fieldTemplateId, "fieldTemplateId");
            return await ApiConnection.GetAll<Field>(ApiUrls.GetFields(fieldTemplateId), null);
        }

        /// <summary>
        /// Gets a specified Field for a specific Field Template ID
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="Field"/></returns>
        public async Task<Field> GetFieldForTemplate(string fieldTemplateId, string fieldId)
        {
            Ensure.ArgumentNotNullOrEmptyString(fieldTemplateId, "fieldTemplateId");
            Ensure.ArgumentNotNullOrEmptyString(fieldId, "fieldId");
            return await ApiConnection.Get<Field>(ApiUrls.GetField(fieldTemplateId, fieldId), null);

        }
        /// <summary>
        /// Creates a Field for a specific Field Template ID
        /// If selected type is SinglePicklist or MultiplePicklist , "values " property should be filled out.
        ///  For each value the id should be a new Guid, and the "name" property should be the value you want to add.
        /// </summary>
        /// <remarks>
        /// <param name="fieldRequest"><see cref="FieldRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> Field Id</returns>
        public async Task<string> CreateFieldForTemplate(string fieldTemplateId, FieldRequest fieldRequest)
        {
            Ensure.ArgumentNotNullOrEmptyString(fieldTemplateId,"fieldTemplateId");
            Ensure.ArgumentNotNull(fieldRequest, "field request");
            var fieldType = Enum.GetName(typeof (FieldRequest.TypeEnum), fieldRequest.Type);

            // in case the type is SinglePicklist or MultiplePicklist the values will be a list of strings.
   
            var field = new Field
            {
                Type = fieldType,
                Name = fieldRequest.Name,
                FieldId = fieldRequest.FieldId,
                Values = GetValues(fieldRequest.Values)
            };
            return
                await
                    ApiConnection.Post<string>(ApiUrls.GetFields(fieldTemplateId), field, "application/json");
        }

        /// <summary>
        /// Helper method in case of SinglePicklist or MultiplePicklist type
        /// </summary>
        /// <param name="valuesList"></param>
        /// <returns>A list of <see cref="Value"/>'s</returns>
        private List<Value> GetValues(List<string> valuesList)
        {
            var multipleValuesList = new List<Value>();
            foreach (var value in valuesList)
                {
                var item = new Value
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = value
                };
                multipleValuesList.Add(item);
            }
            return multipleValuesList;
        }

        /// <summary>
        /// Updates a Field for a specific Field Template ID
        /// </summary>
        /// <remarks>
        /// <param name="fieldRequest"><see cref="FieldRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task UpdateFieldForTemplate(string fieldTemplateId, string fieldId, Field field)
        {
            Ensure.ArgumentNotNullOrEmptyString(fieldId, "fieldId");
            Ensure.ArgumentNotNullOrEmptyString(fieldTemplateId, "fieldTemplateId");
            Ensure.ArgumentNotNull(field, "field request");
            await
                ApiConnection.Put<string>(ApiUrls.GetField(fieldTemplateId, fieldId), field);
        }

        /// <summary>
        /// Deletes a specified Field for a specific Field Template ID
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task DeleteFieldForTemplate(string fieldTemplateId, string fieldId)
        {
            Ensure.ArgumentNotNullOrEmptyString(fieldTemplateId, "fieldTemplateId");
            Ensure.ArgumentNotNullOrEmptyString(fieldId, "fieldId");

            await ApiConnection.Delete(ApiUrls.GetField(fieldTemplateId, fieldId));
        }
    }
}
