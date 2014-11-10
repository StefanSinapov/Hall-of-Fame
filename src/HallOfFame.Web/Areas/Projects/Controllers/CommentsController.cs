namespace HallOfFame.Web.Areas.Projects.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Filters;
    using HallOfFame.Web.Infrastructure.Identity;
    using HallOfFame.Web.ViewModels.Comments;

    public class CommentsController : Controller
    {
        protected readonly IRepository<Comment> Comments;
        protected readonly ICurrentUser CurrentUser;
     
        private const int MinutesBetweenComments = 1;

        public CommentsController(IRepository<Comment> commentsRepository, ICurrentUser user)
        {
            this.Comments = commentsRepository;
            this.CurrentUser = user;
        }

        public ActionResult All(int id, int maxComments = 999, int startFrom = 0)
        {
            var comments = this.Comments
                .All()
                .Where(c => !c.IsDeleted)
                .OrderByDescending(c => c.CreatedOn)
                .Skip(startFrom)
                .Take(maxComments)
                .Project()
                .To<CommentViewModel>();

            return this.PartialView(comments);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, CommentViewModel comment)
        {
            if (this.CurrentUserCommentedInLastMinutes())
            {
                // return this.JsonError(string.Format("You can comment every {0} minute", MinutesBetweenComments));
            }

            if (ModelState.IsValid)
            {
                var newComment = new Comment
                {
                    Content = comment.Content,
                    ProjectId = id,
                    Author = this.CurrentUser.Get()
                };

                this.Comments.Add(newComment);
                this.Comments.SaveChanges();

                comment.UserName = this.CurrentUser.Get().UserName;
                comment.CommentedOn = DateTime.Now;

                return this.PartialView("_CommentDetail", comment);
            }
            else
            {
                return this.Redirect("/");

                // TODO: Fix this
                /*return this.JsonError("Content is required");*/
            }
        }

        private bool CurrentUserCommentedInLastMinutes()
        {
            var lastComment = this.CurrentUser.Get()
                .Comments
                .OrderByDescending(c => c.CreatedOn)
                .FirstOrDefault();

            if (lastComment == null)
            {
                return false;
            }

            return lastComment.CreatedOn.AddMinutes(MinutesBetweenComments) >= DateTime.Now;
        }
    }
}