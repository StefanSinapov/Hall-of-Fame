namespace HallOfFame.Web.Areas.Administration.Controllers.Base
{
    using System.Web.Mvc;

    using HallOfFame.Common.Constants;
    using HallOfFame.Data.Contracts;
    using HallOfFame.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
        public AdministrationController(IHallOfFameData data)
            : base(data)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Data.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}