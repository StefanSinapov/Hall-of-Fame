namespace HallOfFame.Web.Controllers
{
    using System.Web.Mvc;

    using HallOfFame.Data.Contracts;

    public class MessagesController : BaseController
    {
        public MessagesController(IHallOfFameData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}