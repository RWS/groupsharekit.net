using Sdl.Community.GroupShareKit.Clients;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class TranslationUnitDetailsRequest : RequestParameters
    {
        /// <summary>
        /// Gets or sets source language
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets target language
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets start tu id
        /// </summary>
        public int StartTuId { get; set; }

        /// <summary>
        /// Gets or sets count
        /// </summary>
        public int Count { get; set; }

        public TranslationUnitDetailsRequest(string source, string target, int startTu, int count)
        {
            Source = source;
            Target = target;
            StartTuId = startTu;
            Count = count;
        }
    }
}
