using Microsoft.EntityFrameworkCore;
using ASP.Models;


namespace ASP.Services
{
    public class BooksPageSorterFilter : IBooksPageSorterFilter
    {
        const string NameFilter ="Name";
        const string PublisherFilter = "Publisher";
       
        public async Task<IQueryable<BooksNew>> FilteringResult(string nameFilter, string SearchString, IQueryable<BooksNew> books)
        {
            if (!string.IsNullOrEmpty(SearchString) && await books.AnyAsync())
            {
                if (nameFilter.Equals(NameFilter))
                {
                    books = books.Where(s => s.Name.Contains(SearchString));
                }
                else if (nameFilter.Equals(PublisherFilter))
                {
                    books = books.Where(s => s.Izd.Izd.Contains(SearchString));
                }
            }
            return books;
        }
    }
}
