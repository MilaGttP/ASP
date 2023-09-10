using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP.Services;
using ASP.Models;

namespace ASP.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IDatabaseHandlerRepository _repository;

        public CreateModel(IDatabaseHandlerRepository repository)
        {
            _repository = repository;
        }

        public async Task <IActionResult> OnGet()
        {
            var listFormats = await _repository.GetFormatsList();
            var listIzds = await _repository.GetIzdList();
            var listCategories = await _repository.GetCategoriesList();
            var listThemes = await _repository.GetThemesList();

            ViewData["FormatId"] = new SelectList(listFormats, "Id", "Format");
            ViewData["IzdId"] = new SelectList(listIzds, "Id", "Izd");
            ViewData["KategoryId"] = new SelectList(listCategories, "Id", "Category");
            ViewData["ThemesId"] = new SelectList(listThemes, "Id", "Themes");
            return Page();
        }

        [BindProperty]
        public BooksNew BooksNew { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid ||BooksNew == null)
            {
                return Page();
            }
            await _repository.CreateBookNew(BooksNew);

            return RedirectToPage("./Index");
        }
    }
}
