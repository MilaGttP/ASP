
using System.Text;
using UAParser;

namespace ASP
{
    public class GetBrowserMiddleware
    {
        private readonly RequestDelegate _next;
        public GetBrowserMiddleware(RequestDelegate next) =>  _next = next;

        public async Task InvokeAsync(HttpContext context, IEnumerable<IGetBrowser> getBrowsers)
        {
            var browserName = GetBrowserName(context);

            if (!string.IsNullOrEmpty(browserName))
            {
                StringBuilder result = new StringBuilder();
                result.AppendLine("VISITING\n");

                foreach (var browser in getBrowsers)
                {
                    bool hasFavicon = HasFavicon(context);
                    result.AppendLine(browser.GetBrowser(browserName, hasFavicon));
                }
                await context.Response.WriteAsync(result.ToString());
            }
        }

        private string GetBrowserName(HttpContext context)
        {
            string userAgentString = context.Request.Headers["User-Agent"];
            var uaParser = Parser.GetDefault();
            return uaParser.Parse(userAgentString).UA.Family;
        }

        private bool HasFavicon(HttpContext context)
        {
            string favicon = "/favicon.ico";
            return context.Request.Path.Equals(favicon, StringComparison.OrdinalIgnoreCase);
        }
    }
}
