﻿using Sdl.Community.GroupShareKit.Http;
using System;
using System.Diagnostics;
using System.Net;

namespace Sdl.Community.GroupShareKit.Exceptions
{
    /// <summary>
    /// Represents a HTTP 403 - Forbidden response returned from the API.
    /// </summary>
    public class ForbiddenException : ApiException
    {
        /// <summary>
        /// Constructs an instance of ForbiddenException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        public ForbiddenException(IResponse response) : this(response, null)
        {
        }

        /// <summary>
        /// Constructs an instance of ForbiddenException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        /// <param name="innerException">The inner exception</param>
        public ForbiddenException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
            Debug.Assert(response != null && response.StatusCode == HttpStatusCode.Forbidden,
                "ForbiddenException created with wrong status code");
        }

        public override string Message => ApiErrorMessageSafe ?? "Request Forbidden";
    }
}
