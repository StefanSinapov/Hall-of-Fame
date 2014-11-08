namespace HallOfFame.Web.Areas.Projects.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Common.Constants;
    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.ImageUpload;
    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Projects.ViewModels;
    using HallOfFame.Web.ViewModels.Shared;

    using Microsoft.AspNet.Identity;

    using Telerik.Everlive.Sdk.Core;

    [Authorize]
    public class CreateController : Controller
    {
        public CreateController(IRepository<Project> projects, IRepository<Course> courses)
        {
            this.Projects = projects;
            this.Courses = courses;
        }

        public IRepository<Course> Courses { get; set; }

        public IRepository<Project> Projects { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            var courses = this.GetCourses();
            this.ViewBag.Courses = courses;
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CreateProjectViewModel model)
        {
            // TODO: project model, to have collection of photos or collection<string> photoUrl or photoPath in disc
            if (this.ModelState.IsValid)
            {
                var project = new Project
                                  {
                                      Name = model.Name,
                                      CourseId = model.CourseId,
                                      Description = model.Description,
                                      TeamName = model.TeamName,
                                      Info = model.Info,
                                      FacebookLink = model.FacebookLink,
                                      GitHubLink = model.GitHubLink,
                                      GooglePlusLink = model.GooglePlusLink,
                                      PhotoUrl = model.PhotoUrl
                                  };

                this.Projects.Add(project);
                this.Projects.SaveChanges();

                // TODO: redirect to project view
                return this.RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            // this.ModelState.Clear();
            ViewBag.Courses = this.GetCourses();
            return this.View(model);
        }

        [HttpPost]
        public JsonResult DoesProjectNameExist(string name)
        {
            var project = this.Projects.All().Where(p => p.Name == name).Select(p => p.Name).FirstOrDefault();

            return this.Json(project == null);
        }

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

        private List<CourseViewModel> GetCourses()
        {
            return this.Courses.All().Project().To<CourseViewModel>().ToList();
        }
    }
}