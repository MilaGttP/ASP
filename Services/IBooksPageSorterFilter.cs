using ASP.Models;

namespace ASP.Services
{
    public interface IBooksPageSorterFilter
    {
        Task<IQueryable<BooksNew>> FilteringResult(string nameFilter, string SearchString, IQueryable<BooksNew> books);
    }
}