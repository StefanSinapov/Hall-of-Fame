namespace HallOfFame.Web.Controllers
{
    using System.Web.Mvc;

    using HallOfFame.Data.Contracts;

    public class BaseController : Controller
    {
        public BaseController(IHallOfFameData provider)
        {
            this.Data = provider;
        }

        public IHallOfFameData Data { get; set; }
    }
}