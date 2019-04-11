using DataAccessLayer;
using FileUploadFrameworkAPI.Helper;
using FileUploadFrameworkAPI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

        [HttpGet]
        [Route("api/UploadFiles/DownloadFilesFromLocalFolder")]
        public HttpResponseMessage DownloadFilesFromLocalFolder([FromUri]string FilePath)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(FilePath))
                {
                    FileInfo file = new FileInfo(FilePath);

                    var stream = new FileStream(file.FullName, FileMode.Open);

                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StreamContent(stream);
                    if (file.Extension == ".xlsx")
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                    if (file.Extension == ".pdf")
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                    if (file.Extension == ".jpg" || file.Extension == ".jpeg")
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                    if (file.Extension == ".png")
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = file.Name
                    };
                    response.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

                    return response;
                }

                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route("api/UploadFiles/UploadFilesToDatabase")]
        public IHttpActionResult UploadFilesToDatabase()
        {
            FileStatusModel fileStatusModel = new FileStatusModel();

            try
            {
                var httpRequest = HttpContext.Current.Request;

                foreach (string fileTagName in httpRequest.Files)
                {
                    HttpPostedFileBase filebase = new HttpPostedFileWrapper(HttpContext.Current.Request.Files[fileTagName]);

                    fileStatusModel = UploadFileHelper.ToDatabaseHelper(filebase);
                }

                return Ok(fileStatusModel);
            }
            catch (Exception ex)
            {
                return Ok(fileStatusModel);
            }
        }

        [HttpGet]
        [Route("api/UploadFiles/DownloadFilesFromDatabase")]
        public HttpResponseMessage DownloadFilesFromDatabase([FromUri]Guid Id)
        {
            try
            {
                FilesUploadEntities fue = new FilesUploadEntities();
                var fileData = fue.Files.FirstOrDefault(e => e.Id == Id);

                if (fileData != null)
                {
                    string fileExtension = Path.GetExtension(fileData.FileName).ToLower().Trim();

                    MemoryStream ms = new MemoryStream(fileData.InputStream);

                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StreamContent(ms);
                    if (fileExtension == ".xlsx")
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                    if (fileExtension == ".pdf")
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                    if (fileExtension == ".jpg" || fileExtension == ".jpeg")
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                    if (fileExtension == ".png")
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = fileData.FileName
                    };
                    response.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

                    return response;
                }

                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
