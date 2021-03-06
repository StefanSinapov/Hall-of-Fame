﻿namespace HallOfFame.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, },
                namespaces: new[] { "HallOfFame.Web.Controllers" });

            routes.MapRoute(
                name: "Custom_Route",
                url: "{controller}/{id}/{action}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, },
                namespaces: new[] { "HallOfFame.Web.Controllers" });
        }
    }
}
