
namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Translation
    {
        /// <summary>
        /// Gets or sets the translation status
        /// </summary>
        public TranslationStatus Status { get; set; }

        /// <summary>
        /// Checks to see if the translation is done
        /// </summary>
        public bool IsFinal { get; set; }

        /// <summary>
        /// Gets the last error message
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
