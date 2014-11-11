namespace HallOfFame.Web.Controllers
{
    using System.Web.Mvc;

    using HallOfFame.Common.Constants;
    using HallOfFame.Data.Contracts;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
        public AdministrationController(IHallOfFameData data)
            : base(data)
        {
        }
    }
}