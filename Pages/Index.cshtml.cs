using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using ASP.Services;
using ASP.Models;


namespace ASP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDatabaseHandlerRepository _repository;
        [BindProperty(SupportsGet = true)]
        public List<string>? FiltersList { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; } = default;
        [BindProperty(SupportsGet = true)]
        public string? FilterValue { get; set; } = default;
        public IndexModel(IDatabaseHandlerRepository repository)
        {
           _repository = repository;
        }
        [BindProperty]
        public IList<BooksNew> BooksNew { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            FiltersList = new List<string>() { "None", "Name", "Publisher" };
            var books=await _repository.GetBooksNewsList(FilterValue, SearchString);
            BooksNew= books.ToList();
            return Page();
        }
        public async Task<JsonResult> OnPostAsync()
        {
            FiltersList = new List<string>() { "None", "Name", "Publisher" };
            var books = await _repository.GetBooksNewsList(FilterValue, SearchString);
            return new JsonResult(books.ToList());
        }

    }
}
