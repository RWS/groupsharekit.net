﻿namespace Sdl.Community.GroupShareKit.Clients
{
    public class SearchTermRequest : RequestParameters
    {
        /// <summary>
        /// Gets or sets termbase id
        /// </summary>
        public string Tid { get; set; }

        /// <summary>
        /// Gets or sets source language id
        /// </summary>
        public string SrcLangId { get; set; }
        /// <summary>
        /// Gets or sets text to be searched
        /// </summary>
        public string Query { get; set; }
        /// <summary>
        /// Gets or sets target language id
        /// </summary>
        public string TrgLangId { get; set; }
        /// <summary>
        /// Gets or sets page size number
        /// </summary>
        public string PageSize { get; set; }
        /// <summary>
        /// Gets or sets the concept id (by default is empty)
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// Gets or sets filter id (by default is:Sdl.StudioServer.Services.MultiTerm.RestApi.Constants.DefaultFilterId})
        /// </summary>
        public string FilterId { get; set; }

        public SearchTermRequest(string termbaseId, string srcLang, string query, string trgLang, string pageSize,
            string from
            , string filterId) : this(termbaseId, srcLang, trgLang, query)
        {
            PageSize = pageSize;
            From = from;
            FilterId = filterId;
        }
        public SearchTermRequest(string termbaseId, string srcLang, string trgLang, string query)
        {
            Tid = termbaseId;
            SrcLangId = srcLang;
            Query = query;
            TrgLangId = trgLang;
        }

        public SearchTermRequest(string termbaseId, string language, string query)
        {

            Tid = termbaseId;
            SrcLangId = language;
            Query = query;
        }
    }
}
