using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Exceptions
{
    public class ApiException: Exception
    {
        private static readonly IJsonSerializer JsonSerializer = new SimpleJsonSerializer();

        /// <summary>
        /// Constructs an instance of ApiException
        /// </summary>
        public ApiException(): this(new Response())
        {
            
        }

        /// <summary>
        /// Constructs an instance of ApiException
        /// </summary>
        /// <param name="message">The error message</param>
        /// <param name="httpStatusCode">The HTTP status code from the response</param>
        public ApiException(string message, HttpStatusCode httpStatusCode)
            : this(GetApiErrorFromExceptionMessage(message), httpStatusCode, null)
        {
        }

        /// <summary>
        /// Constructs an instance of ApiException
        /// </summary>
        /// <param name="message">The error message</param>
        /// <param name="innerException">The inner exception</param>
        public ApiException(string message, Exception innerException)
            : this(GetApiErrorFromExceptionMessage(message), 0, innerException)
        {
        }

        /// <summary>
        /// Constructs an instance of ApiException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        public ApiException(IResponse response)
            : this(response, null)
        {
        }

        /// <summary>
        /// Constructs an instance of ApiException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        /// <param name="innerException">The inner exception</param>
        public ApiException(IResponse response, Exception innerException)
            : base(null, innerException)
        {
            Ensure.ArgumentNotNull(response, "response");

            StatusCode = response.StatusCode;
            ApiError = GetApiErrorFromExceptionMessage(response);
            HttpResponse = response;
        }

        /// <summary>
        /// Constructs an instance of ApiException
        /// </summary>
        /// <param name="innerException">The inner exception</param>
        protected ApiException(ApiException innerException)
        {
            Ensure.ArgumentNotNull(innerException, "innerException");

            StatusCode = innerException.StatusCode;
            ApiError = innerException.ApiError;
        }

        protected ApiException(HttpStatusCode statusCode, Exception innerException)
            : base(null, innerException)
        {
            ApiError = new ApiError();
            StatusCode = statusCode;
        }

        protected ApiException(ApiError apiError, HttpStatusCode statusCode, Exception innerException)
            : base(null, innerException)
        {
            Ensure.ArgumentNotNull(apiError, "apiError");

            ApiError = apiError;
            StatusCode = statusCode;
        }

        public IResponse HttpResponse { get; private set; }

        public override string Message => ApiErrorMessageSafe ?? "An error occurred with this API request";

        /// <summary>
        /// The HTTP status code associated with the repsonse
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// The raw exception payload from the response
        /// </summary>
        public ApiError ApiError { get; }

        static ApiError GetApiErrorFromExceptionMessage(IResponse response)
        {
            string responseBody = response?.Body as string;
            return GetApiErrorFromExceptionMessage(responseBody);
        }

        static ApiError GetApiErrorFromExceptionMessage(string responseContent)
        {
            try
            {
                if (!String.IsNullOrEmpty(responseContent))
                {
                    return JsonSerializer.Deserialize<ApiError>(responseContent) ?? new ApiError(responseContent);
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return new ApiError(responseContent);
        }

        /// <summary>
        /// Get the inner error message from the API response
        /// </summary>
        /// <remarks>
        /// Returns null if ApiError is not populated
        /// </remarks>
        protected string ApiErrorMessageSafe => ApiError?.Message;
    }
}
