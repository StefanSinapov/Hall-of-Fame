namespace HallOfFame.Web.ViewModels.Shared
{
    using HallOfFame.Models;
    using HallOfFame.Web.Infrastructure.Mapping;

    public class LikeViewModel : IMapFrom<Like>
    {
        public string UserId { get; set; }

        public int ProjectId { get; set; }
    }
}