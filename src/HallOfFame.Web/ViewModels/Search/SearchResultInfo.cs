namespace HallOfFame.Web.ViewModels.Search
{
    using System.ComponentModel.DataAnnotations;

    public class SearchResultInfo
    {
        [Display(Name = "Search")]
        public string Query { get; set; }

        public int ProjectsCount { get; set; }

        public int CoursesCount { get; set; }

        public int UsersCount { get; set; }

        public int Page { get; set; }
    }
}