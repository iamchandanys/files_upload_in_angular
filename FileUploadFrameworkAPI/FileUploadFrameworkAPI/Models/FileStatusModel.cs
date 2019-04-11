using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploadFrameworkAPI.Models
{
    public class FileStatusModel
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string SourcePath { get; set; }
        public string StatusMessage { get; set; }
        public bool IsSuccessfull { get; set; }
    }
}