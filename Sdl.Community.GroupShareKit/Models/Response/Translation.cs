
namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Translation
    {
        /// <summary>
        /// Gets or sets the translation status
        /// </summary>
        public TranslationStatus Status { get; }

        /// <summary>
        /// Checks to see if the translation is done
        /// </summary>
        public bool Final { get; }

        /// <summary>
        /// Gets the last error message
        /// </summary>
        public string Error { get; }
    }
}
