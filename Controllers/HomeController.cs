using ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ASP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult MyData()
        {
            ViewBag.Cities = new string[] { "Львів", "Київ", "Вінниця" };
            ViewBag.Hobbies = new string[] { "Читання", "Плавання", "Програмування" };

            return View();
        }

        [HttpPost]
        public IActionResult _DataPartial(Person model)
        {
            return View("_DataPartial", model);
        }
    }
}
