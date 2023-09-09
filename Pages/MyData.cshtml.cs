using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace ASP.Pages
{
	public enum Gender
	{
		������,
		Ƴ���
	}
	public class MyDataModel : PageModel
    {
		[BindProperty]
		[DisplayName("��'�")]
		public string Name { get; set; }

		[BindProperty]
		[DisplayName("�������")]
		public string Surname { get; set; }

		[BindProperty]
		[DisplayName("�� �������")]
		public string MiddleName { get; set; }

		[BindProperty]
		[DisplayName("�����")]
		public Gender Gender { get; set; }

		[BindProperty]
		[DisplayName("̳���")]
		public string City { get; set; }

		[BindProperty]
		[DisplayName("���")]
		public string[] Hobbies { get; set; }

		[BindProperty]
		[DisplayName("���� ����������")]
		public DateOnly Birthday { get; set; }

		public MyDataModel()
		{
			Name = "";
			Surname = "";
			MiddleName = "";
			Gender = Gender.������;
			City = "";
			Hobbies = new string[0];
			Birthday = new DateOnly();
		}

		public void OnGet()
        {
			var cities = new string[] { "����", "���", "³�����" };
			var hobbies = new string[] { "�������", "��������", "�������������" };

			ViewData["Cities"] = cities.Select(city => new SelectListItem { Text = city, Value = city });
			ViewData["Hobbies"] = hobbies.Select(hobby => new SelectListItem { Text = hobby, Value = hobby });
		}

		public IActionResult OnPost()
		{
			return RedirectToPage("MyDataView");
		}

	}
}
