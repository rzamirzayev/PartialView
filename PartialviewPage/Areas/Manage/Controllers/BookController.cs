using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using PartialviewPage.DAL;
using PartialviewPage.Models;
using PartialviewPage.ViewModels;

namespace PartialviewPage.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BookController : Controller
    {
        private readonly DataContext _context;

        public BookController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1, string search = null)
        {
            var query = _context.Books
                .Include(x => x.Genre)
                .Include(x => x.Author).AsQueryable();

            if (search != null)
            {
                query = query.Where(x => x.Name.Contains(search));
            }

            ViewBag.Search = search;

            return View(PaginatedList<Book>.Create(query, page, 1));
        }
    }
}
