namespace HallOfFame.Web.Areas.Users
{
    using System.Web.Mvc;

    using HallOfFame.Common;

    public class UsersAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Users";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            /* context.MapRoute(
                 "Users_default",
                 "Users/{controller}/{action}/{id}",
                 new { action = "Index", id = UrlParameter.Optional });*/

            // TODO: uncomment this
            context.MapRoute(
               "Users_current_user_profile",
               "Users/Profile/Settings/{action}",
               new { controller = "Settings", action = GlobalConstants.Index, username = UrlParameter.Optional });
            /*
                        context.MapRoute(
                            "Users_settings",
                            "Users/Settings/{action}",
                            new { controller = "Settings", action = GlobalConstants.Index, username = UrlParameter.Optional });*/

            context.MapRoute(
                "Users_profile",
                "Users/{username}",
                new { controller = "Profile", action = GlobalConstants.Index, username = UrlParameter.Optional });
        }
    }
}