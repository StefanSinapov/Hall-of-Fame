namespace HallOfFame.Web
{
    using System.Web.Mvc;

    public class ViewEnginesConfig
    {
        public static void RegisterEngines(ViewEngineCollection engines)
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}