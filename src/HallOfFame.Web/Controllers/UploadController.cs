namespace HallOfFame.Web.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;

    using HallOfFame.Common.Constants;
    using HallOfFame.ImageUpload;

    using Microsoft.AspNet.Identity;

    using Telerik.Everlive.Sdk.Core;

    public class UploadController : Controller
    {
        public ActionResult Save(IEnumerable<HttpPostedFileBase> files)
        {
            // The Name of the Upload component is "files"
            if (files != null)
            {
                foreach (var file in files)
                {
                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Path.GetFileName(file.FileName);
                    if (fileName != null)
                    {
                        var extension = fileName.Substring(fileName.LastIndexOf('.'));

                        // Save locally
                        /* fileName = Guid.NewGuid() + extension;

                         var currentUsername = this.User.Identity.GetUserName();
                         var userFolderPath = Path.Combine(this.Server.MapPath("~/Content/UserFiles/Images/"), currentUsername);
                         if (!Directory.Exists(userFolderPath))
                         {
                             Directory.CreateDirectory(userFolderPath);
                         }
                         var physicalPath = Path.Combine(userFolderPath, fileName);
                        
                         file.SaveAs(physicalPath);
                         return this.Json(new { ImageName = fileName }, "text/plain");
                         */

                        // Telerik Back-end
                        var uploader = new ImageUploader(new EverliveApp(ApiKeys.EverliveAppKey));
                        var url = uploader.UrlFromStream(file.InputStream, "Image/" + extension.Substring(1));
                        return this.Json(new { ImageName = url }, "text/plain");
                    }
                }
            }

            // Return an empty string to signify success
            return this.Content(string.Empty);
        }

        public ActionResult Remove(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"
            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    if (fileName != null)
                    {
                        var currentUsername = this.User.Identity.GetUserName();
                        var physicalPath = Path.Combine(this.Server.MapPath("~/Content/UserFiles/Images/" + currentUsername), fileName);

                        if (System.IO.File.Exists(physicalPath))
                        {
                            // The files are not actually removed in this demo
                            System.IO.File.Delete(physicalPath);
                        }
                    }
                }
            }

            // Return an empty string to signify success
            return this.Content(string.Empty);
        } 
    }
}