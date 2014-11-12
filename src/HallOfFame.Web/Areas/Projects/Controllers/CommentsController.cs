namespace HallOfFame.Web.Areas.Projects.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Models;
    using HallOfFame.Web.ViewModels.Comments;

    using Microsoft.AspNet.Identity;

    using Newtonsoft.Json;

    public class CommentsController : Controller
    {
        protected readonly IRepository<Comment> Comments;

        private const int MinutesBetweenComments = 1;

        public CommentsController(IRepository<Comment> commentsRepository, IRepository<User> users)
        {
            this.Users = users;
            this.Comments = commentsRepository;
        }

        public IRepository<User> Users { get; set; }

        public ActionResult All(int id, int maxComments = 999, int startFrom = 0)
        {
            var comments = this.Comments
                .All()
                .Where(c => c.ProjectId == id)
                .Where(c => !c.IsDeleted)
                .OrderByDescending(c => c.CreatedOn)
                .Skip(startFrom)
                .Take(maxComments)
                .Project()
                .To<CommentViewModel>();

            return this.PartialView(comments);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, CommentViewModel comment)
        {
            var userId = this.User.Identity.GetUserId();

            // TODO: fix anti-spam
            if (this.CurrentUserCommentedInLastMinutes(userId))
            {
                return this.Json(new { Error = string.Format("You can comment every {0} minute", MinutesBetweenComments) });
            }

            if (ModelState.IsValid)
            {
                var newComment = new Comment
                {
                    Content = comment.Content,
                    ProjectId = id,
                    AuthorId = userId
                };

                this.Comments.Add(newComment);
                this.Comments.SaveChanges();

                var user = this.Users.Find(userId);

                comment.UserName = user.UserName;
                comment.UserAvatar = user.AvatarUrl;
                comment.CreatedOn = DateTime.Now;

                ModelState.Clear();

                return this.PartialView("_CommentDetail", comment);
            }

            return this.Json(new { Error = string.Format("You can comment every {0} minute", MinutesBetweenComments) });
        }

        private bool CurrentUserCommentedInLastMinutes(string userId)
        {
            var lastComment = this
                .Comments
                .All()
                .Where(u => u.AuthorId == userId)
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