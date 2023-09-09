using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace ASP.Pages
{
	public enum Gender
	{
		Чоловік,
		Жінка
	}
	public class MyDataModel : PageModel
    {
		[BindProperty]
		[DisplayName("Ім'я")]
		public string Name { get; set; }

		[BindProperty]
		[DisplayName("Прізвище")]
		public string Surname { get; set; }

		[BindProperty]
		[DisplayName("По батькові")]
		public string MiddleName { get; set; }

		[BindProperty]
		[DisplayName("Стать")]
		public Gender Gender { get; set; }

		[BindProperty]
		[DisplayName("Місто")]
		public string City { get; set; }

		[BindProperty]
		[DisplayName("Хобі")]
		public string[] Hobbies { get; set; }

		[BindProperty]
		[DisplayName("День народження")]
		public DateOnly Birthday { get; set; }

		public MyDataModel()
		{
			Name = "";
			Surname = "";
			MiddleName = "";
			Gender = Gender.Чоловік;
			City = "";
			Hobbies = new string[0];
			Birthday = new DateOnly();
		}

		public void OnGet()
        {
			var cities = new string[] { "Львів", "Київ", "Вінниця" };
			var hobbies = new string[] { "Читання", "Плавання", "Програмування" };

			ViewData["Cities"] = cities.Select(city => new SelectListItem { Text = city, Value = city });
			ViewData["Hobbies"] = hobbies.Select(hobby => new SelectListItem { Text = hobby, Value = hobby });
		}

		public IActionResult OnPost()
		{
			return RedirectToPage("MyDataView");
		}

	}
}
