//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class File
    {
        public System.Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] InputStream { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; set; }
        public System.DateTime UploadedDate { get; set; }
    }
}