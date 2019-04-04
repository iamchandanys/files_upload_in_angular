using FileUploadFrameworkAPI.Helper;
using FileUploadFrameworkAPI.Models;
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
        public IHttpActionResult UploadFilesToLocalFolder()
        {
            FileStatusModel fileStatusModel = new FileStatusModel();

            try
            {
                var httpRequest = HttpContext.Current.Request;

                foreach (string fileTagName in httpRequest.Files)
                {
                    HttpPostedFileBase filebase = new HttpPostedFileWrapper(HttpContext.Current.Request.Files[fileTagName]);

                    fileStatusModel = UploadFileHelper.ToLocalFolderHelper(filebase);
                }

                return Ok(fileStatusModel);
            }
            catch (Exception ex)
            {
                return Ok(fileStatusModel);
            }
        }
    }
}
