using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.Models;

namespace ASP.Controllers
{
	public class HomeController : Controller
    {
        private readonly BooksContext _context;

        public HomeController(BooksContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            var booksContext = _context.BooksNews.Include(b => b.Format).Include(b => b.Izd).Include(b => b.Kategory).Include(b => b.Themes);
            return View(await booksContext.ToListAsync());
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
