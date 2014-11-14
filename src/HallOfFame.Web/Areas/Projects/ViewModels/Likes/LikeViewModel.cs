namespace HallOfFame.Web.Areas.Projects.ViewModels.Likes
{
    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;

    public class LikeViewModel : IMapFrom<Like>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int ProjectId { get; set; }

        public bool Value { get; set; }
    }
}