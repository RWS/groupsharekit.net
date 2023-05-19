namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class License
    {
        /// <summary>
        /// Gets or sets Project Server CALs
        /// </summary>
        public LicenseDetails ProjectServerCALs { get; set; }
        /// <summary>
        /// Gets or sets Translation Memory CALs
        /// </summary>
        public LicenseDetails TranslationMemoryCALs { get; set; }
        /// <summary>
        /// Gets or sets TUs
        /// </summary>
        public LicenseDetails TUs { get; set; }
        /// <summary>
        /// Gets or sets Multi TermViewer CALs
        /// </summary>
        public LicenseDetails MultiTermViewerCALs { get; set; }
        /// <summary>
        /// Gets or sets Multi Term Editor CALs
        /// </summary>
        public LicenseDetails MultiTermEditorCALs { get; set; }
    }
}
