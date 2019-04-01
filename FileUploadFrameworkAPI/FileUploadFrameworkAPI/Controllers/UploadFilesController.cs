using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

namespace FileUploadFrameworkAPI.Controllers
{
    public class UploadFilesController : ApiController
    {
        [HttpPost]
        [Route("api/UploadFiles/UploadFilesToLocalFolder")]
        public void UploadFilesToLocalFolder()
        {
            var httpRequest = HttpContext.Current.Request;

            foreach (string fileTagName in httpRequest.Files)
            {
                HttpPostedFileBase filebase = new HttpPostedFileWrapper(HttpContext.Current.Request.Files[fileTagName]);

                string directoryPath = string.Empty;
                string sourcePath = string.Empty;

                //The folder path where we need to upload files is configured in Web.config
                //The folder where we upload files should be shareable
                //Setps to make folder shareable is explained in ReadMe file
                var uploadFolderPath = WebConfigurationManager.AppSettings["UploadFolderPath"].ToString();

                string fileExtension = Path.GetExtension(filebase.FileName).ToLower().Trim();

                if (!string.IsNullOrEmpty(uploadFolderPath) && !string.IsNullOrEmpty(fileExtension))
                {
                    //The new folder with the name current DateTime is created inside Upload Folder Path
                    //So the files uploaded everyday will be stored as per their respective dates
                    directoryPath = Path.Combine(uploadFolderPath, DateTime.Now.ToString(WebConfigurationManager.AppSettings["DateFormat"].ToString(), CultureInfo.InvariantCulture));
                }
            }
        }
    }
}
