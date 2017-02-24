using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class FileVersion
    {
        public string LanguageFileId { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
        public int Version { get; set; }
        public DateTime? LastModified { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string CheckInComment { get; set; }
        public string ProjectId { get; set; }


        //public FileVersion(string languageFileId)
        //{
        //    LanguageFileId = languageFileId;
        //}

        //public FileVersion(string projectId,string languageFileId,int version )
        //{
        //    ProjectId = projectId;
        //    LanguageFileId = languageFileId;
        //    Version = version;
        //}
    }
}
