namespace HallOfFame.Web.Infrastructure.Sanitizer
{
    using Html;

    public class Sanitiezer : ISanitizer
    {
        public string Sanitize(string html)
        {
            var sanitizer = new HtmlSanitizer
                                {
                                    AllowedTags =
                                        new[]
                                            {
                                                "img", "del", "dd", "h3", "address", "big", "sub", "tt", "a",
                                                "ul", "h4", "cite", "dfn", "h5", "small", "kbd", "code", "b",
                                                "ins", "img", "h6", "sup", "pre", "strong", "blockquote",
                                                "acronym", "dt", "br", "p", "div", "samp", "li", "ol", "var",
                                                "em", "h1", "i", "abbr", "h2", "span", "hr"
                                            },
                                    AllowedAttributes =
                                        new[]
                                            {
                                                "name", "href", "cite", "class", "title", "src", "xml:lang", 
                                                "height","datetime", "alt", "abbr", "width", "style"
                                            }
                                };
            var result = sanitizer.Sanitize(html);
            return result;
        }
    }
}