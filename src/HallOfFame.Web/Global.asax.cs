namespace HallOfFame.Web
{
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using HallOfFame.Web.Infrastructure.Mapping;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ViewEnginesConfig.RegisterEngines(ViewEngines.Engines);
            (new AutoMapperConfig(Assembly.GetExecutingAssembly())).Execute();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
