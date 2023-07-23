
using Microsoft.AspNetCore.Mvc;

namespace ASP
{
    [LanguageFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string langs = Response.Headers["Langs"];

            switch (langs)
            {
                case "Ukr":
                    return Content("Привіт, світе!");

                case "Ukrainian":
                    return Content("Привіт, світе!");

                default:
                    return Content("Hello, world!");
            }
        }
    }
}
