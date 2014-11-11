namespace HallOfFame.Web.Areas.Projects
{
    using System.Web.Mvc;

    using HallOfFame.Web.Common;

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
                "Projects/Create/{action}",
                new { controller = "Create", action = "Index", id = UrlParameter.Optional });

            context.MapRoute(
                "Projects_Details_Comments",
                "Projects/{id}/Comments/{action}",
                new { controller = "Comments", id = UrlParameter.Optional });

            context.MapRoute(
                "Projects_Details",
                "Projects/{name}/{controller}/{action}",
                new { controller = "Details", action = ControllerNames.Index, name = UrlParameter.Optional });

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