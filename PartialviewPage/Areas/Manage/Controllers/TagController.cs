using Microsoft.AspNetCore.Mvc;
using PartialviewPage.DAL;
using PartialviewPage.Models;
using PartialviewPage.ViewModels;

namespace PartialviewPage.Areas.Manage.Controllers
{
    [Area("manage")]
    public class TagController : Controller
    {
        private readonly DataContext _context;
        public TagController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1, string searching = null)
        {
            var question = _context.Tags.AsQueryable();

            if (searching != null)
            {
                question = question.Where(x => x.Name.Contains(searching));
            }

            ViewBag.Search = searching;
            return View(PaginatedList<Tag>.Create(question, page, 3));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tag tags)
        {
            _context.Tags.Add(tags);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
