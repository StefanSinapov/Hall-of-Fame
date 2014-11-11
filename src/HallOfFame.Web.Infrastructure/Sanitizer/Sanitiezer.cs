namespace HallOfFame.Web.Infrastructure.Sanitizer
{
    using Html;

    public class Sanitiezer : ISanitizer
    {
        public string Sanitize(string html)
        {
            var sanitizer = new HtmlSanitizer();
            var result = sanitizer.Sanitize(html);
            return result;
        }
    }
}