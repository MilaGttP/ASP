
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP
{
    public class LanguageFilter : Attribute, IActionFilter
    {
        private string GetLanguage(string acceptLanguageHeader)
        {
            var languageItems = acceptLanguageHeader.Split(',')
           .Select(item => item.Trim().Split(';'))
           .Select(item => new
           {
               LanguageCode = item[0],
               Priority = item.Length > 1 ? double.TryParse(item[1].Split('=')[1], out var priority) ? priority : 1.0 : 1.0
           })
           .OrderByDescending(item => item.Priority);

            if (languageItems.Any())
            {
                return languageItems.First().LanguageCode;
            }

            return null;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.TryGetValue("Accept-Language", out var acceptLanguageHeader))
            {
                string language = GetLanguage(acceptLanguageHeader);

                switch (language)
                {
                    case "uk": 
                        context.HttpContext.Response.Headers.Add("Langs", "Ukr");
                        break;

                    case "ru":
                        context.HttpContext.Response.Headers.Add("Langs", "Ukrainian");
                        break;

                    default:
                        context.HttpContext.Response.Headers.Add("Langs", "Eng");
                        break;
                }
            }
            else
            {
                throw new ArgumentException("Accept-Language not found!");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
