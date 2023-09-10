using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP.Services;
using ASP.Models;

namespace ASP.Pages
{
    public class EditModel : PageModel
    {
        private readonly IDatabaseHandlerRepository _repository;

        public EditModel(IDatabaseHandlerRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public BooksNew BooksNew { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booksnew =  await _repository.GetBookById(id);
            if (booksnew == null)
            {
                return NotFound();
            }
            BooksNew = booksnew;

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.EditBook(id,BooksNew);

            return RedirectToPage("./Index");
        }
    }
}
