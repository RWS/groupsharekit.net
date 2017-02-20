using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class File
    {
        public Guid UniqueId { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public string Status { get; set; }
        public string LanguageCode { get; set; }
        public List<UserDetails> Assignees { get; set; }
        public string FileType { get; set; }
        public string FileRole { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? LastCheckOut { get; set; }
        public DateTime? LastCheckIn { get; set; }
        public Statistics Statistics { get; set; }
        public Assignment Assignment { get; set; }
        public UserDetails CheckOutTo { get; set; }
        public UserDetails CheckInBy { get; set; }

    }
}
