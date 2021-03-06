﻿namespace HallOfFame.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Models;
    using HallOfFame.Web.Areas.Projects.ViewModels;
    using HallOfFame.Web.ViewModels.Search;
    using HallOfFame.Web.ViewModels.Shared;

    public class SearchController : BaseController
    {
        public SearchController(IHallOfFameData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index(string q, int page = 1)
        {
            var result = new SearchResultInfo
                             {
                                 Query = q,
                                 Page = page,
                                 ProjectsCount =
                                     this.Data.Projects.All()
                                     .Count(SearchProjectsExpression(q)),
                                 CoursesCount =
                                     this.Data.Courses.All()
                                     .Count(SearchCoursesExpression(q)),
                                 UsersCount =
                                     this.Data.Users.All()
                                     .Count(SearchUsersExpression(q))
                             };

            return this.View(result);
        }

        [HttpGet]
        public ActionResult Users(string q = "", int page = 1)
        {
            var result =
                this.Data.Users.All()
                    .Where(SearchUsersExpression(q))
                    .Project()
                    .To<UserInfoViewModel>().ToList();

            return this.PartialView("_UsersSearchPartial", result);
        }

        [HttpGet]
        public ActionResult Projects(string q = "", int page = 1)
        {
            var result =
                this.Data.Projects.All()
                    .Where(SearchProjectsExpression(q))
                    .Project()
                    .To<ProjectInfoViewModel>()
                    .ToList();
            return this.PartialView("_ProjectsSearchPartial", result);
        }

        [HttpGet]
        public ActionResult Courses(string q = "", int page = 1)
        {
            var result = this.Data
                .Courses
                .All()
                .Where(SearchCoursesExpression(q))
                .Project()
                .To<CourseViewModel>()
                .ToList();

            return this.PartialView("_CoursesSearchPartial", result);
        }

        private static Expression<Func<Project, bool>> SearchProjectsExpression(string q)
        {
            return p => p.Name.Contains(q) || p.Title.Contains(q)
                || p.TeamName.Contains(q) || p.Course.Name.Contains(q);
        }

        private static Expression<Func<User, bool>> SearchUsersExpression(string q)
        {
            return u => u.UserName.Contains(q) || u.FirstName.Contains(q)
                   || u.LastName.Contains(q) || u.TelerikAcademyProfile.Contains(q)
                   || u.Email.Contains(q);
        }

        private static Expression<Func<Course, bool>> SearchCoursesExpression(string q)
        {
            return c => c.Name.Contains(q) || c.Description.Contains(q)
                   || c.Category.Name.Contains(q);
        }
    }
}