using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    /// <summary>
    /// Organization-level AI provider endpoint. Shared infrastructure settings
    /// (such as concurrency limits) are configured once here rather than per user.
    /// </summary>
    public class AiEndpoint
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string DisplayName { get; set; }

        /// <summary>
        /// Provider descriptor id, for example "ollama", "lm-studio", "openai".
        /// </summary>
        public string Provider { get; set; }

        public string Endpoint { get; set; }

        /// <summary>
        /// Maximum concurrent HTTP requests to this endpoint. 0 = no limit.
        /// </summary>
        public int MaxConcurrentRequests { get; set; } = 2;
    }
}
