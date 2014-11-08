namespace HallOfFame.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using HallOfFame.Web.ViewModels.Feedback;

    public class FeedbackController : Controller // BaseController
    {
       /* public FeedbackController(IHallOfFameData data)
            : base(data)
        {
        }*/

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FeedbackViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}