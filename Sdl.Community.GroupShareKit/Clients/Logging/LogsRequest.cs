using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace Sdl.Community.GroupShareKit.Clients.Logging
{
    /// <summary>
    /// Used to request list of logs
    /// </summary>
    /// <remarks>
    /// API docs: http://gs2017dev.sdl.com:41234/documentation/api/index#/
    /// </remarks>
    public class LogsRequest : RequestParameters
    {

        public LogsRequest()
        {
            
        }

        public LogsRequest(LogsSortParameters sortParam)
        {
            Sort = sortParam;
        }

        public LogsRequest(string page, string limit)
        {
            Page = page;
            Limit = limit;
        }
        public string Page { get; set; }
        public string Limit { get; set; }

        public LogsFilter Filter { get; set; }
        public LogsSortParameters Sort { get; set; }     
    }
}