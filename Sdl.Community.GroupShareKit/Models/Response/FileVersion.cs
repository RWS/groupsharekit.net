using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class FileVersion
    {
        /// <summary>
        /// Gets or sets the language file id
        /// </summary>
        public string LanguageFileId { get; set; }
        /// <summary>
        /// Gets or sets the file id
        /// </summary>
        public string FileId { get; set; }
        /// <summary>
        /// Gets or sets the file name
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Gets or sets the file version number
        /// </summary>
        public int Version { get; set; }
        /// <summary>
        /// Gets or sets last modified date
        /// </summary>
        public DateTime? LastModified { get; set; }
        /// <summary>
        /// Gets or sets the name of user who created the document
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the date when the document was created
        /// </summary>
        public string CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets checkin comment
        /// </summary>
        public string CheckInComment { get; set; }
        /// <summary>
        /// Gets or sets the project id
        /// </summary>
        public string ProjectId { get; set; }


    }
}
