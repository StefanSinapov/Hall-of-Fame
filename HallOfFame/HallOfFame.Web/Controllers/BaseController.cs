namespace HallOfFame.Web.Controllers
{
    using System.Web.Mvc;

    using HallOfFame.Data.Contracts;

    public class BaseController : Controller
    {
        public BaseController(IHallOfFameData data)
        {
            this.Data = data;
        }

        public IHallOfFameData Data { get; set; }
    }
}