namespace HallOfFame.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.ViewModels.Feedback;

    public class FeedbackController : BaseController
    {
        public FeedbackController(IHallOfFameData data)
            : base(data)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FeedbackViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}