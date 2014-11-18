namespace HallOfFame.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Areas.Projects.ViewModels;
    using HallOfFame.Web.ViewModels.Shared;
    using HallOfFame.Web.ViewModels.Statistics;

    public class StatisticsController : BaseController
    {
        private const int DefaultStatisticSize = 5;

        public StatisticsController(IHallOfFameData data)
            : base(data)
        {
        }

        [HttpGet]
        [ChildActionOnly]
        [OutputCache(Duration = 1 * 60 * 5)]
        public ActionResult GetStatistics()
        {
            var viewModel = new StatisticViewModel
                                {
                                    Projects =
                                        this.Data.Likes.All()
                                        .GroupBy(l => l.Project)
                                        .OrderByDescending(l => l.Count())
                                        .Take(DefaultStatisticSize)
                                        .Select(l => l.Key)
                                        .Project()
                                        .To<ProjectInfoViewModel>()
                                        .ToList(),
                                    Users =
                                        this.Data.Likes.All()
                                        .GroupBy(l => l.Project)
                                        .Select(group => new { Project = @group.Key, Likes = @group.ToList() })
                                        .SelectMany(p => p.Project.Team)
                                        .GroupBy(p => p)
                                        .OrderByDescending(p => p.Count())
                                        .Take(DefaultStatisticSize)
                                        .Select(l => l.Key)
                                        .Project()
                                        .To<UserInfoViewModel>()
                                        .ToList(),
                                    MostCommented =
                                        this.Data.Comments.All()
                                        .GroupBy(c => c.Project)
                                        .OrderByDescending(l => l.Count())
                                        .Take(DefaultStatisticSize)
                                        .Select(l => l.Key)
                                        .Project()
                                        .To<ProjectInfoViewModel>()
                                        .ToList()
                                };

            return this.PartialView("_StatisticsPartial", viewModel);
        }
    }
}