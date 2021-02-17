namespace Sdl.Community.GroupShareKit.Models.Response
{
    /// <summary>
    /// The list of the password complexity rules. 
    /// </summary>
    public class PasswordConstraints
    {
        /// <summary>
        /// Minimum number of digits that the password should contain
        /// </summary>
        public byte MinimumDigits { get; set; }
        /// <summary>
        /// Minimum number of upper case characters that the password should contain
        /// </summary>
        public byte MinimumUppercaseChars { get; set; }
        /// <summary>
        /// Minimum number of lower case characters that the password should contain
        /// </summary>
        public byte MinimumLowercaseChars { get; set; }
        /// <summary>
        /// Minimum number of length of the password
        /// </summary>
        public byte MinimumPasswordLength { get; set; }
        /// <summary>
        /// Minimum number of special characters that the password should contain
        /// </summary>
        public byte MinimumSpecialChars { get; set; }
    }
}
