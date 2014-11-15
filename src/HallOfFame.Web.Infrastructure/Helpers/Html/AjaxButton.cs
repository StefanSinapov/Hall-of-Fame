namespace HallOfFame.Web.Infrastructure.Helpers.Html
{
    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;

    public static class AjaxButton
    {
        public static MvcHtmlString RawActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var repId = Guid.NewGuid().ToString();
            var lnk = ajaxHelper.ActionLink(repId, actionName, controllerName, routeValues, ajaxOptions, htmlAttributes);
            return MvcHtmlString.Create(lnk.ToString().Replace(repId, linkText));
        }
    }
}