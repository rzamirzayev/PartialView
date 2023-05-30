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
        public IActionResult Edit (int id)
        {
            Tag tag=_context.Tags.Find(id);
            return View(tag);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tag tag)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            Tag ExistTag=_context.Tags.Find(tag.Id);
            if (ExistTag == null)
            {
                return View("Error");
            }
            if(tag.Name!=ExistTag.Name && _context.Tags.Any(x=>x.Name == tag.Name)) {
                ModelState.AddModelError("Name", "Bu ad artiq kullanilib");
                return  View();
            }
            ExistTag.Name=tag.Name;
            _context.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Delete(int id)
        {
            Tag tag=_context.Tags.Find(id);
            if(tag==null) { 
            return View("Error");}
            _context.Remove(tag);
            _context.SaveChanges();
            return View();
        }
        
    }
}
