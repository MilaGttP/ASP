using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.Models;
using ASP.Data;

namespace ASP.Controllers
{
	public class HomeController : Controller
    {
        private readonly BooksContext _context;

        public HomeController(BooksContext context)
        {
            _context = context;
        }

        private async Task<PaginatedList<BooksNew>> PrepareData(
                string sortOrder,
                string SearchString,
                int? pageNumber,
                int? RecordsPerPage)
        {
            if (sortOrder == null) sortOrder = "name_asc";
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewData["IzdSortParam"] = sortOrder == "firstname_asc" ? "firstname_desc" : "firstname_asc";
            ViewData["CategorySortParam"] = sortOrder == "date_asc" ? "date_desc" : "date_asc";

            int pageSize;
            if (RecordsPerPage == null && TempData.Peek("RecordsPerPage") == null)
            {
                pageSize = 3;
                TempData["RecordsPerPage"] = pageSize;
            }
            else if (RecordsPerPage != null)
            {
                pageSize = (int)RecordsPerPage;
                TempData["RecordsPerPage"] = pageSize;
            }
            else int.TryParse(TempData.Peek("RecordsPerPage")?.ToString(), out pageSize);


            ViewData["CurrentFilter"] = SearchString;

            var students = from s in _context.BooksNews
                           select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                students = students.Where(s => s.Name.Contains(SearchString)
                                       || s.Izd.Izd.Contains(SearchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Name);
                    break;
                case "firstname_desc":
                    students = students.OrderByDescending(s => s.Izd.Izd);
                    break;
                case "name_asc":
                    students = students.OrderBy(s => s.Name);
                    break;
                case "firstname_asc":
                    students = students.OrderBy(s => s.Izd.Izd);
                    break;
                case "date_asc":
                    students = students.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.Date);
                    break;
                default:
                    students = students.OrderBy(s => s.Name);
                    break;
            }

            return await PaginatedList<BooksNew>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize);
        }

        // GET: Home
        public async Task<IActionResult> Index(
             string sortOrder,
             string SearchString,
             int? pageNumber,
             int? RecordsPerPage)
        {
            return View(await PrepareData(sortOrder, SearchString, pageNumber, RecordsPerPage));
        }

        // GET: Home
        public async Task<IActionResult> Indexdata(
            string sortOrder,
            string SearchString,
            int? pageNumber,
            int? RecordsPerPage)
        {
            return PartialView(await PrepareData(sortOrder, SearchString, pageNumber, RecordsPerPage));
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BooksNews == null)
            {
                return NotFound();
            }

            var booksNew = await _context.BooksNews
                .Include(b => b.Format)
                .Include(b => b.Izd)
                .Include(b => b.Kategory)
                .Include(b => b.Themes)
                .FirstOrDefaultAsync(m => m.N == id);
            if (booksNew == null)
            {
                return NotFound();
            }

            return View(booksNew);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            ViewData["FormatId"] = new SelectList(_context.SprFormats, "Id", "Format");
            ViewData["IzdId"] = new SelectList(_context.SprIzds, "Id", "Izd");
            ViewData["KategoryId"] = new SelectList(_context.SprKategories, "Id", "Category");
            ViewData["ThemesId"] = new SelectList(_context.SprThemes, "Id", "Themes");
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("N,Code,New,Name,Price,Pages,Date,Pressrun,IzdId,FormatId,ThemesId,KategoryId")] BooksNew booksNew)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booksNew);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormatId"] = new SelectList(_context.SprFormats, "Id", "Format", booksNew.FormatId);
            ViewData["IzdId"] = new SelectList(_context.SprIzds, "Id", "Izd", booksNew.IzdId);
            ViewData["KategoryId"] = new SelectList(_context.SprKategories, "Id", "Category", booksNew.KategoryId);
            ViewData["ThemesId"] = new SelectList(_context.SprThemes, "Id", "Themes", booksNew.ThemesId);
            return View(booksNew);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BooksNews == null)
            {
                return NotFound();
            }

            var booksNew = await _context.BooksNews.FindAsync(id);
            if (booksNew == null)
            {
                return NotFound();
            }
            ViewData["FormatId"] = new SelectList(_context.SprFormats, "Id", "Format", booksNew.FormatId);
            ViewData["IzdId"] = new SelectList(_context.SprIzds, "Id", "Izd", booksNew.IzdId);
            ViewData["KategoryId"] = new SelectList(_context.SprKategories, "Id", "Category", booksNew.KategoryId);
            ViewData["ThemesId"] = new SelectList(_context.SprThemes, "Id", "Themes", booksNew.ThemesId);
            return View(booksNew);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("N,Code,New,Name,Price,Pages,Date,Pressrun,IzdId,FormatId,ThemesId,KategoryId")] BooksNew booksNew)
        {
            if (id != booksNew.N)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booksNew);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksNewExists(booksNew.N))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormatId"] = new SelectList(_context.SprFormats, "Id", "Format", booksNew.FormatId);
            ViewData["IzdId"] = new SelectList(_context.SprIzds, "Id", "Izd", booksNew.IzdId);
            ViewData["KategoryId"] = new SelectList(_context.SprKategories, "Id", "Category", booksNew.KategoryId);
            ViewData["ThemesId"] = new SelectList(_context.SprThemes, "Id", "Themes", booksNew.ThemesId);
            return View(booksNew);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BooksNews == null)
            {
                return NotFound();
            }

            var booksNew = await _context.BooksNews
                .Include(b => b.Format)
                .Include(b => b.Izd)
                .Include(b => b.Kategory)
                .Include(b => b.Themes)
                .FirstOrDefaultAsync(m => m.N == id);
            if (booksNew == null)
            {
                return NotFound();
            }

            return View(booksNew);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BooksNews == null)
            {
                return Problem("Entity set 'BooksContext.BooksNews'  is null.");
            }
            var booksNew = await _context.BooksNews.FindAsync(id);
            if (booksNew != null)
            {
                _context.BooksNews.Remove(booksNew);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksNewExists(int id)
        {
          return (_context.BooksNews?.Any(e => e.N == id)).GetValueOrDefault();
        }
    }
}
