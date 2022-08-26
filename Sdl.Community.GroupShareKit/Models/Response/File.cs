using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class File
    {
        /// <summary>
        /// Gets or sets the file id
        /// </summary>
        public Guid UniqueId { get; set; }
        /// <summary>
        /// Gets or sets the file relative path
        /// </summary>
        public string FileRelativePath { get; set; }
        /// <summary>
        /// Gets or sets the file name
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Gets or sets the file size
        /// </summary>
        public int FileSize { get; set; }
        /// <summary>
        /// Gets or sets the status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets the language code
        /// </summary>
        public string LanguageCode { get; set; }
        /// <summary>
        /// Gets or sets a list of user details <see cref="UserDetails"/>
        /// </summary>
        public List<UserDetails> Assignees { get; set; }
        /// <summary>
        /// Gets or sets the file type
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// Gets or sets the file role
        /// </summary>
        public string FileRole { get; set; }
        /// <summary>
        /// Gets or sets the last modified date
        /// </summary>
        public DateTime? LastModified { get; set; }
        /// <summary>
        /// Gets or sets the last checkout date
        /// </summary>
        public DateTime? LastCheckOut { get; set; }
        /// <summary>
        /// Gets or sets the last checkin date
        /// </summary>
        public DateTime? LastCheckIn { get; set; }
        /// <summary>
        /// Gets or sets the IsCanceled status
        /// </summary>
        public bool IsCanceled { get; set; }
        /// <summary>
        /// Gets or sets the statistics <see cref="Statistics"/>
        /// </summary>
        public Statistics Statistics { get; set; }
        /// <summary>
        /// Gets or sets the assignment <see cref="Assignment"/>
        /// </summary>
        public Assignment Assignment { get; set; }
        /// <summary>
        /// Gets or sets the user to checkout the file <see cref="UserDetails"/>
        /// </summary>
        public UserDetails CheckOutTo { get; set; }
        /// <summary>
        /// Gets or sets the user who checked in the file <see cref="UserDetails"/>
        /// </summary>
        public UserDetails CheckInBy { get; set; }
        /// <summary>
        /// Gets or sets a list of user details <see cref="UserDetails"/>
        /// </summary>
        public List<UserDetails> OnlineCheckOutTo { get; set; }
    }
}
