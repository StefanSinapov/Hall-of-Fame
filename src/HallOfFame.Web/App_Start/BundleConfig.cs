namespace HallOfFame.Web
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/kendo/2014.2.716/kendo.web.min.js",
                        "~/Scripts/kendo/2014.2.716/cultures/kendo.culture.en-GB.min.js",
                        "~/Scripts/kendo/2014.2.716/cultures/kendo.culture.bg-BG.min.js",
                        "~/Scripts/kendo/2014.2.716/kendo.aspnetmvc.js"));

           /* bundles.Add(new StyleBundle("~/Content/KendoUI/kendo").Include(
                      "~/Content/KendoUI/kendo.common.min.css",
                      "~/Content/KendoUI/kendo.metro.min.css"));*/

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/kendo/2014.2.716/kendo.common.min.css",
                      "~/Content/kendo/2014.2.716/kendo.metro.min.css",
                      "~/Content/bootstrap-theme.min.css",
                      "~/Content/font-awesome.css",
                      "~/Content/site.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
