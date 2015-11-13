using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Http;

namespace Sdl.Community.GroupShareKit.Exceptions
{
    /// <summary>
    /// Represents a HTTP 422 - Unprocessable Entity response returned from the API.
    /// </summary>
    public class ApiValidationException: ApiException
    {
        /// <summary>
        /// Constructs an instance of ApiValidationException
        /// </summary>
        public ApiValidationException() : base((HttpStatusCode)422, null)
        {
        }

        /// <summary>
        /// Constructs an instance of ApiValidationException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        public ApiValidationException(IResponse response)
            : this(response, null)
        {
        }

        /// <summary>
        /// Constructs an instance of ApiValidationException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        /// <param name="innerException">The inner exception</param>
        public ApiValidationException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
            Debug.Assert(response != null && response.StatusCode == (HttpStatusCode)422,
                "ApiValidationException created with wrong status code");
        }

        /// <summary>
        /// Constructs an instance of ApiValidationException
        /// </summary>
        /// <param name="innerException">The inner exception</param>
        protected ApiValidationException(ApiException innerException)
            : base(innerException)
        {
        }

        public override string Message => ApiErrorMessageSafe ?? "Validation Failed";

    }
}
