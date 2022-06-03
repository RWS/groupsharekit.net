﻿using Sdl.Community.GroupShareKit.Http;
using System;
using System.Diagnostics;
using System.Net;

namespace Sdl.Community.GroupShareKit.Exceptions
{
    /// <summary>
    /// Constructs an instance of AuthorizationException
    /// </summary>
    public class AuthorizationException : ApiException
    {
        /// <summary>
        /// Constructs an instance of AuthorizationException
        /// </summary>
        public AuthorizationException() : base(HttpStatusCode.Unauthorized, null)
        {
        }

        /// <summary>
        /// Constructs an instance of AuthorizationException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        public AuthorizationException(IResponse response)
            : this(response, null)
        {
        }

        /// <summary>
        /// Constructs an instance of AuthorizationException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        /// <param name="innerException">The inner exception</param>
        public AuthorizationException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
            Debug.Assert(response != null && response.StatusCode == HttpStatusCode.Unauthorized,
                "AuthorizationException created with wrong status code");
        }

        public AuthorizationException(HttpStatusCode httpStatusCode, Exception innerException)
            : base(httpStatusCode, innerException)
        {
        }
    }
}
