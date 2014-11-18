namespace HallOfFame.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using HallOfFame.Data.Contracts;
    using HallOfFame.Models;
    using HallOfFame.Web.ViewModels.Shared;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public class MessagesController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}