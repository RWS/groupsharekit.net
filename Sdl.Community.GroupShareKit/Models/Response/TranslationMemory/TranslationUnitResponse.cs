namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class TranslationUnitResponse
    {
        /// <summary>
        /// Gets or sets action name
        /// </summary>
        public string Action    { get; set; }

        /// <summary>
        /// Gets or sets the error code
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets translation unit id
        /// </summary>
        public string TranslationUnitId { get; set; }

        /// <summary>
        /// Gets or sets translation hash
        /// </summary>
        public string TranslationHash { get; set; }
    }
}
