namespace HallOfFame.Web.Areas.Projects.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Projects.ViewModels;

    using Kendo.Mvc.UI;

    using Microsoft.AspNet.Identity;

    public class LikesController : Controller
    {
        private readonly IDeletableEntityRepository<Project> projects;

        private IDeletableEntityRepository<Like> likes;

        public LikesController(IDeletableEntityRepository<Project> projects, IDeletableEntityRepository<Like> likes )
        {
            this.projects = projects;
            this.likes = likes;
        }

        [HttpGet]
        public ActionResult GetLikes(int id)
        {
            var userId = this.User.Identity.GetUserId();
            var userLike = this.likes.All()
                        .Where(u => u.UserId == userId && u.ProjectId == id)
                        .AsQueryable()
                        .Project()
                        .To<LikeViewModel>().FirstOrDefault();

            if (userLike == null)
            {
                userLike = new LikeViewModel { ProjectId = id, UserId = userId, Value = false };
            }
            else
            {
                userLike.Value = true;
            }

            return this.PartialView("_LikePartial", userLike);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Like(LikeViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                model.Value = true;

                var like = this.likes.AllWithDeleted().FirstOrDefault(l => l.UserId == model.UserId && l.ProjectId == model.ProjectId);

                if (like != null)
                {
                    like.IsDeleted = false;
                    like.DeletedOn = null;
                }
                else
                {
                    like = new Like { UserId = model.UserId, ProjectId = model.ProjectId, };
                    this.likes.Add(like);
                }

                this.likes.SaveChanges();

                return this.RedirectToAction("GetLikes");
            }

            return this.RedirectToAction("GetLikes");
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult UnLike(LikeViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                model.Value = false;
                var like = this.likes.All().First(l => l.UserId == model.UserId && l.ProjectId == model.ProjectId);

                this.likes.Delete(like);
                this.likes.SaveChanges();

                return this.RedirectToAction("GetLikes");
            }

            return this.RedirectToAction("GetLikes");
        }
    }
}