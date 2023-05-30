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
        public IActionResult Edit(int id)
        {
            Genre genre =_context.Genres.Find(id);
            return View(genre);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Genre genre)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            Genre ExistGenre=_context.Genres.Find(genre.Id);
            if(ExistGenre==null)
            {
                return View("Error");
            }
            if (genre.Name != ExistGenre.Name && _context.Genres.Any(x => x.Name == genre.Name))
            {
                ModelState.AddModelError("Name", "Bu adda kullanici var");
                return View();
            }
            ExistGenre.Name= genre.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Genre genre=_context.Genres.Include(x=>x.Books).SingleOrDefault(x=>x.Id==id);
            if(genre==null)
            {
                return View("Error");
            }
            return View (genre);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Genre genre)
        {
            Genre ExistGenre = _context.Genres.Find(genre.Id);
            if(ExistGenre==null)
            {
                return View("Error");
            }
            _context.Genres.Remove(ExistGenre);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
