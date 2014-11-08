namespace HallOfFame.Web.Controllers
{
    using System.Web.Mvc;

    using HallOfFame.Common.Constants;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : Controller // : BaseController
    {
        /*   public AdministrationController(IHallOfFameData data)
               : base(data)
           {
           }*/
    }
}