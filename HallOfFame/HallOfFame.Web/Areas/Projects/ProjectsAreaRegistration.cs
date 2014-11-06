namespace HallOfFame.Web.Areas.Projects
{
    using System.Web.Mvc;

    public class ProjectsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Projects";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Projects_default",
                "Projects/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });

            /* context.MapRoute(
                "Projects_current_user_profile",
                "Projects/Details/{action}",
                new { controller = "Details", action = GlobalConstants.Index, id = UrlParameter.Optional });

            context.MapRoute(
                "Projects_settings",
                "Projects/Settings/{action}",
                new { controller = "Settings", action = GlobalConstants.Index, id = UrlParameter.Optional });

            context.MapRoute(
                "Users_details",
                "Projects/{name}",
                new { controller = "Details", action = GlobalConstants.Index, id = UrlParameter.Optional });*/
        }
    }
}