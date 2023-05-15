using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartialviewPage.DAL;
using PartialviewPage.Models;
using PartialviewPage.ViewModels;

namespace PartialviewPage.Areas.Manage.Controllers
{
    [Area("manage")]
    public class GenreController : Controller
    {
        private readonly DataContext _context;
        public GenreController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1, string search = null)
        {
            var searcing = _context.Genres.AsQueryable();
            if (search != null)
            {
                searcing = searcing.Where(x => x.Name.Contains(search));
            }

            ViewBag.Search = search;
            return View(PaginatedList<Genre>.Create(searcing, page, 3));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
