using FileUploadFrameworkAPI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace FileUploadFrameworkAPI.Helper
{
    public class UploadFileHelper
    {
        public static FileStatusModel ToLocalFolderHelper(HttpPostedFileBase fileBase)
        {
            var sizeConversion = (fileBase.ContentLength / 1024f) / 1024f;
            string directoryPath = string.Empty;
            string sourcePath = string.Empty;

            FileStatusModel fsm = new FileStatusModel()
            {
                FileName = fileBase.FileName,
                FileSize = sizeConversion + " Mb",
            };

            try
            {
                var uploadFolderPath = WebConfigurationManager.AppSettings["UploadFolderPath"].ToString();

                string fileExtension = Path.GetExtension(fileBase.FileName).ToLower().Trim();

                if (!string.IsNullOrEmpty(uploadFolderPath) && !string.IsNullOrEmpty(fileExtension))
                {
                    directoryPath = Path.Combine(uploadFolderPath, DateTime.Now.ToString(WebConfigurationManager.AppSettings["DateFormat"].ToString(), CultureInfo.InvariantCulture));

                    if (fileBase.ContentLength > 2000000)
                    {
                        if (fileExtension == ".img" || fileExtension == ".pdf" || fileExtension == ".xlsx")
                        {
                            sourcePath = directoryPath + "\\" + fileBase.FileName;

                            if (sourcePath.Length < 260)
                            {
                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }

                                fileBase.SaveAs(sourcePath);

                                fsm.SourcePath = sourcePath;
                                fsm.StatusMessage = "Uploaded Successfully!";
                            }
                            else
                            {
                                fsm.StatusMessage = "The specified file path is too long. The fully qualified file path must be less than 260 characters.";
                            }
                        }
                        else
                        {
                            fsm.StatusMessage = "Only Image, PDF and Excel files are allowed.";
                        }
                    }
                    else
                    {
                        fsm.StatusMessage = "Only 2Mb files are allowed.";
                    }
                }
                else
                {
                    fsm.StatusMessage = "Invalid File.";
                }
            }
            catch (Exception ex)
            {
                fsm.StatusMessage = ex.Message;
            }

            return fsm;
        }
    }
}