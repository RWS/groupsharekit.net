﻿using Sdl.Community.GroupShareKit.Http;
using System;
using System.Diagnostics;
using System.Net;

namespace Sdl.Community.GroupShareKit.Exceptions
{
    /// <summary>
    /// Represents a HTTP 404 - Not Found response returned from the API.
    /// </summary>
    public class NotFoundException : ApiException
    {
        /// <summary>
        /// Constructs an instance of NotFoundException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        public NotFoundException(IResponse response) : this(response, null)
        {
        }

        /// <summary>
        /// Constructs an instance of NotFoundException
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="statusCode">The http status code returned by the response</param>
        public NotFoundException(string message, HttpStatusCode statusCode) : base(message, statusCode)
        {
        }

        /// <summary>
        /// Constructs an instance of NotFoundException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        /// <param name="innerException">The inner exception</param>
        public NotFoundException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
            Debug.Assert(response != null && response.StatusCode == HttpStatusCode.NotFound,
                "NotFoundException created with wrong status code");
        }
    }
}
