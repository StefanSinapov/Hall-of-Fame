namespace HallOfFame.Web.ViewModels.Statistics
{
    using System.Collections.Generic;

    using HallOfFame.Web.Areas.Projects.ViewModels;
    using HallOfFame.Web.ViewModels.Shared;

    public class StatisticViewModel
    {
        public IList<UserInfoViewModel> Users { get; set; }

        public IList<ProjectInfoViewModel> Projects { get; set; }

        public IList<ProjectInfoViewModel> MostCommented { get; set; }
    }
}