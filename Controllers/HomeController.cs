using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ASP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult MyData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MyDataView()
        {
            ViewBag.LastName = HttpContext.Request.Form["surname"];
            ViewBag.FirstName = HttpContext.Request.Form["name"];
            ViewBag.MiddleName = HttpContext.Request.Form["middleName"];
            ViewBag.Gender = HttpContext.Request.Form["gender"];
            ViewBag.City = HttpContext.Request.Form["city"];
            ViewBag.Hobbies = HttpContext.Request.Form["hobbies"];
            ViewBag.BirthDate = DateTime.Parse(HttpContext.Request.Form["birthDate"]);

            return View();
        }
    }
}
