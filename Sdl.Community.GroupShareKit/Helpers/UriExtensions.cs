using System;
using System.Collections.Generic;
using System.Linq;

namespace Sdl.Community.GroupShareKit.Helpers
{
    /// <summary>
    /// Extensions for working with Uris
    /// </summary>
    public static class UriExtensions
    {
        /// <summary>
        /// Merge a dictionary of values with an existing <see cref="Uri"/>
        /// </summary>
        /// <param name="uri">Original request Uri</param>
        /// <param name="parameters">Collection of key-value pairs</param>
        /// <returns>Updated request Uri</returns>
        public static Uri ApplyParameters(this Uri uri, IDictionary<string, string> parameters)
        {
            Ensure.ArgumentNotNull(uri,"uri");

            if (parameters == null || !parameters.Any()) return uri;

            // to prevent values being persisted across requests
            // use a temporary dictionary which combines new and existing parameters
            IDictionary<string, string> tempDictionary = new Dictionary<string, string>(parameters);

            string queryString;
            if (uri.IsAbsoluteUri)
            {
                queryString = uri.Query;
            }
            else
            {
                var hasQueryString = uri.OriginalString.IndexOf("?", StringComparison.Ordinal);
                queryString = hasQueryString == -1 ? string.Empty : uri.OriginalString.Substring(hasQueryString);
            }

            var values = queryString.Replace("?", "")
                .Split(new[] {'&'}, StringSplitOptions.RemoveEmptyEntries);

            var existingParameters = values.ToDictionary(
                key => key.Substring(0, key.IndexOf('=')),
                value => value.Substring(value.IndexOf('=') + 1));

            foreach (var existingParameter in existingParameters.Where(existingParameter => !tempDictionary.ContainsKey(existingParameter.Key)))
            {
                tempDictionary.Add(existingParameter);
            }

            Func<string, string, string> mapValueFunc = (key, value) => key == "q" ? value : Uri.EscapeDataString(value);

            var query = string.Join("&", tempDictionary
                .Where(kvp => !string.IsNullOrEmpty(kvp.Value))
                .Select(kvp => kvp.Key + "=" + mapValueFunc(kvp.Key, kvp.Value)));

            if (uri.IsAbsoluteUri)
            {
                var uriBuilder = new UriBuilder(uri)
                {
                    Query = query
                };
                return uriBuilder.Uri;
            }

            return new Uri(uri + "?" + query, UriKind.Relative);
        }
    }
}
